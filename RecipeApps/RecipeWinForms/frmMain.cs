namespace RecipeWinForms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            mnuDashboard.Click += MnuDashboard;
            mnuRecipeList.Click += MnuRecipeList_Click;
            mnuNewRecipe.Click += MnuNewRecipe_Click;
            mnuMealsList.Click += MnuMealsList_Click;
            mnuCookbookList.Click += MnuCookbookList_Click;
            mnuTile.Click += MnuTile_Click;
            mnuCascade.Click += MnuCascade_Click;
            mnuNewCookbook.Click += MnuNewCookbook_Click;
            mnuEditDataMaintenance.Click += MnuEditDataMaintenance_Click;
            mnuCloneRecipe.Click += MnuCloneRecipe_Click;
            mnuCookbookAutoCreate.Click += MnuCookbookAutoCreate_Click;
            this.Shown += FrmMain_Shown;
        }

        private void FrmMain_Shown(object? sender, EventArgs e)
        {
            frmLogin f = new() { StartPosition = FormStartPosition.CenterParent };
            if (!f.ShowLogin())
            {
                this.Close();
                Application.Exit();
            }

            OpenForm(typeof(frmDashboard));
        }

        public void OpenForm(Type frmType, int pkId = 0)
        {
            Form? newFrm = null;
            if (!WindowsFormsUtility.FormIsOpenAlredy(frmType, pkId))
            {
                if (frmType == typeof(frmDashboard))
                {
                    newFrm = new frmDashboard();
                }
                else if (frmType == typeof(frmRecipeList))
                {
                    newFrm = new frmRecipeList();
                }
                else if (frmType == typeof(frmCookbookList))
                {
                    newFrm = new frmCookbookList();
                }
                else if (frmType == typeof(frmMealList))
                {
                    newFrm = new frmMealList();
                }
                else if (frmType == typeof(frmDataMaintenance))
                {
                    newFrm = new frmDataMaintenance();
                }
                else if (frmType == typeof(frmRecipeClone))
                {
                    newFrm = new frmRecipeClone();
                }
                else if (frmType == typeof(frmCookbookAutoCreate))
                {
                    newFrm = new frmCookbookAutoCreate();
                }
                else if (frmType == typeof(frmRecipe))
                {

                    frmRecipe f = new();
                    f.LoadForm(pkId);
                    newFrm = f;
                }
                else if (frmType == typeof(frmRecipeStatus))
                {
                    frmRecipeStatus f = new();
                    f.LoadForm(pkId);
                    newFrm = f;
                }
                else if (frmType == typeof(frmCookbook))
                {
                    frmCookbook f = new();
                    f.LoadForm(pkId);
                    newFrm = f;
                }

                if (newFrm != null)
                {
                    newFrm.MdiParent = this;
                    newFrm.WindowState = FormWindowState.Maximized;
                    newFrm.FormClosed += NewFrm_FormClosed;
                    newFrm.TextChanged += NewFrm_TextChanged;
                    newFrm.Show();
                }
            }
            WindowsFormsUtility.SetUpNav(tsMain);
        }


        private void NewFrm_TextChanged(object? sender, EventArgs e)
        {
            WindowsFormsUtility.SetUpNav(tsMain);
        }

        private void NewFrm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            WindowsFormsUtility.SetUpNav(tsMain);
        }

        private void MnuDashboard(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDashboard));
        }
        private void MnuRecipeList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmRecipeList));
        }
        private void MnuNewRecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmRecipe));
        }
        private void MnuMealsList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmMealList));
        }
        private void MnuCookbookList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCookbookList));
        }
        private void MnuNewCookbook_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCookbook));
        }
        private void MnuEditDataMaintenance_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDataMaintenance));
        }
        private void MnuCloneRecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmRecipeClone));
        }
        private void MnuCookbookAutoCreate_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCookbookAutoCreate));
        }

        private void MnuCascade_Click(object? sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }
        private void MnuTile_Click(object? sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }


    }
}
