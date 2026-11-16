using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Lab3Assignment.Controllers;

namespace Lab3Assignment.Views
{
    public class VendorForm : Form
    {
        DatabaseController db = new DatabaseController();

        // The logged-in vendor's email links them to their profile.
        // currentVendorId stays 0 until the profile exists.
        string userEmail;
        int currentVendorId = 0;

        static readonly Color SidebarColor = Color.FromArgb(61, 76, 155);
        static readonly Color SidebarActiveColor = Color.FromArgb(80, 100, 180);
        static readonly Color SaveGreen = Color.FromArgb(40, 160, 90);
        static readonly Color RejectRed = Color.FromArgb(214, 69, 65);
        static readonly Color Amber = Color.FromArgb(255, 193, 7);
        static readonly Color PageGray = Color.FromArgb(244, 246, 249);
        static readonly Color BorderGray = Color.FromArgb(222, 226, 234);
        static readonly Color SoftWhite = Color.FromArgb(205, 212, 240);
        static readonly Color TextDark = Color.FromArgb(40, 44, 70);

        const int PageWidth = 760;      // width of the profile page content
        const int FieldWidth = 346;     // width of each input (two per row)

        // Panels to switch between
        Panel profileView, bookingsView, avatar;
        FlowLayoutPanel page, statsRow;

        // Sidebar buttons
        Button btnProfile, btnBookings;

        // Header
        Label lblHeaderTitle;

        // Profile controls
        TextBox txtName, txtService, txtPriceMin, txtPriceMax, txtLocation;
        Label lblTitle, lblSubTitle, lblPill, lblDetailsHint;
        Label lblStatTotal, lblStatPending, lblStatAccepted;
        Button btnEditSave, btnCancel;
        string avatarLetter = "+";
        Color avatarFore = SidebarColor;
        bool isEditing = false;
        bool loadFailed = false;

        // Bookings controls
        DataGridView gridBookings;
        Label lblBookingsTitle, lblBkEvent, lblBkInfo, lblBkStatus;
        TextBox txtBkMessage, txtBkResponse;
        Button btnAccept, btnReject;
        int selectedBookingId = 0;
        Font boldFont = new Font("Segoe UI", 10, FontStyle.Bold);

        public VendorForm(string email)
        {
            userEmail = email;

            this.Text = "Vendor Dashboard";
            this.Size = new Size(1200, 760);
            this.MinimumSize = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = PageGray;

            // ==========================================
            // SIDEBAR
            // ==========================================
            Panel sidebar = new Panel() { Width = 250, Dock = DockStyle.Left, BackColor = SidebarColor };
            Label logo = new Label() { Text = "EventKonnect", ForeColor = Color.White, Font = new Font("Segoe UI", 16, FontStyle.Bold), AutoSize = false, Width = 250, Height = 80, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Top };

            btnProfile = CreateSidebarButton("My Profile", 100);
            btnBookings = CreateSidebarButton("Booking Requests", 150);
            Button btnLogout = CreateSidebarButton("Logout", 0);
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Height = 55;
            btnLogout.Click += (s, e) => { new LoginForm().Show(); this.Hide(); };

            sidebar.Controls.Add(btnProfile);
            sidebar.Controls.Add(btnBookings);
            sidebar.Controls.Add(btnLogout);
            sidebar.Controls.Add(logo);

            // ==========================================
            // HEADER
            // ==========================================
            Panel header = new Panel() { Height = 76, Dock = DockStyle.Top, BackColor = Color.White };
            lblHeaderTitle = new Label() { Text = "My Profile", Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = TextDark, Dock = DockStyle.Left, AutoSize = false, Width = 420, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(30, 0, 0, 0) };
            Label lblUser = new Label() { Text = userEmail, Font = new Font("Segoe UI", 9), ForeColor = Color.Gray, AutoSize = false, Width = 300, Dock = DockStyle.Right, TextAlign = ContentAlignment.MiddleRight, Padding = new Padding(0, 0, 25, 0) };
            Panel headerLine = new Panel() { Height = 1, Dock = DockStyle.Bottom, BackColor = BorderGray };
            header.Controls.Add(lblUser);
            header.Controls.Add(lblHeaderTitle);
            header.Controls.Add(headerLine);

            // ==========================================
            // MAIN CONTAINER
            // ==========================================
            Panel mainContainer = new Panel() { Dock = DockStyle.Fill, Padding = new Padding(30), BackColor = PageGray };

            // ==========================================
            // VIEW 1: PROFILE VIEW (hero + stats + details)
            // ==========================================
            profileView = new Panel() { Dock = DockStyle.Fill, BackColor = Color.Transparent, Visible = false, AutoScroll = true };

            page = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            };

            // ---------- HERO ----------
            FlowLayoutPanel hero = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                MinimumSize = new Size(PageWidth, 0),
                Padding = new Padding(28),
                BackColor = SidebarColor,
                Margin = new Padding(0, 0, 0, 16)
            };

            avatar = new Panel() { Size = new Size(76, 76), BackColor = SidebarColor, Margin = new Padding(0, 0, 22, 0) };
            avatar.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (SolidBrush b = new SolidBrush(Color.White))
                    e.Graphics.FillEllipse(b, 0, 0, avatar.Width - 1, avatar.Height - 1);
                using (Font f = new Font("Segoe UI", 26, FontStyle.Bold))
                    TextRenderer.DrawText(e.Graphics, avatarLetter, f, avatar.ClientRectangle, avatarFore,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            FlowLayoutPanel heroText = new FlowLayoutPanel() { FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, Margin = new Padding(0), BackColor = SidebarColor };
            lblTitle = new Label() { Text = "Business Profile", Font = new Font("Segoe UI", 20, FontStyle.Bold), ForeColor = Color.White, AutoSize = true, MaximumSize = new Size(560, 0), Margin = new Padding(0) };
            lblSubTitle = new Label() { Text = "", Font = new Font("Segoe UI", 10.5f), ForeColor = SoftWhite, AutoSize = true, MaximumSize = new Size(560, 0), Margin = new Padding(2, 2, 0, 10) };
            lblPill = new Label() { Text = "", Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true, MaximumSize = new Size(560, 0), Padding = new Padding(12, 4, 12, 4), Margin = new Padding(0) };

            heroText.Controls.Add(lblTitle);
            heroText.Controls.Add(lblSubTitle);
            heroText.Controls.Add(lblPill);
            hero.Controls.Add(avatar);
            hero.Controls.Add(heroText);

            // ---------- STATS ROW ----------
            statsRow = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                MinimumSize = new Size(PageWidth, 0),
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, 0, 16),
                Visible = false
            };
            statsRow.Controls.Add(StatCard("Total requests", out lblStatTotal, 245, false));
            statsRow.Controls.Add(StatCard("Pending", out lblStatPending, 245, false));
            statsRow.Controls.Add(StatCard("Accepted", out lblStatAccepted, 246, true));

            // ---------- DETAILS CARD ----------
            FlowLayoutPanel details = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                MinimumSize = new Size(PageWidth, 0),
                Padding = new Padding(28),
                BackColor = Color.White,
                Margin = new Padding(0)
            };
            AddBorder(details);

            Label lblDetailsTitle = new Label() { Text = "Business Details", Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = TextDark, AutoSize = true, Margin = new Padding(0, 0, 0, 2) };
            lblDetailsHint = new Label() { Text = "", Font = new Font("Segoe UI", 9.5f), ForeColor = Color.Gray, AutoSize = true, MaximumSize = new Size(PageWidth - 56, 0), Margin = new Padding(2, 0, 0, 20) };

            FlowLayoutPanel row1 = NewRow();
            row1.Controls.Add(FieldStack("Business Name", out txtName, "e.g. Kigali Sounds Ltd", false));
            row1.Controls.Add(FieldStack("Service Type", out txtService, "e.g. Catering, DJ, Photography", true));

            FlowLayoutPanel row2 = NewRow();
            row2.Controls.Add(FieldStack("Minimum Price (RWF)", out txtPriceMin, "e.g. 50000", false));
            row2.Controls.Add(FieldStack("Maximum Price (RWF)", out txtPriceMax, "e.g. 150000", true));

            FlowLayoutPanel row3 = NewRow();
            row3.Controls.Add(FieldStack("Location", out txtLocation, "e.g. Kigali", true, PageWidth - 56));

            btnEditSave = new Button() { Text = "Edit Profile", Width = 190, Height = 46, BackColor = SidebarColor, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 11, FontStyle.Bold), Cursor = Cursors.Hand, Margin = new Padding(12, 0, 0, 0) };
            btnEditSave.FlatAppearance.BorderSize = 0;
            btnEditSave.Click += (s, e) => HandleEditSave();

            btnCancel = new Button() { Text = "Cancel", Width = 120, Height = 46, BackColor = Color.White, ForeColor = Color.DimGray, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 11, FontStyle.Bold), Cursor = Cursors.Hand, Margin = new Padding(0), Visible = false };
            btnCancel.FlatAppearance.BorderColor = BorderGray;
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.Click += (s, e) => LoadProfile();

            // Right-aligned button row: first control added sits furthest right
            FlowLayoutPanel btnRow = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                MinimumSize = new Size(PageWidth - 56, 0),
                Margin = new Padding(0, 4, 0, 0)
            };
            btnRow.Controls.Add(btnEditSave);
            btnRow.Controls.Add(btnCancel);

            details.Controls.Add(lblDetailsTitle);
            details.Controls.Add(lblDetailsHint);
            details.Controls.Add(row1);
            details.Controls.Add(row2);
            details.Controls.Add(row3);
            details.Controls.Add(btnRow);

            page.Controls.Add(hero);
            page.Controls.Add(statsRow);
            page.Controls.Add(details);
            profileView.Controls.Add(page);

            profileView.Resize += (s, e) => CenterPage();
            page.SizeChanged += (s, e) => CenterPage();

            // ==========================================
            // VIEW 2: BOOKINGS VIEW (list + message & reply)
            // ==========================================
            bookingsView = new Panel() { Dock = DockStyle.Fill, BackColor = Color.Transparent, Visible = false };

            TableLayoutPanel bkRoot = new TableLayoutPanel() { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, BackColor = Color.Transparent };
            bkRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            bkRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 410));
            bkRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            // ----- Left: list of requests -----
            Panel listCard = NewCard(24);
            listCard.Margin = new Padding(0, 0, 16, 0);

            lblBookingsTitle = new Label() { Text = "Incoming Booking Requests", Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = TextDark, Dock = DockStyle.Top, Height = 50, AutoSize = false };

            gridBookings = new DataGridView()
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                MultiSelect = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                ColumnHeadersHeight = 42,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                EnableHeadersVisualStyles = false,
                GridColor = BorderGray
            };
            gridBookings.ColumnHeadersDefaultCellStyle.BackColor = PageGray;
            gridBookings.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 80);
            gridBookings.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            gridBookings.ColumnHeadersDefaultCellStyle.SelectionBackColor = PageGray;
            gridBookings.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(60, 60, 80);
            gridBookings.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            gridBookings.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            gridBookings.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 230, 250);
            gridBookings.DefaultCellStyle.SelectionForeColor = Color.Black;
            gridBookings.RowTemplate.Height = 42;

            // Colour the status text
            gridBookings.CellFormatting += (s, e) =>
            {
                if (e.RowIndex < 0 || e.Value == null) return;
                if (gridBookings.Columns[e.ColumnIndex].Name != "Status") return;
                string st = e.Value.ToString();
                e.CellStyle.Font = boldFont;
                if (st == "Accepted") e.CellStyle.ForeColor = Color.SeaGreen;
                else if (st == "Rejected") e.CellStyle.ForeColor = Color.Firebrick;
                else e.CellStyle.ForeColor = Color.DarkOrange;
            };

            // Show only #, Event and Status in the list; the rest is in the detail panel
            gridBookings.DataBindingComplete += (s, e) => ConfigureBookingGrid();
            gridBookings.SelectionChanged += (s, e) => ShowBookingDetail();

            listCard.Controls.Add(gridBookings);
            listCard.Controls.Add(lblBookingsTitle);

            // ----- Right: message + reply -----
            Panel detailCard = NewCard(24);
            detailCard.Margin = new Padding(0);

            TableLayoutPanel d = new TableLayoutPanel() { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 8, BackColor = Color.White };
            d.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            d.RowStyles.Add(new RowStyle(SizeType.AutoSize));          // 0 event title
            d.RowStyles.Add(new RowStyle(SizeType.AutoSize));          // 1 date / budget
            d.RowStyles.Add(new RowStyle(SizeType.AutoSize));          // 2 status pill
            d.RowStyles.Add(new RowStyle(SizeType.AutoSize));          // 3 caption: message
            d.RowStyles.Add(new RowStyle(SizeType.Percent, 50));       // 4 planner's message
            d.RowStyles.Add(new RowStyle(SizeType.AutoSize));          // 5 caption: reply
            d.RowStyles.Add(new RowStyle(SizeType.Percent, 50));       // 6 vendor's reply
            d.RowStyles.Add(new RowStyle(SizeType.AutoSize));          // 7 buttons

            lblBkEvent = new Label() { Text = "No request selected", Font = new Font("Segoe UI", 15, FontStyle.Bold), ForeColor = TextDark, AutoSize = true, MaximumSize = new Size(350, 0), Anchor = AnchorStyles.Left, Margin = new Padding(0, 0, 0, 4) };
            lblBkInfo = new Label() { Text = "Pick a request from the list to read the message and reply.", Font = new Font("Segoe UI", 9.5f), ForeColor = Color.Gray, AutoSize = true, MaximumSize = new Size(350, 0), Anchor = AnchorStyles.Left, Margin = new Padding(0, 0, 0, 8) };
            lblBkStatus = new Label() { Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true, Padding = new Padding(12, 4, 12, 4), Anchor = AnchorStyles.Left, Margin = new Padding(0, 0, 0, 16), Visible = false };

            txtBkMessage = new TextBox() { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, BackColor = Color.WhiteSmoke, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10.5f), ScrollBars = ScrollBars.Vertical, Margin = new Padding(0, 0, 0, 14) };
            txtBkResponse = new TextBox() { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10.5f), ScrollBars = ScrollBars.Vertical, Margin = new Padding(0, 0, 0, 14) };

            TableLayoutPanel actions = new TableLayoutPanel() { Dock = DockStyle.Fill, AutoSize = true, ColumnCount = 2, RowCount = 1, Margin = new Padding(0) };
            actions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            actions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            btnAccept = new Button() { Text = "Accept", Dock = DockStyle.Fill, Height = 46, Margin = new Padding(0, 0, 6, 0), BackColor = SaveGreen, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 11, FontStyle.Bold), Cursor = Cursors.Hand, Enabled = false };
            btnReject = new Button() { Text = "Reject", Dock = DockStyle.Fill, Height = 46, Margin = new Padding(6, 0, 0, 0), BackColor = RejectRed, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 11, FontStyle.Bold), Cursor = Cursors.Hand, Enabled = false };
            btnAccept.FlatAppearance.BorderSize = 0;
            btnReject.FlatAppearance.BorderSize = 0;
            btnAccept.Click += (s, e) => Respond("Accepted");
            btnReject.Click += (s, e) => Respond("Rejected");
            actions.Controls.Add(btnAccept, 0, 0);
            actions.Controls.Add(btnReject, 1, 0);

            d.Controls.Add(lblBkEvent, 0, 0);
            d.Controls.Add(lblBkInfo, 0, 1);
            d.Controls.Add(lblBkStatus, 0, 2);
            d.Controls.Add(CaptionLabel("Planner's message"), 0, 3);
            d.Controls.Add(txtBkMessage, 0, 4);
            d.Controls.Add(CaptionLabel("Your response (optional: explain why you accept or reject)"), 0, 5);
            d.Controls.Add(txtBkResponse, 0, 6);
            d.Controls.Add(actions, 0, 7);
            detailCard.Controls.Add(d);

            bkRoot.Controls.Add(listCard, 0, 0);
            bkRoot.Controls.Add(detailCard, 1, 0);
            bookingsView.Controls.Add(bkRoot);

            mainContainer.Controls.Add(profileView);
            mainContainer.Controls.Add(bookingsView);

            this.Controls.Add(mainContainer);
            this.Controls.Add(header);
            this.Controls.Add(sidebar);

            // ==========================================
            // NAVIGATION LOGIC
            // ==========================================
            btnProfile.Click += (s, e) => ShowProfile();
            btnBookings.Click += (s, e) => ShowBookings();

            // Open on the profile page by default
            this.Load += (s, e) => { ShowProfile(); CenterPage(); };
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
        // UI HELPERS
        // ==========================================
        private Panel NewCard(int pad)
        {
            Panel p = new Panel() { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(pad), Margin = new Padding(0) };
            AddBorder(p);
            return p;
        }

        private void AddBorder(Control c)
        {
            c.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(BorderGray))
                    e.Graphics.DrawRectangle(pen, 0, 0, c.Width - 1, c.Height - 1);
            };
        }

        private Label CaptionLabel(string text)
        {
            return new Label() { Text = text, Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.DimGray, AutoSize = true, MaximumSize = new Size(350, 0), Anchor = AnchorStyles.Left, Margin = new Padding(0, 0, 0, 6) };
        }

        private FlowLayoutPanel NewRow()
        {
            return new FlowLayoutPanel() { FlowDirection = FlowDirection.LeftToRight, WrapContents = false, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, Margin = new Padding(0) };
        }

        // Label stacked above a textbox
        private FlowLayoutPanel FieldStack(string caption, out TextBox box, string placeholder, bool isLast, int width = FieldWidth)
        {
            FlowLayoutPanel stack = new FlowLayoutPanel() { FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, Margin = new Padding(0, 0, isLast ? 0 : 12, 16) };
            Label lbl = new Label() { Text = caption, Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.DimGray, AutoSize = true, Margin = new Padding(0, 0, 0, 6) };
            box = new TextBox() { Width = width, Font = new Font("Segoe UI", 12), ReadOnly = true, BackColor = Color.WhiteSmoke, BorderStyle = BorderStyle.FixedSingle, PlaceholderText = placeholder, Margin = new Padding(0) };
            stack.Controls.Add(lbl);
            stack.Controls.Add(box);
            return stack;
        }

        // Small white card with a big number and a caption
        private FlowLayoutPanel StatCard(string caption, out Label valueLabel, int width, bool isLast)
        {
            FlowLayoutPanel card = new FlowLayoutPanel() { FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, MinimumSize = new Size(width, 0), Padding = new Padding(20, 16, 20, 16), BackColor = Color.White, Margin = new Padding(0, 0, isLast ? 0 : 12, 0) };
            AddBorder(card);
            valueLabel = new Label() { Text = "0", Font = new Font("Segoe UI", 22, FontStyle.Bold), ForeColor = SidebarColor, AutoSize = true, Margin = new Padding(0) };
            Label cap = new Label() { Text = caption, Font = new Font("Segoe UI", 9.5f), ForeColor = Color.Gray, AutoSize = true, Margin = new Padding(2, 0, 0, 0) };
            card.Controls.Add(valueLabel);
            card.Controls.Add(cap);
            return card;
        }

        private Button CreateSidebarButton(string text, int y)
        {
            Button btn = new Button() { Text = "   " + text, Location = new Point(0, y), Width = 250, Height = 45, FlatStyle = FlatStyle.Flat, BackColor = SidebarColor, ForeColor = Color.White, Font = new Font("Segoe UI", 11, FontStyle.Bold), TextAlign = ContentAlignment.MiddleLeft, Cursor = Cursors.Hand };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = SidebarActiveColor;

            // Amber marker on the active menu item
            btn.Paint += (s, e) =>
            {
                if (btn.Tag as string == "active")
                    using (SolidBrush b = new SolidBrush(Amber))
                        e.Graphics.FillRectangle(b, 0, 0, 5, btn.Height);
            };
            return btn;
        }

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