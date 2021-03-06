USE [ContosoUniversityProj3]
GO
/****** Object:  Table [dbo].[tblCourses]    Script Date: 18/1/2021 12:19:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCourses](
	[id_Courses] [int] NOT NULL,
	[Title] [varchar](50) NULL,
	[Credit] [int] NOT NULL,
	[Course_Dept] [int] NULL,
 CONSTRAINT [PK_tblCourses] PRIMARY KEY CLUSTERED 
(
	[id_Courses] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDept]    Script Date: 18/1/2021 12:19:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDept](
	[id_Dept] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Budget] [smallmoney] NULL,
	[StartDate] [datetime2](7) NULL,
	[Dept_Admin] [int] NOT NULL,
 CONSTRAINT [PK_tblDept] PRIMARY KEY CLUSTERED 
(
	[id_Dept] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEnrolment]    Script Date: 18/1/2021 12:19:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEnrolment](
	[id_Enroll] [int] NOT NULL,
	[Stud_Courses] [int] NULL,
	[Courses_Student] [int] NULL,
	[EnrollmentDate] [datetime2](7) NULL,
	[Grades] [char](1) NULL,
 CONSTRAINT [PK_tblEnrolment] PRIMARY KEY CLUSTERED 
(
	[id_Enroll] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblInstructor]    Script Date: 18/1/2021 12:19:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblInstructor](
	[id_Instructor] [int] NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[HiredDate] [datetime2](7) NOT NULL,
	[Instructor_Dept] [int] NULL,
 CONSTRAINT [PK_tblInstructor] PRIMARY KEY CLUSTERED 
(
	[id_Instructor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLecture]    Script Date: 18/1/2021 12:19:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLecture](
	[id_Lecture] [int] NOT NULL,
	[instructor] [int] NULL,
	[courses] [int] NULL,
 CONSTRAINT [PK_tblLecture] PRIMARY KEY CLUSTERED 
(
	[id_Lecture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStud]    Script Date: 18/1/2021 12:19:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStud](
	[id_Stud] [int] NOT NULL,
	[FirstName] [varchar](20) NULL,
	[LastName] [varchar](20) NULL,
	[Stud_Courses] [int] NULL,
 CONSTRAINT [PK_tblStud] PRIMARY KEY CLUSTERED 
(
	[id_Stud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblCourses] ADD  CONSTRAINT [DF_tblCourses_Credit]  DEFAULT ((0)) FOR [Credit]
GO
ALTER TABLE [dbo].[tblCourses]  WITH CHECK ADD  CONSTRAINT [CourseDept(FK)_id_Dept(PK)] FOREIGN KEY([Course_Dept])
REFERENCES [dbo].[tblDept] ([id_Dept])
GO
ALTER TABLE [dbo].[tblCourses] CHECK CONSTRAINT [CourseDept(FK)_id_Dept(PK)]
GO
ALTER TABLE [dbo].[tblEnrolment]  WITH CHECK ADD  CONSTRAINT [Enrol-StudCourses(FK)_Stud-StudCourses(PK)] FOREIGN KEY([Stud_Courses])
REFERENCES [dbo].[tblStud] ([Stud_Courses])
GO
ALTER TABLE [dbo].[tblEnrolment] CHECK CONSTRAINT [Enrol-StudCourses(FK)_Stud-StudCourses(PK)]
GO
ALTER TABLE [dbo].[tblEnrolment]  WITH CHECK ADD  CONSTRAINT [StudCourses(FK)_idCourses(PK)] FOREIGN KEY([Stud_Courses])
REFERENCES [dbo].[tblCourses] ([id_Courses])
GO
ALTER TABLE [dbo].[tblEnrolment] CHECK CONSTRAINT [StudCourses(FK)_idCourses(PK)]
GO
ALTER TABLE [dbo].[tblInstructor]  WITH CHECK ADD  CONSTRAINT [Instructor_Dept(FK)_id_Dept(PK)] FOREIGN KEY([Instructor_Dept])
REFERENCES [dbo].[tblDept] ([id_Dept])
GO
ALTER TABLE [dbo].[tblInstructor] CHECK CONSTRAINT [Instructor_Dept(FK)_id_Dept(PK)]
GO
ALTER TABLE [dbo].[tblLecture]  WITH CHECK ADD  CONSTRAINT [courses(FK)_idCourses(PK)] FOREIGN KEY([courses])
REFERENCES [dbo].[tblCourses] ([id_Courses])
GO
ALTER TABLE [dbo].[tblLecture] CHECK CONSTRAINT [courses(FK)_idCourses(PK)]
GO
ALTER TABLE [dbo].[tblLecture]  WITH CHECK ADD  CONSTRAINT [instructor(FK)_idInstructor(PK)] FOREIGN KEY([instructor])
REFERENCES [dbo].[tblInstructor] ([id_Instructor])
GO
ALTER TABLE [dbo].[tblLecture] CHECK CONSTRAINT [instructor(FK)_idInstructor(PK)]
GO
ALTER TABLE [dbo].[tblCourses]  WITH CHECK ADD  CONSTRAINT [CreditChecker] CHECK  (([Credit]>=(0) AND [Credit]<=(5)))
GO
ALTER TABLE [dbo].[tblCourses] CHECK CONSTRAINT [CreditChecker]
GO
ALTER TABLE [dbo].[tblCourses]  WITH CHECK ADD  CONSTRAINT [TitleCharLength] CHECK  ((len([Title])>=(3)))
GO
ALTER TABLE [dbo].[tblCourses] CHECK CONSTRAINT [TitleCharLength]
GO
ALTER TABLE [dbo].[tblDept]  WITH CHECK ADD  CONSTRAINT [MoneyCheck] CHECK  (([Budget]>=(0)))
GO
ALTER TABLE [dbo].[tblDept] CHECK CONSTRAINT [MoneyCheck]
GO
ALTER TABLE [dbo].[tblEnrolment]  WITH CHECK ADD  CONSTRAINT [GradeConstraint] CHECK  (([Grades]='F' OR [Grades]='E' OR [Grades]='D' OR [Grades]='C' OR [Grades]='B' OR [Grades]='A'))
GO
ALTER TABLE [dbo].[tblEnrolment] CHECK CONSTRAINT [GradeConstraint]
GO
