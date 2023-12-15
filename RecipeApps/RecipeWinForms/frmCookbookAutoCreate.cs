using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                ((frmMain)MdiParent).OpenForm(typeof(frmCookbook), (int)dtCookbook.Rows[0]["CookbookId"]);
                this.Close();
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
