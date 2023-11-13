namespace RecipeWinForms
{
    partial class frmSearch
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
            tblSearch = new TableLayoutPanel();
            lblCaptionRecipeName = new Label();
            txtSearchBox = new TextBox();
            btnSearch = new Button();
            gRecipes = new DataGridView();
            tblMain.SuspendLayout();
            tblSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipes).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(tblSearch, 0, 0);
            tblMain.Controls.Add(gRecipes, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(4);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(968, 643);
            tblMain.TabIndex = 0;
            // 
            // tblSearch
            // 
            tblSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tblSearch.AutoSize = true;
            tblSearch.ColumnCount = 3;
            tblSearch.ColumnStyles.Add(new ColumnStyle());
            tblSearch.ColumnStyles.Add(new ColumnStyle());
            tblSearch.ColumnStyles.Add(new ColumnStyle());
            tblSearch.Controls.Add(lblCaptionRecipeName, 0, 0);
            tblSearch.Controls.Add(txtSearchBox, 1, 0);
            tblSearch.Controls.Add(btnSearch, 2, 0);
            tblSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tblSearch.Location = new Point(4, 4);
            tblSearch.Margin = new Padding(4);
            tblSearch.Name = "tblSearch";
            tblSearch.RowCount = 1;
            tblSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblSearch.Size = new Size(960, 50);
            tblSearch.TabIndex = 0;
            // 
            // lblCaptionRecipeName
            // 
            lblCaptionRecipeName.Anchor = AnchorStyles.Left;
            lblCaptionRecipeName.AutoSize = true;
            lblCaptionRecipeName.Location = new Point(3, 14);
            lblCaptionRecipeName.Name = "lblCaptionRecipeName";
            lblCaptionRecipeName.Size = new Size(102, 21);
            lblCaptionRecipeName.TabIndex = 0;
            lblCaptionRecipeName.Text = "Recipe Name";
            // 
            // txtSearchBox
            // 
            txtSearchBox.Anchor = AnchorStyles.Left;
            txtSearchBox.Location = new Point(111, 10);
            txtSearchBox.Name = "txtSearchBox";
            txtSearchBox.Size = new Size(266, 29);
            txtSearchBox.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Left;
            btnSearch.Location = new Point(383, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(141, 44);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // gRecipes
            // 
            gRecipes.AllowUserToAddRows = false;
            gRecipes.AllowUserToDeleteRows = false;
            gRecipes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gRecipes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gRecipes.Dock = DockStyle.Fill;
            gRecipes.Location = new Point(3, 61);
            gRecipes.Name = "gRecipes";
            gRecipes.ReadOnly = true;
            gRecipes.RowTemplate.Height = 25;
            gRecipes.Size = new Size(962, 579);
            gRecipes.TabIndex = 1;
            // 
            // frmSearch
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(968, 643);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmSearch";
            Text = "Search Recipes";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblSearch.ResumeLayout(false);
            tblSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblSearch;
        private Label lblCaptionRecipeName;
        private TextBox txtSearchBox;
        private Button btnSearch;
        private DataGridView gRecipes;
    }
}