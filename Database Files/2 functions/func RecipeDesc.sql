create or alter function dbo.RecipeDesc(@RecipeId int)
returns varchar(155)
begin 
    declare @value varchar(155)

    select @value = 
        concat(r.RecipeName, ' (', ct.CuisineTypeName,') has ',
        count(rg.RecipeIngredientId), ' ingredient(s) and ',
        count(rs.RecipeInstructionId), ' step(s)'
    ) 
    from Recipe r 
    join CuisineType ct 
        on r.CuisineTypeId = ct.CuisineTypeId
    left join RecipeIngredient rg 
        on r.RecipeId = rg.RecipeId
    left join RecipeInstruction rs 
        on r.RecipeId = rs.RecipeId
    where r.RecipeId = @RecipeId
    group by r.RecipeName, ct.CuisineTypeName

    return @value
end 
go 

select dbo.RecipeDesc(RecipeId), * from Recipe r