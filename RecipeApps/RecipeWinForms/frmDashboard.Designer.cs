namespace RecipeWinForms
{
    partial class frmDashboard
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
            gData = new DataGridView();
            tblButtons = new TableLayoutPanel();
            btnMealList = new Button();
            btnRecipeList = new Button();
            btnCookbookList = new Button();
            lblHeader = new Label();
            lblDesc = new Label();
            tblMain = new TableLayoutPanel();
            lblRefreshSampleData = new Label();
            ((System.ComponentModel.ISupportInitialize)gData).BeginInit();
            tblButtons.SuspendLayout();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // gData
            // 
            gData.AllowUserToDeleteRows = false;
            gData.AllowUserToOrderColumns = true;
            gData.Anchor = AnchorStyles.None;
            gData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gData.BackgroundColor = SystemColors.Control;
            gData.BorderStyle = BorderStyle.None;
            gData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gData.Location = new Point(265, 297);
            gData.Name = "gData";
            gData.ReadOnly = true;
            gData.RowTemplate.Height = 25;
            gData.Size = new Size(230, 110);
            gData.TabIndex = 2;
            gData.TabStop = false;
            // 
            // tblButtons
            // 
            tblButtons.Anchor = AnchorStyles.None;
            tblButtons.ColumnCount = 3;
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.Controls.Add(btnMealList, 1, 0);
            tblButtons.Controls.Add(btnRecipeList, 0, 0);
            tblButtons.Controls.Add(btnCookbookList, 2, 0);
            tblButtons.Location = new Point(162, 527);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblButtons.Size = new Size(436, 59);
            tblButtons.TabIndex = 3;
            // 
            // btnMealList
            // 
            btnMealList.Anchor = AnchorStyles.None;
            btnMealList.BackColor = Color.Gainsboro;
            btnMealList.Location = new Point(148, 4);
            btnMealList.Name = "btnMealList";
            btnMealList.Size = new Size(139, 50);
            btnMealList.TabIndex = 1;
            btnMealList.Text = "&Meals";
            btnMealList.UseVisualStyleBackColor = false;
            // 
            // btnRecipeList
            // 
            btnRecipeList.Anchor = AnchorStyles.None;
            btnRecipeList.BackColor = Color.Gainsboro;
            btnRecipeList.Location = new Point(3, 4);
            btnRecipeList.Name = "btnRecipeList";
            btnRecipeList.Size = new Size(139, 50);
            btnRecipeList.TabIndex = 0;
            btnRecipeList.Text = "&Recipes";
            btnRecipeList.UseVisualStyleBackColor = false;
            // 
            // btnCookbookList
            // 
            btnCookbookList.Anchor = AnchorStyles.None;
            btnCookbookList.BackColor = Color.Gainsboro;
            btnCookbookList.Location = new Point(293, 4);
            btnCookbookList.Name = "btnCookbookList";
            btnCookbookList.Size = new Size(140, 50);
            btnCookbookList.TabIndex = 2;
            btnCookbookList.Text = "&Cookbooks";
            btnCookbookList.UseVisualStyleBackColor = false;
            // 
            // lblHeader
            // 
            lblHeader.Anchor = AnchorStyles.None;
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblHeader.Location = new Point(226, 81);
            lblHeader.Margin = new Padding(3, 50, 3, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(308, 32);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Hearty Hearth Desktop App";
            // 
            // lblDesc
            // 
            lblDesc.Anchor = AnchorStyles.None;
            lblDesc.AutoSize = true;
            lblDesc.Location = new Point(205, 138);
            lblDesc.Margin = new Padding(3, 25, 3, 0);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(351, 42);
            lblDesc.TabIndex = 1;
            lblDesc.Text = "Welcome to the Hearty Hearth desktop app.\r\nIn this app you can create recipes and cookbooks.";
            lblDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(lblDesc, 0, 2);
            tblMain.Controls.Add(lblHeader, 0, 1);
            tblMain.Controls.Add(tblButtons, 0, 4);
            tblMain.Controls.Add(gData, 0, 3);
            tblMain.Controls.Add(lblRefreshSampleData, 0, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.Padding = new Padding(0, 0, 0, 50);
            tblMain.RowCount = 5;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(761, 639);
            tblMain.TabIndex = 0;
            // 
            // lblRefreshSampleData
            // 
            lblRefreshSampleData.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRefreshSampleData.AutoSize = true;
            lblRefreshSampleData.ForeColor = Color.RoyalBlue;
            lblRefreshSampleData.Location = new Point(577, 0);
            lblRefreshSampleData.Name = "lblRefreshSampleData";
            lblRefreshSampleData.Size = new Size(181, 21);
            lblRefreshSampleData.TabIndex = 4;
            lblRefreshSampleData.Text = "🔃 Refresh Sample &Data";
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(761, 639);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmDashboard";
            Text = "Hearty Health - Dashboard";
            ((System.ComponentModel.ISupportInitialize)gData).EndInit();
            tblButtons.ResumeLayout(false);
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gData;
        private TableLayoutPanel tblButtons;
        private Button btnMealList;
        private Button btnRecipeList;
        private Button btnCookbookList;
        private Label lblHeader;
        private Label lblDesc;
        private TableLayoutPanel tblMain;
        private Label lblRefreshSampleData;
    }
}