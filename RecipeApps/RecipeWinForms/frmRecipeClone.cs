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
    public partial class frmRecipeClone : Form
    {
        public frmRecipeClone()
        {
            InitializeComponent();
            btnClone.Click += BtnClone_Click;

            WindowsFormsUtility.SetListBinding(lstRecipeName, Recipe.GetAll(), null, "Recipe");
        }

        private void CloneRecipe()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtNewRecipe = Recipe.Clone((int)lstRecipeName.SelectedValue);
                ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipe), (int)dtNewRecipe.Rows[0]["RecipeId"]);
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

        private void BtnClone_Click(object? sender, EventArgs e)
        {
            CloneRecipe();
        }

    }
}
