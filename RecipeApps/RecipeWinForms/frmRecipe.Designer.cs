namespace RecipeWinForms
{
    partial class frmRecipe
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
            lblArchivedTime = new Label();
            lblPublishedTime = new Label();
            lblDraftTime = new Label();
            lblCaptionArchivedTime = new Label();
            lblCaptionPublishedTime = new Label();
            lblCaptionDraftTime = new Label();
            lblCaptionName = new Label();
            txtRecipeName = new TextBox();
            lblCaptionStaff = new Label();
            lstStaff = new ComboBox();
            lblCaptionCalories = new Label();
            txtCalories = new TextBox();
            lstCuisineType = new ComboBox();
            lblCaptionCuisineType = new Label();
            tblButtons = new TableLayoutPanel();
            btnSave = new Button();
            btnDelete = new Button();
            tblStatusBtns = new TableLayoutPanel();
            btnArchive = new Button();
            btnPublish = new Button();
            btnDraft = new Button();
            lblCaptionSaveAs = new Label();
            tblMain.SuspendLayout();
            tblButtons.SuspendLayout();
            tblStatusBtns.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.AutoSize = true;
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(lblArchivedTime, 1, 6);
            tblMain.Controls.Add(lblPublishedTime, 1, 5);
            tblMain.Controls.Add(lblDraftTime, 1, 4);
            tblMain.Controls.Add(lblCaptionArchivedTime, 0, 6);
            tblMain.Controls.Add(lblCaptionPublishedTime, 0, 5);
            tblMain.Controls.Add(lblCaptionDraftTime, 0, 4);
            tblMain.Controls.Add(lblCaptionName, 0, 0);
            tblMain.Controls.Add(txtRecipeName, 1, 0);
            tblMain.Controls.Add(lblCaptionStaff, 0, 3);
            tblMain.Controls.Add(lstStaff, 1, 3);
            tblMain.Controls.Add(lblCaptionCalories, 0, 1);
            tblMain.Controls.Add(txtCalories, 1, 1);
            tblMain.Controls.Add(lstCuisineType, 1, 2);
            tblMain.Controls.Add(lblCaptionCuisineType, 0, 2);
            tblMain.Controls.Add(tblButtons, 1, 9);
            tblMain.Controls.Add(tblStatusBtns, 1, 7);
            tblMain.Controls.Add(lblCaptionSaveAs, 0, 7);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 5;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(490, 423);
            tblMain.TabIndex = 0;
            // 
            // lblArchivedTime
            // 
            lblArchivedTime.Anchor = AnchorStyles.Left;
            lblArchivedTime.AutoSize = true;
            lblArchivedTime.Location = new Point(134, 208);
            lblArchivedTime.Margin = new Padding(6);
            lblArchivedTime.Name = "lblArchivedTime";
            lblArchivedTime.Size = new Size(0, 21);
            lblArchivedTime.TabIndex = 24;
            // 
            // lblPublishedTime
            // 
            lblPublishedTime.Anchor = AnchorStyles.Left;
            lblPublishedTime.AutoSize = true;
            lblPublishedTime.Location = new Point(134, 175);
            lblPublishedTime.Margin = new Padding(6);
            lblPublishedTime.Name = "lblPublishedTime";
            lblPublishedTime.Size = new Size(0, 21);
            lblPublishedTime.TabIndex = 23;
            // 
            // lblDraftTime
            // 
            lblDraftTime.Anchor = AnchorStyles.Left;
            lblDraftTime.AutoSize = true;
            lblDraftTime.Location = new Point(134, 142);
            lblDraftTime.Margin = new Padding(6);
            lblDraftTime.Name = "lblDraftTime";
            lblDraftTime.Size = new Size(0, 21);
            lblDraftTime.TabIndex = 22;
            // 
            // lblCaptionArchivedTime
            // 
            lblCaptionArchivedTime.Anchor = AnchorStyles.Left;
            lblCaptionArchivedTime.AutoSize = true;
            lblCaptionArchivedTime.Location = new Point(6, 208);
            lblCaptionArchivedTime.Margin = new Padding(6);
            lblCaptionArchivedTime.Name = "lblCaptionArchivedTime";
            lblCaptionArchivedTime.Size = new Size(109, 21);
            lblCaptionArchivedTime.TabIndex = 21;
            lblCaptionArchivedTime.Text = "Archived Time";
            // 
            // lblCaptionPublishedTime
            // 
            lblCaptionPublishedTime.Anchor = AnchorStyles.Left;
            lblCaptionPublishedTime.AutoSize = true;
            lblCaptionPublishedTime.Location = new Point(6, 175);
            lblCaptionPublishedTime.Margin = new Padding(6);
            lblCaptionPublishedTime.Name = "lblCaptionPublishedTime";
            lblCaptionPublishedTime.Size = new Size(116, 21);
            lblCaptionPublishedTime.TabIndex = 20;
            lblCaptionPublishedTime.Text = "Published Time";
            // 
            // lblCaptionDraftTime
            // 
            lblCaptionDraftTime.Anchor = AnchorStyles.Left;
            lblCaptionDraftTime.AutoSize = true;
            lblCaptionDraftTime.Location = new Point(6, 142);
            lblCaptionDraftTime.Margin = new Padding(6);
            lblCaptionDraftTime.Name = "lblCaptionDraftTime";
            lblCaptionDraftTime.Size = new Size(83, 21);
            lblCaptionDraftTime.TabIndex = 8;
            lblCaptionDraftTime.Text = "Draft Time";
            // 
            // lblCaptionName
            // 
            lblCaptionName.Anchor = AnchorStyles.Left;
            lblCaptionName.AutoSize = true;
            lblCaptionName.Location = new Point(6, 7);
            lblCaptionName.Margin = new Padding(6);
            lblCaptionName.Name = "lblCaptionName";
            lblCaptionName.Size = new Size(102, 21);
            lblCaptionName.TabIndex = 0;
            lblCaptionName.Text = "Recipe Name";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtRecipeName.BorderStyle = BorderStyle.FixedSingle;
            txtRecipeName.Location = new Point(131, 3);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(356, 29);
            txtRecipeName.TabIndex = 1;
            // 
            // lblCaptionStaff
            // 
            lblCaptionStaff.Anchor = AnchorStyles.Left;
            lblCaptionStaff.AutoSize = true;
            lblCaptionStaff.Location = new Point(6, 109);
            lblCaptionStaff.Margin = new Padding(6);
            lblCaptionStaff.Name = "lblCaptionStaff";
            lblCaptionStaff.Size = new Size(41, 21);
            lblCaptionStaff.TabIndex = 6;
            lblCaptionStaff.Text = "Staff";
            // 
            // lstStaff
            // 
            lstStaff.Anchor = AnchorStyles.Left;
            lstStaff.FormattingEnabled = true;
            lstStaff.Location = new Point(131, 108);
            lstStaff.Name = "lstStaff";
            lstStaff.Size = new Size(170, 29);
            lstStaff.TabIndex = 7;
            // 
            // lblCaptionCalories
            // 
            lblCaptionCalories.Anchor = AnchorStyles.Left;
            lblCaptionCalories.AutoSize = true;
            lblCaptionCalories.Location = new Point(6, 42);
            lblCaptionCalories.Margin = new Padding(6);
            lblCaptionCalories.Name = "lblCaptionCalories";
            lblCaptionCalories.Size = new Size(66, 21);
            lblCaptionCalories.TabIndex = 2;
            lblCaptionCalories.Text = "Calories";
            // 
            // txtCalories
            // 
            txtCalories.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtCalories.BorderStyle = BorderStyle.FixedSingle;
            txtCalories.Location = new Point(131, 38);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(356, 29);
            txtCalories.TabIndex = 3;
            // 
            // lstCuisineType
            // 
            lstCuisineType.Anchor = AnchorStyles.Left;
            lstCuisineType.FormattingEnabled = true;
            lstCuisineType.Location = new Point(131, 75);
            lstCuisineType.Name = "lstCuisineType";
            lstCuisineType.Size = new Size(170, 29);
            lstCuisineType.TabIndex = 5;
            // 
            // lblCaptionCuisineType
            // 
            lblCaptionCuisineType.Anchor = AnchorStyles.Left;
            lblCaptionCuisineType.AutoSize = true;
            lblCaptionCuisineType.Location = new Point(6, 76);
            lblCaptionCuisineType.Margin = new Padding(6);
            lblCaptionCuisineType.Name = "lblCaptionCuisineType";
            lblCaptionCuisineType.Size = new Size(97, 21);
            lblCaptionCuisineType.TabIndex = 4;
            lblCaptionCuisineType.Text = "Cuisine Type";
            // 
            // tblButtons
            // 
            tblButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tblButtons.ColumnCount = 2;
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblButtons.Controls.Add(btnSave, 1, 0);
            tblButtons.Controls.Add(btnDelete, 0, 0);
            tblButtons.Location = new Point(172, 351);
            tblButtons.Margin = new Padding(3, 20, 3, 3);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblButtons.Size = new Size(315, 69);
            tblButtons.TabIndex = 16;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.Location = new Point(172, 13);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(128, 42);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.Location = new Point(14, 13);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(128, 42);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // tblStatusBtns
            // 
            tblStatusBtns.Anchor = AnchorStyles.Left;
            tblStatusBtns.ColumnCount = 3;
            tblStatusBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStatusBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStatusBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStatusBtns.Controls.Add(btnArchive, 2, 0);
            tblStatusBtns.Controls.Add(btnPublish, 1, 0);
            tblStatusBtns.Controls.Add(btnDraft, 0, 0);
            tblStatusBtns.Location = new Point(131, 238);
            tblStatusBtns.Name = "tblStatusBtns";
            tblStatusBtns.RowCount = 1;
            tblStatusBtns.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblStatusBtns.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblStatusBtns.Size = new Size(354, 44);
            tblStatusBtns.TabIndex = 19;
            // 
            // btnArchive
            // 
            btnArchive.Anchor = AnchorStyles.None;
            btnArchive.BackColor = Color.AliceBlue;
            btnArchive.Location = new Point(246, 3);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new Size(97, 38);
            btnArchive.TabIndex = 2;
            btnArchive.Text = "Archived";
            btnArchive.UseVisualStyleBackColor = false;
            // 
            // btnPublish
            // 
            btnPublish.Anchor = AnchorStyles.None;
            btnPublish.BackColor = Color.AliceBlue;
            btnPublish.Location = new Point(128, 3);
            btnPublish.Name = "btnPublish";
            btnPublish.Size = new Size(97, 38);
            btnPublish.TabIndex = 1;
            btnPublish.Text = "Published";
            btnPublish.UseVisualStyleBackColor = false;
            // 
            // btnDraft
            // 
            btnDraft.Anchor = AnchorStyles.None;
            btnDraft.BackColor = Color.AliceBlue;
            btnDraft.Location = new Point(10, 3);
            btnDraft.Name = "btnDraft";
            btnDraft.Size = new Size(97, 38);
            btnDraft.TabIndex = 0;
            btnDraft.Text = "Draft";
            btnDraft.UseVisualStyleBackColor = false;
            // 
            // lblCaptionSaveAs
            // 
            lblCaptionSaveAs.Anchor = AnchorStyles.Left;
            lblCaptionSaveAs.AutoSize = true;
            lblCaptionSaveAs.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCaptionSaveAs.Location = new Point(6, 249);
            lblCaptionSaveAs.Margin = new Padding(6);
            lblCaptionSaveAs.Name = "lblCaptionSaveAs";
            lblCaptionSaveAs.Size = new Size(78, 21);
            lblCaptionSaveAs.TabIndex = 14;
            lblCaptionSaveAs.Text = "Set Status";
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 423);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmRecipe";
            Text = "Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblButtons.ResumeLayout(false);
            tblStatusBtns.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel tblMain;
        private Label lblCaptionStaff;
        private Label lblCaptionDraftTime;
        private Label lblCaptionSaveAs;
        private Label lblCaptionCalories;
        private Label lblCaptionCuisineType;
        private Label lblCaptionName;
        private TextBox txtRecipeName;
        private TextBox txtCalories;
        private ComboBox lstStaff;
        private ComboBox lstCuisineType;
        private TableLayoutPanel tblStatusBtns;
        private Button btnArchive;
        private Button btnPublish;
        private Button btnDraft;
        private TableLayoutPanel tblButtons;
        private Button btnSave;
        private Button btnDelete;
        private Label lblArchivedTime;
        private Label lblPublishedTime;
        private Label lblDraftTime;
        private Label lblCaptionArchivedTime;
        private Label lblCaptionPublishedTime;
    }
}