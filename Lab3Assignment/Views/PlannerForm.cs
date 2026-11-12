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
            this.Size = new System.Drawing.Size(600, 450);

            Label lblTitle = new Label() { Text = "Event Title:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            TextBox txtTitle = new TextBox() { Location = new System.Drawing.Point(120, 20) };
            Label lblBudget = new Label() { Text = "Budget:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            TextBox txtBudget = new TextBox() { Location = new System.Drawing.Point(120, 60) };
            Button btnCreateEvent = new Button() { Text = "Create Event", Location = new System.Drawing.Point(120, 100), Width = 100 };

            DataGridView gridVendors = new DataGridView() { Location = new System.Drawing.Point(250, 20), Width = 300, Height = 200, ReadOnly = true, AllowUserToAddRows = false };
            Button btnLoadVendors = new Button() { Text = "Load Vendors", Location = new System.Drawing.Point(250, 230), Width = 100 };
            btnLoadVendors.Click += (s, e) => { gridVendors.DataSource = db.GetVendors(); };

            Button btnBack = new Button() { Text = "Logout", Location = new System.Drawing.Point(450, 350), Width = 100 };
            btnBack.Click += (s, e) => { new LoginForm().Show(); this.Hide(); };

            btnCreateEvent.Click += (s, e) =>
            {
                try
                {
                    db.AddEvent(txtTitle.Text, DateTime.Now, decimal.Parse(txtBudget.Text));
                    MessageBox.Show("Event Created! You can now book a vendor.");
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
