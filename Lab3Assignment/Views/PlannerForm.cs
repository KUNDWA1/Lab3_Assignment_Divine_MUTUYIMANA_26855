using System;
using System.Windows.Forms;
using EventConnect.Controllers;

namespace EventConnect.Views
{
    public class PlannerForm : Form
    {
        DatabaseController db = new DatabaseController();
        public PlannerForm()
        {
            this.Text = "Planner Dashboard";
            this.Size = new System.Drawing.Size(750, 500); // Made much larger
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label() { Text = "Event Title:", Location = new System.Drawing.Point(30, 30), AutoSize = true };
            TextBox txtTitle = new TextBox() { Location = new System.Drawing.Point(130, 30), Width = 150 };

            Label lblBudget = new Label() { Text = "Budget:", Location = new System.Drawing.Point(30, 80), AutoSize = true };
            TextBox txtBudget = new TextBox() { Location = new System.Drawing.Point(130, 80), Width = 150 };

            Button btnCreateEvent = new Button() { Text = "Create Event", Location = new System.Drawing.Point(130, 130), Width = 150, Height = 35 };

            DataGridView gridVendors = new DataGridView() { Location = new System.Drawing.Point(320, 30), Width = 380, Height = 250, ReadOnly = true, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };

            Button btnLoadVendors = new Button() { Text = "Load Vendors", Location = new System.Drawing.Point(320, 300), Width = 150, Height = 35 };
            btnLoadVendors.Click += (s, e) => { gridVendors.DataSource = db.GetVendors(); };

            Button btnBack = new Button() { Text = "Logout", Location = new System.Drawing.Point(550, 400), Width = 150, Height = 35 };
            btnBack.Click += (s, e) => { new LoginForm().Show(); this.Hide(); };

            btnCreateEvent.Click += (s, e) =>
            {
                try
                {
                    db.AddEvent(txtTitle.Text, DateTime.Now, decimal.Parse(txtBudget.Text));
                    MessageBox.Show("Event Created! You can now book a vendor.");
                    txtTitle.Clear(); txtBudget.Clear();
                }
                catch { MessageBox.Show("Invalid Budget format."); }
            };

            this.Controls.Add(lblTitle); this.Controls.Add(txtTitle);
            this.Controls.Add(lblBudget); this.Controls.Add(txtBudget);
            this.Controls.Add(btnCreateEvent);
            this.Controls.Add(gridVendors); this.Controls.Add(btnLoadVendors);
            this.Controls.Add(btnBack);
        }
    }
}