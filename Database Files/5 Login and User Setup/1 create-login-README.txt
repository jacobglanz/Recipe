script to create login is excluded from this repo.
create a file called create-login.sql (this file is ignored by .gitignor in tis repo)

add the following script
--IMPORTANT create login in MASTER
create login [loginname] with password  = '[password]'

--IMPOETANT switch to target Database
create user [useername] from login [loginname]