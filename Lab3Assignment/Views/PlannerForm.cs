using System;
using System.Drawing;
using System.Windows.Forms;
using Lab3Assignment.Controllers;

namespace Lab3Assignment.Views
{
    public class PlannerForm : Form
    {
        DatabaseController db = new DatabaseController();
        DataGridView gridVendors;
        Label lblList;
        Button btnLoad, btnBookVendor;
        string currentView = "Vendors";

        public PlannerForm()
        {
            this.Text = "Planner Dashboard";
            this.Size = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(244, 246, 249);

            Panel sidebar = new Panel() { Width = 250, Dock = DockStyle.Left, BackColor = Color.FromArgb(61, 76, 155) };
            Label logo = new Label() { Text = "EventKonnect", ForeColor = Color.White, Font = new Font("Segoe UI", 16, FontStyle.Bold), AutoSize = false, Width = 250, Height = 80, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Top };

            Button btnDash = CreateSidebarButton("Dashboard", 100);
            Button btnEvents = CreateSidebarButton("My Events", 150);
            Button btnLogout = CreateSidebarButton("Logout", 600);
            btnLogout.Click += (s, e) => { new LoginForm().Show(); this.Hide(); };

            sidebar.Controls.Add(logo); sidebar.Controls.Add(btnDash); sidebar.Controls.Add(btnEvents); sidebar.Controls.Add(btnLogout);

            Panel header = new Panel() { Height = 70, Dock = DockStyle.Top, BackColor = Color.White };
            Label lblWelcome = new Label() { Text = "Post your event and connect with vendors", Font = new Font("Segoe UI", 12), ForeColor = Color.Gray, Location = new Point(30, 25), AutoSize = true };
            header.Controls.Add(lblWelcome);

            Panel main = new Panel() { Dock = DockStyle.Fill, Padding = new Padding(30) };

            // 1. Create Event Section
            Panel createPanel = new Panel() { Location = new Point(30, 30), Size = new Size(350, 150), BackColor = Color.White };
            Label lblCreate = new Label() { Text = "Create New Event", Font = new Font("Segoe UI", 12, FontStyle.Bold), Location = new Point(15, 15), AutoSize = true };
            Label lblT = new Label() { Text = "Title:", Location = new Point(15, 50), AutoSize = true };
            TextBox txtTitle = new TextBox() { Location = new Point(70, 50), Width = 250 };
            Label lblB = new Label() { Text = "Budget:", Location = new Point(15, 85), AutoSize = true };
            TextBox txtBudget = new TextBox() { Location = new Point(70, 85), Width = 250 };
            Button btnCreate = new Button() { Text = "Post Event", Location = new Point(70, 115), Width = 250, Height = 30, BackColor = Color.FromArgb(61, 76, 155), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnCreate.FlatAppearance.BorderSize = 0;

            btnCreate.Click += (s, e) => {
                try { db.AddEvent(txtTitle.Text, DateTime.Now, decimal.Parse(txtBudget.Text)); MessageBox.Show("Event Posted!"); txtTitle.Clear(); txtBudget.Clear(); }
                catch { MessageBox.Show("Invalid Budget."); }
            };
            createPanel.Controls.Add(lblCreate); createPanel.Controls.Add(lblT); createPanel.Controls.Add(txtTitle);
            createPanel.Controls.Add(lblB); createPanel.Controls.Add(txtBudget); createPanel.Controls.Add(btnCreate);

            // 2. List Section
            Panel listPanel = new Panel() { Location = new Point(400, 30), Size = new Size(600, 450), BackColor = Color.White };
            lblList = new Label() { Text = "Available Vendors", Font = new Font("Segoe UI", 12, FontStyle.Bold), Location = new Point(15, 15), AutoSize = true };

            gridVendors = new DataGridView()
            {
                Location = new Point(15, 50),
                Size = new Size(570, 320),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            btnLoad = new Button() { Text = "Refresh", Location = new Point(15, 390), Width = 120, Height = 35, BackColor = Color.FromArgb(61, 76, 155), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnBookVendor = new Button() { Text = "Book Vendor", Location = new Point(145, 390), Width = 140, Height = 35, BackColor = Color.FromArgb(255, 193, 7), ForeColor = Color.Black, FlatStyle = FlatStyle.Flat };
            Button btnViewBookings = new Button() { Text = "My Bookings", Location = new Point(295, 390), Width = 140, Height = 35, BackColor = Color.LightGray, ForeColor = Color.Black, FlatStyle = FlatStyle.Flat };

            btnLoad.Click += (s, e) => LoadView(currentView);
            btnEvents.Click += (s, e) => LoadView("Events");
            btnDash.Click += (s, e) => LoadView("Vendors");
            btnViewBookings.Click += (s, e) => LoadView("Bookings");

            btnBookVendor.Click += (s, e) => {
                if (currentView != "Vendors") { MessageBox.Show("Select a vendor from the Available Vendors list."); return; }

                if (gridVendors.SelectedRows.Count > 0)
                {
                    int vendorId = Convert.ToInt32(gridVendors.SelectedRows[0].Cells["VendorId"].Value);
                    ShowBookingDialog(vendorId);
                }
                else { MessageBox.Show("Please click on a vendor row first."); }
            };

            listPanel.Controls.Add(lblList); listPanel.Controls.Add(gridVendors); listPanel.Controls.Add(btnLoad); listPanel.Controls.Add(btnBookVendor); listPanel.Controls.Add(btnViewBookings);
            main.Controls.Add(createPanel); main.Controls.Add(listPanel);

            this.Controls.Add(main); this.Controls.Add(header); this.Controls.Add(sidebar);
            LoadView("Vendors");
        }

        private void LoadView(string viewType)
        {
            currentView = viewType;
            if (viewType == "Vendors") { gridVendors.DataSource = db.GetVendors(); lblList.Text = "Available Vendors"; btnBookVendor.Visible = true; }
            else if (viewType == "Events") { gridVendors.DataSource = db.GetEvents(); lblList.Text = "My Events"; btnBookVendor.Visible = false; }
            else if (viewType == "Bookings") { gridVendors.DataSource = db.GetPlannerBookings(); lblList.Text = "My Bookings Status"; btnBookVendor.Visible = false; }
        }

        // POPUP DIALOG FOR BOOKING
        private void ShowBookingDialog(int vendorId)
        {
            Form prompt = new Form() { Width = 400, Height = 300, Text = "Book Vendor", StartPosition = FormStartPosition.CenterParent, BackColor = Color.White };

            Label lblE = new Label() { Text = "Event ID (e.g., 1):", Location = new Point(20, 20), AutoSize = true };
            TextBox txtE = new TextBox() { Location = new Point(20, 45), Width = 340 };

            Label lblMsg = new Label() { Text = "Message / Phone Number:", Location = new Point(20, 80), AutoSize = true };
            TextBox txtMsg = new TextBox() { Location = new Point(20, 105), Width = 340, Multiline = true, Height = 80 };

            Button btnSave = new Button() { Text = "Send Request", Location = new Point(20, 200), Width = 340, Height = 35, BackColor = Color.FromArgb(61, 76, 155), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnSave.Click += (s, e) => {
                try
                {
                    int eventId = int.Parse(txtE.Text);
                    db.CreateBooking(vendorId, eventId, txtMsg.Text);
                    MessageBox.Show("Booking Request Sent!");
                    prompt.Close();
                    LoadView("Bookings");
                }
                catch { MessageBox.Show("Please enter a valid Event ID."); }
            };

            prompt.Controls.Add(lblE); prompt.Controls.Add(txtE);
            prompt.Controls.Add(lblMsg); prompt.Controls.Add(txtMsg); prompt.Controls.Add(btnSave);
            prompt.ShowDialog();
        }

        private Button CreateSidebarButton(string text, int y)
        {
            Button btn = new Button() { Text = "   " + text, Location = new Point(0, y), Width = 250, Height = 45, FlatStyle = FlatStyle.Flat, ForeColor = Color.White, Font = new Font("Segoe UI", 11, FontStyle.Bold), TextAlign = ContentAlignment.MiddleLeft };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 100, 180);
            return btn;
        }
    }
}