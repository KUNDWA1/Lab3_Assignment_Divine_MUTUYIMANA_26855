using System;
using System.Windows.Forms;
using EventConnect.Controllers;

namespace EventConnect.Views
{
    public class VendorForm : Form
    {
        DatabaseController db = new DatabaseController();
        public VendorForm()
        {
            this.Text = "Vendor Dashboard";
            this.Size = new System.Drawing.Size(400, 350);

            Label lblName = new Label() { Text = "Business Name:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            TextBox txtName = new TextBox() { Location = new System.Drawing.Point(150, 20) };
            Label lblService = new Label() { Text = "Service Type:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            TextBox txtService = new TextBox() { Location = new System.Drawing.Point(150, 60) };
            Label lblPrice = new Label() { Text = "Price (RWF):", Location = new System.Drawing.Point(20, 100), AutoSize = true };
            TextBox txtPrice = new TextBox() { Location = new System.Drawing.Point(150, 100) };
            Label lblLoc = new Label() { Text = "Location:", Location = new System.Drawing.Point(20, 140), AutoSize = true };
            TextBox txtLoc = new TextBox() { Location = new System.Drawing.Point(150, 140) };
            Button btnSave = new Button() { Text = "Create Profile", Location = new System.Drawing.Point(150, 180), Width = 100 };
            Button btnBack = new Button() { Text = "Logout", Location = new System.Drawing.Point(150, 240), Width = 100 };

            btnBack.Click += (s, e) => { new LoginForm().Show(); this.Hide(); };
            btnSave.Click += (s, e) =>
            {
                try
                {
                    db.AddVendor(txtName.Text, txtService.Text, decimal.Parse(txtPrice.Text), txtLoc.Text);
                    MessageBox.Show("Profile Created Successfully!");
                    txtName.Clear(); txtService.Clear(); txtPrice.Clear(); txtLoc.Clear();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            };

            this.Controls.Add(lblName); this.Controls.Add(txtName);
            this.Controls.Add(lblService); this.Controls.Add(txtService);
            this.Controls.Add(lblPrice); this.Controls.Add(txtPrice);
            this.Controls.Add(lblLoc); this.Controls.Add(txtLoc);
            this.Controls.Add(btnSave); this.Controls.Add(btnBack);
        }
    }
}
