namespace RecipeWinForms
{
    partial class frmRecipeStatus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            tblMain = new TableLayoutPanel();
            tblStatus = new TableLayoutPanel();
            lblCaptionPublished = new Label();
            lblCaptionArchived = new Label();
            lblDraftTime = new Label();
            lblPublishedTime = new Label();
            lblArchivedTime = new Label();
            lblCaptionDrafted = new Label();
            lblStatusDates = new Label();
            lblRecipeName = new Label();
            btnDraft = new Button();
            btnPublish = new Button();
            btnArchive = new Button();
            tblStatusDisplay = new TableLayoutPanel();
            lblCaptionCurrentStatus = new Label();
            lblRecipeStatus = new Label();
            tblMain.SuspendLayout();
            tblStatus.SuspendLayout();
            tblStatusDisplay.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 3;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tblMain.Controls.Add(tblStatus, 0, 2);
            tblMain.Controls.Add(lblRecipeName, 0, 0);
            tblMain.Controls.Add(btnDraft, 0, 3);
            tblMain.Controls.Add(btnPublish, 1, 3);
            tblMain.Controls.Add(btnArchive, 2, 3);
            tblMain.Controls.Add(tblStatusDisplay, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(4);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 5;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(605, 497);
            tblMain.TabIndex = 0;
            // 
            // tblStatus
            // 
            tblStatus.ColumnCount = 5;
            tblMain.SetColumnSpan(tblStatus, 3);
            tblStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblStatus.ColumnStyles.Add(new ColumnStyle());
            tblStatus.ColumnStyles.Add(new ColumnStyle());
            tblStatus.ColumnStyles.Add(new ColumnStyle());
            tblStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblStatus.Controls.Add(lblCaptionPublished, 2, 0);
            tblStatus.Controls.Add(lblCaptionArchived, 3, 0);
            tblStatus.Controls.Add(lblDraftTime, 1, 1);
            tblStatus.Controls.Add(lblPublishedTime, 2, 1);
            tblStatus.Controls.Add(lblArchivedTime, 3, 1);
            tblStatus.Controls.Add(lblCaptionDrafted, 1, 0);
            tblStatus.Controls.Add(lblStatusDates, 0, 1);
            tblStatus.Dock = DockStyle.Fill;
            tblStatus.Location = new Point(4, 268);
            tblStatus.Margin = new Padding(4);
            tblStatus.Name = "tblStatus";
            tblStatus.RowCount = 2;
            tblStatus.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tblStatus.RowStyles.Add(new RowStyle());
            tblStatus.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblStatus.Size = new Size(597, 70);
            tblStatus.TabIndex = 3;
            // 
            // lblCaptionPublished
            // 
            lblCaptionPublished.Anchor = AnchorStyles.Top;
            lblCaptionPublished.AutoSize = true;
            lblCaptionPublished.Location = new Point(259, 0);
            lblCaptionPublished.Margin = new Padding(4, 0, 4, 0);
            lblCaptionPublished.Name = "lblCaptionPublished";
            lblCaptionPublished.Size = new Size(78, 21);
            lblCaptionPublished.TabIndex = 3;
            lblCaptionPublished.Text = "Punlished";
            // 
            // lblCaptionArchived
            // 
            lblCaptionArchived.Anchor = AnchorStyles.Top;
            lblCaptionArchived.AutoSize = true;
            lblCaptionArchived.Location = new Point(378, 0);
            lblCaptionArchived.Margin = new Padding(4, 0, 4, 0);
            lblCaptionArchived.Name = "lblCaptionArchived";
            lblCaptionArchived.Size = new Size(71, 21);
            lblCaptionArchived.TabIndex = 5;
            lblCaptionArchived.Text = "Archived";
            // 
            // lblDraftTime
            // 
            lblDraftTime.Anchor = AnchorStyles.None;
            lblDraftTime.BackColor = SystemColors.ControlLight;
            lblDraftTime.BorderStyle = BorderStyle.Fixed3D;
            lblDraftTime.Location = new Point(127, 34);
            lblDraftTime.Name = "lblDraftTime";
            lblDraftTime.Size = new Size(110, 30);
            lblDraftTime.TabIndex = 2;
            lblDraftTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPublishedTime
            // 
            lblPublishedTime.Anchor = AnchorStyles.None;
            lblPublishedTime.BackColor = SystemColors.ControlLight;
            lblPublishedTime.BorderStyle = BorderStyle.Fixed3D;
            lblPublishedTime.Location = new Point(243, 34);
            lblPublishedTime.Name = "lblPublishedTime";
            lblPublishedTime.Size = new Size(110, 30);
            lblPublishedTime.TabIndex = 4;
            lblPublishedTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblArchivedTime
            // 
            lblArchivedTime.Anchor = AnchorStyles.None;
            lblArchivedTime.BackColor = SystemColors.ControlLight;
            lblArchivedTime.BorderStyle = BorderStyle.Fixed3D;
            lblArchivedTime.Location = new Point(359, 34);
            lblArchivedTime.Name = "lblArchivedTime";
            lblArchivedTime.Size = new Size(110, 30);
            lblArchivedTime.TabIndex = 6;
            lblArchivedTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCaptionDrafted
            // 
            lblCaptionDrafted.Anchor = AnchorStyles.Top;
            lblCaptionDrafted.AutoSize = true;
            lblCaptionDrafted.Location = new Point(151, 0);
            lblCaptionDrafted.Margin = new Padding(4, 0, 4, 0);
            lblCaptionDrafted.Name = "lblCaptionDrafted";
            lblCaptionDrafted.Size = new Size(62, 21);
            lblCaptionDrafted.TabIndex = 1;
            lblCaptionDrafted.Text = "Drafted";
            // 
            // lblStatusDates
            // 
            lblStatusDates.Anchor = AnchorStyles.Top;
            lblStatusDates.AutoSize = true;
            lblStatusDates.Location = new Point(14, 29);
            lblStatusDates.Margin = new Padding(0);
            lblStatusDates.Name = "lblStatusDates";
            lblStatusDates.Size = new Size(95, 21);
            lblStatusDates.TabIndex = 0;
            lblStatusDates.Text = "Status Dates";
            // 
            // lblRecipeName
            // 
            lblRecipeName.Anchor = AnchorStyles.None;
            lblRecipeName.AutoSize = true;
            tblMain.SetColumnSpan(lblRecipeName, 3);
            lblRecipeName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblRecipeName.Location = new Point(179, 50);
            lblRecipeName.Margin = new Padding(4, 0, 4, 0);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(247, 32);
            lblRecipeName.TabIndex = 1;
            lblRecipeName.Text = "This will be the recipe";
            // 
            // btnDraft
            // 
            btnDraft.Anchor = AnchorStyles.None;
            btnDraft.BackColor = Color.Gainsboro;
            btnDraft.Location = new Point(30, 383);
            btnDraft.Margin = new Padding(4);
            btnDraft.Name = "btnDraft";
            btnDraft.Size = new Size(140, 50);
            btnDraft.TabIndex = 4;
            btnDraft.Text = "&Draft";
            btnDraft.UseVisualStyleBackColor = false;
            // 
            // btnPublish
            // 
            btnPublish.Anchor = AnchorStyles.None;
            btnPublish.BackColor = Color.Gainsboro;
            btnPublish.Location = new Point(231, 383);
            btnPublish.Margin = new Padding(4);
            btnPublish.Name = "btnPublish";
            btnPublish.Size = new Size(140, 50);
            btnPublish.TabIndex = 5;
            btnPublish.Text = "&Publish";
            btnPublish.UseVisualStyleBackColor = false;
            // 
            // btnArchive
            // 
            btnArchive.Anchor = AnchorStyles.None;
            btnArchive.BackColor = Color.Gainsboro;
            btnArchive.Location = new Point(433, 383);
            btnArchive.Margin = new Padding(4);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new Size(140, 50);
            btnArchive.TabIndex = 6;
            btnArchive.Text = "&Archive";
            btnArchive.UseVisualStyleBackColor = false;
            // 
            // tblStatusDisplay
            // 
            tblStatusDisplay.Anchor = AnchorStyles.None;
            tblStatusDisplay.ColumnCount = 1;
            tblMain.SetColumnSpan(tblStatusDisplay, 3);
            tblStatusDisplay.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblStatusDisplay.Controls.Add(lblCaptionCurrentStatus, 0, 0);
            tblStatusDisplay.Controls.Add(lblRecipeStatus, 0, 1);
            tblStatusDisplay.Location = new Point(188, 172);
            tblStatusDisplay.Name = "tblStatusDisplay";
            tblStatusDisplay.RowCount = 2;
            tblStatusDisplay.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblStatusDisplay.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblStatusDisplay.Size = new Size(228, 52);
            tblStatusDisplay.TabIndex = 2;
            // 
            // lblCaptionCurrentStatus
            // 
            lblCaptionCurrentStatus.Anchor = AnchorStyles.None;
            lblCaptionCurrentStatus.AutoSize = true;
            lblCaptionCurrentStatus.Location = new Point(56, 2);
            lblCaptionCurrentStatus.Margin = new Padding(4, 0, 4, 0);
            lblCaptionCurrentStatus.Name = "lblCaptionCurrentStatus";
            lblCaptionCurrentStatus.Size = new Size(116, 21);
            lblCaptionCurrentStatus.TabIndex = 0;
            lblCaptionCurrentStatus.Text = "Current Status: ";
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.Anchor = AnchorStyles.None;
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblRecipeStatus.Location = new Point(40, 28);
            lblRecipeStatus.Margin = new Padding(4, 0, 4, 0);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(148, 21);
            lblRecipeStatus.TabIndex = 1;
            lblRecipeStatus.Text = "RecipeStatus Here";
            lblRecipeStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmRecipeStatus
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 497);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmRecipeStatus";
            Text = "Recipe Status";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblStatus.ResumeLayout(false);
            tblStatus.PerformLayout();
            tblStatusDisplay.ResumeLayout(false);
            tblStatusDisplay.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblStatus;
        private Button button4;
        private Button button5;
        private Button button6;
        private Label lblRecipeName;
        private Label lblCaptionCurrentStatus;
        private Button btnDraft;
        private Button btnPublish;
        private Button btnArchive;
        private Label label3;
        private Label label4;
        private Label lblCaptionPublished;
        private Label lblCaptionArchived;
        private Label lblDraftTime;
        private Label lblPublishedTime;
        private Label lblArchivedTime;
        private Label lblCaptionDrafted;
        private Label lblStatusDates;
        private TableLayoutPanel tblStatusDisplay;
        private Label lblRecipeStatus;
    }
}