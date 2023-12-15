declare @TableName varchar(100) = 'Ingredient', @CRUDVerb varchar(20) = 'Update',
    @InsertStatment varchar(5000) = '', @InsertValues varchar(5000) = '', @UpdateStatement varchar(5000) = ''

declare @Table table (
    TABLE_NAME varchar(128),
    COLUMN_NAME varchar(128),
    ColumnType varchar(10),
    IS_NULLABLE varchar(3),
    DATA_TYPE varchar(128),
    CHARACTER_MAXIMUM_LENGTH int
)
insert @Table (TABLE_NAME, COLUMN_NAME, ColumnType, IS_NULLABLE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH)
    select
        c.TABLE_NAME,
        c.COLUMN_NAME,
        case
            when pk.COLUMN_NAME is not null then 'PK'
            when fk.COLUMN_NAME is not null then 'FK'
            when cc.COLUMN_NAME is not null then 'Computed'
            else 'Regular'
        END AS ColumnType,
        c.IS_NULLABLE,
        c.DATA_TYPE,
        c.CHARACTER_MAXIMUM_LENGTH
    from
        INFORMATIon_SCHEMA.COLUMNS c
    left join
        (select
            kcu.TABLE_NAME,
            kcu.COLUMN_NAME
        from
            INFORMATIon_SCHEMA.TABLE_ConSTRAINTS tc
        join
            INFORMATIon_SCHEMA.KEY_COLUMN_USAGE kcu on tc.ConSTRAINT_NAME = kcu.ConSTRAINT_NAME
        where
            tc.ConSTRAINT_TYPE = 'PRIMARY KEY'
        ) pk on c.TABLE_NAME = pk.TABLE_NAME and c.COLUMN_NAME = pk.COLUMN_NAME
    left join
        (select
            kcu.TABLE_NAME,
            kcu.COLUMN_NAME
        from
            INFORMATIon_SCHEMA.REFERENTIAL_ConSTRAINTS rc
        join
            INFORMATIon_SCHEMA.KEY_COLUMN_USAGE kcu on rc.ConSTRAINT_NAME = kcu.ConSTRAINT_NAME
        ) fk on c.TABLE_NAME = fk.TABLE_NAME and c.COLUMN_NAME = fk.COLUMN_NAME
    left join
        (select
            TABLE_NAME,
            COLUMN_NAME
        from
            INFORMATIon_SCHEMA.COLUMNS
        where
            COLUMNPROPERTY(OBJECT_ID(TABLE_NAME), COLUMN_NAME, 'IsComputed') = 1
        ) cc on c.TABLE_NAME = cc.TABLE_NAME and c.COLUMN_NAME = cc.COLUMN_NAME
    where
        c.TABLE_NAME = 'recipe'
    order by
        case
            when pk.COLUMN_NAME is not null then 1
            when fk.COLUMN_NAME is not null then 2
            when cc.COLUMN_NAME is not null then 4
            else 3
        end,
        c.ORDINAL_POSITIon;

select @InsertStatment = @InsertStatment + concat(COLUMN_NAME, ', ')
    from INFORMATION_SCHEMA.COLUMNS
    where TABLE_NAME = @TableName
    and TABLE_NAME + 'Id' <> COLUMN_NAME
    and columnproperty(object_id(TABLE_NAME), COLUMN_NAME, 'IsComputed') = 0
    select @InsertStatment = concat('insert ', @TableName, '(', substring(@InsertStatment, 1, len(@InsertStatment)-1), ')')

select @InsertValues = @InsertValues + concat('@',COLUMN_NAME, ', ')
    from INFORMATION_SCHEMA.COLUMNS
    where TABLE_NAME = @TableName
    and TABLE_NAME + 'Id' <> COLUMN_NAME
    and columnproperty(object_id(TABLE_NAME), COLUMN_NAME, 'IsComputed') = 0
    select @InsertValues = concat('values (', substring(@InsertValues, 1, len(@InsertValues)-1), ')')

select @UpdateStatement = concat(COLUMN_NAME, ' = ', '@', COLUMN_NAME, ',')
    from INFORMATION_SCHEMA.COLUMNS
    where TABLE_NAME = @TableName and columnproperty(object_id(TABLE_NAME), COLUMN_NAME, 'IsComputed') = 0 and COLUMN_NAME <> TABLE_NAME + 'Id'


if @CRUDVerb = 'Update'
begin
    select params =  concat(
            '	@', COLUMN_NAME, ' ', DATA_TYPE,
            case when DATA_TYPE = 'varchar' then concat('(', CHARACTER_MAXIMUM_LENGTH, ')') end,
            case when COLUMN_NAME = TABLE_NAME + 'Id' then ' output' end, ',')
            ,
        Seq = 1, ordinal_position
        from INFORMATION_SCHEMA.COLUMNS
        where TABLE_NAME = @TableName and columnproperty(object_id(TABLE_NAME), COLUMN_NAME, 'IsComputed') = 0
    union select concat('create or alter procedure dbo.', @TableName, @CRUDVerb, '('), 0, 99999
    union select '	@Message varchar(500) = '''' output', 2, 99999
    union select ')', 3, 99999
    union select 'as', 4, 99999
    union select 'begin', 5, 99999
    union select '	declare @Return int = 0', 6, 99999
    union select '	', 7, 99999
    union select '	if', 8, 99999
    union select '	begin', 9, 99999
    union select concat('		',@InsertStatment), 10, 99999
    union select concat('		',@InsertValues), 11, 99999
    union select '	end', 12, 99999
    union select '	else', 13, 99999
    union select '	begin', 14, 99999
    union select concat('		', @UpdateStatement), 15, 99999
    union select '	end', 16, 99999
    union select '	', 17, 99999
    union select '	return @Return', 18, 99999
    union select 'end', 19, 99999
    order by Seq, ordinal_position
end

/*
Pk - if its null change it to 0
FK - if its 0 change it to null
PK scope_identity() - on insert: select @CookBookRecipeId = scope_identity()
Where PK - add a where clause to the update statement to only do the update where PK matchaes param PK
:finished - add a finished: tag before the return = @Return
Dacimal Param - for a param that takes a dacimal set the dacimal limit. for example: dacimal(5,2)
Computer column should maybe always b output param
Add a "go" at the end
DeleteTransaction - for delete make a transaction to also delete all related records
*/

-- if @CRUDVerb = 'Get'
-- begin

-- end