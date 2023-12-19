namespace RecipeWinForms
{
    partial class frmCookbookAutoCreate
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
            lstUsername = new ComboBox();
            btnCreateCookbook = new Button();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lstUsername, 0, 0);
            tblMain.Controls.Add(btnCreateCookbook, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.Size = new Size(759, 542);
            tblMain.TabIndex = 3;
            // 
            // lstUsername
            // 
            lstUsername.Anchor = AnchorStyles.Bottom;
            lstUsername.DropDownStyle = ComboBoxStyle.DropDownList;
            lstUsername.FormattingEnabled = true;
            lstUsername.Location = new Point(229, 216);
            lstUsername.Margin = new Padding(3, 3, 3, 26);
            lstUsername.Name = "lstUsername";
            lstUsername.Size = new Size(300, 29);
            lstUsername.TabIndex = 0;
            // 
            // btnCreateCookbook
            // 
            btnCreateCookbook.Anchor = AnchorStyles.Top;
            btnCreateCookbook.BackColor = Color.Gainsboro;
            btnCreateCookbook.Location = new Point(309, 274);
            btnCreateCookbook.Name = "btnCreateCookbook";
            btnCreateCookbook.Size = new Size(140, 50);
            btnCreateCookbook.TabIndex = 1;
            btnCreateCookbook.Text = "&Create Cookbook";
            btnCreateCookbook.UseVisualStyleBackColor = false;
            // 
            // frmCookbookAutoCreate
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 542);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmCookbookAutoCreate";
            Text = "Auto-Create a Cookbook";
            tblMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private ComboBox lstUsername;
        private Button btnCreateCookbook;
    }
}