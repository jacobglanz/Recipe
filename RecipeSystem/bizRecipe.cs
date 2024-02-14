using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizRecipe : bizObject
    {
        int _recipeId;
        int _staffId;
        int _cuisineTypeId;
        string _recipeName = "";
        int _calories;
        DateTime _draftTime;
        DateTime? _publishedTime;
        DateTime? _archivedTime;
        string _recipeStatus = "";

        public int RecipeId
        {
            get => _recipeId;
            set
            {
                _recipeId = value;
                InvokePropertyChanged();
            }
        }

        public int StaffId
        {
            get => _staffId;
            set
            {
                _staffId = value;
                InvokePropertyChanged();
            }
        }

        public int CuisineTypeId
        {
            get => _cuisineTypeId;
            set
            {
                _cuisineTypeId = value;
                InvokePropertyChanged();
            }
        }

        public string RecipeName
        {
            get => _recipeName;
            set
            {
                _recipeName = value;
                InvokePropertyChanged();
            }
        }

        public int Calories
        {
            get => _calories;
            set
            {
                _calories = value;
                InvokePropertyChanged();
            }
        }

        public DateTime DraftTime
        {
            get => _draftTime;
            set
            {
                _draftTime = value;
                InvokePropertyChanged();
            }
        }

        public DateTime? PublishedTime
        {
            get => _publishedTime;
            set
            {
                _publishedTime = value;
                InvokePropertyChanged();
            }
        }

        public DateTime? ArchivedTime
        {
            get => _archivedTime;
            set
            {
                _archivedTime = value;
                InvokePropertyChanged();
            }
        }

        public string RecipeStatus
        {
            get => _recipeStatus;
            set
            {
                _recipeStatus = value;
                InvokePropertyChanged();
            }
        }

    }
}
