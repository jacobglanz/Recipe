namespace RecipeWinForms
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            SetUpButtons();
            this.Activated += FrmDashboard_Activated;
        }

        private void SetUpButtons()
        {
            btnRecipeList.Tag = typeof(frmRecipeList);
            btnMealList.Tag = typeof(frmMealList);
            btnCookbookList.Tag = typeof(frmCookbookList);
            lblRefreshSampleData.Click += LblRefreshSampleData_Click;
            foreach (Control c in tblButtons.Controls)
            {
                if (c is Button b)
                {
                    b.Click += B_Click;
                }
            }
        }

        private void LoadDashboard()
        {
            gData.DataSource = DataMaintenance.DashboardGet();
            WindowsFormsUtility.FormatGridForSearchResults(gData);
        }

        private void OpenForm(Type frmType)
        {
            if (MdiParent is frmMain)
            {
                ((frmMain)MdiParent).OpenForm(frmType);
            }
        }


        private void FrmDashboard_Activated(object? sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void B_Click(object? sender, EventArgs e)
        {
            if (sender is Button b)
            {
                OpenForm((Type)b.Tag);
            }
        }

        private void LblRefreshSampleData_Click(object? sender, EventArgs e)
        {
            try
            {
                lblRefreshSampleData.ForeColor = Color.LightSteelBlue;
                this.Cursor = Cursors.WaitCursor;
                DataMaintenance.RefreshSampleData();
                LoadDashboard();
                MessageBox.Show("Data Refreshed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                this.Cursor = Cursors.Default;
                lblRefreshSampleData.ForeColor = Color.RoyalBlue;
            }
        }

    }
}
