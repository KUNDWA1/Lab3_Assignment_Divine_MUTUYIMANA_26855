using System;
using System.Drawing;
using System.Windows.Forms;
using Lab3Assignment.Controllers;

namespace Lab3Assignment.Views
{
    public class LoginForm : Form
    {
        DatabaseController db = new DatabaseController();

        // Form Elements
        Panel loginPanel, signupPanel;
        Label lblSwitchToSignup, lblSwitchToLogin;

        // Login Inputs
        TextBox txtLoginEmail, txtLoginPassword;

        // Signup Inputs
        TextBox txtSignName, txtSignEmail, txtSignPhone, txtSignPassword;
        ComboBox cmbRole;
        CheckBox chkTerms;

        public LoginForm()
        {
            this.Text = "Event Connect";
            this.Size = new Size(1100, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // ==========================================
            // 1. TOP NAVIGATION BAR
            // ==========================================
            Panel navBar = new Panel() { Dock = DockStyle.Top, Height = 70, BackColor = Color.FromArgb(61, 76, 155) };
            Label logo = new Label() { Text = "EventKonnect", ForeColor = Color.White, Font = new Font("Segoe UI", 18, FontStyle.Bold), Location = new Point(30, 20), AutoSize = true };

            Label lblNavLogin = new Label() { Text = "Login", ForeColor = Color.White, Font = new Font("Segoe UI", 11), Location = new Point(850, 24), AutoSize = true, Cursor = Cursors.Hand };
            lblNavLogin.Click += (s, e) => ShowLogin();

            Button btnGetStarted = new Button()
            {
                Text = "Get Started",
                Location = new Point(930, 18),
                Width = 130,
                Height = 35,
                BackColor = Color.FromArgb(255, 193, 7),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnGetStarted.FlatAppearance.BorderSize = 0;
            btnGetStarted.Click += (s, e) => ShowSignup();

            navBar.Controls.Add(logo); navBar.Controls.Add(lblNavLogin); navBar.Controls.Add(btnGetStarted);

            // ==========================================
            // 2. LEFT PANEL (Branding & Stats)
            // ==========================================
            Panel leftPanel = new Panel() { Width = 500, Dock = DockStyle.Left, BackColor = Color.White };

            Label lblWelcome = new Label() { Text = "Welcome to\nEventKonnect", Font = new Font("Segoe UI", 32, FontStyle.Bold), Location = new Point(50, 150), AutoSize = true };
            Label lblSub = new Label() { Text = "Join thousands of event planners and vendors", Font = new Font("Segoe UI", 12), ForeColor = Color.Gray, Location = new Point(50, 240), AutoSize = true };

            Label lblBullet1 = new Label() { Text = "✓  Connect with top vendors instantly", Font = new Font("Segoe UI", 11), ForeColor = Color.DimGray, Location = new Point(50, 310), AutoSize = true };
            Label lblBullet2 = new Label() { Text = "✓  Plan events seamlessly from start to finish", Font = new Font("Segoe UI", 11), ForeColor = Color.DimGray, Location = new Point(50, 350), AutoSize = true };
            Label lblBullet3 = new Label() { Text = "✓  Secure payments with escrow protection", Font = new Font("Segoe UI", 11), ForeColor = Color.DimGray, Location = new Point(50, 390), AutoSize = true };

            Panel statsBox = new Panel() { Location = new Point(50, 460), Size = new Size(400, 80), BackColor = Color.FromArgb(248, 249, 250) };
            statsBox.Controls.Add(CreateStat("500+", "Verified Vendors", 20));
            statsBox.Controls.Add(CreateStat("1000+", "Events Planned", 150));
            statsBox.Controls.Add(CreateStat("98%", "Satisfaction", 280));

            leftPanel.Controls.Add(lblWelcome); leftPanel.Controls.Add(lblSub);
            leftPanel.Controls.Add(lblBullet1); leftPanel.Controls.Add(lblBullet2); leftPanel.Controls.Add(lblBullet3);
            leftPanel.Controls.Add(statsBox);

            // ==========================================
            // 3. RIGHT PANEL (The Form Cards)
            // ==========================================
            Panel rightPanel = new Panel() { Dock = DockStyle.Fill, BackColor = Color.FromArgb(244, 246, 249) };

            // --- LOGIN CARD ---
            loginPanel = new Panel() { Size = new Size(450, 380), BackColor = Color.White, Location = new Point(80, 80) };
            Label lblLoginTitle = new Label() { Text = "Login", Font = new Font("Segoe UI", 24, FontStyle.Bold), Width = 450, TextAlign = ContentAlignment.MiddleCenter, Location = new Point(0, 30) };

            txtLoginEmail = CreateTextBox("Email", new Point(50, 110));
            txtLoginPassword = CreateTextBox("Password", new Point(50, 180), true);

            Button btnLogin = new Button() { Text = "Login", Location = new Point(50, 260), Width = 350, Height = 45, BackColor = Color.FromArgb(61, 76, 155), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 12, FontStyle.Bold) };
            btnLogin.FlatAppearance.BorderSize = 0;

            lblSwitchToSignup = new Label() { Text = "Don't have an account? Sign Up", ForeColor = Color.FromArgb(61, 76, 155), Font = new Font("Segoe UI", 10, FontStyle.Underline), Width = 450, TextAlign = ContentAlignment.MiddleCenter, Location = new Point(0, 330), Cursor = Cursors.Hand };
            lblSwitchToSignup.Click += (s, e) => ShowSignup();

            loginPanel.Controls.Add(lblLoginTitle);
            loginPanel.Controls.Add(txtLoginEmail); loginPanel.Controls.Add(txtLoginPassword);
            loginPanel.Controls.Add(btnLogin); loginPanel.Controls.Add(lblSwitchToSignup);

            // --- SIGNUP CARD ---
            signupPanel = new Panel() { Size = new Size(450, 550), BackColor = Color.White, Location = new Point(80, 40), Visible = false };
            Label lblSignupTitle = new Label() { Text = "Create Account", Font = new Font("Segoe UI", 24, FontStyle.Bold), Width = 450, TextAlign = ContentAlignment.MiddleCenter, Location = new Point(0, 20) };

            cmbRole = new ComboBox() { Location = new Point(50, 80), Width = 350, Font = new Font("Segoe UI", 12), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbRole.Items.AddRange(new string[] { "Vendor", "Event Planner" });
            cmbRole.SelectedIndex = 0;

            txtSignName = CreateTextBox("Full Name", new Point(50, 130));
            txtSignEmail = CreateTextBox("Email", new Point(50, 190));
            txtSignPhone = CreateTextBox("Phone Number", new Point(50, 250));
            txtSignPassword = CreateTextBox("Password", new Point(50, 310), true);

            chkTerms = new CheckBox() { Text = "I agree to the Terms and Conditions", Font = new Font("Segoe UI", 9), Location = new Point(50, 360), Width = 350 };

            Button btnSignup = new Button() { Text = "Sign Up", Location = new Point(50, 400), Width = 350, Height = 45, BackColor = Color.FromArgb(61, 76, 155), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 12, FontStyle.Bold) };
            btnSignup.FlatAppearance.BorderSize = 0;

            lblSwitchToLogin = new Label() { Text = "Already have an account? Login", ForeColor = Color.FromArgb(61, 76, 155), Font = new Font("Segoe UI", 10, FontStyle.Underline), Width = 450, TextAlign = ContentAlignment.MiddleCenter, Location = new Point(0, 470), Cursor = Cursors.Hand };
            lblSwitchToLogin.Click += (s, e) => ShowLogin();

            signupPanel.Controls.Add(lblSignupTitle); signupPanel.Controls.Add(cmbRole);
            signupPanel.Controls.Add(txtSignName); signupPanel.Controls.Add(txtSignEmail); signupPanel.Controls.Add(txtSignPhone); signupPanel.Controls.Add(txtSignPassword);
            signupPanel.Controls.Add(chkTerms); signupPanel.Controls.Add(btnSignup); signupPanel.Controls.Add(lblSwitchToLogin);

            // Add both panels to the right side
            rightPanel.Controls.Add(loginPanel);
            rightPanel.Controls.Add(signupPanel);

            // Add everything to form
            this.Controls.Add(rightPanel);
            this.Controls.Add(leftPanel);
            this.Controls.Add(navBar);

            // ==========================================
            // 4. BUTTON LOGIC
            // ==========================================

            btnLogin.Click += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtLoginEmail.Text) || string.IsNullOrWhiteSpace(txtLoginPassword.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }
                string? role = db.LoginUser(txtLoginEmail.Text, txtLoginPassword.Text);
                if (role == "Vendor") { new VendorForm().Show(); this.Hide(); }
                else if (role == "Event Planner") { new PlannerForm().Show(); this.Hide(); }
                else { MessageBox.Show("Invalid email or password."); }
            };

            btnSignup.Click += (s, e) => {
                if (!chkTerms.Checked)
                {
                    MessageBox.Show("You must agree to the Terms and Conditions.");
                    return;
                }
                string selectedRole = cmbRole.SelectedItem?.ToString() ?? "Vendor";
                bool success = db.RegisterUser(txtSignName.Text, txtSignEmail.Text, txtSignPhone.Text, txtSignPassword.Text, selectedRole);
                if (success)
                {
                    MessageBox.Show("Account created! You can now login.");
                    ShowLogin();
                }
                else { MessageBox.Show("Error: Email might already be in use."); }
            };

            // Start with Login
            ShowLogin();
        }

        // ==========================================
        // UI SWITCH METHODS
        // ==========================================

        private void ShowLogin()
        {
            signupPanel.Visible = false;
            loginPanel.Visible = true;
        }

        private void ShowSignup()
        {
            loginPanel.Visible = false;
            signupPanel.Visible = true;
        }

        private Panel CreateStat(string value, string label, int x)
        {
            Panel p = new Panel() { Location = new Point(x, 15), Size = new Size(110, 50) };
            Label v = new Label() { Text = value, ForeColor = Color.FromArgb(255, 193, 7), Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(0, 0), AutoSize = true };
            Label l = new Label() { Text = label, ForeColor = Color.Gray, Font = new Font("Segoe UI", 8), Location = new Point(0, 25), AutoSize = true };
            p.Controls.Add(v); p.Controls.Add(l);
            return p;
        }

        private TextBox CreateTextBox(string placeholder, Point location, bool isPassword = false)
        {
            TextBox txt = new TextBox() { Location = location, Width = 350, Font = new Font("Segoe UI", 12), ForeColor = Color.Gray, Text = placeholder };

            if (isPassword)
            {
                txt.UseSystemPasswordChar = true;
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }

            txt.GotFocus += (s, e) => {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                    if (isPassword) txt.UseSystemPasswordChar = true;
                }
            };

            txt.LostFocus += (s, e) => {
                if (txt.Text == "")
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                    if (isPassword) txt.UseSystemPasswordChar = false;
                }
            };

            return txt;
        }
    }
}