namespace Lab3Assignment.Views
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rightPanel = new System.Windows.Forms.Panel();
            this.loginPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLoginTitle = new System.Windows.Forms.Label();
            this.lblLoginSubtitle = new System.Windows.Forms.Label();
            this.lblLoginEmail = new System.Windows.Forms.Label();
            this.txtLoginEmail = new System.Windows.Forms.TextBox();
            this.lblLoginPassword = new System.Windows.Forms.Label();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lnkSignup = new System.Windows.Forms.Label();
            this.signupPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSignupTitle = new System.Windows.Forms.Label();
            this.lblSignupSubtitle = new System.Windows.Forms.Label();
            this.lblSignRole = new System.Windows.Forms.Label();
            this.roleRow = new System.Windows.Forms.TableLayoutPanel();
            this.btnRoleVendor = new System.Windows.Forms.Button();
            this.btnRolePlanner = new System.Windows.Forms.Button();
            this.lblSignName = new System.Windows.Forms.Label();
            this.txtSignName = new System.Windows.Forms.TextBox();
            this.lblSignEmail = new System.Windows.Forms.Label();
            this.txtSignEmail = new System.Windows.Forms.TextBox();
            this.lblSignPhone = new System.Windows.Forms.Label();
            this.txtSignPhone = new System.Windows.Forms.TextBox();
            this.lblSignPassword = new System.Windows.Forms.Label();
            this.txtSignPassword = new System.Windows.Forms.TextBox();
            this.chkTerms = new System.Windows.Forms.CheckBox();
            this.btnSignup = new System.Windows.Forms.Button();
            this.lnkLogin = new System.Windows.Forms.Label();
            this.rightPanel.SuspendLayout();
            this.loginPanel.SuspendLayout();
            this.signupPanel.SuspendLayout();
            this.roleRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightPanel
            // 
            this.rightPanel.AutoScroll = true;
            this.rightPanel.BackColor = System.Drawing.Color.FromArgb(240, 247, 247);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Size = new System.Drawing.Size(624, 781);
            // 
            // loginPanel
            // 
            this.loginPanel.AutoSize = true;
            this.loginPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loginPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.loginPanel.WrapContents = false;
            this.loginPanel.BackColor = System.Drawing.Color.White;
            this.loginPanel.Location = new System.Drawing.Point(92, 30);
            this.loginPanel.MinimumSize = new System.Drawing.Size(460, 0);
            this.loginPanel.Padding = new System.Windows.Forms.Padding(40, 32, 40, 32);
            this.loginPanel.Visible = true;
            // 
            // lblLoginTitle
            // 
            this.lblLoginTitle.AutoSize = true;
            this.lblLoginTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLoginTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.lblLoginTitle.Text = "Welcome back";
            // 
            // lblLoginSubtitle
            // 
            this.lblLoginSubtitle.AutoSize = true;
            this.lblLoginSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLoginSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblLoginSubtitle.Margin = new System.Windows.Forms.Padding(2, 0, 0, 20);
            this.lblLoginSubtitle.Text = "Sign in to your account to continue";
            // 
            // lblLoginEmail
            // 
            this.lblLoginEmail.AutoSize = true;
            this.lblLoginEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLoginEmail.ForeColor = System.Drawing.Color.DimGray;
            this.lblLoginEmail.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblLoginEmail.Text = "Email address";
            // 
            // txtLoginEmail
            // 
            this.txtLoginEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoginEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLoginEmail.Margin = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.txtLoginEmail.PlaceholderText = "you@example.com";
            this.txtLoginEmail.Size = new System.Drawing.Size(380, 31);
            // 
            // lblLoginPassword
            // 
            this.lblLoginPassword.AutoSize = true;
            this.lblLoginPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLoginPassword.ForeColor = System.Drawing.Color.DimGray;
            this.lblLoginPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblLoginPassword.Text = "Password";
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoginPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLoginPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.txtLoginPassword.PlaceholderText = "Enter your password";
            this.txtLoginPassword.Size = new System.Drawing.Size(380, 31);
            this.txtLoginPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnLogin.Size = new System.Drawing.Size(380, 46);
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 112, 112);
            // 
            // lnkSignup
            // 
            this.lnkSignup.AutoSize = false;
            this.lnkSignup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkSignup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lnkSignup.ForeColor = System.Drawing.Color.FromArgb(0, 128, 128);
            this.lnkSignup.Margin = new System.Windows.Forms.Padding(0, 14, 0, 0);
            this.lnkSignup.Size = new System.Drawing.Size(380, 28);
            this.lnkSignup.Text = "Don't have an account? Sign up";
            this.lnkSignup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signupPanel
            // 
            this.signupPanel.AutoSize = true;
            this.signupPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.signupPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.signupPanel.WrapContents = false;
            this.signupPanel.BackColor = System.Drawing.Color.White;
            this.signupPanel.Location = new System.Drawing.Point(92, 520);
            this.signupPanel.MinimumSize = new System.Drawing.Size(460, 0);
            this.signupPanel.Padding = new System.Windows.Forms.Padding(40, 32, 40, 32);
            this.signupPanel.Visible = false;
            // 
            // lblSignupTitle
            // 
            this.lblSignupTitle.AutoSize = true;
            this.lblSignupTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSignupTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.lblSignupTitle.Text = "Create your account";
            // 
            // lblSignupSubtitle
            // 
            this.lblSignupSubtitle.AutoSize = true;
            this.lblSignupSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSignupSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSignupSubtitle.Margin = new System.Windows.Forms.Padding(2, 0, 0, 20);
            this.lblSignupSubtitle.Text = "Join EventKonnect in less than a minute";
            // 
            // lblSignRole
            // 
            this.lblSignRole.AutoSize = true;
            this.lblSignRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSignRole.ForeColor = System.Drawing.Color.DimGray;
            this.lblSignRole.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblSignRole.Text = "I am a";
            // 
            // roleRow
            // 
            this.roleRow.ColumnCount = 2;
            this.roleRow.RowCount = 1;
            this.roleRow.Margin = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.roleRow.Size = new System.Drawing.Size(380, 42);
            this.roleRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.roleRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.roleRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            // 
            // btnRoleVendor
            // 
            this.btnRoleVendor.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.btnRoleVendor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoleVendor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRoleVendor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoleVendor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRoleVendor.ForeColor = System.Drawing.Color.White;
            this.btnRoleVendor.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.btnRoleVendor.Size = new System.Drawing.Size(186, 42);
            this.btnRoleVendor.Text = "Vendor";
            this.btnRoleVendor.UseVisualStyleBackColor = false;
            this.btnRoleVendor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.btnRoleVendor.FlatAppearance.BorderSize = 1;
            // 
            // btnRolePlanner
            // 
            this.btnRolePlanner.BackColor = System.Drawing.Color.White;
            this.btnRolePlanner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRolePlanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRolePlanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRolePlanner.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRolePlanner.ForeColor = System.Drawing.Color.DimGray;
            this.btnRolePlanner.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnRolePlanner.Size = new System.Drawing.Size(186, 42);
            this.btnRolePlanner.Text = "Event Planner";
            this.btnRolePlanner.UseVisualStyleBackColor = false;
            this.btnRolePlanner.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(207, 226, 226);
            this.btnRolePlanner.FlatAppearance.BorderSize = 1;
            // 
            // lblSignName
            // 
            this.lblSignName.AutoSize = true;
            this.lblSignName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSignName.ForeColor = System.Drawing.Color.DimGray;
            this.lblSignName.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblSignName.Text = "Full name";
            // 
            // txtSignName
            // 
            this.txtSignName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSignName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSignName.Margin = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.txtSignName.PlaceholderText = "e.g. Kundwa Divine";
            this.txtSignName.Size = new System.Drawing.Size(380, 31);
            // 
            // lblSignEmail
            // 
            this.lblSignEmail.AutoSize = true;
            this.lblSignEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSignEmail.ForeColor = System.Drawing.Color.DimGray;
            this.lblSignEmail.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblSignEmail.Text = "Email address";
            // 
            // txtSignEmail
            // 
            this.txtSignEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSignEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSignEmail.Margin = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.txtSignEmail.PlaceholderText = "you@example.com";
            this.txtSignEmail.Size = new System.Drawing.Size(380, 31);
            // 
            // lblSignPhone
            // 
            this.lblSignPhone.AutoSize = true;
            this.lblSignPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSignPhone.ForeColor = System.Drawing.Color.DimGray;
            this.lblSignPhone.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblSignPhone.Text = "Phone number";
            // 
            // txtSignPhone
            // 
            this.txtSignPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSignPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSignPhone.Margin = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.txtSignPhone.PlaceholderText = "e.g. 0788 123 456";
            this.txtSignPhone.Size = new System.Drawing.Size(380, 31);
            // 
            // lblSignPassword
            // 
            this.lblSignPassword.AutoSize = true;
            this.lblSignPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSignPassword.ForeColor = System.Drawing.Color.DimGray;
            this.lblSignPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblSignPassword.Text = "Password";
            // 
            // txtSignPassword
            // 
            this.txtSignPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSignPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSignPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.txtSignPassword.PlaceholderText = "Create a password";
            this.txtSignPassword.Size = new System.Drawing.Size(380, 31);
            this.txtSignPassword.UseSystemPasswordChar = true;
            // 
            // chkTerms
            // 
            this.chkTerms.AutoSize = true;
            this.chkTerms.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkTerms.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.chkTerms.Text = "I agree to the Terms and Conditions";
            this.chkTerms.UseVisualStyleBackColor = true;
            // 
            // btnSignup
            // 
            this.btnSignup.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.btnSignup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSignup.ForeColor = System.Drawing.Color.White;
            this.btnSignup.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnSignup.Size = new System.Drawing.Size(380, 46);
            this.btnSignup.Text = "Create Account";
            this.btnSignup.UseVisualStyleBackColor = false;
            this.btnSignup.FlatAppearance.BorderSize = 0;
            this.btnSignup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 112, 112);
            // 
            // lnkLogin
            // 
            this.lnkLogin.AutoSize = false;
            this.lnkLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lnkLogin.ForeColor = System.Drawing.Color.FromArgb(0, 128, 128);
            this.lnkLogin.Margin = new System.Windows.Forms.Padding(0, 14, 0, 0);
            this.lnkLogin.Size = new System.Drawing.Size(380, 28);
            this.lnkLogin.Text = "Already have an account? Login";
            this.lnkLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hierarchy
            // 
            this.rightPanel.Controls.Add(this.loginPanel);
            this.rightPanel.Controls.Add(this.signupPanel);
            this.loginPanel.Controls.Add(this.lblLoginTitle);
            this.loginPanel.Controls.Add(this.lblLoginSubtitle);
            this.loginPanel.Controls.Add(this.lblLoginEmail);
            this.loginPanel.Controls.Add(this.txtLoginEmail);
            this.loginPanel.Controls.Add(this.lblLoginPassword);
            this.loginPanel.Controls.Add(this.txtLoginPassword);
            this.loginPanel.Controls.Add(this.btnLogin);
            this.loginPanel.Controls.Add(this.lnkSignup);
            this.signupPanel.Controls.Add(this.lblSignupTitle);
            this.signupPanel.Controls.Add(this.lblSignupSubtitle);
            this.signupPanel.Controls.Add(this.lblSignRole);
            this.signupPanel.Controls.Add(this.roleRow);
            this.signupPanel.Controls.Add(this.lblSignName);
            this.signupPanel.Controls.Add(this.txtSignName);
            this.signupPanel.Controls.Add(this.lblSignEmail);
            this.signupPanel.Controls.Add(this.txtSignEmail);
            this.signupPanel.Controls.Add(this.lblSignPhone);
            this.signupPanel.Controls.Add(this.txtSignPhone);
            this.signupPanel.Controls.Add(this.lblSignPassword);
            this.signupPanel.Controls.Add(this.txtSignPassword);
            this.signupPanel.Controls.Add(this.chkTerms);
            this.signupPanel.Controls.Add(this.btnSignup);
            this.signupPanel.Controls.Add(this.lnkLogin);
            this.roleRow.Controls.Add(this.btnRoleVendor, 0, 0);
            this.roleRow.Controls.Add(this.btnRolePlanner, 1, 0);
            // 
            // LoginForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(240, 247, 247);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(560, 600);
            this.Size = new System.Drawing.Size(640, 820);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EventKonnect";
            this.Controls.Add(this.rightPanel);
            this.Name = "LoginForm";
            this.rightPanel.Resize += new System.EventHandler(this.rightPanel_Resize);
            this.loginPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.loginPanel.SizeChanged += new System.EventHandler(this.Card_SizeChanged);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.lnkSignup.Click += new System.EventHandler(this.lnkSignup_Click);
            this.signupPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.signupPanel.SizeChanged += new System.EventHandler(this.Card_SizeChanged);
            this.btnRoleVendor.Click += new System.EventHandler(this.btnRoleVendor_Click);
            this.btnRolePlanner.Click += new System.EventHandler(this.btnRolePlanner_Click);
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            this.lnkLogin.Click += new System.EventHandler(this.lnkLogin_Click);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.signupPanel.ResumeLayout(false);
            this.signupPanel.PerformLayout();
            this.roleRow.ResumeLayout(false);
            this.roleRow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.FlowLayoutPanel loginPanel;
        private System.Windows.Forms.Label lblLoginTitle;
        private System.Windows.Forms.Label lblLoginSubtitle;
        private System.Windows.Forms.Label lblLoginEmail;
        private System.Windows.Forms.TextBox txtLoginEmail;
        private System.Windows.Forms.Label lblLoginPassword;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lnkSignup;
        private System.Windows.Forms.FlowLayoutPanel signupPanel;
        private System.Windows.Forms.Label lblSignupTitle;
        private System.Windows.Forms.Label lblSignupSubtitle;
        private System.Windows.Forms.Label lblSignRole;
        private System.Windows.Forms.TableLayoutPanel roleRow;
        private System.Windows.Forms.Button btnRoleVendor;
        private System.Windows.Forms.Button btnRolePlanner;
        private System.Windows.Forms.Label lblSignName;
        private System.Windows.Forms.TextBox txtSignName;
        private System.Windows.Forms.Label lblSignEmail;
        private System.Windows.Forms.TextBox txtSignEmail;
        private System.Windows.Forms.Label lblSignPhone;
        private System.Windows.Forms.TextBox txtSignPhone;
        private System.Windows.Forms.Label lblSignPassword;
        private System.Windows.Forms.TextBox txtSignPassword;
        private System.Windows.Forms.CheckBox chkTerms;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.Label lnkLogin;
    }
}
