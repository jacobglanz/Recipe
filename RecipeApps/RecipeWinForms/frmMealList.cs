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
            WindowsFormsUtility.FormatGridForSearchResults(gMeals);
        }
    }
}
