IF NOT EXISTS (SELECT name FROM master.sys.databases WHERE name = N'db_TrackerX')
BEGIN
	CREATE DATABASE [db_TrackerX];
END