using System;
using System.Windows.Forms;

namespace EventConnect.Views
{
    public class LoginForm : Form
    {
        public LoginForm()
        {
            this.Text = "Event Connect - Select Role";
            this.Size = new System.Drawing.Size(300, 200);
            Button btnVendor = new Button() { Text = "I am a Vendor", Location = new System.Drawing.Point(50, 30), Width = 180 };
            Button btnPlanner = new Button() { Text = "I am an Event Planner", Location = new System.Drawing.Point(50, 80), Width = 180 };
            btnVendor.Click += (s, e) => { new VendorForm().Show(); this.Hide(); };
            btnPlanner.Click += (s, e) => { new PlannerForm().Show(); this.Hide(); };
            this.Controls.Add(btnVendor);
            this.Controls.Add(btnPlanner);
        }
    }
}
