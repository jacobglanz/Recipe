declare @TableName varchar(100) = 'Recipe', @InsertStatment varchar(5000) = '', @InsertValues varchar(5000) = ''

select @InsertStatment = @InsertStatment + concat(COLUMN_NAME, ', ')
from INFORMATION_SCHEMA.COLUMNS
where TABLE_NAME = @TableName
and TABLE_NAME + 'Id' <> COLUMN_NAME
and columnproperty(object_id(TABLE_NAME), COLUMN_NAME, 'IsComputed') = 0

select @InsertValues = @InsertValues + concat('@',COLUMN_NAME, ', ')
from INFORMATION_SCHEMA.COLUMNS
where TABLE_NAME = @TableName
and TABLE_NAME + 'Id' <> COLUMN_NAME
and columnproperty(object_id(TABLE_NAME), COLUMN_NAME, 'IsComputed') = 0



select concat(
    '@', COLUMN_NAME, ' ', DATA_TYPE, 
    case when DATA_TYPE = 'varchar' then concat('(', CHARACTER_MAXIMUM_LENGTH, ')') end,
    case when COLUMN_NAME = TABLE_NAME + 'Id' then ' output' end, ',') 
    from INFORMATION_SCHEMA.COLUMNS 
    where TABLE_NAME = @TableName and columnproperty(object_id(TABLE_NAME), COLUMN_NAME, 'IsComputed') = 0
select concat('insert ', @TableName, '(', substring(@InsertStatment, 1, len(@InsertStatment)-1), ')')
select concat('values (', substring(@InsertValues, 1, len(@InsertValues)-1), ')')
select concat('insert ', @TableName, '(', substring(@InsertStatment, 1, len(@InsertStatment)-1), ')')
select concat(COLUMN_NAME, ' = ', '@', COLUMN_NAME, ',') 
    from INFORMATION_SCHEMA.COLUMNS
    where TABLE_NAME = @TableName and columnproperty(object_id(TABLE_NAME), COLUMN_NAME, 'IsComputed') = 0 and COLUMN_NAME <> TABLE_NAME + 'Id'


