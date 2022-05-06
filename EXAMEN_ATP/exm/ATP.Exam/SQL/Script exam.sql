use master
go

if(DB_ID('ExamDev') is not null)
drop database ExamDev
go

create database ExamDev
go

use ExamDev
go

if(OBJECT_ID('Exam') is not null)
drop schema Exam
go

create schema Exam
go

create table Exam.Project(
	projectId uniqueidentifier primary key default newsequentialid(),
	title varchar(300),
	dateInit date,
	dateEnd date,
	cost decimal(10,2),
	[month] varchar(100),
	createdDate datetime
)
go

create table Exam.Employee(
	employeeId uniqueidentifier primary key default newsequentialid(),
	name varchar(300),
	birthDate date,
	entryDate date,
	job varchar(250),
	salary decimal(10,2),
	createdDate datetime
)
go

create table Exam.Project_Employee(
	projectEmployeeId	uniqueidentifier primary key,
	projectId	uniqueidentifier foreign key references Exam.Project(projectId),
	employeeId	uniqueidentifier foreign key references Exam.Employee(employeeId),
	[role] varchar(500),
	createdDate datetime
)
go


insert into Exam.Project (title,dateInit,dateEnd,cost,month,createdDate)
values ('ATP Project',DATEADD(Month,-3,GETDATE()),DATEADD(Month,3,GETDATE()),100000,'ENERO',GETDATE())
insert into Exam.Project (title,dateInit,dateEnd,cost,month,createdDate)
values ('Business Project',DATEADD(Month,-2,GETDATE()),DATEADD(Month,2,GETDATE()),50000,'FEBRERO',GETDATE())


insert into Exam.Employee (name,birthDate,entryDate,job,salary,createdDate)
values ('Jose Perez','1995-04-16','2016-05-15','Frontend Developer',2200,GETDATE())
insert into Exam.Employee (name,birthDate,entryDate,job,salary,createdDate)
values ('Gabriel Jimenez','1990-01-12','2016-05-01','Backend Developer',2200,GETDATE())
insert into Exam.Employee (name,birthDate,entryDate,job,salary,createdDate)
values ('Maria Gonzales','1996-03-11','2017-01-15','Frontend Developer',2200,GETDATE())
insert into Exam.Employee (name,birthDate,entryDate,job,salary,createdDate)
values ('Julia Martinez','1990-01-12','2017-01-01','Backend Developer',2200,GETDATE())

