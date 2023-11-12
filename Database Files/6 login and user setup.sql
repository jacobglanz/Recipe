--replace //loginname// and //password// with secret values from vault
--IMPOETANT switch to target Database 
-- use master
create user dev_user from login //loginname//

alter role db_datareader add member dev_user
alter role db_datawriter add member dev_user
