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
            txtArchivedTime = new TextBox();
            lblCaptionArchivedTime = new Label();
            lblCaptionPublishedTime = new Label();
            lblCaptionDraftTime = new Label();
            lblCaptionName = new Label();
            txtRecipeName = new TextBox();
            tblButtons = new TableLayoutPanel();
            btnSave = new Button();
            btnDelete = new Button();
            dtpDraftTime = new DateTimePicker();
            lblCaptionStaff = new Label();
            lstStaff = new ComboBox();
            lblCaptionCalories = new Label();
            txtCalories = new TextBox();
            lstCuisineType = new ComboBox();
            lblCaptionCuisineType = new Label();
            lblCaptionStatus = new Label();
            lblRecipeStatus = new Label();
            txtPublishedTime = new TextBox();
            tblMain.SuspendLayout();
            tblButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.AutoSize = true;
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(txtArchivedTime, 1, 6);
            tblMain.Controls.Add(lblCaptionArchivedTime, 0, 6);
            tblMain.Controls.Add(lblCaptionPublishedTime, 0, 5);
            tblMain.Controls.Add(lblCaptionDraftTime, 0, 4);
            tblMain.Controls.Add(lblCaptionName, 0, 0);
            tblMain.Controls.Add(txtRecipeName, 1, 0);
            tblMain.Controls.Add(tblButtons, 1, 10);
            tblMain.Controls.Add(dtpDraftTime, 1, 4);
            tblMain.Controls.Add(lblCaptionStaff, 0, 3);
            tblMain.Controls.Add(lstStaff, 1, 3);
            tblMain.Controls.Add(lblCaptionCalories, 0, 1);
            tblMain.Controls.Add(txtCalories, 1, 1);
            tblMain.Controls.Add(lstCuisineType, 1, 2);
            tblMain.Controls.Add(lblCaptionCuisineType, 0, 2);
            tblMain.Controls.Add(lblCaptionStatus, 0, 7);
            tblMain.Controls.Add(lblRecipeStatus, 1, 7);
            tblMain.Controls.Add(txtPublishedTime, 1, 5);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 10;
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
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(497, 373);
            tblMain.TabIndex = 0;
            // 
            // txtArchivedTime
            // 
            txtArchivedTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtArchivedTime.BorderStyle = BorderStyle.FixedSingle;
            txtArchivedTime.Location = new Point(131, 211);
            txtArchivedTime.Name = "txtArchivedTime";
            txtArchivedTime.Size = new Size(363, 29);
            txtArchivedTime.TabIndex = 13;
            // 
            // lblCaptionArchivedTime
            // 
            lblCaptionArchivedTime.Anchor = AnchorStyles.Left;
            lblCaptionArchivedTime.AutoSize = true;
            lblCaptionArchivedTime.Location = new Point(6, 215);
            lblCaptionArchivedTime.Margin = new Padding(6);
            lblCaptionArchivedTime.Name = "lblCaptionArchivedTime";
            lblCaptionArchivedTime.Size = new Size(109, 21);
            lblCaptionArchivedTime.TabIndex = 12;
            lblCaptionArchivedTime.Text = "Archived Time";
            // 
            // lblCaptionPublishedTime
            // 
            lblCaptionPublishedTime.Anchor = AnchorStyles.Left;
            lblCaptionPublishedTime.AutoSize = true;
            lblCaptionPublishedTime.Location = new Point(6, 180);
            lblCaptionPublishedTime.Margin = new Padding(6);
            lblCaptionPublishedTime.Name = "lblCaptionPublishedTime";
            lblCaptionPublishedTime.Size = new Size(116, 21);
            lblCaptionPublishedTime.TabIndex = 10;
            lblCaptionPublishedTime.Text = "Published Time";
            // 
            // lblCaptionDraftTime
            // 
            lblCaptionDraftTime.Anchor = AnchorStyles.Left;
            lblCaptionDraftTime.AutoSize = true;
            lblCaptionDraftTime.Location = new Point(6, 145);
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
            txtRecipeName.Size = new Size(363, 29);
            txtRecipeName.TabIndex = 1;
            // 
            // tblButtons
            // 
            tblButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tblButtons.ColumnCount = 2;
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblButtons.Controls.Add(btnSave, 1, 0);
            tblButtons.Controls.Add(btnDelete, 0, 0);
            tblButtons.Location = new Point(179, 301);
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
            // dtpDraftTime
            // 
            dtpDraftTime.Anchor = AnchorStyles.Left;
            dtpDraftTime.Format = DateTimePickerFormat.Short;
            dtpDraftTime.Location = new Point(131, 141);
            dtpDraftTime.Name = "dtpDraftTime";
            dtpDraftTime.Size = new Size(170, 29);
            dtpDraftTime.TabIndex = 9;
            // 
            // lblCaptionStaff
            // 
            lblCaptionStaff.Anchor = AnchorStyles.Left;
            lblCaptionStaff.AutoSize = true;
            lblCaptionStaff.Location = new Point(6, 111);
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
            lstStaff.Location = new Point(131, 110);
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
            txtCalories.Size = new Size(363, 29);
            txtCalories.TabIndex = 3;
            // 
            // lstCuisineType
            // 
            lstCuisineType.Anchor = AnchorStyles.Left;
            lstCuisineType.FormattingEnabled = true;
            lstCuisineType.Location = new Point(131, 73);
            lstCuisineType.Name = "lstCuisineType";
            lstCuisineType.Size = new Size(170, 29);
            lstCuisineType.TabIndex = 5;
            // 
            // lblCaptionCuisineType
            // 
            lblCaptionCuisineType.Anchor = AnchorStyles.Left;
            lblCaptionCuisineType.AutoSize = true;
            lblCaptionCuisineType.Location = new Point(6, 77);
            lblCaptionCuisineType.Margin = new Padding(6);
            lblCaptionCuisineType.Name = "lblCaptionCuisineType";
            lblCaptionCuisineType.Size = new Size(97, 21);
            lblCaptionCuisineType.TabIndex = 4;
            lblCaptionCuisineType.Text = "Cuisine Type";
            // 
            // lblCaptionStatus
            // 
            lblCaptionStatus.Anchor = AnchorStyles.Left;
            lblCaptionStatus.AutoSize = true;
            lblCaptionStatus.Location = new Point(6, 249);
            lblCaptionStatus.Margin = new Padding(6);
            lblCaptionStatus.Name = "lblCaptionStatus";
            lblCaptionStatus.Size = new Size(52, 21);
            lblCaptionStatus.TabIndex = 14;
            lblCaptionStatus.Text = "Status";
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Location = new Point(131, 249);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(363, 21);
            lblRecipeStatus.TabIndex = 15;
            // 
            // txtPublishedTime
            // 
            txtPublishedTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPublishedTime.BorderStyle = BorderStyle.FixedSingle;
            txtPublishedTime.Location = new Point(131, 176);
            txtPublishedTime.Name = "txtPublishedTime";
            txtPublishedTime.Size = new Size(363, 29);
            txtPublishedTime.TabIndex = 11;
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 373);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmRecipe";
            Text = "Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel tblMain;
        private Label lblCaptionStaff;
        private Label lblCaptionArchivedTime;
        private Label lblCaptionPublishedTime;
        private Label lblCaptionDraftTime;
        private Label lblCaptionStatus;
        private Label lblCaptionCalories;
        private Label lblCaptionCuisineType;
        private Label lblCaptionName;
        private TextBox txtRecipeName;
        private TextBox txtCalories;
        private ComboBox lstStaff;
        private ComboBox lstCuisineType;
        private DateTimePicker dtpDraftTime;
        private Label lblRecipeStatus;
        private TextBox txtArchivedTime;
        private TextBox txtPublishedTime;
        private TableLayoutPanel tblButtons;
        private Button btnSave;
        private Button btnDelete;
    }
}