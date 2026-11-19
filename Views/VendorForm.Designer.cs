namespace Lab3Assignment.Views
{
    partial class VendorForm
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
            this.mainContainer = new System.Windows.Forms.Panel();
            this.profileView = new System.Windows.Forms.Panel();
            this.page = new System.Windows.Forms.FlowLayoutPanel();
            this.hero = new System.Windows.Forms.FlowLayoutPanel();
            this.avatar = new System.Windows.Forms.Panel();
            this.heroText = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblPill = new System.Windows.Forms.Label();
            this.statsRow = new System.Windows.Forms.FlowLayoutPanel();
            this.cardStatTotal = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStatTotal = new System.Windows.Forms.Label();
            this.lblStatTotalCaption = new System.Windows.Forms.Label();
            this.cardStatPending = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStatPending = new System.Windows.Forms.Label();
            this.lblStatPendingCaption = new System.Windows.Forms.Label();
            this.cardStatAccepted = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStatAccepted = new System.Windows.Forms.Label();
            this.lblStatAcceptedCaption = new System.Windows.Forms.Label();
            this.details = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.lblDetailsHint = new System.Windows.Forms.Label();
            this.row1 = new System.Windows.Forms.FlowLayoutPanel();
            this.stackName = new System.Windows.Forms.FlowLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.stackService = new System.Windows.Forms.FlowLayoutPanel();
            this.lblService = new System.Windows.Forms.Label();
            this.txtService = new System.Windows.Forms.TextBox();
            this.row2 = new System.Windows.Forms.FlowLayoutPanel();
            this.stackPriceMin = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPriceMin = new System.Windows.Forms.Label();
            this.txtPriceMin = new System.Windows.Forms.TextBox();
            this.stackPriceMax = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPriceMax = new System.Windows.Forms.Label();
            this.txtPriceMax = new System.Windows.Forms.TextBox();
            this.row3 = new System.Windows.Forms.FlowLayoutPanel();
            this.stackLocation = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnRow = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEditSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bookingsView = new System.Windows.Forms.Panel();
            this.bkRoot = new System.Windows.Forms.TableLayoutPanel();
            this.bkListCard = new System.Windows.Forms.Panel();
            this.gridBookings = new System.Windows.Forms.DataGridView();
            this.lblBookingsTitle = new System.Windows.Forms.Label();
            this.bkDetailCard = new System.Windows.Forms.Panel();
            this.bkDetail = new System.Windows.Forms.TableLayoutPanel();
            this.lblBkEvent = new System.Windows.Forms.Label();
            this.lblBkInfo = new System.Windows.Forms.Label();
            this.lblBkStatus = new System.Windows.Forms.Label();
            this.lblBkMsgCaption = new System.Windows.Forms.Label();
            this.txtBkMessage = new System.Windows.Forms.TextBox();
            this.lblBkRespCaption = new System.Windows.Forms.Label();
            this.txtBkResponse = new System.Windows.Forms.TextBox();
            this.actions = new System.Windows.Forms.TableLayoutPanel();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.headerLine = new System.Windows.Forms.Panel();
            this.sidebar = new System.Windows.Forms.Panel();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnBookings = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridBookings)).BeginInit();
            this.mainContainer.SuspendLayout();
            this.profileView.SuspendLayout();
            this.page.SuspendLayout();
            this.hero.SuspendLayout();
            this.avatar.SuspendLayout();
            this.heroText.SuspendLayout();
            this.statsRow.SuspendLayout();
            this.cardStatTotal.SuspendLayout();
            this.cardStatPending.SuspendLayout();
            this.cardStatAccepted.SuspendLayout();
            this.details.SuspendLayout();
            this.row1.SuspendLayout();
            this.stackName.SuspendLayout();
            this.stackService.SuspendLayout();
            this.row2.SuspendLayout();
            this.stackPriceMin.SuspendLayout();
            this.stackPriceMax.SuspendLayout();
            this.row3.SuspendLayout();
            this.stackLocation.SuspendLayout();
            this.btnRow.SuspendLayout();
            this.bookingsView.SuspendLayout();
            this.bkRoot.SuspendLayout();
            this.bkListCard.SuspendLayout();
            this.bkDetailCard.SuspendLayout();
            this.bkDetail.SuspendLayout();
            this.actions.SuspendLayout();
            this.header.SuspendLayout();
            this.headerLine.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.BackColor = System.Drawing.Color.FromArgb(240, 247, 247);
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Padding = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.mainContainer.Size = new System.Drawing.Size(950, 684);
            // 
            // profileView
            // 
            this.profileView.AutoScroll = true;
            this.profileView.BackColor = System.Drawing.Color.Transparent;
            this.profileView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profileView.Size = new System.Drawing.Size(900, 600);
            this.profileView.Visible = false;
            // 
            // page
            // 
            this.page.AutoSize = true;
            this.page.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.page.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.page.WrapContents = false;
            this.page.BackColor = System.Drawing.Color.Transparent;
            this.page.Location = new System.Drawing.Point(0, 0);
            this.page.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // 
            // hero
            // 
            this.hero.AutoSize = true;
            this.hero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hero.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.hero.WrapContents = false;
            this.hero.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.hero.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.hero.MinimumSize = new System.Drawing.Size(760, 0);
            this.hero.Padding = new System.Windows.Forms.Padding(28, 28, 28, 28);
            // 
            // avatar
            // 
            this.avatar.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.avatar.Margin = new System.Windows.Forms.Padding(0, 0, 22, 0);
            this.avatar.Size = new System.Drawing.Size(76, 76);
            // 
            // heroText
            // 
            this.heroText.AutoSize = true;
            this.heroText.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.heroText.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.heroText.WrapContents = false;
            this.heroText.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.heroText.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.MaximumSize = new System.Drawing.Size(560, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.lblTitle.Text = "Business Profile";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(170, 230, 230);
            this.lblSubTitle.MaximumSize = new System.Drawing.Size(560, 0);
            this.lblSubTitle.Margin = new System.Windows.Forms.Padding(2, 2, 0, 10);
            this.lblSubTitle.Text = "Catering  •  Kigali  •  50,000 – 150,000 RWF";
            // 
            // lblPill
            // 
            this.lblPill.AutoSize = true;
            this.lblPill.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPill.ForeColor = System.Drawing.Color.White;
            this.lblPill.MaximumSize = new System.Drawing.Size(560, 0);
            this.lblPill.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.lblPill.Text = "●  Profile live";
            this.lblPill.BackColor = System.Drawing.Color.FromArgb(40, 160, 90);
            this.lblPill.Padding = new System.Windows.Forms.Padding(12, 4, 12, 4);
            // 
            // statsRow
            // 
            this.statsRow.AutoSize = true;
            this.statsRow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.statsRow.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.statsRow.WrapContents = false;
            this.statsRow.BackColor = System.Drawing.Color.Transparent;
            this.statsRow.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.statsRow.MinimumSize = new System.Drawing.Size(760, 0);
            this.statsRow.Visible = false;
            // 
            // cardStatTotal
            // 
            this.cardStatTotal.AutoSize = true;
            this.cardStatTotal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cardStatTotal.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cardStatTotal.WrapContents = false;
            this.cardStatTotal.BackColor = System.Drawing.Color.White;
            this.cardStatTotal.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.cardStatTotal.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.cardStatTotal.MinimumSize = new System.Drawing.Size(245, 0);
            // 
            // lblStatTotal
            // 
            this.lblStatTotal.AutoSize = true;
            this.lblStatTotal.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatTotal.ForeColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.lblStatTotal.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.lblStatTotal.Text = "0";
            // 
            // lblStatTotalCaption
            // 
            this.lblStatTotalCaption.AutoSize = true;
            this.lblStatTotalCaption.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatTotalCaption.ForeColor = System.Drawing.Color.Gray;
            this.lblStatTotalCaption.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblStatTotalCaption.Text = "Total requests";
            // 
            // cardStatPending
            // 
            this.cardStatPending.AutoSize = true;
            this.cardStatPending.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cardStatPending.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cardStatPending.WrapContents = false;
            this.cardStatPending.BackColor = System.Drawing.Color.White;
            this.cardStatPending.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.cardStatPending.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.cardStatPending.MinimumSize = new System.Drawing.Size(245, 0);
            // 
            // lblStatPending
            // 
            this.lblStatPending.AutoSize = true;
            this.lblStatPending.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatPending.ForeColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.lblStatPending.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.lblStatPending.Text = "0";
            // 
            // lblStatPendingCaption
            // 
            this.lblStatPendingCaption.AutoSize = true;
            this.lblStatPendingCaption.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatPendingCaption.ForeColor = System.Drawing.Color.Gray;
            this.lblStatPendingCaption.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblStatPendingCaption.Text = "Pending";
            // 
            // cardStatAccepted
            // 
            this.cardStatAccepted.AutoSize = true;
            this.cardStatAccepted.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cardStatAccepted.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cardStatAccepted.WrapContents = false;
            this.cardStatAccepted.BackColor = System.Drawing.Color.White;
            this.cardStatAccepted.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.cardStatAccepted.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.cardStatAccepted.MinimumSize = new System.Drawing.Size(246, 0);
            // 
            // lblStatAccepted
            // 
            this.lblStatAccepted.AutoSize = true;
            this.lblStatAccepted.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatAccepted.ForeColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.lblStatAccepted.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.lblStatAccepted.Text = "0";
            // 
            // lblStatAcceptedCaption
            // 
            this.lblStatAcceptedCaption.AutoSize = true;
            this.lblStatAcceptedCaption.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatAcceptedCaption.ForeColor = System.Drawing.Color.Gray;
            this.lblStatAcceptedCaption.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblStatAcceptedCaption.Text = "Accepted";
            // 
            // details
            // 
            this.details.AutoSize = true;
            this.details.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.details.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.details.WrapContents = false;
            this.details.BackColor = System.Drawing.Color.White;
            this.details.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.details.MinimumSize = new System.Drawing.Size(760, 0);
            this.details.Padding = new System.Windows.Forms.Padding(28, 28, 28, 28);
            // 
            // lblDetailsTitle
            // 
            this.lblDetailsTitle.AutoSize = true;
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.lblDetailsTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.lblDetailsTitle.Text = "Business Details";
            // 
            // lblDetailsHint
            // 
            this.lblDetailsHint.AutoSize = true;
            this.lblDetailsHint.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDetailsHint.ForeColor = System.Drawing.Color.Gray;
            this.lblDetailsHint.MaximumSize = new System.Drawing.Size(704, 0);
            this.lblDetailsHint.Margin = new System.Windows.Forms.Padding(2, 0, 0, 20);
            this.lblDetailsHint.Text = "These details are shown to event planners.";
            // 
            // row1
            // 
            this.row1.AutoSize = true;
            this.row1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.row1.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.row1.WrapContents = false;
            this.row1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // 
            // stackName
            // 
            this.stackName.AutoSize = true;
            this.stackName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stackName.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.stackName.WrapContents = false;
            this.stackName.Margin = new System.Windows.Forms.Padding(0, 0, 12, 16);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.ForeColor = System.Drawing.Color.DimGray;
            this.lblName.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.lblName.Text = "Business Name";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.txtName.PlaceholderText = "e.g. Kigali Sounds Ltd";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(346, 31);
            // 
            // stackService
            // 
            this.stackService.AutoSize = true;
            this.stackService.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stackService.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.stackService.WrapContents = false;
            this.stackService.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblService.ForeColor = System.Drawing.Color.DimGray;
            this.lblService.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.lblService.Text = "Service Type";
            // 
            // txtService
            // 
            this.txtService.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtService.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtService.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtService.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.txtService.PlaceholderText = "e.g. Catering, DJ, Photography";
            this.txtService.ReadOnly = true;
            this.txtService.Size = new System.Drawing.Size(346, 31);
            // 
            // row2
            // 
            this.row2.AutoSize = true;
            this.row2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.row2.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.row2.WrapContents = false;
            this.row2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // 
            // stackPriceMin
            // 
            this.stackPriceMin.AutoSize = true;
            this.stackPriceMin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stackPriceMin.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.stackPriceMin.WrapContents = false;
            this.stackPriceMin.Margin = new System.Windows.Forms.Padding(0, 0, 12, 16);
            // 
            // lblPriceMin
            // 
            this.lblPriceMin.AutoSize = true;
            this.lblPriceMin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPriceMin.ForeColor = System.Drawing.Color.DimGray;
            this.lblPriceMin.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.lblPriceMin.Text = "Minimum Price (RWF)";
            // 
            // txtPriceMin
            // 
            this.txtPriceMin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPriceMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPriceMin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPriceMin.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.txtPriceMin.PlaceholderText = "e.g. 50000";
            this.txtPriceMin.ReadOnly = true;
            this.txtPriceMin.Size = new System.Drawing.Size(346, 31);
            // 
            // stackPriceMax
            // 
            this.stackPriceMax.AutoSize = true;
            this.stackPriceMax.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stackPriceMax.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.stackPriceMax.WrapContents = false;
            this.stackPriceMax.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            // 
            // lblPriceMax
            // 
            this.lblPriceMax.AutoSize = true;
            this.lblPriceMax.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPriceMax.ForeColor = System.Drawing.Color.DimGray;
            this.lblPriceMax.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.lblPriceMax.Text = "Maximum Price (RWF)";
            // 
            // txtPriceMax
            // 
            this.txtPriceMax.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPriceMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPriceMax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPriceMax.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.txtPriceMax.PlaceholderText = "e.g. 150000";
            this.txtPriceMax.ReadOnly = true;
            this.txtPriceMax.Size = new System.Drawing.Size(346, 31);
            // 
            // row3
            // 
            this.row3.AutoSize = true;
            this.row3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.row3.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.row3.WrapContents = false;
            this.row3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // 
            // stackLocation
            // 
            this.stackLocation.AutoSize = true;
            this.stackLocation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stackLocation.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.stackLocation.WrapContents = false;
            this.stackLocation.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLocation.ForeColor = System.Drawing.Color.DimGray;
            this.lblLocation.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.lblLocation.Text = "Location";
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.txtLocation.PlaceholderText = "e.g. Kigali";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(704, 31);
            // 
            // btnRow
            // 
            this.btnRow.AutoSize = true;
            this.btnRow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRow.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.btnRow.WrapContents = false;
            this.btnRow.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnRow.MinimumSize = new System.Drawing.Size(704, 0);
            // 
            // btnEditSave
            // 
            this.btnEditSave.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.btnEditSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditSave.ForeColor = System.Drawing.Color.White;
            this.btnEditSave.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnEditSave.Size = new System.Drawing.Size(190, 46);
            this.btnEditSave.Text = "Edit Profile";
            this.btnEditSave.UseVisualStyleBackColor = false;
            this.btnEditSave.FlatAppearance.BorderSize = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnCancel.Size = new System.Drawing.Size(120, 46);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Visible = false;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(207, 226, 226);
            this.btnCancel.FlatAppearance.BorderSize = 1;
            // 
            // bookingsView
            // 
            this.bookingsView.BackColor = System.Drawing.Color.Transparent;
            this.bookingsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookingsView.Size = new System.Drawing.Size(900, 600);
            this.bookingsView.Visible = false;
            // 
            // bkRoot
            // 
            this.bkRoot.BackColor = System.Drawing.Color.Transparent;
            this.bkRoot.ColumnCount = 2;
            this.bkRoot.RowCount = 1;
            this.bkRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bkRoot.Size = new System.Drawing.Size(900, 600);
            this.bkRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bkRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.bkRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            // 
            // bkListCard
            // 
            this.bkListCard.BackColor = System.Drawing.Color.White;
            this.bkListCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bkListCard.Padding = new System.Windows.Forms.Padding(24, 24, 24, 24);
            this.bkListCard.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            // 
            // gridBookings
            // 
            this.gridBookings.AllowUserToAddRows = false;
            this.gridBookings.AllowUserToDeleteRows = false;
            this.gridBookings.AllowUserToResizeRows = false;
            this.gridBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridBookings.BackgroundColor = System.Drawing.Color.White;
            this.gridBookings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridBookings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridBookings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridBookings.ColumnHeadersHeight = 42;
            this.gridBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBookings.EnableHeadersVisualStyles = false;
            this.gridBookings.GridColor = System.Drawing.Color.FromArgb(207, 226, 226);
            this.gridBookings.MultiSelect = false;
            this.gridBookings.ReadOnly = true;
            this.gridBookings.RowHeadersVisible = false;
            this.gridBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridBookings.Size = new System.Drawing.Size(400, 300);
            // 
            // lblBookingsTitle
            // 
            this.lblBookingsTitle.AutoSize = false;
            this.lblBookingsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBookingsTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBookingsTitle.ForeColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.lblBookingsTitle.Size = new System.Drawing.Size(500, 50);
            this.lblBookingsTitle.Text = "Incoming Booking Requests";
            // 
            // bkDetailCard
            // 
            this.bkDetailCard.BackColor = System.Drawing.Color.White;
            this.bkDetailCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bkDetailCard.Padding = new System.Windows.Forms.Padding(24, 24, 24, 24);
            this.bkDetailCard.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // 
            // bkDetail
            // 
            this.bkDetail.BackColor = System.Drawing.Color.White;
            this.bkDetail.ColumnCount = 1;
            this.bkDetail.RowCount = 8;
            this.bkDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bkDetail.Size = new System.Drawing.Size(360, 500);
            this.bkDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bkDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.bkDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.bkDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.bkDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.bkDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bkDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.bkDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bkDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            // 
            // lblBkEvent
            // 
            this.lblBkEvent.AutoSize = true;
            this.lblBkEvent.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBkEvent.ForeColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.lblBkEvent.MaximumSize = new System.Drawing.Size(350, 0);
            this.lblBkEvent.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblBkEvent.Text = "No request selected";
            this.lblBkEvent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // lblBkInfo
            // 
            this.lblBkInfo.AutoSize = true;
            this.lblBkInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBkInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblBkInfo.MaximumSize = new System.Drawing.Size(350, 0);
            this.lblBkInfo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblBkInfo.Text = "Pick a request from the list to read the message and reply.";
            this.lblBkInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // lblBkStatus
            // 
            this.lblBkStatus.AutoSize = true;
            this.lblBkStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBkStatus.ForeColor = System.Drawing.Color.Black;
            this.lblBkStatus.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.lblBkStatus.Text = "●  Pending";
            this.lblBkStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBkStatus.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.lblBkStatus.Padding = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.lblBkStatus.Visible = false;
            // 
            // lblBkMsgCaption
            // 
            this.lblBkMsgCaption.AutoSize = true;
            this.lblBkMsgCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBkMsgCaption.ForeColor = System.Drawing.Color.DimGray;
            this.lblBkMsgCaption.MaximumSize = new System.Drawing.Size(350, 0);
            this.lblBkMsgCaption.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.lblBkMsgCaption.Text = "Planner's message";
            this.lblBkMsgCaption.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // txtBkMessage
            // 
            this.txtBkMessage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBkMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBkMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBkMessage.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBkMessage.Margin = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.txtBkMessage.Multiline = true;
            this.txtBkMessage.ReadOnly = true;
            this.txtBkMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBkMessage.Size = new System.Drawing.Size(350, 100);
            // 
            // lblBkRespCaption
            // 
            this.lblBkRespCaption.AutoSize = true;
            this.lblBkRespCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBkRespCaption.ForeColor = System.Drawing.Color.DimGray;
            this.lblBkRespCaption.MaximumSize = new System.Drawing.Size(350, 0);
            this.lblBkRespCaption.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.lblBkRespCaption.Text = "Your response (optional: explain why you accept or reject)";
            this.lblBkRespCaption.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // txtBkResponse
            // 
            this.txtBkResponse.BackColor = System.Drawing.Color.White;
            this.txtBkResponse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBkResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBkResponse.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBkResponse.Margin = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.txtBkResponse.Multiline = true;
            this.txtBkResponse.ReadOnly = true;
            this.txtBkResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBkResponse.Size = new System.Drawing.Size(350, 100);
            // 
            // actions
            // 
            this.actions.AutoSize = true;
            this.actions.ColumnCount = 2;
            this.actions.RowCount = 1;
            this.actions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actions.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.actions.Size = new System.Drawing.Size(360, 46);
            this.actions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.actions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.actions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(40, 160, 90);
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnAccept.Size = new System.Drawing.Size(100, 46);
            this.btnAccept.Text = "Accept";
            this.btnAccept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAccept.Enabled = false;
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.FlatAppearance.BorderSize = 0;
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(214, 69, 65);
            this.btnReject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnReject.Size = new System.Drawing.Size(100, 46);
            this.btnReject.Text = "Reject";
            this.btnReject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReject.Enabled = false;
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.FlatAppearance.BorderSize = 0;
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.White;
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Size = new System.Drawing.Size(1000, 76);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = false;
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUser.ForeColor = System.Drawing.Color.Gray;
            this.lblUser.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.lblUser.Size = new System.Drawing.Size(300, 76);
            this.lblUser.Text = "vendor@example.com";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = false;
            this.lblHeaderTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.lblHeaderTitle.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.lblHeaderTitle.Size = new System.Drawing.Size(420, 76);
            this.lblHeaderTitle.Text = "My Profile";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // headerLine
            // 
            this.headerLine.BackColor = System.Drawing.Color.FromArgb(207, 226, 226);
            this.headerLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.headerLine.Size = new System.Drawing.Size(1000, 1);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Size = new System.Drawing.Size(250, 700);
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.Location = new System.Drawing.Point(0, 100);
            this.btnProfile.Size = new System.Drawing.Size(250, 45);
            this.btnProfile.Text = "   My Profile";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 112, 112);
            // 
            // btnBookings
            // 
            this.btnBookings.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.btnBookings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookings.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBookings.ForeColor = System.Drawing.Color.White;
            this.btnBookings.Location = new System.Drawing.Point(0, 150);
            this.btnBookings.Size = new System.Drawing.Size(250, 45);
            this.btnBookings.Text = "   Booking Requests";
            this.btnBookings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBookings.UseVisualStyleBackColor = false;
            this.btnBookings.FlatAppearance.BorderSize = 0;
            this.btnBookings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 112, 112);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 600);
            this.btnLogout.Size = new System.Drawing.Size(250, 55);
            this.btnLogout.Text = "   Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 112, 112);
            // 
            // logo
            // 
            this.logo.AutoSize = false;
            this.logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.logo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.logo.ForeColor = System.Drawing.Color.FromArgb(0, 192, 192);
            this.logo.Size = new System.Drawing.Size(250, 80);
            this.logo.Text = "EventKonnect";
            this.logo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hierarchy
            // 
            this.mainContainer.Controls.Add(this.profileView);
            this.mainContainer.Controls.Add(this.bookingsView);
            this.profileView.Controls.Add(this.page);
            this.page.Controls.Add(this.hero);
            this.page.Controls.Add(this.statsRow);
            this.page.Controls.Add(this.details);
            this.hero.Controls.Add(this.avatar);
            this.hero.Controls.Add(this.heroText);
            this.heroText.Controls.Add(this.lblTitle);
            this.heroText.Controls.Add(this.lblSubTitle);
            this.heroText.Controls.Add(this.lblPill);
            this.statsRow.Controls.Add(this.cardStatTotal);
            this.statsRow.Controls.Add(this.cardStatPending);
            this.statsRow.Controls.Add(this.cardStatAccepted);
            this.cardStatTotal.Controls.Add(this.lblStatTotal);
            this.cardStatTotal.Controls.Add(this.lblStatTotalCaption);
            this.cardStatPending.Controls.Add(this.lblStatPending);
            this.cardStatPending.Controls.Add(this.lblStatPendingCaption);
            this.cardStatAccepted.Controls.Add(this.lblStatAccepted);
            this.cardStatAccepted.Controls.Add(this.lblStatAcceptedCaption);
            this.details.Controls.Add(this.lblDetailsTitle);
            this.details.Controls.Add(this.lblDetailsHint);
            this.details.Controls.Add(this.row1);
            this.details.Controls.Add(this.row2);
            this.details.Controls.Add(this.row3);
            this.details.Controls.Add(this.btnRow);
            this.row1.Controls.Add(this.stackName);
            this.row1.Controls.Add(this.stackService);
            this.stackName.Controls.Add(this.lblName);
            this.stackName.Controls.Add(this.txtName);
            this.stackService.Controls.Add(this.lblService);
            this.stackService.Controls.Add(this.txtService);
            this.row2.Controls.Add(this.stackPriceMin);
            this.row2.Controls.Add(this.stackPriceMax);
            this.stackPriceMin.Controls.Add(this.lblPriceMin);
            this.stackPriceMin.Controls.Add(this.txtPriceMin);
            this.stackPriceMax.Controls.Add(this.lblPriceMax);
            this.stackPriceMax.Controls.Add(this.txtPriceMax);
            this.row3.Controls.Add(this.stackLocation);
            this.stackLocation.Controls.Add(this.lblLocation);
            this.stackLocation.Controls.Add(this.txtLocation);
            this.btnRow.Controls.Add(this.btnEditSave);
            this.btnRow.Controls.Add(this.btnCancel);
            this.bookingsView.Controls.Add(this.bkRoot);
            this.bkRoot.Controls.Add(this.bkListCard, 0, 0);
            this.bkRoot.Controls.Add(this.bkDetailCard, 1, 0);
            this.bkListCard.Controls.Add(this.gridBookings);
            this.bkListCard.Controls.Add(this.lblBookingsTitle);
            this.bkDetailCard.Controls.Add(this.bkDetail);
            this.bkDetail.Controls.Add(this.lblBkEvent, 0, 0);
            this.bkDetail.Controls.Add(this.lblBkInfo, 0, 1);
            this.bkDetail.Controls.Add(this.lblBkStatus, 0, 2);
            this.bkDetail.Controls.Add(this.lblBkMsgCaption, 0, 3);
            this.bkDetail.Controls.Add(this.txtBkMessage, 0, 4);
            this.bkDetail.Controls.Add(this.lblBkRespCaption, 0, 5);
            this.bkDetail.Controls.Add(this.txtBkResponse, 0, 6);
            this.bkDetail.Controls.Add(this.actions, 0, 7);
            this.actions.Controls.Add(this.btnAccept, 0, 0);
            this.actions.Controls.Add(this.btnReject, 1, 0);
            this.header.Controls.Add(this.lblUser);
            this.header.Controls.Add(this.lblHeaderTitle);
            this.header.Controls.Add(this.headerLine);
            this.sidebar.Controls.Add(this.btnProfile);
            this.sidebar.Controls.Add(this.btnBookings);
            this.sidebar.Controls.Add(this.btnLogout);
            this.sidebar.Controls.Add(this.logo);
            // 
            // VendorForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(240, 247, 247);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Size = new System.Drawing.Size(1200, 760);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendor Dashboard";
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.header);
            this.Controls.Add(this.sidebar);
            this.Name = "VendorForm";
            this.profileView.Resize += new System.EventHandler(this.profileView_Resize);
            this.page.SizeChanged += new System.EventHandler(this.page_SizeChanged);
            this.avatar.Paint += new System.Windows.Forms.PaintEventHandler(this.avatar_Paint);
            this.cardStatTotal.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.cardStatPending.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.cardStatAccepted.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.details.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.btnEditSave.Click += new System.EventHandler(this.btnEditSave_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.bkListCard.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.gridBookings.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Grid_CellFormatting);
            this.gridBookings.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Grid_DataBindingComplete);
            this.gridBookings.SelectionChanged += new System.EventHandler(this.gridBookings_SelectionChanged);
            this.bkDetailCard.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            this.btnProfile.Paint += new System.Windows.Forms.PaintEventHandler(this.SidebarButton_Paint);
            this.btnBookings.Click += new System.EventHandler(this.btnBookings_Click);
            this.btnBookings.Paint += new System.Windows.Forms.PaintEventHandler(this.SidebarButton_Paint);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.btnLogout.Paint += new System.Windows.Forms.PaintEventHandler(this.SidebarButton_Paint);
            this.Load += new System.EventHandler(this.VendorForm_Load);
            this.mainContainer.ResumeLayout(false);
            this.mainContainer.PerformLayout();
            this.profileView.ResumeLayout(false);
            this.profileView.PerformLayout();
            this.page.ResumeLayout(false);
            this.page.PerformLayout();
            this.hero.ResumeLayout(false);
            this.hero.PerformLayout();
            this.avatar.ResumeLayout(false);
            this.avatar.PerformLayout();
            this.heroText.ResumeLayout(false);
            this.heroText.PerformLayout();
            this.statsRow.ResumeLayout(false);
            this.statsRow.PerformLayout();
            this.cardStatTotal.ResumeLayout(false);
            this.cardStatTotal.PerformLayout();
            this.cardStatPending.ResumeLayout(false);
            this.cardStatPending.PerformLayout();
            this.cardStatAccepted.ResumeLayout(false);
            this.cardStatAccepted.PerformLayout();
            this.details.ResumeLayout(false);
            this.details.PerformLayout();
            this.row1.ResumeLayout(false);
            this.row1.PerformLayout();
            this.stackName.ResumeLayout(false);
            this.stackName.PerformLayout();
            this.stackService.ResumeLayout(false);
            this.stackService.PerformLayout();
            this.row2.ResumeLayout(false);
            this.row2.PerformLayout();
            this.stackPriceMin.ResumeLayout(false);
            this.stackPriceMin.PerformLayout();
            this.stackPriceMax.ResumeLayout(false);
            this.stackPriceMax.PerformLayout();
            this.row3.ResumeLayout(false);
            this.row3.PerformLayout();
            this.stackLocation.ResumeLayout(false);
            this.stackLocation.PerformLayout();
            this.btnRow.ResumeLayout(false);
            this.btnRow.PerformLayout();
            this.bookingsView.ResumeLayout(false);
            this.bookingsView.PerformLayout();
            this.bkRoot.ResumeLayout(false);
            this.bkRoot.PerformLayout();
            this.bkListCard.ResumeLayout(false);
            this.bkListCard.PerformLayout();
            this.bkDetailCard.ResumeLayout(false);
            this.bkDetailCard.PerformLayout();
            this.bkDetail.ResumeLayout(false);
            this.bkDetail.PerformLayout();
            this.actions.ResumeLayout(false);
            this.actions.PerformLayout();
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.headerLine.ResumeLayout(false);
            this.headerLine.PerformLayout();
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBookings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel mainContainer;
        private System.Windows.Forms.Panel profileView;
        private System.Windows.Forms.FlowLayoutPanel page;
        private System.Windows.Forms.FlowLayoutPanel hero;
        private System.Windows.Forms.Panel avatar;
        private System.Windows.Forms.FlowLayoutPanel heroText;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblPill;
        private System.Windows.Forms.FlowLayoutPanel statsRow;
        private System.Windows.Forms.FlowLayoutPanel cardStatTotal;
        private System.Windows.Forms.Label lblStatTotal;
        private System.Windows.Forms.Label lblStatTotalCaption;
        private System.Windows.Forms.FlowLayoutPanel cardStatPending;
        private System.Windows.Forms.Label lblStatPending;
        private System.Windows.Forms.Label lblStatPendingCaption;
        private System.Windows.Forms.FlowLayoutPanel cardStatAccepted;
        private System.Windows.Forms.Label lblStatAccepted;
        private System.Windows.Forms.Label lblStatAcceptedCaption;
        private System.Windows.Forms.FlowLayoutPanel details;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.Label lblDetailsHint;
        private System.Windows.Forms.FlowLayoutPanel row1;
        private System.Windows.Forms.FlowLayoutPanel stackName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.FlowLayoutPanel stackService;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.TextBox txtService;
        private System.Windows.Forms.FlowLayoutPanel row2;
        private System.Windows.Forms.FlowLayoutPanel stackPriceMin;
        private System.Windows.Forms.Label lblPriceMin;
        private System.Windows.Forms.TextBox txtPriceMin;
        private System.Windows.Forms.FlowLayoutPanel stackPriceMax;
        private System.Windows.Forms.Label lblPriceMax;
        private System.Windows.Forms.TextBox txtPriceMax;
        private System.Windows.Forms.FlowLayoutPanel row3;
        private System.Windows.Forms.FlowLayoutPanel stackLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.FlowLayoutPanel btnRow;
        private System.Windows.Forms.Button btnEditSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel bookingsView;
        private System.Windows.Forms.TableLayoutPanel bkRoot;
        private System.Windows.Forms.Panel bkListCard;
        private System.Windows.Forms.DataGridView gridBookings;
        private System.Windows.Forms.Label lblBookingsTitle;
        private System.Windows.Forms.Panel bkDetailCard;
        private System.Windows.Forms.TableLayoutPanel bkDetail;
        private System.Windows.Forms.Label lblBkEvent;
        private System.Windows.Forms.Label lblBkInfo;
        private System.Windows.Forms.Label lblBkStatus;
        private System.Windows.Forms.Label lblBkMsgCaption;
        private System.Windows.Forms.TextBox txtBkMessage;
        private System.Windows.Forms.Label lblBkRespCaption;
        private System.Windows.Forms.TextBox txtBkResponse;
        private System.Windows.Forms.TableLayoutPanel actions;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel headerLine;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnBookings;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label logo;
    }
}
