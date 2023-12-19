using System.Data;
namespace RecipeWinForms
{
    public partial class frmDataMaintenance : Form
    {
        string deleteColName = "deleteCol";
        DataTable dt = new();
        DataMaintenance.DataType currentDataType;
        RadioButton currentRB = new();

        public frmDataMaintenance()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            gData.CellContentClick += GData_CellContentClick;

            optStaff.Tag = DataMaintenance.DataType.Staff;
            optCuisines.Tag = DataMaintenance.DataType.CuisineType;
            optIngredients.Tag = DataMaintenance.DataType.Ingredient;
            optMeasurements.Tag = DataMaintenance.DataType.UnitOfMeasure;
            optCourses.Tag = DataMaintenance.DataType.Course;
            foreach (Control c in flpDataTypes.Controls)
            {
                if (c is RadioButton)
                {
                    c.Click += C_Click;
                }
            }
        }


        private bool LoadGrid(DataMaintenance.DataType dataType)
        {
            if (dt.GetChanges() != null)
            {
                DialogResult res = MessageBox.Show($"Wanna save your {currentDataType} changes before leaving?", Application.ProductName, MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    if (!Save())
                    {
                        return false;
                    }
                }
            }

            currentDataType = dataType;
            gData.Columns.Clear();
            dt = DataMaintenance.GetAll(currentDataType);
            gData.DataSource = dt;
            WindowsFormsUtility.FormatGridForEdit(gData);
            WindowsFormsUtility.AddDeleteButtonToGrid(gData, deleteColName);

            return true;
        }

        private void Delete(int rowIndex)
        {
            string deletePrompt = "Are you sure you want to delete this " + currentDataType switch
            {
                DataMaintenance.DataType.Staff => "User and all related recipes, meals, and cookbooks?",
                DataMaintenance.DataType.CuisineType => "Cuisine and all related recipes?",
                DataMaintenance.DataType.Ingredient => "Ingredient and remove it from recipes?",
                DataMaintenance.DataType.UnitOfMeasure => "Measurement and remove it from recipes' ingredients?",
                DataMaintenance.DataType.Course => "Course and remove it from Meals?",
            };
            DialogResult res = MessageBox.Show(deletePrompt, Application.ProductName, MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return;
            }

            int pkId = WindowsFormsUtility.GetPkIdFromGrid(gData, currentDataType + "Id", rowIndex);
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataMaintenance.DeleteRecord(currentDataType, pkId);
                LoadGrid(currentDataType);
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

        private bool Save()
        {
            bool b = true;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataMaintenance.SaveAll(currentDataType, dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
                b = false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return b;
        }

        private void GData_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (gData.Columns[e.ColumnIndex].Name == deleteColName && e.RowIndex > -1)
            {
                if (gData.Rows[e.RowIndex].Cells[currentDataType + "id"].Value.ToString() != "")
                {
                    Delete(e.RowIndex);
                }
            }
        }
        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }
        private void C_Click(object? sender, EventArgs e)
        {
            if (sender is RadioButton rb)
            {
                if (LoadGrid((DataMaintenance.DataType)rb.Tag))
                {
                    currentRB = rb; //switch to new
                }
                else
                {
                    currentRB.Checked = true; //change back bacause or error at unsaved table
                }
            }
        }

    }
}
