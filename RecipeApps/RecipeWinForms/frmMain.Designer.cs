namespace RecipeWinForms
{
    partial class frmMain
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
            mnuMain = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuDashboard = new ToolStripMenuItem();
            mnuRecipes = new ToolStripMenuItem();
            mnuRecipeList = new ToolStripMenuItem();
            mnuNewRecipe = new ToolStripMenuItem();
            mnuCloneRecipe = new ToolStripMenuItem();
            mnuMeals = new ToolStripMenuItem();
            mnuMealsList = new ToolStripMenuItem();
            mnuCookbooks = new ToolStripMenuItem();
            mnuCookbookList = new ToolStripMenuItem();
            mnuNewCookbook = new ToolStripMenuItem();
            mnuCookbookAutoCreate = new ToolStripMenuItem();
            mnuDataMaintenance = new ToolStripMenuItem();
            mnuEditDataMaintenance = new ToolStripMenuItem();
            mnuWindow = new ToolStripMenuItem();
            mnuTile = new ToolStripMenuItem();
            mnuCascade = new ToolStripMenuItem();
            tsMain = new ToolStrip();
            mnuMain.SuspendLayout();
            SuspendLayout();
            // 
            // mnuMain
            // 
            mnuMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            mnuMain.Items.AddRange(new ToolStripItem[] { mnuFile, mnuRecipes, mnuMeals, mnuCookbooks, mnuDataMaintenance, mnuWindow });
            mnuMain.Location = new Point(0, 0);
            mnuMain.Margin = new Padding(0, 0, 0, 5);
            mnuMain.Name = "mnuMain";
            mnuMain.Padding = new Padding(5, 2, 0, 2);
            mnuMain.Size = new Size(738, 29);
            mnuMain.TabIndex = 0;
            mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuDashboard });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(46, 25);
            mnuFile.Text = "&File";
            // 
            // mnuDashboard
            // 
            mnuDashboard.Name = "mnuDashboard";
            mnuDashboard.Size = new Size(180, 26);
            mnuDashboard.Text = "Dashoboard";
            // 
            // mnuRecipes
            // 
            mnuRecipes.DropDownItems.AddRange(new ToolStripItem[] { mnuRecipeList, mnuNewRecipe, mnuCloneRecipe });
            mnuRecipes.Name = "mnuRecipes";
            mnuRecipes.Size = new Size(75, 25);
            mnuRecipes.Text = "&Recipes";
            // 
            // mnuRecipeList
            // 
            mnuRecipeList.Name = "mnuRecipeList";
            mnuRecipeList.Size = new Size(180, 26);
            mnuRecipeList.Text = "Recipes";
            // 
            // mnuNewRecipe
            // 
            mnuNewRecipe.Name = "mnuNewRecipe";
            mnuNewRecipe.Size = new Size(180, 26);
            mnuNewRecipe.Text = "New Recipe";
            // 
            // mnuCloneRecipe
            // 
            mnuCloneRecipe.Name = "mnuCloneRecipe";
            mnuCloneRecipe.Size = new Size(180, 26);
            mnuCloneRecipe.Text = "Clone Recipe";
            // 
            // mnuMeals
            // 
            mnuMeals.DropDownItems.AddRange(new ToolStripItem[] { mnuMealsList });
            mnuMeals.Name = "mnuMeals";
            mnuMeals.Size = new Size(63, 25);
            mnuMeals.Text = "&Meals";
            // 
            // mnuMealsList
            // 
            mnuMealsList.Name = "mnuMealsList";
            mnuMealsList.Size = new Size(180, 26);
            mnuMealsList.Text = "Meals";
            // 
            // mnuCookbooks
            // 
            mnuCookbooks.DropDownItems.AddRange(new ToolStripItem[] { mnuCookbookList, mnuNewCookbook, mnuCookbookAutoCreate });
            mnuCookbooks.Name = "mnuCookbooks";
            mnuCookbooks.Size = new Size(100, 25);
            mnuCookbooks.Text = "&Cookbooks";
            // 
            // mnuCookbookList
            // 
            mnuCookbookList.Name = "mnuCookbookList";
            mnuCookbookList.Size = new Size(187, 26);
            mnuCookbookList.Text = "Cookbooks";
            // 
            // mnuNewCookbook
            // 
            mnuNewCookbook.Name = "mnuNewCookbook";
            mnuNewCookbook.Size = new Size(187, 26);
            mnuNewCookbook.Text = "New Cookbook";
            // 
            // mnuCookbookAutoCreate
            // 
            mnuCookbookAutoCreate.Name = "mnuCookbookAutoCreate";
            mnuCookbookAutoCreate.Size = new Size(187, 26);
            mnuCookbookAutoCreate.Text = "Auto-Create";
            // 
            // mnuDataMaintenance
            // 
            mnuDataMaintenance.DropDownItems.AddRange(new ToolStripItem[] { mnuEditDataMaintenance });
            mnuDataMaintenance.Name = "mnuDataMaintenance";
            mnuDataMaintenance.Size = new Size(147, 25);
            mnuDataMaintenance.Text = "Data &Maintenance";
            // 
            // mnuEditDataMaintenance
            // 
            mnuEditDataMaintenance.Name = "mnuEditDataMaintenance";
            mnuEditDataMaintenance.Size = new Size(180, 26);
            mnuEditDataMaintenance.Text = "Edit Data";
            // 
            // mnuWindow
            // 
            mnuWindow.DropDownItems.AddRange(new ToolStripItem[] { mnuTile, mnuCascade });
            mnuWindow.Name = "mnuWindow";
            mnuWindow.Size = new Size(80, 25);
            mnuWindow.Text = "&Window";
            // 
            // mnuTile
            // 
            mnuTile.Name = "mnuTile";
            mnuTile.Size = new Size(180, 26);
            mnuTile.Text = "Tile";
            // 
            // mnuCascade
            // 
            mnuCascade.Name = "mnuCascade";
            mnuCascade.Size = new Size(180, 26);
            mnuCascade.Text = "Cascade";
            // 
            // tsMain
            // 
            tsMain.AutoSize = false;
            tsMain.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tsMain.Location = new Point(0, 29);
            tsMain.Margin = new Padding(3);
            tsMain.Name = "tsMain";
            tsMain.Size = new Size(738, 30);
            tsMain.TabIndex = 1;
            tsMain.Text = "toolStrip1";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 695);
            Controls.Add(tsMain);
            Controls.Add(mnuMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            IsMdiContainer = true;
            Margin = new Padding(4);
            MinimumSize = new Size(600, 600);
            Name = "frmMain";
            Text = "Hearty Health";
            mnuMain.ResumeLayout(false);
            mnuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuMain;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuDashboard;
        private ToolStripMenuItem mnuRecipes;
        private ToolStripMenuItem mnuRecipeList;
        private ToolStripMenuItem mnuNewRecipe;
        private ToolStripMenuItem mnuCloneRecipe;
        private ToolStrip tsMain;
        private ToolStripMenuItem mnuWindow;
        private ToolStripMenuItem mnuMeals;
        private ToolStripMenuItem mnuMealsList;
        private ToolStripMenuItem mnuCookbooks;
        private ToolStripMenuItem mnuCookbookList;
        private ToolStripMenuItem mnuNewCookbook;
        private ToolStripMenuItem mnuCookbookAutoCreate;
        private ToolStripMenuItem mnuTile;
        private ToolStripMenuItem mnuCascade;
        private ToolStripMenuItem mnuDataMaintenance;
        private ToolStripMenuItem mnuEditDataMaintenance;
    }
}