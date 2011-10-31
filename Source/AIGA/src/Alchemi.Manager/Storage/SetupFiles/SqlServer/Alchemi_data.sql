set nocount on;

/*Default users and groups are added from code, examine ManagerStorageBase.cs for details*/

/*
TB: Do not change the database from these scripts as it messes up the test scripts which go to a different database
use Alchemi;

set nocount on;
*/
-- grp
--insert grp values(1, 'Administrators', 'Administrators Group', 1);
--insert grp values(2, 'Executors', 'Executors Group', 1);
--insert grp values(3, 'Users', 'Users Group', 1);

-- prm
insert prm values(1, 'ExecuteThread', 'Execute a thread or job');
insert prm values(2, 'ManageOwnApp', 'Manage own application');
insert prm values(3, 'ManageAllApps', 'Manage all applications');
insert prm values(4, 'ManageUsers', 'Manage users');

-- grp_prm
--insert grp_prm values(1, 1);
--insert grp_prm values(1, 2);
--insert grp_prm values(1, 3);
--insert grp_prm values(1, 4);
--insert grp_prm values(2, 1);
--insert grp_prm values(3, 2);

-- usr
--insert usr values('admin', '19a2854144b63a8f7617a6f225019b12', 1, '', 1);
--insert usr values('executor', '63c2867ae3b5ea1dccf158f6b084a9ec', 2, '', 1);
--insert usr values('user', '9ce4b5879f3fcb5a9842547bebe191e1', 3, '', 1);