IF NOT EXISTS (SELECT name FROM master.sys.databases WHERE name = N'MusicTrackerDb')
BEGIN
	CREATE DATABASE [MusicTrackerDb];
END