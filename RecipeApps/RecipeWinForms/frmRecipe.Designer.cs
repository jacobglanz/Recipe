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
            tableLayoutPanel1 = new TableLayoutPanel();
            txtUsername = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            txtArchivedTime = new TextBox();
            txtPublishedTime = new TextBox();
            txtDraftTime = new TextBox();
            txtStatus = new TextBox();
            txtCalories = new TextBox();
            txtCuisineTypeName = new TextBox();
            lblCaptionStaffUsername = new Label();
            lblCaptionLastName = new Label();
            lblCaptionFirstName = new Label();
            lblCaptionArchivedTime = new Label();
            lblCaptionPublishedTime = new Label();
            lblCaptionDraftTime = new Label();
            lblCaptionStatus = new Label();
            lblCaptionCalories = new Label();
            lblCaptionCuisineTypeName = new Label();
            lblCaptionName = new Label();
            txtRecipeName = new TextBox();
            lblCaptionDetails = new Label();
            gInstructions = new DataGridView();
            gIngredients = new DataGridView();
            lblCaptionIngredients = new Label();
            lblCaptionInstructions = new Label();
            tblMain.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gInstructions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gIngredients).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(tableLayoutPanel1, 0, 0);
            tblMain.Controls.Add(gInstructions, 1, 3);
            tblMain.Controls.Add(gIngredients, 1, 1);
            tblMain.Controls.Add(lblCaptionIngredients, 1, 0);
            tblMain.Controls.Add(lblCaptionInstructions, 1, 2);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.Padding = new Padding(10);
            tblMain.RowCount = 5;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(1018, 694);
            tblMain.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(txtUsername, 1, 10);
            tableLayoutPanel1.Controls.Add(txtLastName, 1, 9);
            tableLayoutPanel1.Controls.Add(txtFirstName, 1, 8);
            tableLayoutPanel1.Controls.Add(txtArchivedTime, 1, 7);
            tableLayoutPanel1.Controls.Add(txtPublishedTime, 1, 6);
            tableLayoutPanel1.Controls.Add(txtDraftTime, 1, 5);
            tableLayoutPanel1.Controls.Add(txtStatus, 1, 4);
            tableLayoutPanel1.Controls.Add(txtCalories, 1, 3);
            tableLayoutPanel1.Controls.Add(txtCuisineTypeName, 1, 2);
            tableLayoutPanel1.Controls.Add(lblCaptionStaffUsername, 0, 10);
            tableLayoutPanel1.Controls.Add(lblCaptionLastName, 0, 9);
            tableLayoutPanel1.Controls.Add(lblCaptionFirstName, 0, 8);
            tableLayoutPanel1.Controls.Add(lblCaptionArchivedTime, 0, 7);
            tableLayoutPanel1.Controls.Add(lblCaptionPublishedTime, 0, 6);
            tableLayoutPanel1.Controls.Add(lblCaptionDraftTime, 0, 5);
            tableLayoutPanel1.Controls.Add(lblCaptionStatus, 0, 4);
            tableLayoutPanel1.Controls.Add(lblCaptionCalories, 0, 3);
            tableLayoutPanel1.Controls.Add(lblCaptionCuisineTypeName, 0, 2);
            tableLayoutPanel1.Controls.Add(lblCaptionName, 0, 1);
            tableLayoutPanel1.Controls.Add(txtRecipeName, 1, 1);
            tableLayoutPanel1.Controls.Add(lblCaptionDetails, 0, 0);
            tableLayoutPanel1.Location = new Point(13, 13);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 11;
            tblMain.SetRowSpan(tableLayoutPanel1, 4);
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(493, 380);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Left;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(152, 348);
            txtUsername.Margin = new Padding(3, 3, 15, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(331, 29);
            txtUsername.TabIndex = 28;
            // 
            // txtLastName
            // 
            txtLastName.Anchor = AnchorStyles.Left;
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Location = new Point(152, 313);
            txtLastName.Margin = new Padding(3, 3, 15, 3);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(331, 29);
            txtLastName.TabIndex = 27;
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = AnchorStyles.Left;
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Location = new Point(152, 278);
            txtFirstName.Margin = new Padding(3, 3, 15, 3);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(331, 29);
            txtFirstName.TabIndex = 26;
            // 
            // txtArchivedTime
            // 
            txtArchivedTime.Anchor = AnchorStyles.Left;
            txtArchivedTime.BorderStyle = BorderStyle.FixedSingle;
            txtArchivedTime.Location = new Point(152, 243);
            txtArchivedTime.Margin = new Padding(3, 3, 15, 3);
            txtArchivedTime.Name = "txtArchivedTime";
            txtArchivedTime.Size = new Size(331, 29);
            txtArchivedTime.TabIndex = 25;
            // 
            // txtPublishedTime
            // 
            txtPublishedTime.Anchor = AnchorStyles.Left;
            txtPublishedTime.BorderStyle = BorderStyle.FixedSingle;
            txtPublishedTime.Location = new Point(152, 208);
            txtPublishedTime.Margin = new Padding(3, 3, 15, 3);
            txtPublishedTime.Name = "txtPublishedTime";
            txtPublishedTime.Size = new Size(331, 29);
            txtPublishedTime.TabIndex = 24;
            // 
            // txtDraftTime
            // 
            txtDraftTime.Anchor = AnchorStyles.Left;
            txtDraftTime.BorderStyle = BorderStyle.FixedSingle;
            txtDraftTime.Location = new Point(152, 173);
            txtDraftTime.Margin = new Padding(3, 3, 15, 3);
            txtDraftTime.Name = "txtDraftTime";
            txtDraftTime.Size = new Size(331, 29);
            txtDraftTime.TabIndex = 23;
            // 
            // txtStatus
            // 
            txtStatus.Anchor = AnchorStyles.Left;
            txtStatus.BorderStyle = BorderStyle.FixedSingle;
            txtStatus.Location = new Point(152, 138);
            txtStatus.Margin = new Padding(3, 3, 15, 3);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(331, 29);
            txtStatus.TabIndex = 22;
            // 
            // txtCalories
            // 
            txtCalories.Anchor = AnchorStyles.Left;
            txtCalories.BorderStyle = BorderStyle.FixedSingle;
            txtCalories.Location = new Point(152, 103);
            txtCalories.Margin = new Padding(3, 3, 15, 3);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(331, 29);
            txtCalories.TabIndex = 21;
            // 
            // txtCuisineTypeName
            // 
            txtCuisineTypeName.Anchor = AnchorStyles.Left;
            txtCuisineTypeName.BorderStyle = BorderStyle.FixedSingle;
            txtCuisineTypeName.Location = new Point(152, 68);
            txtCuisineTypeName.Margin = new Padding(3, 3, 15, 3);
            txtCuisineTypeName.Name = "txtCuisineTypeName";
            txtCuisineTypeName.Size = new Size(331, 29);
            txtCuisineTypeName.TabIndex = 20;
            // 
            // lblCaptionStaffUsername
            // 
            lblCaptionStaffUsername.Anchor = AnchorStyles.Left;
            lblCaptionStaffUsername.AutoSize = true;
            lblCaptionStaffUsername.Location = new Point(3, 352);
            lblCaptionStaffUsername.Name = "lblCaptionStaffUsername";
            lblCaptionStaffUsername.Size = new Size(116, 21);
            lblCaptionStaffUsername.TabIndex = 18;
            lblCaptionStaffUsername.Text = "Staff Username";
            // 
            // lblCaptionLastName
            // 
            lblCaptionLastName.Anchor = AnchorStyles.Left;
            lblCaptionLastName.AutoSize = true;
            lblCaptionLastName.Location = new Point(3, 317);
            lblCaptionLastName.Name = "lblCaptionLastName";
            lblCaptionLastName.Size = new Size(119, 21);
            lblCaptionLastName.TabIndex = 16;
            lblCaptionLastName.Text = "Staff Last Name";
            // 
            // lblCaptionFirstName
            // 
            lblCaptionFirstName.Anchor = AnchorStyles.Left;
            lblCaptionFirstName.AutoSize = true;
            lblCaptionFirstName.Location = new Point(3, 282);
            lblCaptionFirstName.Name = "lblCaptionFirstName";
            lblCaptionFirstName.Size = new Size(121, 21);
            lblCaptionFirstName.TabIndex = 14;
            lblCaptionFirstName.Text = "Staff First Name";
            // 
            // lblCaptionArchivedTime
            // 
            lblCaptionArchivedTime.Anchor = AnchorStyles.Left;
            lblCaptionArchivedTime.AutoSize = true;
            lblCaptionArchivedTime.Location = new Point(3, 247);
            lblCaptionArchivedTime.Name = "lblCaptionArchivedTime";
            lblCaptionArchivedTime.Size = new Size(109, 21);
            lblCaptionArchivedTime.TabIndex = 12;
            lblCaptionArchivedTime.Text = "Archived Time";
            // 
            // lblCaptionPublishedTime
            // 
            lblCaptionPublishedTime.Anchor = AnchorStyles.Left;
            lblCaptionPublishedTime.AutoSize = true;
            lblCaptionPublishedTime.Location = new Point(3, 212);
            lblCaptionPublishedTime.Name = "lblCaptionPublishedTime";
            lblCaptionPublishedTime.Size = new Size(116, 21);
            lblCaptionPublishedTime.TabIndex = 10;
            lblCaptionPublishedTime.Text = "Published Time";
            // 
            // lblCaptionDraftTime
            // 
            lblCaptionDraftTime.Anchor = AnchorStyles.Left;
            lblCaptionDraftTime.AutoSize = true;
            lblCaptionDraftTime.Location = new Point(3, 177);
            lblCaptionDraftTime.Name = "lblCaptionDraftTime";
            lblCaptionDraftTime.Size = new Size(83, 21);
            lblCaptionDraftTime.TabIndex = 8;
            lblCaptionDraftTime.Text = "Draft Time";
            // 
            // lblCaptionStatus
            // 
            lblCaptionStatus.Anchor = AnchorStyles.Left;
            lblCaptionStatus.AutoSize = true;
            lblCaptionStatus.Location = new Point(3, 142);
            lblCaptionStatus.Name = "lblCaptionStatus";
            lblCaptionStatus.Size = new Size(52, 21);
            lblCaptionStatus.TabIndex = 6;
            lblCaptionStatus.Text = "Status";
            // 
            // lblCaptionCalories
            // 
            lblCaptionCalories.Anchor = AnchorStyles.Left;
            lblCaptionCalories.AutoSize = true;
            lblCaptionCalories.Location = new Point(3, 107);
            lblCaptionCalories.Name = "lblCaptionCalories";
            lblCaptionCalories.Size = new Size(66, 21);
            lblCaptionCalories.TabIndex = 4;
            lblCaptionCalories.Text = "Calories";
            // 
            // lblCaptionCuisineTypeName
            // 
            lblCaptionCuisineTypeName.Anchor = AnchorStyles.Left;
            lblCaptionCuisineTypeName.AutoSize = true;
            lblCaptionCuisineTypeName.Location = new Point(3, 72);
            lblCaptionCuisineTypeName.Name = "lblCaptionCuisineTypeName";
            lblCaptionCuisineTypeName.Size = new Size(143, 21);
            lblCaptionCuisineTypeName.TabIndex = 2;
            lblCaptionCuisineTypeName.Text = "Cuisine Type Name";
            // 
            // lblCaptionName
            // 
            lblCaptionName.Anchor = AnchorStyles.Left;
            lblCaptionName.AutoSize = true;
            lblCaptionName.Location = new Point(3, 37);
            lblCaptionName.Name = "lblCaptionName";
            lblCaptionName.Size = new Size(102, 21);
            lblCaptionName.TabIndex = 0;
            lblCaptionName.Text = "Recipe Name";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Anchor = AnchorStyles.Left;
            txtRecipeName.BorderStyle = BorderStyle.FixedSingle;
            txtRecipeName.Location = new Point(152, 33);
            txtRecipeName.Margin = new Padding(3, 3, 30, 3);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(331, 29);
            txtRecipeName.TabIndex = 19;
            // 
            // lblCaptionDetails
            // 
            lblCaptionDetails.AutoSize = true;
            lblCaptionDetails.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCaptionDetails.Location = new Point(3, 0);
            lblCaptionDetails.Name = "lblCaptionDetails";
            lblCaptionDetails.Size = new Size(63, 21);
            lblCaptionDetails.TabIndex = 29;
            lblCaptionDetails.Text = "Details";
            // 
            // gInstructions
            // 
            gInstructions.AllowUserToAddRows = false;
            gInstructions.AllowUserToDeleteRows = false;
            gInstructions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gInstructions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gInstructions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gInstructions.BackgroundColor = SystemColors.Control;
            gInstructions.BorderStyle = BorderStyle.None;
            gInstructions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gInstructions.Location = new Point(512, 346);
            gInstructions.Margin = new Padding(3, 10, 3, 3);
            gInstructions.Name = "gInstructions";
            gInstructions.ReadOnly = true;
            gInstructions.RowTemplate.Height = 25;
            gInstructions.Size = new Size(493, 248);
            gInstructions.TabIndex = 1;
            // 
            // gIngredients
            // 
            gIngredients.AllowUserToAddRows = false;
            gIngredients.AllowUserToDeleteRows = false;
            gIngredients.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gIngredients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gIngredients.BackgroundColor = SystemColors.Control;
            gIngredients.BorderStyle = BorderStyle.None;
            gIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gIngredients.Location = new Point(512, 41);
            gIngredients.Margin = new Padding(3, 10, 3, 3);
            gIngredients.Name = "gIngredients";
            gIngredients.ReadOnly = true;
            gIngredients.RowTemplate.Height = 25;
            gIngredients.Size = new Size(493, 221);
            gIngredients.TabIndex = 0;
            // 
            // lblCaptionIngredients
            // 
            lblCaptionIngredients.AutoSize = true;
            lblCaptionIngredients.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCaptionIngredients.Location = new Point(512, 10);
            lblCaptionIngredients.Name = "lblCaptionIngredients";
            lblCaptionIngredients.Size = new Size(97, 21);
            lblCaptionIngredients.TabIndex = 3;
            lblCaptionIngredients.Text = "Ingredients";
            // 
            // lblCaptionInstructions
            // 
            lblCaptionInstructions.AutoSize = true;
            lblCaptionInstructions.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCaptionInstructions.Location = new Point(512, 315);
            lblCaptionInstructions.Margin = new Padding(3, 50, 3, 0);
            lblCaptionInstructions.Name = "lblCaptionInstructions";
            lblCaptionInstructions.Size = new Size(100, 21);
            lblCaptionInstructions.TabIndex = 4;
            lblCaptionInstructions.Text = "Instructions";
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 694);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmRecipe";
            Text = "Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gInstructions).EndInit();
            ((System.ComponentModel.ISupportInitialize)gIngredients).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private DataGridView gIngredients;
        private DataGridView gInstructions;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblCaptionStaffUsername;
        private Label lblCaptionLastName;
        private Label lblCaptionFirstName;
        private Label lblCaptionArchivedTime;
        private Label lblCaptionPublishedTime;
        private Label lblCaptionDraftTime;
        private Label lblCaptionStatus;
        private Label lblCaptionCalories;
        private Label lblCaptionCuisineTypeName;
        private Label lblCaptionName;
        private TextBox txtRecipeName;
        private TextBox txtUsername;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtArchivedTime;
        private TextBox txtPublishedTime;
        private TextBox txtDraftTime;
        private TextBox txtStatus;
        private TextBox txtCalories;
        private TextBox txtCuisineTypeName;
        private Label lblCaptionIngredients;
        private Label lblCaptionInstructions;
        private Label lblCaptionDetails;
    }
}