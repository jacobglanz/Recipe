namespace RecipeWinForms
{
    partial class frmRecipeList
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
            btnNewRecipe = new Button();
            gRecipes = new DataGridView();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipes).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(btnNewRecipe, 0, 0);
            tblMain.Controls.Add(gRecipes, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(972, 721);
            tblMain.TabIndex = 0;
            // 
            // btnNewRecipe
            // 
            btnNewRecipe.Anchor = AnchorStyles.Left;
            btnNewRecipe.BackColor = Color.Gainsboro;
            btnNewRecipe.Location = new Point(10, 10);
            btnNewRecipe.Margin = new Padding(10);
            btnNewRecipe.Name = "btnNewRecipe";
            btnNewRecipe.Size = new Size(140, 50);
            btnNewRecipe.TabIndex = 1;
            btnNewRecipe.Text = "&New Recipe";
            btnNewRecipe.UseVisualStyleBackColor = false;
            // 
            // gRecipes
            // 
            gRecipes.AllowUserToAddRows = false;
            gRecipes.AllowUserToDeleteRows = false;
            gRecipes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gRecipes.BackgroundColor = SystemColors.Control;
            gRecipes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gRecipes.Dock = DockStyle.Fill;
            gRecipes.Location = new Point(3, 73);
            gRecipes.Name = "gRecipes";
            gRecipes.ReadOnly = true;
            gRecipes.RowTemplate.Height = 25;
            gRecipes.Size = new Size(966, 645);
            gRecipes.TabIndex = 0;
            gRecipes.KeyDown += GRecipes_KeyDown;
            // 
            // frmRecipeList
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(972, 721);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmRecipeList";
            Text = "Recipes";
            tblMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gRecipes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Button btnNewRecipe;
        private DataGridView gRecipes;
    }
}