/*
HeartyHearthDB


CuisineType
    CuisineTypeName varchar(30) unique
CourseType
    CourseTypeName varchar(30) unique (Appetizer, Dessert, etc.)
    Sequence int unique
UnitOfMeasure
    UnitName varchar(30) unique
Ingredient
    IngredientName varchar(30) unique
    IngredientImage concat(Ingredient_, IngredientName(Replace space with _), .jpg)



User
    FirstName varchar(30)
    LastName varchar(30)
    Username varchar(50)
    unique FirstName, LastName
Meal
    UserId (fk User)
    MealName varchar(30) Unique
    Active bit
    MealImage concat(Meal_, MealName(Replace space with _), .jpg)
    CreatedAt date default to current date

MealCourse
    MealId (fk Meal)
    CourseTypeId (fk CourseType)
    unique MealId, CourseTypeId

Recipe
    UserId (fk User)
    CuisineTypeId (fk CuisineType)
    RecipeName varchar(30) unique
    Calories int
    DraftTime Datetime default to CurrentTime
    PublishedTime Datetime null
    ArchivedTime Datetime null
    Status 
        when ArchivedTime not null then Archived
        when PublishedTime not null then Published
        else Draft
    RecipeImage concat(Recipe_, RecipeName(Replace space with _), .jpg)
    check (DraftTime < PublishedTime < ArchivedTime)
RecipeIngredient
    RecipeId (fk Recipe)
    IngredientId (fk Ingredient)
    UnitOfMeasureId (fk UnitOfMeasure)
    Amount decimal(8,3)
    Sequence int
    unique RecipeId, IngredientId
    unique RecipeId, Sequence

Direction:
    RecipeId (fk Recipe)
    Sequence int
    Action varchar(30)
    unique RecipeId, Sequence

MealCourseRecipe
    MealCourseId (fk MealCourse)
    RecipeId (fk Recipe)
    MainDish bit
    unique MealCourseId, RecipeId
    unique -if Sequence is not null- MealCourseId, Sequence 


CookBook
    UserId (fk User)
    CookBookName varchar(100) Unique
    Price decimal(6,2)
    Active bit
    CookBookImage concat(CookBook_, CookBookName(Replace space with _), .jpg)
    CreatedAt date default to current date
CookBookRecipe
    CookBookId (fk CookBook)
    RecipeId (fk Recipe)
    Sequence int
    unique CookBookId, RecipeId
    unique CookBookId, Sequence

*/
