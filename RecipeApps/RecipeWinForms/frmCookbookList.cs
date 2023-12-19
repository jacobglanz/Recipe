using System.Data;

namespace RecipeWinForms
{
    public partial class frmCookbookList : Form
    {
        DataTable dtCookBooks = new();
        public frmCookbookList()
        {
            InitializeComponent();

            gCookbooks.KeyDown += GCookbooks_KeyDown;
            gCookbooks.CellDoubleClick += GCookbooks_CellDoubleClick;
            btnNewCookbook.Click += BtnNewCookbook_Click;
            this.Activated += FrmCookbookList_Activated;
        }

        private void LoadForm()
        {
            dtCookBooks = Cookbook.GetAll();
            gCookbooks.DataSource = dtCookBooks;
            WindowsFormsUtility.FormatGridForSearchResults(gCookbooks);
        }

        public void OpenForm(int rowIndex)
        {
            int id = 0;
            if (rowIndex > -1)
            {
                id = WindowsFormsUtility.GetPkIdFromGrid(gCookbooks, "CookBookId", rowIndex);
            }
            ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbook), id);
        }

        private void GCookbooks_KeyDown(object? sender, KeyEventArgs e)
        
        {
            if (gCookbooks.CurrentCell != null && e.KeyCode == Keys.Enter)
            {
                OpenForm(gCookbooks.CurrentCell.RowIndex);
            }
        }
        private void GCookbooks_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                OpenForm(e.RowIndex);
            }
        }
        private void BtnNewCookbook_Click(object? sender, EventArgs e)
        {
            OpenForm(-1);
        }
        private void FrmCookbookList_Activated(object? sender, EventArgs e)
        {
            LoadForm();
        }
    }
}
