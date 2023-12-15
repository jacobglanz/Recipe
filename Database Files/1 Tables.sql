use HeartyHearthDB
    go
    drop table if exists CookBookRecipe
    drop table if exists CookBook
    drop table if exists MealCourseRecipe
    drop table if exists RecipeInstruction
    drop table if exists RecipeIngredient
    drop table if exists Recipe
    drop table if exists MealCourse
    drop table if exists Meal
    drop table if exists Staff
    drop table if exists Ingredient
    drop table if exists UnitOfMeasure
    drop table if exists Course
    drop table if exists CuisineType
    go

--Master Tables
create table dbo.CuisineType(
    CuisineTypeId int not null identity primary key,
    CuisineTypeName varchar(30) not null
        constraint ck_CuisineType_CuisineTypeName_should_not_be_blank check(CuisineTypeName <> '')
        constraint u_CuisineType_CuisineTypeName unique
)
go
create table dbo.Course(
    CourseId int not null identity primary key,
    CourseName varchar(30) not null
        constraint ck_Course_CourseName_cannot_be_blank check(CourseName <> '')
        constraint u_Course_CourseName unique,
    Seq int not null
        constraint u_Course_Seq unique
        constraint ck_Course_Seq_must_be_more_then_0 check(Seq > 0)
)
go
create table dbo.UnitOfMeasure(
    UnitOfMeasureId int not null identity primary key,
    UnitName varchar(30) not null
        constraint ck_UnitOfMeasure_UnitName_cannot_be_blank check(UnitName <> '')
        constraint u_UnitOfMeasure_UnitName unique,
    Abbreviation varchar(5) not null
        constraint ck_UnitOfMeasure_Abbreviation_cannot_be_blank check(Abbreviation <> '')
        constraint u_UnitOfMeasure_Abbreviation unique
)
go
create table dbo.Ingredient(
    IngredientId int not null identity primary key,
    IngredientName varchar(30) not null
        constraint ck_Ingredient_IngredientName_cannot_be_blank check(IngredientName <> '')
        constraint u_Ingredient_IngredientName unique,
    IngredientImage as concat('Ingredient_', replace(IngredientName, ' ', '_'), '.jpg')
)
go

--Data Tables
create table dbo.Staff(
    StaffId int not null identity primary key,
    FirstName varchar(30) not null
        constraint ck_Staff_FirstName_cannot_be_blank check(FirstName <> ''),
    LastName varchar(30) not null
        constraint ck_Staff_LastName_cannot_be_blank check(LastName <> ''),
    StaffName as concat(FirstName, ' ',  LastName),
    UserName varchar(100) not null
        constraint ck_Staff_Username_should_not_be_blank check(Username <> '')
        constraint u_Staff_Username unique
    )
go
create table dbo.Meal(
    MealId int not null identity primary key,
    StaffId int not null
        constraint f_Staff_Meal foreign key references Staff(StaffId),
    MealName varchar(30) not null
        constraint ck_Meal_MealName_cannot_be_blank check(MealName <> '')
        constraint u_Meal_MealName Unique,
    Active bit not null
        constraint d_Meal_Active default 1,
    CreatedDate date not null
        constraint ck_Meal_CreatedDate_cannot_be_in_the_future check(CreatedDate <= getdate()),
    MealImage as concat('Meal_', replace(MealName, ' ', '_'), '.jpg'),
)
go
create table dbo.MealCourse(
    MealCourseId int not null identity primary key,
    MealId int not null
        constraint f_Meal_MealCourse foreign key references Meal(MealId),
    CourseId int not null
        constraint f_Course_MealCourse foreign key references Course(CourseId),
    constraint u_Meal_Course unique(MealId, CourseId)
)
go
create table dbo.Recipe(
    RecipeId int not null identity primary key,
    StaffId int not null
        constraint f_Staff_Recipe foreign key references Staff(StaffId),
    CuisineTypeId int not null
        constraint f_CuisineType_Recipe foreign key references CuisineType(CuisineTypeId),
    RecipeName varchar(75) not null
        constraint ck_Recipe_RecipeName_cannot_be_blank check(RecipeName <> '')
        constraint u_Recipe_RecipeName unique,
    Calories int not null
        constraint ck_Recipe_Calories_must_be_more_then_0 check(Calories > 0),
    DraftTime Datetime not null
        constraint ck_Recipe_DraftTime_cannot_be_in_the_future check(DraftTime <= getdate()),
    PublishedTime Datetime null,
    ArchivedTime Datetime null,
    RecipeStatus as case
        when ArchivedTime is not null then 'Archived'
        when  PublishedTime is not null then 'Published'
        else 'Draft'
    end persisted,
    RecipeImage as concat('Recipe_', replace(RecipeName, ' ', '_'), '.jpg') persisted,
    constraint ck_Recipe_PublishedTime_cannot_be_before_DraftTime check(PublishedTime >= DraftTime),
    constraint ck_Recipe_ArchivedTime_cannot_be_before_PublishedTime_and_or_DraftTime check(isnull(PublishedTime, DraftTime) <= ArchivedTime)
)
go
create table dbo.RecipeIngredient(
    RecipeIngredientId int not null identity primary key,
    RecipeId int not null
        constraint f_Recipe_RecipeIngredient foreign key references Recipe(RecipeId),
    IngredientId int not null
        constraint f_Ingredient_RecipeIngredient foreign key references Ingredient(IngredientId),
    UnitOfMeasureId int null
        constraint f_UnitOfMeasureId_RecipeIngredient foreign key references UnitOfMeasure(UnitOfMeasureId),
    Amount decimal(8,3) not null
        constraint ck_RecipeIngredient_Amount_must_be_more_then_0 check(Amount > 0),
    Seq int not null
        constraint ck_RecipeIngredient_Seq_must_be_more_then_0 check(Seq > 0),
    constraint u_RecipeId_IngredientId unique(RecipeId, IngredientId),
    constraint u_RecipeId_Seq unique(RecipeId, Seq)
)
go
create table dbo.RecipeInstruction(
    RecipeInstructionId int not null identity primary key,
    RecipeId int not null
        constraint f_Recipe_RecipeInstruction foreign key references Recipe(RecipeId),
    Seq int not null
        constraint ck_RecipeInstruction_Seq_must_more_then_0 check(Seq > 0),
    InstructionDesc varchar(100) not null
        constraint ck_RecipeInstruction_Action_cannot_be_blank check(InstructionDesc <> ''),
    constraint u_Seq_RecipeId unique(Seq, RecipeId)
)
go
create table dbo.MealCourseRecipe(
    MealCourseRecipeId int not null identity primary key,
    MealCourseId int not null
        constraint f_MealCourse_MealCourseRecipe foreign key references MealCourse(MealCourseId),
    RecipeId int not null
        constraint f_Recipe_MealCourseRecipe foreign key references Recipe(RecipeId),
    MainDish bit not null,
    constraint u_MealCourse_Recipe unique(MealCourseId, RecipeId)
)
go
create table dbo.CookBook(
    CookBookId int not null identity primary key,
    StaffId int not null
        constraint f_Staff_CookBook foreign key references Staff(StaffId),
    CookBookName varchar(50) not null
        constraint ck_CookBook_CookBookName_cannot_be_blank check(CookBookName <> '')
        constraint u_CookBook_CookBookName unique,
    Price decimal(5,2) not null
        constraint ck_CookBook_Price_must_be_more_then_0 check(Price > 0.00),
    Active bit not null
        constraint d_CookBook_Active default 1,
    CookBookImage as concat('CookBook_', replace(CookBookName, ' ', '_'), '.jpg'),
    CreatedDate date not null
        constraint ck_CookBook_CreatedDate_cannot_be_in_the_future check(CreatedDate <= getdate())
)
go
create table CookBookRecipe(
    CookBookRecipeId int not null identity primary key,
    CookBookId int not null
        constraint f_CookBook_CookBookRecipe foreign key references CookBook(CookBookId),
    RecipeId int not null
        constraint f_Recipe_CookBookRecipe foreign key references Recipe(RecipeId),
    Seq int not null
        constraint ck_CookBookRecipe_Seq_must_be_more_then_0 check(Seq > 0),
    constraint u_CookBookId_RecipeId unique(CookBookId, RecipeId),
    constraint u_CookBookId_Seq unique(CookBookId, Seq)
)
