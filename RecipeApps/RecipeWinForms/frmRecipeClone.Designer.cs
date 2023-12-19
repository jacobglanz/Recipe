namespace RecipeWinForms
{
    partial class frmRecipeClone
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
            lstRecipeName = new ComboBox();
            btnClone = new Button();
            tblMain = new TableLayoutPanel();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // lstRecipeName
            // 
            lstRecipeName.Anchor = AnchorStyles.Bottom;
            lstRecipeName.DropDownStyle = ComboBoxStyle.DropDownList;
            lstRecipeName.FormattingEnabled = true;
            lstRecipeName.Location = new Point(313, 217);
            lstRecipeName.Margin = new Padding(2, 3, 2, 21);
            lstRecipeName.Name = "lstRecipeName";
            lstRecipeName.Size = new Size(300, 29);
            lstRecipeName.TabIndex = 0;
            // 
            // btnClone
            // 
            btnClone.Anchor = AnchorStyles.Top;
            btnClone.BackColor = Color.Gainsboro;
            btnClone.Location = new Point(393, 270);
            btnClone.Margin = new Padding(2, 3, 2, 3);
            btnClone.Name = "btnClone";
            btnClone.Size = new Size(140, 50);
            btnClone.TabIndex = 1;
            btnClone.Text = "&Clone";
            btnClone.UseVisualStyleBackColor = false;
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lstRecipeName, 0, 0);
            tblMain.Controls.Add(btnClone, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(2, 3, 2, 3);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.Size = new Size(927, 535);
            tblMain.TabIndex = 0;
            // 
            // frmRecipeClone
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(927, 535);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmRecipeClone";
            Text = "Clone a Recipe";
            tblMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox lstRecipeName;
        private Button btnClone;
        private TableLayoutPanel tblMain;
    }
}