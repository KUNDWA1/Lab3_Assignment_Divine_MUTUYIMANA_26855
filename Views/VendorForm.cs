using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Lab3Assignment.Controllers;

namespace Lab3Assignment.Views
{
    // The layout lives in VendorForm.Designer.cs (open it in Design view to edit).
    // This file only contains the behaviour.
    public partial class VendorForm : Form
    {
        DatabaseController db = new DatabaseController();

        // The logged-in vendor's email links them to their profile.
        // currentVendorId stays 0 until the profile exists.
        string userEmail;
        int currentVendorId = 0;

        static readonly Color SidebarColor = Color.FromArgb(0, 64, 64);
        static readonly Color SidebarActiveColor = Color.FromArgb(0, 112, 112);
        static readonly Color SaveGreen = Color.FromArgb(40, 160, 90);
        static readonly Color RejectRed = Color.FromArgb(214, 69, 65);
        static readonly Color Amber = Color.FromArgb(255, 193, 7);
        static readonly Color PageGray = Color.FromArgb(240, 247, 247);
        static readonly Color BorderGray = Color.FromArgb(207, 226, 226);

        string avatarLetter = "+";
        Color avatarFore = SidebarColor;
        bool isEditing = false;
        bool loadFailed = false;
        int selectedBookingId = 0;
        Font boldFont = new Font("Segoe UI", 10, FontStyle.Bold);

        public VendorForm(string email)
        {
            InitializeComponent();

            userEmail = email;
            lblUser.Text = userEmail;

            // Colours for the bookings table (the layout itself is in the designer)
            gridBookings.ColumnHeadersDefaultCellStyle.BackColor = PageGray;
            gridBookings.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 64, 64);
            gridBookings.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            gridBookings.ColumnHeadersDefaultCellStyle.SelectionBackColor = PageGray;
            gridBookings.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 64, 64);
            gridBookings.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            gridBookings.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            gridBookings.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 242, 242);
            gridBookings.DefaultCellStyle.SelectionForeColor = Color.Black;
            gridBookings.RowTemplate.Height = 42;
        }

        // ==========================================
        // EVENTS WIRED UP IN THE DESIGNER
        // ==========================================
        private void VendorForm_Load(object sender, EventArgs e) { ShowProfile(); CenterPage(); }

        private void btnProfile_Click(object sender, EventArgs e) { ShowProfile(); }
        private void btnBookings_Click(object sender, EventArgs e) { ShowBookings(); }
        private void btnLogout_Click(object sender, EventArgs e) { new LoginForm().Show(); this.Hide(); }

        private void btnEditSave_Click(object sender, EventArgs e) { HandleEditSave(); }
        private void btnCancel_Click(object sender, EventArgs e) { LoadProfile(); }
        private void btnAccept_Click(object sender, EventArgs e) { Respond("Accepted"); }
        private void btnReject_Click(object sender, EventArgs e) { Respond("Rejected"); }

        private void profileView_Resize(object sender, EventArgs e) { CenterPage(); }
        private void page_SizeChanged(object sender, EventArgs e) { CenterPage(); }
        private void gridBookings_SelectionChanged(object sender, EventArgs e) { ShowBookingDetail(); }
        private void Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) { ConfigureBookingGrid(); }

        // Thin border around every white card
        private void Card_Paint(object sender, PaintEventArgs e)
        {
            Control c = (Control)sender;
            using (Pen pen = new Pen(BorderGray))
                e.Graphics.DrawRectangle(pen, 0, 0, c.Width - 1, c.Height - 1);
        }

        // Amber marker on the active menu item
        private void SidebarButton_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag as string == "active")
                using (SolidBrush b = new SolidBrush(Color.FromArgb(0, 192, 192)))
                    e.Graphics.FillRectangle(b, 0, 0, 5, btn.Height);
        }

        // Round avatar with the vendor's initial
        private void avatar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush b = new SolidBrush(Color.White))
                e.Graphics.FillEllipse(b, 0, 0, avatar.Width - 1, avatar.Height - 1);
            using (Font f = new Font("Segoe UI", 26, FontStyle.Bold))
                TextRenderer.DrawText(e.Graphics, avatarLetter, f, avatar.ClientRectangle, avatarFore,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // Colour the status text
        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;
            if (gridBookings.Columns[e.ColumnIndex].Name != "Status") return;
            string st = e.Value.ToString();
            e.CellStyle.Font = boldFont;
            if (st == "Accepted") e.CellStyle.ForeColor = Color.SeaGreen;
            else if (st == "Rejected") e.CellStyle.ForeColor = Color.Firebrick;
            else e.CellStyle.ForeColor = Color.DarkOrange;
        }

        // ==========================================
        // VIEW SWITCHING
        // ==========================================
        private void ShowProfile()
        {
            bookingsView.Visible = false;
            profileView.Visible = true;
            SetActiveButton(btnProfile, "My Profile");
            LoadProfile();
        }

        private void ShowBookings()
        {
            if (currentVendorId == 0)
            {
                MessageBox.Show("Please create your business profile first. Once it exists, planners can book you and requests will appear here.", "Profile needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowProfile();
                return;
            }

            profileView.Visible = false;
            bookingsView.Visible = true;
            SetActiveButton(btnBookings, "Booking Requests");
            LoadBookings();
        }

        private void SetActiveButton(Button active, string headerText)
        {
            foreach (Button b in new[] { btnProfile, btnBookings })
            {
                b.BackColor = SidebarColor;
                b.Tag = null;
                b.Invalidate();
            }
            active.BackColor = SidebarActiveColor;
            active.Tag = "active";
            active.Invalidate();
            lblHeaderTitle.Text = headerText;
        }

        private void CenterPage()
        {
            page.Left = Math.Max(0, (profileView.ClientSize.Width - page.Width) / 2);
            page.Top = 0;
        }

        // ==========================================
        // PROFILE
        // ==========================================
        private void LoadProfile()
        {
            DataTable dt;
            try
            {
                dt = db.GetVendorByEmail(userEmail);
                loadFailed = false;
            }
            catch (Exception ex)
            {
                // Show the problem on screen instead of silently showing "Edit Profile"
                loadFailed = true;
                currentVendorId = 0;
                isEditing = false;
                SetFieldsEditable(false);
                statsRow.Visible = false;
                SetAvatar("!", Color.Firebrick);
                lblTitle.Text = "Something went wrong";
                lblSubTitle.Text = ex.Message;
                SetPill("Could not load your profile", Color.Firebrick, Color.White);
                lblDetailsHint.Text = "Check that MySQL is running and the Vendors table has the OwnerEmail, PriceMin and PriceMax columns.";
                btnEditSave.Text = "Retry";
                btnEditSave.BackColor = Color.Firebrick;
                btnCancel.Visible = false;
                return;
            }

            if (dt.Rows.Count > 0)
            {
                // ----- EXISTING PROFILE: show it read-only -----
                DataRow row = dt.Rows[0];
                currentVendorId = Convert.ToInt32(row["VendorId"]);

                txtName.Text = row["Name"].ToString();
                txtService.Text = row["ServiceType"].ToString();
                txtLocation.Text = row["Location"].ToString();

                decimal pMin, pMax;
                decimal.TryParse(row["PriceMin"].ToString(), out pMin);
                decimal.TryParse(row["PriceMax"].ToString(), out pMax);
                txtPriceMin.Text = pMin.ToString("0.##");
                txtPriceMax.Text = pMax.ToString("0.##");

                SetFieldsEditable(false);
                isEditing = false;

                string name = txtName.Text.Trim();
                SetAvatar(name.Length > 0 ? name.Substring(0, 1).ToUpper() : "V", SidebarColor);
                lblTitle.Text = name;
                lblSubTitle.Text = txtService.Text + "  •  " + txtLocation.Text + "  •  " + FormatRange(pMin, pMax);
                SetPill("●  Profile live", SaveGreen, Color.White);
                lblDetailsHint.Text = "These details are shown to event planners.";

                statsRow.Visible = true;
                LoadStats();

                btnEditSave.Text = "Edit Profile";
                btnEditSave.BackColor = SidebarColor;
                btnCancel.Visible = false;
            }
            else
            {
                // ----- NO PROFILE YET: open the form ready to fill in -----
                currentVendorId = 0;
                txtName.Clear(); txtService.Clear(); txtPriceMin.Clear(); txtPriceMax.Clear(); txtLocation.Clear();

                SetFieldsEditable(true);
                isEditing = true;
                statsRow.Visible = false;

                SetAvatar("+", SidebarColor);
                lblTitle.Text = "Create Your Profile";
                lblSubTitle.Text = "Set up your profile so planners can find and book you";
                SetPill("No profile yet", Amber, Color.Black);
                lblDetailsHint.Text = "Fill in your business details and your price range, then press Create Profile.";

                btnEditSave.Text = "Create Profile";
                btnEditSave.BackColor = SaveGreen;
                btnCancel.Visible = false;
                txtName.Focus();
            }
        }

        // Fills the three stat cards from the vendor's bookings
        private void LoadStats()
        {
            try
            {
                DataTable dt = db.GetVendorBookings(currentVendorId);
                int pending = 0, accepted = 0;
                foreach (DataRow r in dt.Rows)
                {
                    string st = r["Status"].ToString();
                    if (st == "Accepted") accepted++;
                    else if (st == "Pending") pending++;
                }
                lblStatTotal.Text = dt.Rows.Count.ToString();
                lblStatPending.Text = pending.ToString();
                lblStatAccepted.Text = accepted.ToString();
            }
            catch
            {
                lblStatTotal.Text = lblStatPending.Text = lblStatAccepted.Text = "–";
            }
        }

        private void HandleEditSave()
        {
            // Last load failed: this button retries
            if (loadFailed) { LoadProfile(); return; }

            // No profile yet: this button creates it
            if (currentVendorId == 0) { CreateProfile(); return; }

            if (!isEditing)
            {
                EnterEditMode();
                return;
            }

            // Save changes to the existing profile
            decimal pMin, pMax;
            if (!TryReadForm(out pMin, out pMax)) return;

            try
            {
                db.UpdateVendor(currentVendorId, txtName.Text.Trim(), txtService.Text.Trim(), pMin, pMax, txtLocation.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadProfile();   // reload fresh data in read-only mode
        }

        private void EnterEditMode()
        {
            SetFieldsEditable(true);
            isEditing = true;
            lblSubTitle.Text = "Update your details, then save";
            SetPill("Editing mode", Color.White, SidebarColor);
            lblDetailsHint.Text = "Don't forget to save your changes.";
            btnEditSave.Text = "Save Changes";
            btnEditSave.BackColor = SaveGreen;
            btnCancel.Visible = true;
            txtName.Focus();
            txtName.SelectionStart = txtName.Text.Length;
        }

        private void CreateProfile()
        {
            decimal pMin, pMax;
            if (!TryReadForm(out pMin, out pMax)) return;

            try
            {
                currentVendorId = db.CreateVendorProfile(userEmail, txtName.Text.Trim(), txtService.Text.Trim(), pMin, pMax, txtLocation.Text.Trim());
            }
            catch (Exception ex)
            {
                currentVendorId = 0;
                MessageBox.Show("Could not create the profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Your profile has been created! Planners can now find and book you.", "Profile created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadProfile();
        }

        // Checks the fields and reads the price range
        private bool TryReadForm(out decimal priceMin, out decimal priceMax)
        {
            priceMin = 0;
            priceMax = 0;

            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtService.Text) ||
                string.IsNullOrWhiteSpace(txtPriceMin.Text) || string.IsNullOrWhiteSpace(txtPriceMax.Text) ||
                string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtPriceMin.Text, out priceMin) || !decimal.TryParse(txtPriceMax.Text, out priceMax) ||
                priceMin < 0 || priceMax < 0)
            {
                MessageBox.Show("Prices must be valid numbers, for example 50000 and 150000.", "Invalid price", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (priceMax < priceMin)
            {
                MessageBox.Show("The maximum price can't be lower than the minimum price.", "Invalid price range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void SetFieldsEditable(bool editable)
        {
            Color back = editable ? Color.White : Color.WhiteSmoke;
            foreach (TextBox t in new[] { txtName, txtService, txtPriceMin, txtPriceMax, txtLocation })
            {
                t.ReadOnly = !editable;
                t.BackColor = back;
            }
        }

        private void SetPill(string text, Color back, Color fore)
        {
            lblPill.Text = text;
            lblPill.BackColor = back;
            lblPill.ForeColor = fore;
        }

        private void SetAvatar(string letter, Color fore)
        {
            avatarLetter = letter;
            avatarFore = fore;
            avatar.Invalidate();
        }

        // ==========================================
        // BOOKINGS
        // ==========================================
        private void LoadBookings()
        {
            try
            {
                DataTable dt = db.GetVendorBookings(currentVendorId);
                gridBookings.DataSource = dt;
                lblBookingsTitle.Text = "Incoming Booking Requests (" + dt.Rows.Count + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load bookings: " + ex.Message + Environment.NewLine + Environment.NewLine +
                                "Make sure the Bookings table has the Message and VendorResponse columns.",
                                "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Runs after every bind: choose visible columns and keep the same request selected
        private void ConfigureBookingGrid()
        {
            foreach (DataGridViewColumn c in gridBookings.Columns)
            {
                switch (c.Name)
                {
                    case "BookingId": c.HeaderText = "#"; c.FillWeight = 30; break;
                    case "EventTitle": c.HeaderText = "Event"; break;
                    case "Status": c.HeaderText = "Status"; c.FillWeight = 55; break;
                    default: c.Visible = false; break;
                }
            }

            if (selectedBookingId != 0 && gridBookings.Columns.Contains("EventTitle"))
            {
                foreach (DataGridViewRow r in gridBookings.Rows)
                {
                    if (Convert.ToInt32(r.Cells["BookingId"].Value) == selectedBookingId)
                    {
                        gridBookings.ClearSelection();
                        r.Selected = true;
                        gridBookings.CurrentCell = r.Cells["EventTitle"];
                        break;
                    }
                }
            }
        }

        // Fills the right-hand panel for the selected request
        private void ShowBookingDetail()
        {
            DataRowView v = null;
            if (gridBookings.SelectedRows.Count > 0)
                v = gridBookings.SelectedRows[0].DataBoundItem as DataRowView;

            if (v == null)
            {
                selectedBookingId = 0;
                lblBkEvent.Text = "No request selected";
                lblBkInfo.Text = "Pick a request from the list to read the message and reply.";
                lblBkStatus.Visible = false;
                txtBkMessage.Text = "";
                txtBkResponse.Text = "";
                txtBkResponse.ReadOnly = true;
                btnAccept.Enabled = false;
                btnReject.Enabled = false;
                return;
            }

            selectedBookingId = Convert.ToInt32(v["BookingId"]);
            lblBkEvent.Text = v["EventTitle"].ToString();
            lblBkInfo.Text = "Date: " + FormatDate(v["EventDate"]) + "   •   Budget: " + FormatMoney(v["Budget"]) + " RWF";
            StylePill(lblBkStatus, v["Status"].ToString());
            txtBkMessage.Text = NormalizeNewLines(v["Message"].ToString());
            txtBkResponse.Text = NormalizeNewLines(v["VendorResponse"].ToString());
            txtBkResponse.ReadOnly = false;
            btnAccept.Enabled = true;
            btnReject.Enabled = true;
        }

        // Accept or reject, with an optional explanation the planner will see
        private void Respond(string status)
        {
            if (selectedBookingId == 0)
            {
                MessageBox.Show("Please select a booking request from the list.", "No request selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string reason = txtBkResponse.Text.Trim();

            if (status == "Rejected" && reason == "")
            {
                DialogResult dr = MessageBox.Show("You haven't explained why you are rejecting this request. Reject without a reason?",
                    "Reject request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) { txtBkResponse.Focus(); return; }
            }

            try
            {
                db.RespondToBooking(selectedBookingId, status, reason);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save your response: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Request " + status.ToLower() + ". The planner can now see your response.", "Response sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadBookings();
        }


        // ==========================================
        // HELPERS
        // ==========================================
        private static void StylePill(Label l, string status)
        {
            l.Visible = true;
            if (status == "Accepted") { l.Text = "●  Accepted"; l.BackColor = SaveGreen; l.ForeColor = Color.White; }
            else if (status == "Rejected") { l.Text = "●  Rejected"; l.BackColor = RejectRed; l.ForeColor = Color.White; }
            else { l.Text = "●  Pending"; l.BackColor = Amber; l.ForeColor = Color.Black; }
        }

        private static string FormatRange(decimal min, decimal max)
        {
            if (min == max) return min.ToString("N0") + " RWF";
            return min.ToString("N0") + " – " + max.ToString("N0") + " RWF";
        }

        private static string FormatDate(object o)
        {
            if (o == null || o == DBNull.Value) return "-";
            DateTime d;
            return DateTime.TryParse(o.ToString(), out d) ? d.ToString("dd MMM yyyy") : o.ToString();
        }

        private static string FormatMoney(object o)
        {
            if (o == null || o == DBNull.Value) return "-";
            decimal m;
            return decimal.TryParse(o.ToString(), out m) ? m.ToString("N0") : o.ToString();
        }

        // Textboxes need \r\n to show line breaks correctly
        private static string NormalizeNewLines(string s)
        {
            return (s ?? "").Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
        }
    }
}
