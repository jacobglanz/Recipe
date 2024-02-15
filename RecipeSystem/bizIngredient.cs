using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizIngredient : bizObject<bizIngredient>
    {
        int _ingredientId;
        string _ingredientName = "";

        public List<bizIngredient> Search(string searchValue)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "IngredientName", searchValue);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return GetListFromDataTable(dt);
        }

        public int IngredientId
        {
            get => _ingredientId;
            set
            {
                _ingredientId = value;
                InvokePropertyChanged();
            }
        }

        public string IngredientName
        {
            get => _ingredientName;
            set
            {
                _ingredientName = value;
                InvokePropertyChanged();
            }
        }
    }
}
