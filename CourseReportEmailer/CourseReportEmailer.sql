-- 1
CREATE DATABASE CourseReport;

-- 2
USE CourseReport;

-- 3
CREATE TABLE [dbo].[Courses] (
	CourseId INT IDENTITY (1, 1) NOT NULL,
	CourseCode VARCHAR(5) NOT NULL,
	[Description] VARCHAR(50) NOT NULL,
	PRIMARY KEY (CourseId)
);

CREATE TABLE [dbo].[Students] (
	StudentId INT IDENTITY (1, 1) NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	PRIMARY KEY (StudentId)
);

CREATE TABLE [dbo].[Enrollments] (
	EnrollmentId INT IDENTITY(1, 1) NOT NULL,
	StudentId INT NOT NULL,
	CourseId INT NOT NULL,
	PRIMARY KEY (EnrollmentId),
	FOREIGN KEY (StudentId) REFERENCES Students(StudentId),
	FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
);

-- 4
INSERT INTO [dbo].[Courses] (CourseCode, [Description]) VALUES ('AF', 'Accounting and Finance');
INSERT INTO [dbo].[Courses] (CourseCode, [Description]) VALUES ('ME', 'Aeronautical & Manufacturing Engineering');
INSERT INTO [dbo].[Courses] (CourseCode, [Description]) VALUES ('AF', 'Agriculture and Forestry');
INSERT INTO [dbo].[Courses] (CourseCode, [Description]) VALUES ('AS', 'American Studies');
INSERT INTO [dbo].[Courses] (CourseCode, [Description]) VALUES ('APSY', 'Anatomy & Physiology');
INSERT INTO [dbo].[Courses] (CourseCode, [Description]) VALUES ('ANT', 'Anthropology');
INSERT INTO [dbo].[Courses] (CourseCode, [Description]) VALUES ('ARC', 'Archaeology');
INSERT INTO [dbo].[Courses] (CourseCode, [Description]) VALUES ('ARCH', 'Architecture');

INSERT INTO [dbo].[Students] (FirstName, LastName) VALUES ('Millard', 'Lamb');
INSERT INTO [dbo].[Students] (FirstName, LastName) VALUES ('Gayle', 'Reid');
INSERT INTO [dbo].[Students] (FirstName, LastName) VALUES ('Quinton', 'Beltran');
INSERT INTO [dbo].[Students] (FirstName, LastName) VALUES ('Eusebio', 'Moyer');
INSERT INTO [dbo].[Students] (FirstName, LastName) VALUES ('Imelda', 'Shea');
INSERT INTO [dbo].[Students] (FirstName, LastName) VALUES ('Ellsworth', 'Fletcher');

INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (1, 1);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (2, 1);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (3, 1);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (1, 2);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (2, 2);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (3, 2);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (4, 2);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (5, 3);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (6, 4);

-- 5
CREATE VIEW [dbo].[EnrollmentReport] AS
	SELECT 
		T1.EnrollmentId,
		T2.FirstName,
		T2.LastName,
		T3.CourseCode,
		T3.[Description]
	FROM
		[dbo].[Enrollments] T1
	INNER JOIN
		[dbo].[Students] T2 ON T1.StudentId = T2.StudentId
	INNER JOIN
		[dbo].[Courses] T3 ON T1.CourseId = T3.CourseId

-- 6
CREATE PROCEDURE [dbo].[EnrollmentReport_Get]
AS
	SELECT
		EnrollmentId,
		FirstName,
		LastName,
		CourseCode,
		[Description]
	FROM
		[dbo].[EnrollmentReport]

-- 7






-- cleanup
DELETE FROM [dbo].[Enrollments];
DELETE FROM [dbo].[Courses];
DELETE FROM [dbo].[Students];
DROP TABLE [dbo].[Enrollments];
DROP TABLE [dbo].[Courses];
DROP TABLE [dbo].[Students];










