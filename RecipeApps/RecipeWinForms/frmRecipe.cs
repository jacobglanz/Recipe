using CPUFramework;
using CPUWindowsFormsFramework;
using System.Data;
using System.Diagnostics;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtRecipe;
        DataTable dtStaff;
        DataTable dtCuisineType;
        public frmRecipe()
        {
            InitializeComponent();
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BtnSave_Click;
        }

        public void ShowForm(int recipeId)
        {
            foreach (Control c in tblMain.Controls)
            {
                c.DataBindings.Clear();
            }

            string sql = "select r.RecipeId, r.StaffId, r.CuisineTypeId, r.RecipeName, r.Calories, r.DraftTime, r.PublishedTime, r.ArchivedTime, r.RecipeStatus from Recipe r where r.RecipeId = " + recipeId;
            dtRecipe = SQLUtility.GetDateTable(sql);
            if (recipeId < 1)
            {
                dtRecipe.Rows.Add();
            }
            dtStaff = SQLUtility.GetDateTable("select * from Staff");
            dtCuisineType = SQLUtility.GetDateTable("select * from CuisineType");

            WindowsFormsUtility.SetControlBinding(txtRecipeName, dtRecipe);
            WindowsFormsUtility.SetControlBinding(txtCalories, dtRecipe);
            WindowsFormsUtility.SetControlBinding(lblRecipeStatus, dtRecipe);
            WindowsFormsUtility.SetControlBinding(dtpDraftTime, dtRecipe);
            WindowsFormsUtility.SetControlBinding(txtPublishedTime, dtRecipe);
            WindowsFormsUtility.SetControlBinding(txtArchivedTime, dtRecipe);
            WindowsFormsUtility.SetListBinding(lstStaff, dtStaff, dtRecipe, "Staff");
            WindowsFormsUtility.SetListBinding(lstCuisineType, dtCuisineType, dtRecipe, "CuisineType");
            this.Show();
        }

        private void Save()
        {
            string sql = "";
            DataRow r = dtRecipe.Rows[0];

            string publishedDate = r["PublishedTime"].ToString() == "" ? "null" : $"'{r["PublishedTime"]}'";
            string archivedTime = r["ArchivedTime"].ToString() == "" ? "null" : $"'{r["ArchivedTime"]}'";

            if ((int)r["RecipeId"] == 0)
            {
                sql = "insert Recipe (StaffId, CuisineTypeId, RecipeName, Calories, DraftTime, PublishedTime, ArchivedTime) ";
                sql += $"select {r["StaffId"]}, {r["CuisineTypeId"]}, '{r["RecipeName"]}', {r["Calories"]}, '{r["DraftTime"]}', {publishedDate}, {archivedTime}";
                SQLUtility.ExecuteSQL(sql);
                int newRecipeId = (int)SQLUtility.GetDateTable("select top 1 RecipeId from Recipe order by RecipeId Desc").Rows[0][0];
                ShowForm(newRecipeId);
            }
            else
            {
                sql = string.Join(Environment.NewLine, "update Recipe",
                    $"set StaffId = {r["StaffId"]},",
                    $"CuisineTypeId = {r["CuisineTypeId"]},",
                    $"RecipeName = '{r["RecipeName"]}',",
                    $"Calories = {r["Calories"]},",
                    $"DraftTime = '{r["DraftTime"]}',",
                    $"PublishedTime = {publishedDate},",
                    $"ArchivedTime = {archivedTime}",
                    $"where Recipeid = {r["RecipeId"]}"
                    );
                SQLUtility.ExecuteSQL(sql);
            }
            //Debug.Print(sql);
        }
        private void Delete()
        {
            int recipeId = (int)dtRecipe.Rows[0]["RecipeId"];
            SQLUtility.ExecuteSQL("delete recipe where RecipeId = " + recipeId);
            this.Close();
        }
        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

    }
}
