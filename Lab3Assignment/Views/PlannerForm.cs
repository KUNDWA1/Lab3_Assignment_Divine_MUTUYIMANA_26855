using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lab3Assignment.Controllers;

namespace Lab3Assignment.Views
{
    public class PlannerForm : Form
    {
        DatabaseController db = new DatabaseController();

        static readonly Color Indigo = Color.FromArgb(61, 76, 155);
        static readonly Color IndigoLight = Color.FromArgb(80, 100, 180);
        static readonly Color Amber = Color.FromArgb(255, 193, 7);
        static readonly Color Green = Color.FromArgb(40, 160, 90);
        static readonly Color Red = Color.FromArgb(214, 69, 65);
        static readonly Color PageGray = Color.FromArgb(244, 246, 249);
        static readonly Color BorderGray = Color.FromArgb(222, 226, 234);
        static readonly Color TextDark = Color.FromArgb(40, 44, 70);

        const int InnerWidth = 316;     // width of inputs inside the Create Event card

        // Views and navigation
        Panel dashboardView, eventsView, bookingsView;
        Button btnDash, btnEvents, btnMyBookings;
        Label lblHeaderTitle;

        // Dashboard
        TextBox txtTitle, txtBudget, txtSearch;
        DateTimePicker dtpDate;
        DataGridView gridVendors;
        Label lblStatEvents, lblStatVendors, lblStatAccepted;

        // My Events
        DataGridView gridEvents;

        // My Bookings
        DataGridView gridBookings;
        Label lblBkEvent, lblBkVendor, lblBkStatus;
        TextBox txtBkMessage, txtBkResponse;

        Font boldFont = new Font("Segoe UI", 10, FontStyle.Bold);

        public PlannerForm()
        {
            this.Text = "Planner Dashboard";
            this.Size = new Size(1280, 780);
            this.MinimumSize = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = PageGray;

            // ==========================================
            // SIDEBAR
            // ==========================================
            Panel sidebar = new Panel() { Width = 250, Dock = DockStyle.Left, BackColor = Indigo };
            Label logo = new Label() { Text = "EventKonnect", ForeColor = Color.White, Font = new Font("Segoe UI", 16, FontStyle.Bold), AutoSize = false, Width = 250, Height = 80, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Top };

            btnDash = CreateSidebarButton("Dashboard", 100);
            btnEvents = CreateSidebarButton("My Events", 150);
            btnMyBookings = CreateSidebarButton("My Bookings", 200);
            Button btnLogout = CreateSidebarButton("Logout", 0);
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Height = 55;
            btnLogout.Click += (s, e) => { new LoginForm().Show(); this.Hide(); };

            btnDash.Click += (s, e) => ShowView("Dashboard");
            btnEvents.Click += (s, e) => ShowView("Events");
            btnMyBookings.Click += (s, e) => ShowView("Bookings");

            sidebar.Controls.Add(btnDash);
            sidebar.Controls.Add(btnEvents);
            sidebar.Controls.Add(btnMyBookings);
            sidebar.Controls.Add(btnLogout);
            sidebar.Controls.Add(logo);

            // ==========================================
            // HEADER
            // ==========================================
            Panel header = new Panel() { Height = 76, Dock = DockStyle.Top, BackColor = Color.White };
            lblHeaderTitle = new Label() { Text = "Dashboard", Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = TextDark, Dock = DockStyle.Left, AutoSize = false, Width = 420, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(30, 0, 0, 0) };
            Label lblHint = new Label() { Text = "Post your event and connect with vendors", Font = new Font("Segoe UI", 10), ForeColor = Color.Gray, Dock = DockStyle.Right, AutoSize = false, Width = 420, TextAlign = ContentAlignment.MiddleRight, Padding = new Padding(0, 0, 25, 0) };
            Panel headerLine = new Panel() { Height = 1, Dock = DockStyle.Bottom, BackColor = BorderGray };
            header.Controls.Add(lblHint);
            header.Controls.Add(lblHeaderTitle);
            header.Controls.Add(headerLine);

            // ==========================================
            // MAIN CONTAINER + VIEWS
            // ==========================================
            Panel mainContainer = new Panel() { Dock = DockStyle.Fill, Padding = new Padding(30), BackColor = PageGray };

            dashboardView = BuildDashboard();
            eventsView = BuildEvents();
            bookingsView = BuildBookings();

            mainContainer.Controls.Add(dashboardView);
            mainContainer.Controls.Add(eventsView);
            mainContainer.Controls.Add(bookingsView);

            this.Controls.Add(mainContainer);
            this.Controls.Add(header);
            this.Controls.Add(sidebar);

            this.Load += (s, e) => ShowView("Dashboard");
        }

        // ==========================================
        // BUILD: DASHBOARD (stats + create event + vendors)
        // ==========================================
        private Panel BuildDashboard()
        {
            Panel view = new Panel() { Dock = DockStyle.Fill, BackColor = Color.Transparent, Visible = false };

            TableLayoutPanel root = new TableLayoutPanel() { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 2, BackColor = Color.Transparent };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 380));
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            // ---------- Stats row ----------
            TableLayoutPanel stats = new TableLayoutPanel() { Dock = DockStyle.Fill, AutoSize = true, ColumnCount = 3, RowCount = 1, Margin = new Padding(0, 0, 0, 16) };
            for (int i = 0; i < 3; i++) stats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            stats.Controls.Add(StatCard("Events posted", out lblStatEvents, false), 0, 0);
            stats.Controls.Add(StatCard("Vendors available", out lblStatVendors, false), 1, 0);
            stats.Controls.Add(StatCard("Bookings accepted", out lblStatAccepted, true), 2, 0);
            root.Controls.Add(stats, 0, 0);
            root.SetColumnSpan(stats, 2);

            // ---------- Create event card ----------
            FlowLayoutPanel createCard = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Top,
                Padding = new Padding(24),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 16, 0)
            };
            AddBorder(createCard);

            createCard.Controls.Add(new Label() { Text = "Create New Event", Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = TextDark, AutoSize = true, Margin = new Padding(0, 0, 0, 2) });
            createCard.Controls.Add(new Label() { Text = "Post an event, then book vendors for it.", Font = new Font("Segoe UI", 9.5f), ForeColor = Color.Gray, AutoSize = true, MaximumSize = new Size(InnerWidth, 0), Margin = new Padding(2, 0, 0, 18) });

            createCard.Controls.Add(FieldLabel("Event title"));
            txtTitle = new TextBox() { Width = InnerWidth, Font = new Font("Segoe UI", 12), BorderStyle = BorderStyle.FixedSingle, PlaceholderText = "e.g. Wedding reception", Margin = new Padding(0, 0, 0, 14) };
            createCard.Controls.Add(txtTitle);

            createCard.Controls.Add(FieldLabel("Event date"));
            dtpDate = new DateTimePicker() { Width = InnerWidth, Font = new Font("Segoe UI", 11), Format = DateTimePickerFormat.Long, MinDate = DateTime.Today, Margin = new Padding(0, 0, 0, 14) };
            createCard.Controls.Add(dtpDate);

            createCard.Controls.Add(FieldLabel("Budget (RWF)"));
            txtBudget = new TextBox() { Width = InnerWidth, Font = new Font("Segoe UI", 12), BorderStyle = BorderStyle.FixedSingle, PlaceholderText = "e.g. 500000", Margin = new Padding(0, 0, 0, 18) };
            createCard.Controls.Add(txtBudget);

            Button btnCreate = new Button() { Text = "Post Event", Width = InnerWidth, Height = 46, BackColor = Indigo, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 11, FontStyle.Bold), Cursor = Cursors.Hand, Margin = new Padding(0) };
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatAppearance.MouseOverBackColor = IndigoLight;
            btnCreate.Click += (s, e) => PostEvent();
            createCard.Controls.Add(btnCreate);

            root.Controls.Add(createCard, 0, 1);

            // ---------- Vendors card ----------
            Panel vendorsCard = NewCard(24);

            gridVendors = NewGrid();

            // Header row: title on the left, search box on the right
            TableLayoutPanel vHeader = new TableLayoutPanel() { Dock = DockStyle.Top, AutoSize = true, ColumnCount = 2, RowCount = 1, BackColor = Color.White, Margin = new Padding(0) };
            vHeader.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            vHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            vHeader.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            Label lblVendors = new Label() { Text = "Available Vendors", Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = TextDark, AutoSize = true, Anchor = AnchorStyles.Left, Margin = new Padding(0, 0, 0, 14) };
            txtSearch = new TextBox() { Width = 260, Font = new Font("Segoe UI", 11), BorderStyle = BorderStyle.FixedSingle, PlaceholderText = "Search name, service or location", Anchor = AnchorStyles.Right, Margin = new Padding(0, 0, 0, 14) };
            txtSearch.TextChanged += (s, e) => ApplyVendorFilter();
            vHeader.Controls.Add(lblVendors, 0, 0);
            vHeader.Controls.Add(txtSearch, 1, 0);

            // Buttons under the list
            FlowLayoutPanel vButtons = new FlowLayoutPanel() { Dock = DockStyle.Bottom, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, FlowDirection = FlowDirection.LeftToRight, WrapContents = false, Padding = new Padding(0, 16, 0, 0), BackColor = Color.White };
            Button btnBook = new Button() { Text = "Book Vendor", Width = 170, Height = 44, BackColor = Amber, ForeColor = Color.Black, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10.5f, FontStyle.Bold), Cursor = Cursors.Hand, Margin = new Padding(0, 0, 10, 0) };
            btnBook.FlatAppearance.BorderSize = 0;
            Button btnRefresh = new Button() { Text = "Refresh", Width = 120, Height = 44, BackColor = Color.White, ForeColor = Color.DimGray, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10.5f, FontStyle.Bold), Cursor = Cursors.Hand, Margin = new Padding(0) };
            btnRefresh.FlatAppearance.BorderColor = BorderGray;
            btnRefresh.FlatAppearance.BorderSize = 1;
            btnBook.Click += (s, e) => BookSelectedVendor();
            btnRefresh.Click += (s, e) => LoadDashboard();
            vButtons.Controls.Add(btnBook);
            vButtons.Controls.Add(btnRefresh);

            // Fill first, then bottom, then top (docking order)
            vendorsCard.Controls.Add(gridVendors);
            vendorsCard.Controls.Add(vButtons);
            vendorsCard.Controls.Add(vHeader);

            root.Controls.Add(vendorsCard, 1, 1);

            view.Controls.Add(root);
            return view;
        }

        // ==========================================
        // BUILD: MY EVENTS
        // ==========================================
        private Panel BuildEvents()
        {
            Panel view = new Panel() { Dock = DockStyle.Fill, BackColor = Color.Transparent, Visible = false };
            Panel card = NewCard(24);

            Label title = new Label() { Text = "My Events", Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = TextDark, Dock = DockStyle.Top, Height = 50, AutoSize = false };
            gridEvents = NewGrid();

            card.Controls.Add(gridEvents);
            card.Controls.Add(title);
            view.Controls.Add(card);
            return view;
        }

        // ==========================================
        // BUILD: MY BOOKINGS (list + vendor's response)
        // ==========================================
        private Panel BuildBookings()
        {
            Panel view = new Panel() { Dock = DockStyle.Fill, BackColor = Color.Transparent, Visible = false };

            TableLayoutPanel root = new TableLayoutPanel() { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, BackColor = Color.Transparent };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 410));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            // ----- Left: list -----
            Panel listCard = NewCard(24);
            listCard.Margin = new Padding(0, 0, 16, 0);
            Label title = new Label() { Text = "My Bookings", Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = TextDark, Dock = DockStyle.Top, Height = 50, AutoSize = false };
            gridBookings = NewGrid();
            gridBookings.SelectionChanged += (s, e) => UpdateBookingDetail();
            listCard.Controls.Add(gridBookings);
            listCard.Controls.Add(title);

            // ----- Right: message + vendor's response -----
            Panel detailCard = NewCard(24);
            detailCard.Margin = new Padding(0);

            TableLayoutPanel d = new TableLayoutPanel() { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 7, BackColor = Color.White };
            d.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            d.RowStyles.Add(new RowStyle(SizeType.AutoSize));          // 0 event title
            d.RowStyles.Add(new RowStyle(SizeType.AutoSize));          // 1 vendor
            d.RowStyles.Add(new RowStyle(SizeType.AutoSize));          // 2 status pill
            d.RowStyles.Add(new RowStyle(SizeType.AutoSize));          // 3 caption: your message
            d.RowStyles.Add(new RowStyle(SizeType.Percent, 50));       // 4 your message
            d.RowStyles.Add(new RowStyle(SizeType.AutoSize));          // 5 caption: vendor response
            d.RowStyles.Add(new RowStyle(SizeType.Percent, 50));       // 6 vendor response

            lblBkEvent = new Label() { Text = "No booking selected", Font = new Font("Segoe UI", 15, FontStyle.Bold), ForeColor = TextDark, AutoSize = true, MaximumSize = new Size(350, 0), Anchor = AnchorStyles.Left, Margin = new Padding(0, 0, 0, 4) };
            lblBkVendor = new Label() { Text = "Pick a booking to see the vendor's response.", Font = new Font("Segoe UI", 9.5f), ForeColor = Color.Gray, AutoSize = true, MaximumSize = new Size(350, 0), Anchor = AnchorStyles.Left, Margin = new Padding(0, 0, 0, 8) };
            lblBkStatus = new Label() { Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true, Padding = new Padding(12, 4, 12, 4), Anchor = AnchorStyles.Left, Margin = new Padding(0, 0, 0, 16), Visible = false };

            txtBkMessage = new TextBox() { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, BackColor = Color.WhiteSmoke, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10.5f), ScrollBars = ScrollBars.Vertical, Margin = new Padding(0, 0, 0, 14) };
            txtBkResponse = new TextBox() { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, BackColor = Color.WhiteSmoke, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10.5f), ScrollBars = ScrollBars.Vertical, Margin = new Padding(0) };

            d.Controls.Add(lblBkEvent, 0, 0);
            d.Controls.Add(lblBkVendor, 0, 1);
            d.Controls.Add(lblBkStatus, 0, 2);
            d.Controls.Add(CaptionLabel("Your message to the vendor"), 0, 3);
            d.Controls.Add(txtBkMessage, 0, 4);
            d.Controls.Add(CaptionLabel("Vendor's response"), 0, 5);
            d.Controls.Add(txtBkResponse, 0, 6);
            detailCard.Controls.Add(d);

            root.Controls.Add(listCard, 0, 0);
            root.Controls.Add(detailCard, 1, 0);
            view.Controls.Add(root);
            return view;
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

        private Label FieldLabel(string text)
        {
            return new Label() { Text = text, Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.DimGray, AutoSize = true, Margin = new Padding(0, 0, 0, 6) };
        }

        private Label CaptionLabel(string text)
        {
            return new Label() { Text = text, Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.DimGray, AutoSize = true, MaximumSize = new Size(350, 0), Anchor = AnchorStyles.Left, Margin = new Padding(0, 0, 0, 6) };
        }

        // Small white card with a big number and a caption
        private FlowLayoutPanel StatCard(string caption, out Label valueLabel, bool isLast)
        {
            FlowLayoutPanel card = new FlowLayoutPanel() { FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, Dock = DockStyle.Fill, Padding = new Padding(20, 16, 20, 16), BackColor = Color.White, Margin = new Padding(0, 0, isLast ? 0 : 12, 0) };
            AddBorder(card);
            valueLabel = new Label() { Text = "0", Font = new Font("Segoe UI", 22, FontStyle.Bold), ForeColor = Indigo, AutoSize = true, Margin = new Padding(0) };
            Label cap = new Label() { Text = caption, Font = new Font("Segoe UI", 9.5f), ForeColor = Color.Gray, AutoSize = true, Margin = new Padding(2, 0, 0, 0) };
            card.Controls.Add(valueLabel);
            card.Controls.Add(cap);
            return card;
        }

        // One consistent grid style for every table in the planner dashboard
        private DataGridView NewGrid()
        {
            DataGridView g = new DataGridView()
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
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
            g.ColumnHeadersDefaultCellStyle.BackColor = PageGray;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 80);
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = PageGray;
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(60, 60, 80);
            g.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            g.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 230, 250);
            g.DefaultCellStyle.SelectionForeColor = Color.Black;
            g.RowTemplate.Height = 42;

            // Colour the Status column in any grid that has one
            g.CellFormatting += (s, e) =>
            {
                if (e.RowIndex < 0 || e.Value == null) return;
                if (g.Columns[e.ColumnIndex].Name != "Status") return;
                string st = e.Value.ToString();
                e.CellStyle.Font = boldFont;
                if (st == "Accepted") e.CellStyle.ForeColor = Color.SeaGreen;
                else if (st == "Rejected") e.CellStyle.ForeColor = Color.Firebrick;
                else e.CellStyle.ForeColor = Color.DarkOrange;
            };

            g.DataBindingComplete += (s, e) => PrettifyGrid(g);
            return g;
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

        private Button CreateSidebarButton(string text, int y)
        {
            Button btn = new Button() { Text = "   " + text, Location = new Point(0, y), Width = 250, Height = 45, FlatStyle = FlatStyle.Flat, BackColor = Indigo, ForeColor = Color.White, Font = new Font("Segoe UI", 11, FontStyle.Bold), TextAlign = ContentAlignment.MiddleLeft, Cursor = Cursors.Hand };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = IndigoLight;

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