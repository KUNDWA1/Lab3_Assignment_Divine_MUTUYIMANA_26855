using System;
using System.Windows.Forms;

namespace EventConnect.Views
{
    public class LoginForm : Form
    {
        public LoginForm()
        {
            this.Text = "Event Connect - Select Role";
            this.Size = new System.Drawing.Size(400, 250); // Made wider
            this.StartPosition = FormStartPosition.CenterScreen;

            Button btnVendor = new Button() { Text = "I am a Vendor", Location = new System.Drawing.Point(80, 40), Width = 220, Height = 40 };
            Button btnPlanner = new Button() { Text = "I am an Event Planner", Location = new System.Drawing.Point(80, 100), Width = 220, Height = 40 };

            btnVendor.Click += (s, e) => { new VendorForm().Show(); this.Hide(); };
            btnPlanner.Click += (s, e) => { new PlannerForm().Show(); this.Hide(); };

            this.Controls.Add(btnVendor);
            this.Controls.Add(btnPlanner);
        }
    }
}