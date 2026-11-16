using System;
using System.Drawing;
using System.Windows.Forms;
using Lab3Assignment.Controllers;

namespace Lab3Assignment.Views
{
    public class LoginForm : Form
    {
        DatabaseController db = new DatabaseController();

        static readonly Color Indigo = Color.FromArgb(61, 76, 155);
        static readonly Color IndigoDark = Color.FromArgb(48, 60, 128);
        static readonly Color Amber = Color.FromArgb(255, 193, 7);
        static readonly Color PageGray = Color.FromArgb(244, 246, 249);
        static readonly Color BorderGray = Color.FromArgb(222, 226, 234);
        static readonly Color SoftWhite = Color.FromArgb(205, 212, 240);

        const int FieldWidth = 380;   // width of inputs and buttons inside the cards

        Panel rightPanel;
        FlowLayoutPanel loginPanel, signupPanel;

        // Login inputs
        TextBox txtLoginEmail, txtLoginPassword;
        Button btnLogin;

        // Signup inputs
        TextBox txtSignName, txtSignEmail, txtSignPhone, txtSignPassword;
        Button btnRoleVendor, btnRolePlanner, btnSignup;
        CheckBox chkTerms;
        string selectedRole = "Vendor";

        public LoginForm()
        {
            this.Text = "EventKonnect";
            this.Size = new Size(1100, 780);
            this.MinimumSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = PageGray;
            this.Font = new Font("Segoe UI", 10);

            // Closing the login window closes the whole app
            this.FormClosed += (s, e) => Application.Exit();

            // IMPORTANT: the Fill panel must be added BEFORE the Left panel,
            // otherwise it is drawn on top of it.
            BuildRightPanel();
            BuildLeftPanel();

            ShowLogin();
        }

        // ==========================================
        // LEFT: BRANDING (flows top to bottom, so it adapts to text size)
        // ==========================================
        private void BuildLeftPanel()
        {
            Panel leftPanel = new Panel() { Dock = DockStyle.Left, Width = 480, BackColor = Indigo };

            FlowLayoutPanel content = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(48, 48, 24, 24),
                BackColor = Indigo
            };

            content.Controls.Add(new Label() { Text = "EventKonnect", ForeColor = Color.White, Font = new Font("Segoe UI", 20, FontStyle.Bold), AutoSize = true, Margin = new Padding(0) });
            content.Controls.Add(new Panel() { Size = new Size(48, 4), BackColor = Amber, Margin = new Padding(4, 8, 0, 0) });

            content.Controls.Add(new Label()
            {
                Text = "Plan events." + Environment.NewLine + "Find vendors." + Environment.NewLine + "Get it done.",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 26, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(0, 50, 0, 0)
            });

            content.Controls.Add(new Label()
            {
                Text = "One place for planners and vendors to connect.",
                ForeColor = SoftWhite,
                Font = new Font("Segoe UI", 11),
                AutoSize = true,
                MaximumSize = new Size(400, 0),     // wraps instead of being cut off
                Margin = new Padding(3, 14, 0, 30)
            });

            content.Controls.Add(Bullet("Connect with top vendors instantly"));
            content.Controls.Add(Bullet("Plan events from start to finish"));
            content.Controls.Add(Bullet("Secure escrow payments"));

            // Stats strip at the bottom
            TableLayoutPanel stats = new TableLayoutPanel()
            {
                Dock = DockStyle.Bottom,
                AutoSize = true,
                ColumnCount = 3,
                RowCount = 1,
                BackColor = IndigoDark,
                Padding = new Padding(48, 22, 16, 22)
            };
            for (int i = 0; i < 3; i++) stats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            stats.Controls.Add(Stat("500+", "Verified vendors"), 0, 0);
            stats.Controls.Add(Stat("1000+", "Events planned"), 1, 0);
            stats.Controls.Add(Stat("98%", "Satisfaction"), 2, 0);

            // Fill first, then the bottom strip
            leftPanel.Controls.Add(content);
            leftPanel.Controls.Add(stats);

            this.Controls.Add(leftPanel);
        }

        private Label Bullet(string text)
        {
            return new Label()
            {
                Text = "✓   " + text,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11),
                AutoSize = true,
                MaximumSize = new Size(400, 0),
                Margin = new Padding(3, 0, 0, 12)
            };
        }

        private Control Stat(string value, string label)
        {
            FlowLayoutPanel p = new FlowLayoutPanel() { FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoSize = true, Margin = new Padding(0), BackColor = IndigoDark };
            p.Controls.Add(new Label() { Text = value, ForeColor = Amber, Font = new Font("Segoe UI", 18, FontStyle.Bold), AutoSize = true, Margin = new Padding(0) });
            p.Controls.Add(new Label() { Text = label, ForeColor = SoftWhite, Font = new Font("Segoe UI", 9), AutoSize = true, Margin = new Padding(2, 0, 0, 0) });
            return p;
        }

        // ==========================================
        // RIGHT: LOGIN / SIGNUP CARDS
        // ==========================================
        private void BuildRightPanel()
        {
            rightPanel = new Panel() { Dock = DockStyle.Fill, BackColor = PageGray, AutoScroll = true };

            // ---------- LOGIN CARD ----------
            loginPanel = CreateCard();
            loginPanel.Controls.Add(CardTitle("Welcome back"));
            loginPanel.Controls.Add(CardSubtitle("Sign in to your account to continue"));

            loginPanel.Controls.Add(FieldLabel("Email address"));
            txtLoginEmail = CreateTextBox(" you@example.com ");
            loginPanel.Controls.Add(txtLoginEmail);

            loginPanel.Controls.Add(FieldLabel("Password"));
            txtLoginPassword = CreateTextBox("Enter your password", true);
            loginPanel.Controls.Add(txtLoginPassword);

            btnLogin = CreatePrimaryButton("Login");
            btnLogin.Click += (s, e) => HandleLogin();
            loginPanel.Controls.Add(btnLogin);

            loginPanel.Controls.Add(CreateLink("Don't have an account? Sign up", ShowSignup));

            // ---------- SIGNUP CARD ----------
            signupPanel = CreateCard();
            signupPanel.Controls.Add(CardTitle("Create your account"));
            signupPanel.Controls.Add(CardSubtitle("Join EventKonnect in less than a minute"));

            signupPanel.Controls.Add(FieldLabel("I am a"));
            signupPanel.Controls.Add(CreateRoleRow());

            signupPanel.Controls.Add(FieldLabel("Full name"));
            txtSignName = CreateTextBox(" Kundwa Divine");
            signupPanel.Controls.Add(txtSignName);

            signupPanel.Controls.Add(FieldLabel("Email address"));
            txtSignEmail = CreateTextBox("you@example.com");
            signupPanel.Controls.Add(txtSignEmail);

            signupPanel.Controls.Add(FieldLabel("Phone number"));
            txtSignPhone = CreateTextBox(" ");
            signupPanel.Controls.Add(txtSignPhone);

            signupPanel.Controls.Add(FieldLabel("Password"));
            txtSignPassword = CreateTextBox("Create a password", true);
            signupPanel.Controls.Add(txtSignPassword);

            chkTerms = new CheckBox() { Text = "I agree to the Terms and Conditions", Font = new Font("Segoe UI", 9), AutoSize = true, Margin = new Padding(0, 0, 0, 6) };
            signupPanel.Controls.Add(chkTerms);

            btnSignup = CreatePrimaryButton("Create Account");
            btnSignup.Click += (s, e) => HandleSignup();
            signupPanel.Controls.Add(btnSignup);

            signupPanel.Controls.Add(CreateLink("Already have an account? Login", ShowLogin));

            rightPanel.Controls.Add(loginPanel);
            rightPanel.Controls.Add(signupPanel);
            this.Controls.Add(rightPanel);

            // Keep the cards centred when the window or card size changes
            rightPanel.Resize += (s, e) => CenterCards();
            loginPanel.SizeChanged += (s, e) => CenterCards();
            signupPanel.SizeChanged += (s, e) => CenterCards();

            SetRole("Vendor");
            CenterCards();
        }

        private void CenterCards()
        {
            foreach (Panel card in new Panel[] { loginPanel, signupPanel })
            {
                int x = Math.Max(10, (rightPanel.ClientSize.Width - card.Width) / 2);
                int y = Math.Max(10, (rightPanel.ClientSize.Height - card.Height) / 2);
                card.Location = new Point(x, y);
            }
        }

        // ==========================================
        // ACTIONS
        // ==========================================
        private void HandleLogin()
        {
            string email = txtLoginEmail.Text.Trim();
            string password = txtLoginPassword.Text;

            if (email == "" || password == "")
            {
                MessageBox.Show("Please fill in all fields.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string? role;
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
            this.AcceptButton = btnLogin;   // Enter key submits
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

        // ==========================================
        // UI HELPERS
        // ==========================================
        private FlowLayoutPanel CreateCard()
        {
            FlowLayoutPanel card = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                MinimumSize = new Size(FieldWidth + 80, 0),
                Padding = new Padding(40, 32, 40, 32),
                BackColor = Color.White
            };
            card.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(BorderGray))
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
            };
            return card;
        }

        private Label CardTitle(string text)
        {
            return new Label() { Text = text, Font = new Font("Segoe UI", 18, FontStyle.Bold), AutoSize = true, Margin = new Padding(0, 0, 0, 2) };
        }

        private Label CardSubtitle(string text)
        {
            return new Label() { Text = text, Font = new Font("Segoe UI", 10), ForeColor = Color.Gray, AutoSize = true, Margin = new Padding(2, 0, 0, 20) };
        }

        private Label FieldLabel(string text)
        {
            return new Label() { Text = text, Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.DimGray, AutoSize = true, Margin = new Padding(0, 0, 0, 4) };
        }

        private TextBox CreateTextBox(string placeholder, bool isPassword = false)
        {
            return new TextBox()
            {
                Width = FieldWidth,
                Font = new Font("Segoe UI", 12),
                BorderStyle = BorderStyle.FixedSingle,
                PlaceholderText = placeholder,
                UseSystemPasswordChar = isPassword,
                Margin = new Padding(0, 0, 0, 14)
            };
        }

        private Button CreatePrimaryButton(string text)
        {
            Button btn = new Button() { Text = text, Width = FieldWidth, Height = 46, BackColor = Indigo, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 12, FontStyle.Bold), Cursor = Cursors.Hand, Margin = new Padding(0, 10, 0, 0) };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 100, 180);
            return btn;
        }

        // Two side-by-side buttons that act like a toggle
        private Control CreateRoleRow()
        {
            TableLayoutPanel row = new TableLayoutPanel() { Width = FieldWidth, Height = 42, ColumnCount = 2, RowCount = 1, Margin = new Padding(0, 0, 0, 14) };
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            btnRoleVendor = CreateRoleButton("Vendor", new Padding(0, 0, 4, 0));
            btnRolePlanner = CreateRoleButton("Event Planner", new Padding(4, 0, 0, 0));
            btnRoleVendor.Click += (s, e) => SetRole("Vendor");
            btnRolePlanner.Click += (s, e) => SetRole("Event Planner");

            row.Controls.Add(btnRoleVendor, 0, 0);
            row.Controls.Add(btnRolePlanner, 1, 0);
            return row;
        }

        private Button CreateRoleButton(string text, Padding margin)
        {
            Button btn = new Button() { Text = text, Dock = DockStyle.Fill, Margin = margin, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold), Cursor = Cursors.Hand };
            btn.FlatAppearance.BorderSize = 1;
            return btn;
        }

        private Label CreateLink(string text, Action onClick)
        {
            Label link = new Label() { Text = text, ForeColor = Indigo, Font = new Font("Segoe UI", 10, FontStyle.Underline), AutoSize = false, Width = FieldWidth, Height = 28, TextAlign = ContentAlignment.MiddleCenter, Cursor = Cursors.Hand, Margin = new Padding(0, 14, 0, 0) };
            link.Click += (s, e) => onClick();
            return link;
        }
    }
}