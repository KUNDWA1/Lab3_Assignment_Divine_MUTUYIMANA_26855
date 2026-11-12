using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Lab3Assignment.Controllers;

namespace Lab3Assignment.Views
{
    public class VendorForm : Form
    {
        DatabaseController db = new DatabaseController();
        int currentVendorId = 1; 

        // Panels to switch between
        Panel profileView;
        Panel bookingsView;

        // Profile Controls
        TextBox txtName, txtService, txtPrice, txtLocation;
        Button btnEditSave;
        bool isEditing = false;

        // Bookings Controls
        DataGridView gridBookings;

        public VendorForm()
        {
            this.Text = "Vendor Dashboard";
            this.Size = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(244, 246, 249);

            // ==========================================
            // SIDEBAR
            // ==========================================
            Panel sidebar = new Panel() { Width = 250, Dock = DockStyle.Left, BackColor = Color.FromArgb(61, 76, 155) };
            Label logo = new Label() { Text = "EventKonnect", ForeColor = Color.White, Font = new Font("Segoe UI", 16, FontStyle.Bold), AutoSize = false, Width = 250, Height = 80, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Top };
            
            Button btnBookings = CreateSidebarButton("Booking Requests", 100);
            Button btnProfile = CreateSidebarButton("My Profile", 150);
            Button btnLogout = CreateSidebarButton("Logout", 600);
            
            btnLogout.Click += (s, e) => { new LoginForm().Show(); this.Hide(); };
            
            sidebar.Controls.Add(logo); 
            sidebar.Controls.Add(btnBookings); 
            sidebar.Controls.Add(btnProfile); 
            sidebar.Controls.Add(btnLogout);

            // ==========================================
            // HEADER
            // ==========================================
            Panel header = new Panel() { Height = 70, Dock = DockStyle.Top, BackColor = Color.White };
            Label lblWelcome = new Label() { Text = "Manage your profile and incoming bookings", Font = new Font("Segoe UI", 12), ForeColor = Color.Gray, Location = new Point(30, 25), AutoSize = true };
            header.Controls.Add(lblWelcome);

            // ==========================================
            // MAIN CONTAINER
            // ==========================================
            Panel mainContainer = new Panel() { Dock = DockStyle.Fill, Padding = new Padding(30) };

            // ==========================================
            // VIEW 1: PROFILE VIEW (Social Media Style)
            // ==========================================
            profileView = new Panel() { Dock = DockStyle.Fill, BackColor = Color.Transparent, Visible = false };
            
            Panel profileCard = new Panel() { Location = new Point(0, 0), Size = new Size(500, 520), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
            
            // Avatar Placeholder
            Panel avatar = new Panel() { Location = new Point(30, 30), Size = new Size(80, 80), BackColor = Color.LightGray };
            Label avatarText = new Label() { Text = "V", Font = new Font("Segoe UI", 30, FontStyle.Bold), ForeColor = Color.White, AutoSize = false, Width = 80, Height = 80, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill };
            avatar.Controls.Add(avatarText);

            Label lblTitle = new Label() { Text = "Business Profile", Font = new Font("Segoe UI", 20, FontStyle.Bold), Location = new Point(130, 40), AutoSize = true };
            Label lblSubTitle = new Label() { Text = "Manage your public business details", Font = new Font("Segoe UI", 10), ForeColor = Color.Gray, Location = new Point(130, 75), AutoSize = true };

            // Inputs
            Label lblName = new Label() { Text = "Business Name", Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.DimGray, Location = new Point(30, 150), AutoSize = true };
            txtName = new TextBox() { Location = new Point(30, 175), Width = 440, Font = new Font("Segoe UI", 12), ReadOnly = true, BackColor = Color.WhiteSmoke, BorderStyle = BorderStyle.FixedSingle };
            
            Label lblService = new Label() { Text = "Service Type", Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.DimGray, Location = new Point(30, 220), AutoSize = true };
            txtService = new TextBox() { Location = new Point(30, 245), Width = 440, Font = new Font("Segoe UI", 12), ReadOnly = true, BackColor = Color.WhiteSmoke, BorderStyle = BorderStyle.FixedSingle };
            
            Label lblPrice = new Label() { Text = "Price (RWF)", Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.DimGray, Location = new Point(30, 290), AutoSize = true };
            txtPrice = new TextBox() { Location = new Point(30, 315), Width = 440, Font = new Font("Segoe UI", 12), ReadOnly = true, BackColor = Color.WhiteSmoke, BorderStyle = BorderStyle.FixedSingle };

            Label lblLoc = new Label() { Text = "Location", Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.DimGray, Location = new Point(30, 360), AutoSize = true };
            txtLocation = new TextBox() { Location = new Point(30, 385), Width = 440, Font = new Font("Segoe UI", 12), ReadOnly = true, BackColor = Color.WhiteSmoke, BorderStyle = BorderStyle.FixedSingle };

            btnEditSave = new Button() { Text = "Edit Profile", Location = new Point(30, 440), Width = 440, Height = 45, BackColor = Color.FromArgb(61, 76, 155), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 12, FontStyle.Bold) };
            btnEditSave.FlatAppearance.BorderSize = 0;
            btnEditSave.Click += (s, e) => HandleEditSave();

            profileCard.Controls.Add(avatar); profileCard.Controls.Add(lblTitle); profileCard.Controls.Add(lblSubTitle);
            profileCard.Controls.Add(lblName); profileCard.Controls.Add(txtName);
            profileCard.Controls.Add(lblService); profileCard.Controls.Add(txtService);
            profileCard.Controls.Add(lblPrice); profileCard.Controls.Add(txtPrice);
            profileCard.Controls.Add(lblLoc); profileCard.Controls.Add(txtLocation);
            profileCard.Controls.Add(btnEditSave);
            
            profileView.Controls.Add(profileCard);

            // ==========================================
            // VIEW 2: BOOKINGS VIEW
            // ==========================================
            bookingsView = new Panel() { Dock = DockStyle.Fill, BackColor = Color.Transparent, Visible = false };

            Panel bookingsPanel = new Panel() { Location = new Point(0, 0), Size = new Size(750, 520), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
            
            Label lblBookingsTitle = new Label() { Text = "Incoming Booking Requests", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(30, 30), AutoSize = true };
            
            gridBookings = new DataGridView() { 
                Location = new Point(30, 80), Size = new Size(690, 320), 
                BackgroundColor = Color.White, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, 
                AllowUserToAddRows = false, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BorderStyle = BorderStyle.None, CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None, EnableHeadersVisualStyles = false
            };
            gridBookings.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(244, 246, 249);
            gridBookings.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            gridBookings.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            gridBookings.RowTemplate.Height = 40;
            
            Button btnAccept = new Button() { Text = "Accept Request", Location = new Point(30, 430), Width = 335, Height = 45, BackColor = Color.LightGreen, ForeColor = Color.Black, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            Button btnReject = new Button() { Text = "Reject Request", Location = new Point(385, 430), Width = 335, Height = 45, BackColor = Color.LightCoral, ForeColor = Color.Black, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold) };

            btnAccept.FlatAppearance.BorderSize = 0;
            btnReject.FlatAppearance.BorderSize = 0;

            btnAccept.Click += (s, e) => UpdateStatus("Accepted");
            btnReject.Click += (s, e) => UpdateStatus("Rejected");

            bookingsPanel.Controls.Add(lblBookingsTitle); bookingsPanel.Controls.Add(gridBookings);
            bookingsPanel.Controls.Add(btnAccept); bookingsPanel.Controls.Add(btnReject);

            bookingsView.Controls.Add(bookingsPanel);

            // Add views to main container
            mainContainer.Controls.Add(profileView);
            mainContainer.Controls.Add(bookingsView);

            this.Controls.Add(mainContainer); 
            this.Controls.Add(header); 
            this.Controls.Add(sidebar);

            // ==========================================
            // NAVIGATION LOGIC
            // ==========================================
            btnProfile.Click += (s, e) => {
                bookingsView.Visible = false;
                profileView.Visible = true;
                LoadProfile(); // Refresh profile data
            };

            btnBookings.Click += (s, e) => {
                profileView.Visible = false;
                bookingsView.Visible = true;
                gridBookings.DataSource = db.GetVendorBookings(currentVendorId); // Refresh bookings
            };

            // Default view on startup
            btnProfile.PerformClick();
        }

        private void LoadProfile()
        {
            DataTable dt = db.GetVendorProfile(currentVendorId);
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtService.Text = dt.Rows[0]["ServiceType"].ToString();
                txtPrice.Text = dt.Rows[0]["Price"].ToString();
                txtLocation.Text = dt.Rows[0]["Location"].ToString();
            }
        }

        private void HandleEditSave()
        {
            if (!isEditing)
            {
                // Enable fields
                txtName.ReadOnly = false; txtName.BackColor = Color.White;
                txtService.ReadOnly = false; txtService.BackColor = Color.White;
                txtPrice.ReadOnly = false; txtPrice.BackColor = Color.White;
                txtLocation.ReadOnly = false; txtLocation.BackColor = Color.White;
                
                btnEditSave.Text = "Save Changes";
                btnEditSave.BackColor = Color.Green;
                isEditing = true;
            }
            else
            {
                // Save fields
                try {
                    db.UpdateVendor(currentVendorId, txtName.Text, txtService.Text, decimal.Parse(txtPrice.Text), txtLocation.Text);
                    MessageBox.Show("Profile Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
                catch (Exception ex) { 
                    MessageBox.Show("Error saving: " + ex.Message); 
                    return; 
                }

                // Disable fields
                txtName.ReadOnly = true; txtName.BackColor = Color.WhiteSmoke;
                txtService.ReadOnly = true; txtService.BackColor = Color.WhiteSmoke;
                txtPrice.ReadOnly = true; txtPrice.BackColor = Color.WhiteSmoke;
                txtLocation.ReadOnly = true; txtLocation.BackColor = Color.WhiteSmoke;
                
                btnEditSave.Text = "Edit Profile";
                btnEditSave.BackColor = Color.FromArgb(61, 76, 155);
                isEditing = false;
            }
        }

        private void UpdateStatus(string status)
        {
            if (gridBookings.SelectedRows.Count > 0)
            {
                try
                {
                    int bookingId = Convert.ToInt32(gridBookings.SelectedRows[0].Cells["BookingId"].Value);
                    db.UpdateBookingStatus(bookingId, status);
                    MessageBox.Show("Booking " + status + "!", "Success");
                    gridBookings.DataSource = db.GetVendorBookings(currentVendorId);
                }
                catch { MessageBox.Show("Please select a booking first."); }
            }
            else { MessageBox.Show("Please select a booking from the table."); }
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