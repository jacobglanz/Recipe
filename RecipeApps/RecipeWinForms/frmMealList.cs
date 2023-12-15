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
    public partial class frmMealList : Form
    {
        public frmMealList()
        {
            InitializeComponent();
            LoadForm();
        }

        public void LoadForm()
        {
            gMeals.DataSource = Meal.GetAll();
            WindowsFormsUtility.FormatGridForSearchResults(gMeals, "Meal");
        }
    }
}
