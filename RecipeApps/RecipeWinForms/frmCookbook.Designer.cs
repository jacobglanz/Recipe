namespace RecipeWinForms
{
    partial class frmCookbook
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
            lblCaptionPrice = new Label();
            btnDelete = new Button();
            btnSave = new Button();
            btnSaveRecipes = new Button();
            lblCaptionName = new Label();
            lblCaptionActive = new Label();
            cbxActive = new CheckBox();
            lblCaptionStaff = new Label();
            tblPrice = new TableLayoutPanel();
            txtPrice = new TextBox();
            txtCaptionCreatedDate = new Label();
            lblCreatedDate = new Label();
            gRecipes = new DataGridView();
            txtCookBookName = new TextBox();
            lstUserName = new ComboBox();
            tblMain.SuspendLayout();
            tblPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipes).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.Controls.Add(lblCaptionPrice, 0, 3);
            tblMain.Controls.Add(btnDelete, 1, 0);
            tblMain.Controls.Add(btnSave, 0, 0);
            tblMain.Controls.Add(btnSaveRecipes, 0, 5);
            tblMain.Controls.Add(lblCaptionName, 0, 1);
            tblMain.Controls.Add(lblCaptionActive, 0, 4);
            tblMain.Controls.Add(cbxActive, 1, 4);
            tblMain.Controls.Add(lblCaptionStaff, 0, 2);
            tblMain.Controls.Add(tblPrice, 1, 3);
            tblMain.Controls.Add(gRecipes, 0, 6);
            tblMain.Controls.Add(txtCookBookName, 1, 1);
            tblMain.Controls.Add(lstUserName, 1, 2);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 7;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(722, 588);
            tblMain.TabIndex = 0;
            // 
            // lblCaptionPrice
            // 
            lblCaptionPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCaptionPrice.AutoSize = true;
            lblCaptionPrice.Location = new Point(10, 197);
            lblCaptionPrice.Margin = new Padding(10);
            lblCaptionPrice.Name = "lblCaptionPrice";
            lblCaptionPrice.Size = new Size(44, 21);
            lblCaptionPrice.TabIndex = 6;
            lblCaptionPrice.Text = "&Price";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Left;
            btnDelete.BackColor = Color.Gainsboro;
            btnDelete.Location = new Point(163, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 50);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "&Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.BackColor = Color.Gainsboro;
            btnSave.Location = new Point(10, 10);
            btnSave.Margin = new Padding(10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 50);
            btnSave.TabIndex = 0;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnSaveRecipes
            // 
            btnSaveRecipes.Anchor = AnchorStyles.Left;
            btnSaveRecipes.BackColor = Color.Transparent;
            btnSaveRecipes.Location = new Point(10, 279);
            btnSaveRecipes.Margin = new Padding(10);
            btnSaveRecipes.Name = "btnSaveRecipes";
            btnSaveRecipes.Size = new Size(110, 40);
            btnSaveRecipes.TabIndex = 10;
            btnSaveRecipes.Text = "Save Recipes";
            btnSaveRecipes.UseVisualStyleBackColor = false;
            // 
            // lblCaptionName
            // 
            lblCaptionName.Anchor = AnchorStyles.Left;
            lblCaptionName.AutoSize = true;
            lblCaptionName.Location = new Point(10, 80);
            lblCaptionName.Margin = new Padding(10);
            lblCaptionName.Name = "lblCaptionName";
            lblCaptionName.Size = new Size(52, 21);
            lblCaptionName.TabIndex = 2;
            lblCaptionName.Text = "&Name";
            // 
            // lblCaptionActive
            // 
            lblCaptionActive.Anchor = AnchorStyles.Left;
            lblCaptionActive.AutoSize = true;
            lblCaptionActive.Location = new Point(10, 238);
            lblCaptionActive.Margin = new Padding(10);
            lblCaptionActive.Name = "lblCaptionActive";
            lblCaptionActive.Size = new Size(52, 21);
            lblCaptionActive.TabIndex = 8;
            lblCaptionActive.Text = "Active";
            // 
            // cbxActive
            // 
            cbxActive.Anchor = AnchorStyles.Left;
            cbxActive.AutoSize = true;
            cbxActive.Location = new Point(163, 241);
            cbxActive.Name = "cbxActive";
            cbxActive.Size = new Size(15, 14);
            cbxActive.TabIndex = 9;
            cbxActive.UseVisualStyleBackColor = true;
            // 
            // lblCaptionStaff
            // 
            lblCaptionStaff.AutoSize = true;
            lblCaptionStaff.Location = new Point(10, 121);
            lblCaptionStaff.Margin = new Padding(10);
            lblCaptionStaff.Name = "lblCaptionStaff";
            lblCaptionStaff.Size = new Size(41, 21);
            lblCaptionStaff.TabIndex = 4;
            lblCaptionStaff.Text = "Sta&ff";
            // 
            // tblPrice
            // 
            tblPrice.AutoSize = true;
            tblPrice.ColumnCount = 2;
            tblPrice.ColumnStyles.Add(new ColumnStyle());
            tblPrice.ColumnStyles.Add(new ColumnStyle());
            tblPrice.Controls.Add(txtPrice, 0, 1);
            tblPrice.Controls.Add(txtCaptionCreatedDate, 1, 0);
            tblPrice.Controls.Add(lblCreatedDate, 1, 1);
            tblPrice.Location = new Point(163, 155);
            tblPrice.Name = "tblPrice";
            tblPrice.RowCount = 2;
            tblPrice.RowStyles.Add(new RowStyle());
            tblPrice.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPrice.Size = new Size(262, 70);
            tblPrice.TabIndex = 7;
            // 
            // txtPrice
            // 
            txtPrice.Anchor = AnchorStyles.None;
            txtPrice.BorderStyle = BorderStyle.FixedSingle;
            txtPrice.Location = new Point(3, 31);
            txtPrice.Margin = new Padding(3, 10, 50, 10);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 29);
            txtPrice.TabIndex = 0;
            // 
            // txtCaptionCreatedDate
            // 
            txtCaptionCreatedDate.Anchor = AnchorStyles.None;
            txtCaptionCreatedDate.AutoSize = true;
            txtCaptionCreatedDate.Location = new Point(156, 0);
            txtCaptionCreatedDate.Name = "txtCaptionCreatedDate";
            txtCaptionCreatedDate.Size = new Size(103, 21);
            txtCaptionCreatedDate.TabIndex = 1;
            txtCaptionCreatedDate.Text = "Date Created:";
            // 
            // lblCreatedDate
            // 
            lblCreatedDate.Anchor = AnchorStyles.None;
            lblCreatedDate.AutoSize = true;
            lblCreatedDate.BackColor = SystemColors.Control;
            lblCreatedDate.Location = new Point(207, 35);
            lblCreatedDate.Name = "lblCreatedDate";
            lblCreatedDate.Size = new Size(0, 21);
            lblCreatedDate.TabIndex = 1;
            // 
            // gRecipes
            // 
            gRecipes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tblMain.SetColumnSpan(gRecipes, 2);
            gRecipes.Dock = DockStyle.Fill;
            gRecipes.Location = new Point(3, 332);
            gRecipes.Name = "gRecipes";
            gRecipes.RowTemplate.Height = 25;
            gRecipes.Size = new Size(721, 253);
            gRecipes.TabIndex = 11;
            // 
            // txtCookBookName
            // 
            txtCookBookName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtCookBookName.BorderStyle = BorderStyle.FixedSingle;
            txtCookBookName.Location = new Point(163, 76);
            txtCookBookName.Name = "txtCookBookName";
            txtCookBookName.Size = new Size(561, 29);
            txtCookBookName.TabIndex = 3;
            // 
            // lstUserName
            // 
            lstUserName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lstUserName.DropDownStyle = ComboBoxStyle.DropDownList;
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(163, 120);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(561, 29);
            lstUserName.TabIndex = 5;
            // 
            // frmCookbook
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(722, 588);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmCookbook";
            Text = "Cookbook";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblPrice.ResumeLayout(false);
            tblPrice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Button btnDelete;
        private Button btnSave;
        private Label lblCaptionName;
        private Label lblCaptionStaff;
        private Label lblPrice;
        private Label lblCaptionActive;
        private CheckBox cbxActive;
        private TableLayoutPanel tblPrice;
        private Label txtCaptionCreatedDate;
        private TextBox txtPrice;
        private Button btnSaveRecipes;
        private Label lblCreatedDate;
        private DataGridView gRecipes;
        private TextBox txtCookBookName;
        private ComboBox lstUserName;
        private Label lblCaptionPrice;
    }
}