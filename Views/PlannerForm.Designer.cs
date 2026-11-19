namespace Lab3Assignment.Views
{
    partial class PlannerForm
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
            this.dashboardView = new System.Windows.Forms.Panel();
            this.dashRoot = new System.Windows.Forms.TableLayoutPanel();
            this.statsTable = new System.Windows.Forms.TableLayoutPanel();
            this.cardStatEvents = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStatEvents = new System.Windows.Forms.Label();
            this.lblStatEventsCaption = new System.Windows.Forms.Label();
            this.cardStatVendors = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStatVendors = new System.Windows.Forms.Label();
            this.lblStatVendorsCaption = new System.Windows.Forms.Label();
            this.cardStatAccepted = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStatAccepted = new System.Windows.Forms.Label();
            this.lblStatAcceptedCaption = new System.Windows.Forms.Label();
            this.createCard = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCreateTitle = new System.Windows.Forms.Label();
            this.lblCreateHint = new System.Windows.Forms.Label();
            this.lblEventTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblEventDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblBudget = new System.Windows.Forms.Label();
            this.txtBudget = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.vendorsCard = new System.Windows.Forms.Panel();
            this.gridVendors = new System.Windows.Forms.DataGridView();
            this.vButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.vHeader = new System.Windows.Forms.TableLayoutPanel();
            this.lblVendors = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.eventsView = new System.Windows.Forms.Panel();
            this.eventsCard = new System.Windows.Forms.Panel();
            this.gridEvents = new System.Windows.Forms.DataGridView();
            this.lblEventsTitle = new System.Windows.Forms.Label();
            this.bookingsView = new System.Windows.Forms.Panel();
            this.bkRoot = new System.Windows.Forms.TableLayoutPanel();
            this.bkListCard = new System.Windows.Forms.Panel();
            this.gridBookings = new System.Windows.Forms.DataGridView();
            this.lblBookingsTitle = new System.Windows.Forms.Label();
            this.bkDetailCard = new System.Windows.Forms.Panel();
            this.bkDetail = new System.Windows.Forms.TableLayoutPanel();
            this.lblBkEvent = new System.Windows.Forms.Label();
            this.lblBkVendor = new System.Windows.Forms.Label();
            this.lblBkStatus = new System.Windows.Forms.Label();
            this.lblBkMsgCaption = new System.Windows.Forms.Label();
            this.txtBkMessage = new System.Windows.Forms.TextBox();
            this.lblBkRespCaption = new System.Windows.Forms.Label();
            this.txtBkResponse = new System.Windows.Forms.TextBox();
            this.header = new System.Windows.Forms.Panel();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.headerLine = new System.Windows.Forms.Panel();
            this.sidebar = new System.Windows.Forms.Panel();
            this.btnDash = new System.Windows.Forms.Button();
            this.btnEvents = new System.Windows.Forms.Button();
            this.btnMyBookings = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridVendors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBookings)).BeginInit();
            this.mainContainer.SuspendLayout();
            this.dashboardView.SuspendLayout();
            this.dashRoot.SuspendLayout();
            this.statsTable.SuspendLayout();
            this.cardStatEvents.SuspendLayout();
            this.cardStatVendors.SuspendLayout();
            this.cardStatAccepted.SuspendLayout();
            this.createCard.SuspendLayout();
            this.vendorsCard.SuspendLayout();
            this.vButtons.SuspendLayout();
            this.vHeader.SuspendLayout();
            this.eventsView.SuspendLayout();
            this.eventsCard.SuspendLayout();
            this.bookingsView.SuspendLayout();
            this.bkRoot.SuspendLayout();
            this.bkListCard.SuspendLayout();
            this.bkDetailCard.SuspendLayout();
            this.bkDetail.SuspendLayout();
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
            this.mainContainer.Size = new System.Drawing.Size(1030, 704);
            // 
            // dashboardView
            // 
            this.dashboardView.BackColor = System.Drawing.Color.Transparent;
            this.dashboardView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardView.Size = new System.Drawing.Size(900, 600);
            this.dashboardView.Visible = false;
            // 
            // dashRoot
            // 
            this.dashRoot.BackColor = System.Drawing.Color.Transparent;
            this.dashRoot.ColumnCount = 2;
            this.dashRoot.RowCount = 2;
            this.dashRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashRoot.Size = new System.Drawing.Size(900, 600);
            this.dashRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.dashRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dashRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.dashRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            // 
            // statsTable
            // 
            this.statsTable.AutoSize = true;
            this.statsTable.ColumnCount = 3;
            this.statsTable.RowCount = 1;
            this.statsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsTable.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.statsTable.Size = new System.Drawing.Size(1000, 90);
            this.statsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.statsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.statsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            // 
            // cardStatEvents
            // 
            this.cardStatEvents.AutoSize = true;
            this.cardStatEvents.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cardStatEvents.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cardStatEvents.WrapContents = false;
            this.cardStatEvents.BackColor = System.Drawing.Color.White;
            this.cardStatEvents.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.cardStatEvents.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.cardStatEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // lblStatEvents
            // 
            this.lblStatEvents.AutoSize = true;
            this.lblStatEvents.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatEvents.ForeColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.lblStatEvents.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.lblStatEvents.Text = "0";
            // 
            // lblStatEventsCaption
            // 
            this.lblStatEventsCaption.AutoSize = true;
            this.lblStatEventsCaption.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatEventsCaption.ForeColor = System.Drawing.Color.Gray;
            this.lblStatEventsCaption.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblStatEventsCaption.Text = "Events posted";
            // 
            // cardStatVendors
            // 
            this.cardStatVendors.AutoSize = true;
            this.cardStatVendors.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cardStatVendors.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cardStatVendors.WrapContents = false;
            this.cardStatVendors.BackColor = System.Drawing.Color.White;
            this.cardStatVendors.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.cardStatVendors.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.cardStatVendors.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // lblStatVendors
            // 
            this.lblStatVendors.AutoSize = true;
            this.lblStatVendors.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatVendors.ForeColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.lblStatVendors.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.lblStatVendors.Text = "0";
            // 
            // lblStatVendorsCaption
            // 
            this.lblStatVendorsCaption.AutoSize = true;
            this.lblStatVendorsCaption.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatVendorsCaption.ForeColor = System.Drawing.Color.Gray;
            this.lblStatVendorsCaption.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblStatVendorsCaption.Text = "Vendors available";
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
            this.cardStatAccepted.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.lblStatAcceptedCaption.Text = "Bookings accepted";
            // 
            // createCard
            // 
            this.createCard.AutoSize = true;
            this.createCard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.createCard.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.createCard.WrapContents = false;
            this.createCard.BackColor = System.Drawing.Color.White;
            this.createCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.createCard.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.createCard.Padding = new System.Windows.Forms.Padding(24, 24, 24, 24);
            this.createCard.Size = new System.Drawing.Size(364, 400);
            // 
            // lblCreateTitle
            // 
            this.lblCreateTitle.AutoSize = true;
            this.lblCreateTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCreateTitle.ForeColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.lblCreateTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.lblCreateTitle.Text = "Create New Event";
            // 
            // lblCreateHint
            // 
            this.lblCreateHint.AutoSize = true;
            this.lblCreateHint.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCreateHint.ForeColor = System.Drawing.Color.Gray;
            this.lblCreateHint.MaximumSize = new System.Drawing.Size(316, 0);
            this.lblCreateHint.Margin = new System.Windows.Forms.Padding(2, 0, 0, 18);
            this.lblCreateHint.Text = "Post an event, then book vendors for it.";
            // 
            // lblEventTitle
            // 
            this.lblEventTitle.AutoSize = true;
            this.lblEventTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEventTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblEventTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.lblEventTitle.Text = "Event title";
            // 
            // txtTitle
            // 
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.txtTitle.PlaceholderText = "e.g. Wedding reception";
            this.txtTitle.Size = new System.Drawing.Size(316, 31);
            // 
            // lblEventDate
            // 
            this.lblEventDate.AutoSize = true;
            this.lblEventDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEventDate.ForeColor = System.Drawing.Color.DimGray;
            this.lblEventDate.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.lblEventDate.Text = "Event date";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDate.Margin = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.dtpDate.Size = new System.Drawing.Size(316, 27);
            // 
            // lblBudget
            // 
            this.lblBudget.AutoSize = true;
            this.lblBudget.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBudget.ForeColor = System.Drawing.Color.DimGray;
            this.lblBudget.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.lblBudget.Text = "Budget (RWF)";
            // 
            // txtBudget
            // 
            this.txtBudget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBudget.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBudget.Margin = new System.Windows.Forms.Padding(0, 0, 0, 18);
            this.txtBudget.PlaceholderText = "e.g. 500000";
            this.txtBudget.Size = new System.Drawing.Size(316, 31);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnCreate.Size = new System.Drawing.Size(316, 46);
            this.btnCreate.Text = "Post Event";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 112, 112);
            // 
            // vendorsCard
            // 
            this.vendorsCard.BackColor = System.Drawing.Color.White;
            this.vendorsCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vendorsCard.Padding = new System.Windows.Forms.Padding(24, 24, 24, 24);
            this.vendorsCard.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // 
            // gridVendors
            // 
            this.gridVendors.AllowUserToAddRows = false;
            this.gridVendors.AllowUserToDeleteRows = false;
            this.gridVendors.AllowUserToResizeRows = false;
            this.gridVendors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridVendors.BackgroundColor = System.Drawing.Color.White;
            this.gridVendors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridVendors.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridVendors.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridVendors.ColumnHeadersHeight = 42;
            this.gridVendors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridVendors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVendors.EnableHeadersVisualStyles = false;
            this.gridVendors.GridColor = System.Drawing.Color.FromArgb(207, 226, 226);
            this.gridVendors.MultiSelect = false;
            this.gridVendors.ReadOnly = true;
            this.gridVendors.RowHeadersVisible = false;
            this.gridVendors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridVendors.Size = new System.Drawing.Size(400, 300);
            // 
            // vButtons
            // 
            this.vButtons.AutoSize = true;
            this.vButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.vButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.vButtons.WrapContents = false;
            this.vButtons.BackColor = System.Drawing.Color.White;
            this.vButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.vButtons.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.vButtons.Size = new System.Drawing.Size(600, 60);
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBook.ForeColor = System.Drawing.Color.Black;
            this.btnBook.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnBook.Size = new System.Drawing.Size(170, 44);
            this.btnBook.Text = "Book Vendor";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.FlatAppearance.BorderSize = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.ForeColor = System.Drawing.Color.DimGray;
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnRefresh.Size = new System.Drawing.Size(120, 44);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(207, 226, 226);
            this.btnRefresh.FlatAppearance.BorderSize = 1;
            // 
            // vHeader
            // 
            this.vHeader.AutoSize = true;
            this.vHeader.BackColor = System.Drawing.Color.White;
            this.vHeader.ColumnCount = 2;
            this.vHeader.RowCount = 1;
            this.vHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.vHeader.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.vHeader.Size = new System.Drawing.Size(600, 40);
            this.vHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.vHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.vHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            // 
            // lblVendors
            // 
            this.lblVendors.AutoSize = true;
            this.lblVendors.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblVendors.ForeColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.lblVendors.Margin = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.lblVendors.Text = "Available Vendors";
            this.lblVendors.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.txtSearch.PlaceholderText = "Search name, service or location";
            this.txtSearch.Size = new System.Drawing.Size(260, 31);
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            // 
            // eventsView
            // 
            this.eventsView.BackColor = System.Drawing.Color.Transparent;
            this.eventsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsView.Size = new System.Drawing.Size(900, 600);
            this.eventsView.Visible = false;
            // 
            // eventsCard
            // 
            this.eventsCard.BackColor = System.Drawing.Color.White;
            this.eventsCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsCard.Padding = new System.Windows.Forms.Padding(24, 24, 24, 24);
            this.eventsCard.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // 
            // gridEvents
            // 
            this.gridEvents.AllowUserToAddRows = false;
            this.gridEvents.AllowUserToDeleteRows = false;
            this.gridEvents.AllowUserToResizeRows = false;
            this.gridEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridEvents.BackgroundColor = System.Drawing.Color.White;
            this.gridEvents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridEvents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridEvents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridEvents.ColumnHeadersHeight = 42;
            this.gridEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEvents.EnableHeadersVisualStyles = false;
            this.gridEvents.GridColor = System.Drawing.Color.FromArgb(207, 226, 226);
            this.gridEvents.MultiSelect = false;
            this.gridEvents.ReadOnly = true;
            this.gridEvents.RowHeadersVisible = false;
            this.gridEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEvents.Size = new System.Drawing.Size(400, 300);
            // 
            // lblEventsTitle
            // 
            this.lblEventsTitle.AutoSize = false;
            this.lblEventsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEventsTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEventsTitle.ForeColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.lblEventsTitle.Size = new System.Drawing.Size(800, 50);
            this.lblEventsTitle.Text = "My Events";
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
            this.lblBookingsTitle.Text = "My Bookings";
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
            this.bkDetail.RowCount = 7;
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
            // 
            // lblBkEvent
            // 
            this.lblBkEvent.AutoSize = true;
            this.lblBkEvent.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBkEvent.ForeColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.lblBkEvent.MaximumSize = new System.Drawing.Size(350, 0);
            this.lblBkEvent.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblBkEvent.Text = "No booking selected";
            this.lblBkEvent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // lblBkVendor
            // 
            this.lblBkVendor.AutoSize = true;
            this.lblBkVendor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBkVendor.ForeColor = System.Drawing.Color.Gray;
            this.lblBkVendor.MaximumSize = new System.Drawing.Size(350, 0);
            this.lblBkVendor.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblBkVendor.Text = "Pick a booking to see the vendor's response.";
            this.lblBkVendor.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
            this.lblBkMsgCaption.Text = "Your message to the vendor";
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
            this.lblBkRespCaption.Text = "Vendor's response";
            this.lblBkRespCaption.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // txtBkResponse
            // 
            this.txtBkResponse.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBkResponse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBkResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBkResponse.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBkResponse.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.txtBkResponse.Multiline = true;
            this.txtBkResponse.ReadOnly = true;
            this.txtBkResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBkResponse.Size = new System.Drawing.Size(350, 100);
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.White;
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Size = new System.Drawing.Size(1000, 76);
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = false;
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.lblHint.Size = new System.Drawing.Size(420, 76);
            this.lblHint.Text = "Post your event and connect with vendors";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = false;
            this.lblHeaderTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.lblHeaderTitle.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.lblHeaderTitle.Size = new System.Drawing.Size(420, 76);
            this.lblHeaderTitle.Text = "Dashboard";
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
            // btnDash
            // 
            this.btnDash.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.btnDash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDash.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDash.ForeColor = System.Drawing.Color.White;
            this.btnDash.Location = new System.Drawing.Point(0, 100);
            this.btnDash.Size = new System.Drawing.Size(250, 45);
            this.btnDash.Text = "   Dashboard";
            this.btnDash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDash.UseVisualStyleBackColor = false;
            this.btnDash.FlatAppearance.BorderSize = 0;
            this.btnDash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 112, 112);
            // 
            // btnEvents
            // 
            this.btnEvents.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.btnEvents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvents.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEvents.ForeColor = System.Drawing.Color.White;
            this.btnEvents.Location = new System.Drawing.Point(0, 150);
            this.btnEvents.Size = new System.Drawing.Size(250, 45);
            this.btnEvents.Text = "   My Events";
            this.btnEvents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEvents.UseVisualStyleBackColor = false;
            this.btnEvents.FlatAppearance.BorderSize = 0;
            this.btnEvents.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 112, 112);
            // 
            // btnMyBookings
            // 
            this.btnMyBookings.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            this.btnMyBookings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMyBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyBookings.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMyBookings.ForeColor = System.Drawing.Color.White;
            this.btnMyBookings.Location = new System.Drawing.Point(0, 200);
            this.btnMyBookings.Size = new System.Drawing.Size(250, 45);
            this.btnMyBookings.Text = "   My Bookings";
            this.btnMyBookings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyBookings.UseVisualStyleBackColor = false;
            this.btnMyBookings.FlatAppearance.BorderSize = 0;
            this.btnMyBookings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 112, 112);
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
            this.mainContainer.Controls.Add(this.dashboardView);
            this.mainContainer.Controls.Add(this.eventsView);
            this.mainContainer.Controls.Add(this.bookingsView);
            this.dashboardView.Controls.Add(this.dashRoot);
            this.dashRoot.Controls.Add(this.statsTable, 0, 0);
            this.dashRoot.Controls.Add(this.createCard, 0, 1);
            this.dashRoot.Controls.Add(this.vendorsCard, 1, 1);
            this.dashRoot.SetColumnSpan(this.statsTable, 2);
            this.statsTable.Controls.Add(this.cardStatEvents, 0, 0);
            this.statsTable.Controls.Add(this.cardStatVendors, 1, 0);
            this.statsTable.Controls.Add(this.cardStatAccepted, 2, 0);
            this.cardStatEvents.Controls.Add(this.lblStatEvents);
            this.cardStatEvents.Controls.Add(this.lblStatEventsCaption);
            this.cardStatVendors.Controls.Add(this.lblStatVendors);
            this.cardStatVendors.Controls.Add(this.lblStatVendorsCaption);
            this.cardStatAccepted.Controls.Add(this.lblStatAccepted);
            this.cardStatAccepted.Controls.Add(this.lblStatAcceptedCaption);
            this.createCard.Controls.Add(this.lblCreateTitle);
            this.createCard.Controls.Add(this.lblCreateHint);
            this.createCard.Controls.Add(this.lblEventTitle);
            this.createCard.Controls.Add(this.txtTitle);
            this.createCard.Controls.Add(this.lblEventDate);
            this.createCard.Controls.Add(this.dtpDate);
            this.createCard.Controls.Add(this.lblBudget);
            this.createCard.Controls.Add(this.txtBudget);
            this.createCard.Controls.Add(this.btnCreate);
            this.vendorsCard.Controls.Add(this.gridVendors);
            this.vendorsCard.Controls.Add(this.vButtons);
            this.vendorsCard.Controls.Add(this.vHeader);
            this.vButtons.Controls.Add(this.btnBook);
            this.vButtons.Controls.Add(this.btnRefresh);
            this.vHeader.Controls.Add(this.lblVendors, 0, 0);
            this.vHeader.Controls.Add(this.txtSearch, 1, 0);
            this.eventsView.Controls.Add(this.eventsCard);
            this.eventsCard.Controls.Add(this.gridEvents);
            this.eventsCard.Controls.Add(this.lblEventsTitle);
            this.bookingsView.Controls.Add(this.bkRoot);
            this.bkRoot.Controls.Add(this.bkListCard, 0, 0);
            this.bkRoot.Controls.Add(this.bkDetailCard, 1, 0);
            this.bkListCard.Controls.Add(this.gridBookings);
            this.bkListCard.Controls.Add(this.lblBookingsTitle);
            this.bkDetailCard.Controls.Add(this.bkDetail);
            this.bkDetail.Controls.Add(this.lblBkEvent, 0, 0);
            this.bkDetail.Controls.Add(this.lblBkVendor, 0, 1);
            this.bkDetail.Controls.Add(this.lblBkStatus, 0, 2);
            this.bkDetail.Controls.Add(this.lblBkMsgCaption, 0, 3);
            this.bkDetail.Controls.Add(this.txtBkMessage, 0, 4);
            this.bkDetail.Controls.Add(this.lblBkRespCaption, 0, 5);
            this.bkDetail.Controls.Add(this.txtBkResponse, 0, 6);
            this.header.Controls.Add(this.lblHint);
            this.header.Controls.Add(this.lblHeaderTitle);
            this.header.Controls.Add(this.headerLine);
            this.sidebar.Controls.Add(this.btnDash);
            this.sidebar.Controls.Add(this.btnEvents);
            this.sidebar.Controls.Add(this.btnMyBookings);
            this.sidebar.Controls.Add(this.btnLogout);
            this.sidebar.Controls.Add(this.logo);
            // 
            // PlannerForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(240, 247, 247);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Size = new System.Drawing.Size(1280, 780);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planner Dashboard";
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.header);
            this.Controls.Add(this.sidebar);
            this.Name = "PlannerForm";
            this.cardStatEvents.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.cardStatVendors.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.cardStatAccepted.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.createCard.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            this.vendorsCard.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.gridVendors.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Grid_CellFormatting);
            this.gridVendors.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Grid_DataBindingComplete);
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.eventsCard.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.gridEvents.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Grid_CellFormatting);
            this.gridEvents.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Grid_DataBindingComplete);
            this.bkListCard.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.gridBookings.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Grid_CellFormatting);
            this.gridBookings.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Grid_DataBindingComplete);
            this.gridBookings.SelectionChanged += new System.EventHandler(this.gridBookings_SelectionChanged);
            this.bkDetailCard.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
            this.btnDash.Click += new System.EventHandler(this.btnDash_Click);
            this.btnDash.Paint += new System.Windows.Forms.PaintEventHandler(this.SidebarButton_Paint);
            this.btnEvents.Click += new System.EventHandler(this.btnEvents_Click);
            this.btnEvents.Paint += new System.Windows.Forms.PaintEventHandler(this.SidebarButton_Paint);
            this.btnMyBookings.Click += new System.EventHandler(this.btnMyBookings_Click);
            this.btnMyBookings.Paint += new System.Windows.Forms.PaintEventHandler(this.SidebarButton_Paint);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.btnLogout.Paint += new System.Windows.Forms.PaintEventHandler(this.SidebarButton_Paint);
            this.Load += new System.EventHandler(this.PlannerForm_Load);
            this.mainContainer.ResumeLayout(false);
            this.mainContainer.PerformLayout();
            this.dashboardView.ResumeLayout(false);
            this.dashboardView.PerformLayout();
            this.dashRoot.ResumeLayout(false);
            this.dashRoot.PerformLayout();
            this.statsTable.ResumeLayout(false);
            this.statsTable.PerformLayout();
            this.cardStatEvents.ResumeLayout(false);
            this.cardStatEvents.PerformLayout();
            this.cardStatVendors.ResumeLayout(false);
            this.cardStatVendors.PerformLayout();
            this.cardStatAccepted.ResumeLayout(false);
            this.cardStatAccepted.PerformLayout();
            this.createCard.ResumeLayout(false);
            this.createCard.PerformLayout();
            this.vendorsCard.ResumeLayout(false);
            this.vendorsCard.PerformLayout();
            this.vButtons.ResumeLayout(false);
            this.vButtons.PerformLayout();
            this.vHeader.ResumeLayout(false);
            this.vHeader.PerformLayout();
            this.eventsView.ResumeLayout(false);
            this.eventsView.PerformLayout();
            this.eventsCard.ResumeLayout(false);
            this.eventsCard.PerformLayout();
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
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.headerLine.ResumeLayout(false);
            this.headerLine.PerformLayout();
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVendors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBookings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel mainContainer;
        private System.Windows.Forms.Panel dashboardView;
        private System.Windows.Forms.TableLayoutPanel dashRoot;
        private System.Windows.Forms.TableLayoutPanel statsTable;
        private System.Windows.Forms.FlowLayoutPanel cardStatEvents;
        private System.Windows.Forms.Label lblStatEvents;
        private System.Windows.Forms.Label lblStatEventsCaption;
        private System.Windows.Forms.FlowLayoutPanel cardStatVendors;
        private System.Windows.Forms.Label lblStatVendors;
        private System.Windows.Forms.Label lblStatVendorsCaption;
        private System.Windows.Forms.FlowLayoutPanel cardStatAccepted;
        private System.Windows.Forms.Label lblStatAccepted;
        private System.Windows.Forms.Label lblStatAcceptedCaption;
        private System.Windows.Forms.FlowLayoutPanel createCard;
        private System.Windows.Forms.Label lblCreateTitle;
        private System.Windows.Forms.Label lblCreateHint;
        private System.Windows.Forms.Label lblEventTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblEventDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblBudget;
        private System.Windows.Forms.TextBox txtBudget;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Panel vendorsCard;
        private System.Windows.Forms.DataGridView gridVendors;
        private System.Windows.Forms.FlowLayoutPanel vButtons;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TableLayoutPanel vHeader;
        private System.Windows.Forms.Label lblVendors;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel eventsView;
        private System.Windows.Forms.Panel eventsCard;
        private System.Windows.Forms.DataGridView gridEvents;
        private System.Windows.Forms.Label lblEventsTitle;
        private System.Windows.Forms.Panel bookingsView;
        private System.Windows.Forms.TableLayoutPanel bkRoot;
        private System.Windows.Forms.Panel bkListCard;
        private System.Windows.Forms.DataGridView gridBookings;
        private System.Windows.Forms.Label lblBookingsTitle;
        private System.Windows.Forms.Panel bkDetailCard;
        private System.Windows.Forms.TableLayoutPanel bkDetail;
        private System.Windows.Forms.Label lblBkEvent;
        private System.Windows.Forms.Label lblBkVendor;
        private System.Windows.Forms.Label lblBkStatus;
        private System.Windows.Forms.Label lblBkMsgCaption;
        private System.Windows.Forms.TextBox txtBkMessage;
        private System.Windows.Forms.Label lblBkRespCaption;
        private System.Windows.Forms.TextBox txtBkResponse;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel headerLine;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Button btnDash;
        private System.Windows.Forms.Button btnEvents;
        private System.Windows.Forms.Button btnMyBookings;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label logo;
    }
}
