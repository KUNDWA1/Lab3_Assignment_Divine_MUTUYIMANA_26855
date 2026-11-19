using System;
using System.Drawing;
using System.Windows.Forms;
using Lab3Assignment.Controllers;

namespace Lab3Assignment.Views
{
    // The layout lives in LoginForm.Designer.cs (open it in Design view to edit).
    // This file only contains the behaviour.
    public partial class LoginForm : Form
    {
        DatabaseController db = new DatabaseController();

        static readonly Color Indigo = Color.FromArgb(0, 64, 64);
        static readonly Color BorderGray = Color.FromArgb(207, 226, 226);

        string selectedRole = "Vendor";

        public LoginForm()
        {
            InitializeComponent();

            SetRole("Vendor");
            ShowLogin();
        }

        
        // LAYOUT EVENTS
        
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();   
        }

        private void rightPanel_Resize(object sender, EventArgs e) { CenterCards(); }

        private void Card_SizeChanged(object sender, EventArgs e) { CenterCards(); }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            Control c = (Control)sender;
            using (Pen pen = new Pen(BorderGray))
                e.Graphics.DrawRectangle(pen, 0, 0, c.Width - 1, c.Height - 1);
        }

        // Keep the cards centred when the window or card size changes
        private void CenterCards()
        {
            foreach (Panel card in new Panel[] { loginPanel, signupPanel })
            {
                int x = Math.Max(10, (rightPanel.ClientSize.Width - card.Width) / 2);
                int y = Math.Max(10, (rightPanel.ClientSize.Height - card.Height) / 2);
                card.Location = new Point(x, y);
            }
        }

      
        // CLICK HANDLERS
       
        private void btnLogin_Click(object sender, EventArgs e) { HandleLogin(); }
        private void btnSignup_Click(object sender, EventArgs e) { HandleSignup(); }
        private void lnkSignup_Click(object sender, EventArgs e) { ShowSignup(); }
        private void lnkLogin_Click(object sender, EventArgs e) { ShowLogin(); }
        private void btnRoleVendor_Click(object sender, EventArgs e) { SetRole("Vendor"); }
        private void btnRolePlanner_Click(object sender, EventArgs e) { SetRole("Event Planner"); }

        
        // ACTIONS
        
        private void HandleLogin()
        {
            string email = txtLoginEmail.Text.Trim();
            string password = txtLoginPassword.Text;

            if (email == "" || password == "")
            {
                MessageBox.Show("Please fill in all fields.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role;
            try { role = db.LoginUser(email, password); }
            catch (Exception ex)
            {
                MessageBox.Show("Could not reach the database. Is MySQL running?" + Environment.NewLine + Environment.NewLine + ex.Message, "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (role == "Vendor") OpenDashboard(new VendorForm(email));
            else if (role == "Event Planner") OpenDashboard(new PlannerForm());
            else MessageBox.Show("Invalid email or password.", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void OpenDashboard(Form dashboard)
        {
            txtLoginPassword.Clear();
            dashboard.FormClosed += (s, e) => Application.Exit();
            dashboard.Show();
            this.Hide();
        }

        private void HandleSignup()
        {
            if (string.IsNullOrWhiteSpace(txtSignName.Text) || string.IsNullOrWhiteSpace(txtSignEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSignPhone.Text) || string.IsNullOrWhiteSpace(txtSignPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!txtSignEmail.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address like you@example.com.", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!chkTerms.Checked)
            {
                MessageBox.Show("You must agree to the Terms and Conditions.", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = db.RegisterUser(txtSignName.Text.Trim(), txtSignEmail.Text.Trim(), txtSignPhone.Text.Trim(), txtSignPassword.Text, selectedRole);
            if (success)
            {
                MessageBox.Show("Account created! You can now log in.", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoginEmail.Text = txtSignEmail.Text.Trim();
                txtSignName.Clear(); txtSignEmail.Clear(); txtSignPhone.Clear(); txtSignPassword.Clear();
                chkTerms.Checked = false;
                ShowLogin();
                txtLoginPassword.Focus();
            }
            else
            {
                MessageBox.Show("Could not create the account. This email might already be in use.", "Sign up failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowLogin()
        {
            signupPanel.Visible = false;
            loginPanel.Visible = true;
            this.AcceptButton = btnLogin;   
            CenterCards();
        }

        private void ShowSignup()
        {
            loginPanel.Visible = false;
            signupPanel.Visible = true;
            this.AcceptButton = btnSignup;
            CenterCards();
        }

        private void SetRole(string role)
        {
            selectedRole = role;
            StyleRoleButton(btnRoleVendor, role == "Vendor");
            StyleRoleButton(btnRolePlanner, role == "Event Planner");
        }

        private void StyleRoleButton(Button b, bool selected)
        {
            b.BackColor = selected ? Indigo : Color.White;
            b.ForeColor = selected ? Color.White : Color.DimGray;
            b.FlatAppearance.BorderColor = selected ? Indigo : BorderGray;
        }
    }
}
