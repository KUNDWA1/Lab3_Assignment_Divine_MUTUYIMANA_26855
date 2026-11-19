using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lab3Assignment.Controllers;

namespace Lab3Assignment.Views
{
    // The layout lives in PlannerForm.Designer.cs (open it in Design view to edit).
    // This file only contains the behaviour.
    public partial class PlannerForm : Form
    {
        DatabaseController db = new DatabaseController();

        static readonly Color Indigo = Color.FromArgb(0, 64, 64);
        static readonly Color IndigoLight = Color.FromArgb(0, 112, 112);
        static readonly Color Amber = Color.FromArgb(255, 193, 7);
        static readonly Color Green = Color.FromArgb(40, 160, 90);
        static readonly Color Red = Color.FromArgb(214, 69, 65);
        static readonly Color PageGray = Color.FromArgb(240, 247, 247);
        static readonly Color BorderGray = Color.FromArgb(207, 226, 226);
        static readonly Color TextDark = Color.FromArgb(0, 64, 64);

        Font boldFont = new Font("Segoe UI", 10, FontStyle.Bold);

        public PlannerForm()
        {
            InitializeComponent();

            dtpDate.MinDate = DateTime.Today;   // can't be stored in the designer (it would go stale)

            StyleGrid(gridVendors);
            StyleGrid(gridEvents);
            StyleGrid(gridBookings);
        }

        // ==========================================
        // EVENTS WIRED UP IN THE DESIGNER
        // ==========================================
        private void PlannerForm_Load(object sender, EventArgs e) { ShowView("Dashboard"); }

        private void btnDash_Click(object sender, EventArgs e) { ShowView("Dashboard"); }
        private void btnEvents_Click(object sender, EventArgs e) { ShowView("Events"); }
        private void btnMyBookings_Click(object sender, EventArgs e) { ShowView("Bookings"); }
        private void btnLogout_Click(object sender, EventArgs e) { new LoginForm().Show(); this.Hide(); }

        private void btnCreate_Click(object sender, EventArgs e) { PostEvent(); }
        private void btnBook_Click(object sender, EventArgs e) { BookSelectedVendor(); }
        private void btnRefresh_Click(object sender, EventArgs e) { LoadDashboard(); }
        private void txtSearch_TextChanged(object sender, EventArgs e) { ApplyVendorFilter(); }
        private void gridBookings_SelectionChanged(object sender, EventArgs e) { UpdateBookingDetail(); }

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

        // Colour the Status column in any grid that has one
        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView g = (DataGridView)sender;
            if (e.RowIndex < 0 || e.Value == null) return;
            if (g.Columns[e.ColumnIndex].Name != "Status") return;
            string st = e.Value.ToString();
            e.CellStyle.Font = boldFont;
            if (st == "Accepted") e.CellStyle.ForeColor = Color.SeaGreen;
            else if (st == "Rejected") e.CellStyle.ForeColor = Color.Firebrick;
            else e.CellStyle.ForeColor = Color.DarkOrange;
        }

        private void Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            PrettifyGrid((DataGridView)sender);
        }

        // Header/row colours shared by every table in the planner dashboard
        private void StyleGrid(DataGridView g)
        {
            g.ColumnHeadersDefaultCellStyle.BackColor = PageGray;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 64, 64);
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = PageGray;
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 64, 64);
            g.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            g.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 242, 242);
            g.DefaultCellStyle.SelectionForeColor = Color.Black;
            g.RowTemplate.Height = 42;
        }

        // ==========================================
        // NAVIGATION
        // ==========================================
        private void ShowView(string name)
        {
            dashboardView.Visible = name == "Dashboard";
            eventsView.Visible = name == "Events";
            bookingsView.Visible = name == "Bookings";

            foreach (Button b in new[] { btnDash, btnEvents, btnMyBookings })
            {
                b.BackColor = Indigo;
                b.Tag = null;
                b.Invalidate();
            }

            Button active = name == "Dashboard" ? btnDash : name == "Events" ? btnEvents : btnMyBookings;
            active.BackColor = IndigoLight;
            active.Tag = "active";
            active.Invalidate();
            lblHeaderTitle.Text = name == "Dashboard" ? "Dashboard" : name == "Events" ? "My Events" : "My Bookings";

            if (name == "Dashboard") LoadDashboard();
            else if (name == "Events") LoadEvents();
            else LoadBookings();
        }

        // ==========================================
        // LOADING DATA
        // ==========================================
        private void LoadDashboard()
        {
            try
            {
                DataTable vendors = db.GetVendors();
                gridVendors.DataSource = vendors;
                ApplyVendorFilter();

                lblStatVendors.Text = vendors.Rows.Count.ToString();
                lblStatEvents.Text = db.GetEvents().Rows.Count.ToString();

                int accepted = 0;
                foreach (DataRow r in db.GetPlannerBookings().Rows)
                    if (r["Status"].ToString() == "Accepted") accepted++;
                lblStatAccepted.Text = accepted.ToString();
            }
            catch (Exception ex) { ShowDbError(ex); }
        }

        private void LoadEvents()
        {
            try { gridEvents.DataSource = db.GetEvents(); }
            catch (Exception ex) { ShowDbError(ex); }
        }

        private void LoadBookings()
        {
            try { gridBookings.DataSource = db.GetPlannerBookings(); }
            catch (Exception ex) { ShowDbError(ex); }
            UpdateBookingDetail();
        }

        private void ShowDbError(Exception ex)
        {
            MessageBox.Show("Could not load data: " + ex.Message + Environment.NewLine + Environment.NewLine +
                            "Check that MySQL is running and that you ran the latest SQL changes (PriceMin, PriceMax, VendorResponse).",
                            "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ==========================================
        // ACTIONS
        // ==========================================
        private void PostEvent()
        {
            string title = txtTitle.Text.Trim();
            decimal budget;

            if (title == "")
            {
                MessageBox.Show("Please enter a title for your event.", "Missing title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }
            if (!decimal.TryParse(txtBudget.Text, out budget) || budget <= 0)
            {
                MessageBox.Show("Budget must be a valid amount greater than 0, for example 500000.", "Invalid budget", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBudget.Focus();
                return;
            }

            try
            {
                db.AddEvent(title, dtpDate.Value.Date, budget);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not post the event: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Your event has been posted!", "Event posted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtTitle.Clear();
            txtBudget.Clear();
            dtpDate.Value = DateTime.Today;
            LoadDashboard();
        }

        private void BookSelectedVendor()
        {
            if (gridVendors.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please click on a vendor in the list first.", "No vendor selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow r = gridVendors.SelectedRows[0];
            int vendorId = Convert.ToInt32(r.Cells["VendorId"].Value);
            string vendorName = r.Cells["Name"].Value.ToString();
            string priceRange = r.Cells["PriceRange"].Value.ToString();
            ShowBookingDialog(vendorId, vendorName, priceRange);
        }

        // POPUP DIALOG FOR BOOKING
        private void ShowBookingDialog(int vendorId, string vendorName, string priceRange)
        {
            DataTable events;
            try { events = db.GetEvents(); }
            catch (Exception ex) { ShowDbError(ex); return; }

            if (events.Rows.Count == 0)
            {
                MessageBox.Show("You need to post an event before you can book a vendor.", "No events yet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            const int W = 400;

            Form dlg = new Form()
            {
                Text = "Book Vendor",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false,
                BackColor = Color.White,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            FlowLayoutPanel f = new FlowLayoutPanel() { FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, Padding = new Padding(28), BackColor = Color.White };

            f.Controls.Add(new Label() { Text = "Book " + vendorName, Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = TextDark, AutoSize = true, MaximumSize = new Size(W, 0), Margin = new Padding(0, 0, 0, 2) });
            f.Controls.Add(new Label() { Text = "Price range: " + priceRange, Font = new Font("Segoe UI", 10), ForeColor = Color.Gray, AutoSize = true, MaximumSize = new Size(W, 0), Margin = new Padding(2, 0, 0, 20) });

            f.Controls.Add(FieldLabel("Choose your event"));
            ComboBox cmbEvent = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList, Width = W, Font = new Font("Segoe UI", 11), Margin = new Padding(0, 0, 0, 14) };
            cmbEvent.DataSource = events;
            cmbEvent.DisplayMember = "Title";
            cmbEvent.ValueMember = "EventId";
            f.Controls.Add(cmbEvent);

            f.Controls.Add(FieldLabel("Message / phone number"));
            TextBox txtMsg = new TextBox() { Width = W, Height = 110, Multiline = true, Font = new Font("Segoe UI", 11), BorderStyle = BorderStyle.FixedSingle, ScrollBars = ScrollBars.Vertical, Margin = new Padding(0, 0, 0, 18) };
            f.Controls.Add(txtMsg);

            Button btnSend = new Button() { Text = "Send Request", Width = W, Height = 46, BackColor = Indigo, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 11, FontStyle.Bold), Cursor = Cursors.Hand, Margin = new Padding(0) };
            btnSend.FlatAppearance.BorderSize = 0;
            Button btnCancel = new Button() { Text = "Cancel", Width = W, Height = 42, BackColor = Color.White, ForeColor = Color.DimGray, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10.5f, FontStyle.Bold), Cursor = Cursors.Hand, Margin = new Padding(0, 8, 0, 0) };
            btnCancel.FlatAppearance.BorderColor = BorderGray;
            btnCancel.FlatAppearance.BorderSize = 1;

            bool sent = false;
            btnCancel.Click += (s, e) => dlg.Close();
            btnSend.Click += (s, e) =>
            {
                if (cmbEvent.SelectedValue == null)
                {
                    MessageBox.Show("Please choose an event.", "Book Vendor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string msg = txtMsg.Text.Trim();
                if (msg == "")
                {
                    MessageBox.Show("Please add a short message or your phone number so the vendor can reach you.", "Book Vendor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMsg.Focus();
                    return;
                }

                try
                {
                    db.CreateBooking(vendorId, Convert.ToInt32(cmbEvent.SelectedValue), msg);
                    sent = true;
                    dlg.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not send the request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            f.Controls.Add(btnSend);
            f.Controls.Add(btnCancel);
            dlg.Controls.Add(f);
            dlg.CancelButton = btnCancel;
            dlg.ShowDialog(this);

            if (sent)
            {
                MessageBox.Show("Your booking request was sent to " + vendorName + "!", "Request sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowView("Bookings");
            }
        }

        // Shows the planner's message and the vendor's reply for the selected booking
        private void UpdateBookingDetail()
        {
            DataRowView v = null;
            if (gridBookings.SelectedRows.Count > 0)
                v = gridBookings.SelectedRows[0].DataBoundItem as DataRowView;

            if (v == null)
            {
                lblBkEvent.Text = "No booking selected";
                lblBkVendor.Text = "Pick a booking to see the vendor's response.";
                lblBkStatus.Visible = false;
                txtBkMessage.Text = "";
                txtBkResponse.Text = "";
                return;
            }

            string status = v["Status"].ToString();
            lblBkEvent.Text = v["EventTitle"].ToString();
            lblBkVendor.Text = "Vendor: " + v["VendorName"];
            StylePill(lblBkStatus, status);
            txtBkMessage.Text = NormalizeNewLines(v["Message"].ToString());

            string response = NormalizeNewLines(v["VendorResponse"].ToString());
            if (response.Trim() == "")
            {
                txtBkResponse.ForeColor = Color.Gray;
                txtBkResponse.Text = status == "Pending"
                    ? "No response yet. The vendor hasn't replied to your request."
                    : "The vendor " + status.ToLower() + " your request without leaving a note.";
            }
            else
            {
                txtBkResponse.ForeColor = Color.Black;
                txtBkResponse.Text = response;
            }
        }

        // ==========================================
        // VENDOR SEARCH
        // ==========================================
        private void ApplyVendorFilter()
        {
            DataTable dt = gridVendors.DataSource as DataTable;
            if (dt == null) return;

            string t = EscapeLike(txtSearch.Text.Trim());
            dt.DefaultView.RowFilter = t == ""
                ? ""
                : "Name LIKE '%" + t + "%' OR ServiceType LIKE '%" + t + "%' OR Location LIKE '%" + t + "%'";
        }

        private static string EscapeLike(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if (c == '\'') sb.Append("''");
                else if (c == '[' || c == ']' || c == '*' || c == '%') sb.Append('[').Append(c).Append(']');
                else sb.Append(c);
            }
            return sb.ToString();
        }

        // ==========================================
        // UI HELPERS
        // ==========================================
        private Label FieldLabel(string text)
        {
            return new Label() { Text = text, Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.DimGray, AutoSize = true, Margin = new Padding(0, 0, 0, 6) };
        }

        // Friendly headers, number formats and hidden long-text columns
        private void PrettifyGrid(DataGridView g)
        {
            foreach (DataGridViewColumn c in g.Columns)
            {
                switch (c.Name)
                {
                    case "VendorId":
                    case "EventId":
                    case "BookingId": c.HeaderText = "#"; c.FillWeight = 30; break;
                    case "Name": c.HeaderText = "Vendor"; break;
                    case "ServiceType": c.HeaderText = "Service"; break;
                    case "PriceRange": c.HeaderText = "Price Range"; c.FillWeight = 130; break;
                    case "Title":
                    case "EventTitle": c.HeaderText = "Event"; break;
                    case "VendorName": c.HeaderText = "Vendor"; break;
                    case "EventDate": c.HeaderText = "Date"; c.DefaultCellStyle.Format = "dd MMM yyyy"; break;
                    case "Budget": c.HeaderText = "Budget (RWF)"; c.DefaultCellStyle.Format = "N0"; break;
                    case "Message":
                    case "VendorResponse": c.Visible = false; break;
                }
            }
        }

        private static void StylePill(Label l, string status)
        {
            l.Visible = true;
            if (status == "Accepted") { l.Text = "●  Accepted"; l.BackColor = Green; l.ForeColor = Color.White; }
            else if (status == "Rejected") { l.Text = "●  Rejected"; l.BackColor = Red; l.ForeColor = Color.White; }
            else { l.Text = "●  Pending"; l.BackColor = Amber; l.ForeColor = Color.Black; }
        }

        // Textboxes need \r\n to show line breaks correctly
        private static string NormalizeNewLines(string s)
        {
            return (s ?? "").Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
        }
    }
}
