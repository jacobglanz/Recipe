using System.Data;

namespace RecipeWinForms
{
    public partial class frmCookbookAutoCreate : Form
    {
        public frmCookbookAutoCreate()
        {
            InitializeComponent();
            btnCreateCookbook.Click += BtnCreateCookbook_Click;
            WindowsFormsUtility.SetListBinding(lstUsername, DataMaintenance.GetAll(DataMaintenance.DataType.Staff), null, "Staff");
        }

        private void CreateCookbook()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtCookbook = Cookbook.CreateForUser((int)lstUsername.SelectedValue);
                if (dtCookbook.Rows.Count == 1 && dtCookbook.Columns.Contains("CookbookId"))
                {
                    ((frmMain)MdiParent).OpenForm(typeof(frmCookbook), (int)dtCookbook.Rows[0]["CookbookId"]);
                    this.Close();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnCreateCookbook_Click(object? sender, EventArgs e)
        {
            CreateCookbook();
        }

    }
}
