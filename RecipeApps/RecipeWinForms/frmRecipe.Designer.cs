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
            lblCaptionRecipeName = new Label();
            lblCaptionStaff = new Label();
            lblCaptionCalories = new Label();
            lblCaptionCuisineType = new Label();
            tblMain = new TableLayoutPanel();
            lstUserName = new ComboBox();
            txtRecipeName = new TextBox();
            txtCalories = new TextBox();
            lstCuisineTypeName = new ComboBox();
            tblButtons = new TableLayoutPanel();
            btnSave = new Button();
            btnChangeStatus = new Button();
            btnDelete = new Button();
            lblCaptionCurrentStatus = new Label();
            lblRecipeStatus = new Label();
            lblCaptionStatusDates = new Label();
            tblStatusDates = new TableLayoutPanel();
            lblDraftTime = new Label();
            lblPublishedTime = new Label();
            lblArchivedTime = new Label();
            lblCaptionDrafted = new Label();
            lblCaptionPublished = new Label();
            lblCaptionArchived = new Label();
            tabs = new TabControl();
            tbIngredients = new TabPage();
            tblIngredients = new TableLayoutPanel();
            btnSaveIngredients = new Button();
            gIngredients = new DataGridView();
            tbInstructions = new TabPage();
            tblInstructions = new TableLayoutPanel();
            btnSaveInstructions = new Button();
            gInstructions = new DataGridView();
            tblMain.SuspendLayout();
            tblButtons.SuspendLayout();
            tblStatusDates.SuspendLayout();
            tabs.SuspendLayout();
            tbIngredients.SuspendLayout();
            tblIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredients).BeginInit();
            tbInstructions.SuspendLayout();
            tblInstructions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gInstructions).BeginInit();
            SuspendLayout();
            // 
            // lblCaptionRecipeName
            // 
            lblCaptionRecipeName.Anchor = AnchorStyles.Left;
            lblCaptionRecipeName.AutoSize = true;
            lblCaptionRecipeName.Location = new Point(6, 90);
            lblCaptionRecipeName.Margin = new Padding(6);
            lblCaptionRecipeName.Name = "lblCaptionRecipeName";
            lblCaptionRecipeName.Size = new Size(52, 21);
            lblCaptionRecipeName.TabIndex = 1;
            lblCaptionRecipeName.Text = "&Name";
            // 
            // lblCaptionStaff
            // 
            lblCaptionStaff.Anchor = AnchorStyles.Left;
            lblCaptionStaff.AutoSize = true;
            lblCaptionStaff.Location = new Point(6, 124);
            lblCaptionStaff.Margin = new Padding(6);
            lblCaptionStaff.Name = "lblCaptionStaff";
            lblCaptionStaff.Size = new Size(41, 21);
            lblCaptionStaff.TabIndex = 3;
            lblCaptionStaff.Text = "Sta&ff";
            // 
            // lblCaptionCalories
            // 
            lblCaptionCalories.Anchor = AnchorStyles.Left;
            lblCaptionCalories.AutoSize = true;
            lblCaptionCalories.Location = new Point(6, 191);
            lblCaptionCalories.Margin = new Padding(6);
            lblCaptionCalories.Name = "lblCaptionCalories";
            lblCaptionCalories.Size = new Size(66, 21);
            lblCaptionCalories.TabIndex = 7;
            lblCaptionCalories.Text = "Calo&ries";
            // 
            // lblCaptionCuisineType
            // 
            lblCaptionCuisineType.Anchor = AnchorStyles.Left;
            lblCaptionCuisineType.AutoSize = true;
            lblCaptionCuisineType.Location = new Point(6, 157);
            lblCaptionCuisineType.Margin = new Padding(6);
            lblCaptionCuisineType.Name = "lblCaptionCuisineType";
            lblCaptionCuisineType.Size = new Size(97, 21);
            lblCaptionCuisineType.TabIndex = 5;
            lblCaptionCuisineType.Text = "Cuisine &Type";
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(lblCaptionRecipeName, 0, 1);
            tblMain.Controls.Add(lblCaptionCalories, 0, 4);
            tblMain.Controls.Add(lblCaptionCuisineType, 0, 3);
            tblMain.Controls.Add(lstUserName, 1, 2);
            tblMain.Controls.Add(txtRecipeName, 1, 1);
            tblMain.Controls.Add(lblCaptionStaff, 0, 2);
            tblMain.Controls.Add(txtCalories, 1, 4);
            tblMain.Controls.Add(lstCuisineTypeName, 1, 3);
            tblMain.Controls.Add(tblButtons, 0, 0);
            tblMain.Controls.Add(lblCaptionCurrentStatus, 0, 5);
            tblMain.Controls.Add(lblRecipeStatus, 1, 5);
            tblMain.Controls.Add(lblCaptionStatusDates, 0, 6);
            tblMain.Controls.Add(tblStatusDates, 1, 6);
            tblMain.Controls.Add(tabs, 0, 7);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 8;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 83F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
            tblMain.Size = new Size(657, 633);
            tblMain.TabIndex = 0;
            // 
            // lstUserName
            // 
            lstUserName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lstUserName.DropDownStyle = ComboBoxStyle.DropDownList;
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(124, 123);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(530, 29);
            lstUserName.TabIndex = 4;
            // 
            // txtRecipeName
            // 
            txtRecipeName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtRecipeName.BorderStyle = BorderStyle.FixedSingle;
            txtRecipeName.Location = new Point(124, 86);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(530, 29);
            txtRecipeName.TabIndex = 2;
            // 
            // txtCalories
            // 
            txtCalories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtCalories.BorderStyle = BorderStyle.FixedSingle;
            txtCalories.Location = new Point(124, 187);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(530, 29);
            txtCalories.TabIndex = 8;
            // 
            // lstCuisineTypeName
            // 
            lstCuisineTypeName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lstCuisineTypeName.DropDownStyle = ComboBoxStyle.DropDownList;
            lstCuisineTypeName.FormattingEnabled = true;
            lstCuisineTypeName.Location = new Point(124, 156);
            lstCuisineTypeName.Name = "lstCuisineTypeName";
            lstCuisineTypeName.Size = new Size(530, 29);
            lstCuisineTypeName.TabIndex = 6;
            // 
            // tblButtons
            // 
            tblButtons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tblButtons.ColumnCount = 3;
            tblMain.SetColumnSpan(tblButtons, 2);
            tblButtons.ColumnStyles.Add(new ColumnStyle());
            tblButtons.ColumnStyles.Add(new ColumnStyle());
            tblButtons.ColumnStyles.Add(new ColumnStyle());
            tblButtons.Controls.Add(btnSave, 0, 0);
            tblButtons.Controls.Add(btnChangeStatus, 1, 0);
            tblButtons.Controls.Add(btnDelete, 1, 0);
            tblButtons.Location = new Point(3, 3);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblButtons.Size = new Size(651, 56);
            tblButtons.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.BackColor = Color.Gainsboro;
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 50);
            btnSave.TabIndex = 1;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.Anchor = AnchorStyles.Right;
            btnChangeStatus.BackColor = Color.Gainsboro;
            btnChangeStatus.Location = new Point(508, 3);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(140, 50);
            btnChangeStatus.TabIndex = 2;
            btnChangeStatus.Text = "&Change Status";
            btnChangeStatus.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Left;
            btnDelete.BackColor = Color.Gainsboro;
            btnDelete.Location = new Point(149, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 50);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "&Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // lblCaptionCurrentStatus
            // 
            lblCaptionCurrentStatus.Anchor = AnchorStyles.Left;
            lblCaptionCurrentStatus.AutoSize = true;
            lblCaptionCurrentStatus.Location = new Point(6, 225);
            lblCaptionCurrentStatus.Margin = new Padding(6);
            lblCaptionCurrentStatus.Name = "lblCaptionCurrentStatus";
            lblCaptionCurrentStatus.Size = new Size(109, 21);
            lblCaptionCurrentStatus.TabIndex = 9;
            lblCaptionCurrentStatus.Text = "Current Status";
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.Anchor = AnchorStyles.Left;
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Location = new Point(124, 225);
            lblRecipeStatus.Margin = new Padding(3, 5, 3, 5);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(22, 21);
            lblRecipeStatus.TabIndex = 10;
            lblRecipeStatus.Text = "   ";
            // 
            // lblCaptionStatusDates
            // 
            lblCaptionStatusDates.Anchor = AnchorStyles.Left;
            lblCaptionStatusDates.AutoSize = true;
            lblCaptionStatusDates.Location = new Point(6, 270);
            lblCaptionStatusDates.Margin = new Padding(6);
            lblCaptionStatusDates.Name = "lblCaptionStatusDates";
            lblCaptionStatusDates.Size = new Size(95, 21);
            lblCaptionStatusDates.TabIndex = 11;
            lblCaptionStatusDates.Text = "Status Dates";
            // 
            // tblStatusDates
            // 
            tblStatusDates.ColumnCount = 3;
            tblStatusDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStatusDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStatusDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStatusDates.Controls.Add(lblDraftTime, 0, 1);
            tblStatusDates.Controls.Add(lblPublishedTime, 1, 1);
            tblStatusDates.Controls.Add(lblArchivedTime, 2, 1);
            tblStatusDates.Controls.Add(lblCaptionDrafted, 0, 0);
            tblStatusDates.Controls.Add(lblCaptionPublished, 1, 0);
            tblStatusDates.Controls.Add(lblCaptionArchived, 2, 0);
            tblStatusDates.Location = new Point(124, 255);
            tblStatusDates.Name = "tblStatusDates";
            tblStatusDates.RowCount = 2;
            tblStatusDates.RowStyles.Add(new RowStyle());
            tblStatusDates.RowStyles.Add(new RowStyle());
            tblStatusDates.Size = new Size(411, 51);
            tblStatusDates.TabIndex = 12;
            // 
            // lblDraftTime
            // 
            lblDraftTime.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDraftTime.BackColor = SystemColors.ControlLight;
            lblDraftTime.BorderStyle = BorderStyle.Fixed3D;
            lblDraftTime.Location = new Point(5, 21);
            lblDraftTime.Margin = new Padding(5, 0, 5, 0);
            lblDraftTime.Name = "lblDraftTime";
            lblDraftTime.Size = new Size(126, 30);
            lblDraftTime.TabIndex = 1;
            lblDraftTime.Text = " ";
            lblDraftTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPublishedTime
            // 
            lblPublishedTime.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblPublishedTime.BackColor = SystemColors.ControlLight;
            lblPublishedTime.BorderStyle = BorderStyle.Fixed3D;
            lblPublishedTime.Location = new Point(141, 21);
            lblPublishedTime.Margin = new Padding(5, 0, 5, 0);
            lblPublishedTime.Name = "lblPublishedTime";
            lblPublishedTime.Size = new Size(126, 30);
            lblPublishedTime.TabIndex = 3;
            lblPublishedTime.Text = " ";
            lblPublishedTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblArchivedTime
            // 
            lblArchivedTime.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblArchivedTime.BackColor = SystemColors.ControlLight;
            lblArchivedTime.BorderStyle = BorderStyle.Fixed3D;
            lblArchivedTime.Location = new Point(277, 21);
            lblArchivedTime.Margin = new Padding(5, 0, 5, 0);
            lblArchivedTime.Name = "lblArchivedTime";
            lblArchivedTime.Size = new Size(129, 30);
            lblArchivedTime.TabIndex = 5;
            lblArchivedTime.Text = " ";
            lblArchivedTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCaptionDrafted
            // 
            lblCaptionDrafted.Anchor = AnchorStyles.None;
            lblCaptionDrafted.AutoSize = true;
            lblCaptionDrafted.Location = new Point(37, 0);
            lblCaptionDrafted.Name = "lblCaptionDrafted";
            lblCaptionDrafted.Size = new Size(62, 21);
            lblCaptionDrafted.TabIndex = 0;
            lblCaptionDrafted.Text = "Drafted";
            lblCaptionDrafted.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCaptionPublished
            // 
            lblCaptionPublished.Anchor = AnchorStyles.None;
            lblCaptionPublished.AutoSize = true;
            lblCaptionPublished.Location = new Point(165, 0);
            lblCaptionPublished.Name = "lblCaptionPublished";
            lblCaptionPublished.Size = new Size(78, 21);
            lblCaptionPublished.TabIndex = 2;
            lblCaptionPublished.Text = "Published";
            lblCaptionPublished.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCaptionArchived
            // 
            lblCaptionArchived.Anchor = AnchorStyles.None;
            lblCaptionArchived.AutoSize = true;
            lblCaptionArchived.Location = new Point(306, 0);
            lblCaptionArchived.Name = "lblCaptionArchived";
            lblCaptionArchived.Size = new Size(71, 21);
            lblCaptionArchived.TabIndex = 4;
            lblCaptionArchived.Text = "Archived";
            lblCaptionArchived.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabs
            // 
            tblMain.SetColumnSpan(tabs, 2);
            tabs.Controls.Add(tbIngredients);
            tabs.Controls.Add(tbInstructions);
            tabs.Dock = DockStyle.Fill;
            tabs.Location = new Point(3, 312);
            tabs.Name = "tabs";
            tabs.SelectedIndex = 0;
            tabs.Size = new Size(651, 318);
            tabs.TabIndex = 13;
            // 
            // tbIngredients
            // 
            tbIngredients.Controls.Add(tblIngredients);
            tbIngredients.Location = new Point(4, 30);
            tbIngredients.Name = "tbIngredients";
            tbIngredients.Padding = new Padding(3);
            tbIngredients.Size = new Size(643, 284);
            tbIngredients.TabIndex = 0;
            tbIngredients.Text = "Ingredients";
            tbIngredients.UseVisualStyleBackColor = true;
            // 
            // tblIngredients
            // 
            tblIngredients.ColumnCount = 1;
            tblIngredients.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblIngredients.Controls.Add(btnSaveIngredients, 0, 0);
            tblIngredients.Controls.Add(gIngredients, 0, 1);
            tblIngredients.Dock = DockStyle.Fill;
            tblIngredients.Location = new Point(3, 3);
            tblIngredients.Name = "tblIngredients";
            tblIngredients.RowCount = 2;
            tblIngredients.RowStyles.Add(new RowStyle());
            tblIngredients.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblIngredients.Size = new Size(637, 278);
            tblIngredients.TabIndex = 0;
            // 
            // btnSaveIngredients
            // 
            btnSaveIngredients.Location = new Point(3, 3);
            btnSaveIngredients.Name = "btnSaveIngredients";
            btnSaveIngredients.Size = new Size(110, 40);
            btnSaveIngredients.TabIndex = 0;
            btnSaveIngredients.Text = "Save";
            btnSaveIngredients.UseVisualStyleBackColor = true;
            // 
            // gIngredients
            // 
            gIngredients.AllowUserToOrderColumns = true;
            gIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gIngredients.Dock = DockStyle.Fill;
            gIngredients.Location = new Point(3, 49);
            gIngredients.Name = "gIngredients";
            gIngredients.RowHeadersWidth = 62;
            gIngredients.RowTemplate.Height = 25;
            gIngredients.Size = new Size(631, 226);
            gIngredients.TabIndex = 1;
            // 
            // tbInstructions
            // 
            tbInstructions.Controls.Add(tblInstructions);
            tbInstructions.Location = new Point(4, 24);
            tbInstructions.Name = "tbInstructions";
            tbInstructions.Padding = new Padding(3);
            tbInstructions.Size = new Size(643, 316);
            tbInstructions.TabIndex = 1;
            tbInstructions.Text = "Instructions";
            tbInstructions.UseVisualStyleBackColor = true;
            // 
            // tblInstructions
            // 
            tblInstructions.ColumnCount = 1;
            tblInstructions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblInstructions.Controls.Add(btnSaveInstructions, 0, 0);
            tblInstructions.Controls.Add(gInstructions, 0, 1);
            tblInstructions.Dock = DockStyle.Fill;
            tblInstructions.Location = new Point(3, 3);
            tblInstructions.Name = "tblInstructions";
            tblInstructions.RowCount = 2;
            tblInstructions.RowStyles.Add(new RowStyle());
            tblInstructions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblInstructions.Size = new Size(637, 310);
            tblInstructions.TabIndex = 0;
            // 
            // btnSaveInstructions
            // 
            btnSaveInstructions.BackColor = Color.Gainsboro;
            btnSaveInstructions.Location = new Point(3, 3);
            btnSaveInstructions.Name = "btnSaveInstructions";
            btnSaveInstructions.Size = new Size(110, 40);
            btnSaveInstructions.TabIndex = 0;
            btnSaveInstructions.Text = "Save";
            btnSaveInstructions.UseVisualStyleBackColor = false;
            // 
            // gInstructions
            // 
            gInstructions.AllowUserToOrderColumns = true;
            gInstructions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gInstructions.Dock = DockStyle.Fill;
            gInstructions.Location = new Point(3, 49);
            gInstructions.Name = "gInstructions";
            gInstructions.RowHeadersWidth = 62;
            gInstructions.RowTemplate.Height = 25;
            gInstructions.Size = new Size(631, 258);
            gInstructions.TabIndex = 1;
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 633);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmRecipe";
            Text = "Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblButtons.ResumeLayout(false);
            tblStatusDates.ResumeLayout(false);
            tblStatusDates.PerformLayout();
            tabs.ResumeLayout(false);
            tbIngredients.ResumeLayout(false);
            tblIngredients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gIngredients).EndInit();
            tbInstructions.ResumeLayout(false);
            tblInstructions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gInstructions).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tblMain;
        private Label lblCaptionStaff;
        private Label lblCaptionDraftTime;
        private Label lblCaptionCalories;
        private Label lblCaptionCuisineType;
        private Label lblCaptionRecipeName;
        private TableLayoutPanel tblButtons;
        private Button btnSave;
        private Button btnChangeStatus;
        private Label lblCaptionArchivedTime;
        private Label lblCaptionPublishedTime;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label lblCaptionCurrentStatus;
        private Label lblCaptionStatusDates;
        private Label lbl;
        private Label label3;
        private Label label4;
        private Button btnDelete;
        private ComboBox lstUserName;
        private TextBox txtRecipeName;
        private TextBox txtCalories;
        private ComboBox lstCuisineTypeName;
        private Label lblRecipeStatus;
        private TableLayoutPanel tblStatusDates;
        private Label lblDraftTime;
        private Label lblPublishedTime;
        private Label lblArchivedTime;
        private Label lblCaptionDrafted;
        private Label lblCaptionPublished;
        private Label lblCaptionArchived;
        private TabControl tabs;
        private TabPage tbIngredients;
        private Button btnSaveIngredients;
        private TabPage tbInstructions;
        private Button button1;
        private DataGridView gIngredients;
        private TableLayoutPanel tblIngredients;
        private TableLayoutPanel tblInstructions;
        private Button btnSaveInstructions;
        private DataGridView gInstructions;
    }
}