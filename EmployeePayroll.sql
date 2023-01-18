--UC1 Create payroll_service database
CREATE DATABASE Payroll_Service;
USE Payroll_Service;

--UC2 Creating a employee payroCREATE TABLE Employee_Payroll
CREATE TABLE Employee_Payroll(
Id int PRIMARY KEY IDENTITY(1,1),
Name varchar(30) NOT NULL,
Salary BIGINT NOT NULL,
Start DATE NOT NULL
);

--UC3 Insert Data into table
INSERT INTO Employee_Payroll(Name,Salary,Start)VALUES('Tamana',300000,'2009-03-04'),('Kumar',500000,'2011-09-11'),('Misty',200000,'2006-08-26'),('Amit',800000,'2017-05-19');

--UC4 Retrieve all the employee payroll
SELECT * FROM Employee_Payroll;

--UC5 Retriving Particular data for a particuler Enployee
SELECT Salary FROM Employee_Payroll WHERE Name = 'Amit';
SELECT * FROM Employee_Payroll WHERE Start BETWEEN CAST ('2003-02-02' AS DATE) AND GETDATE();

--UC6 Adding Gender Column in Table
ALTER TABLE Employee_Payroll ADD Gender varchar(1);
UPDATE Employee_Payroll SET Gender = 'F' WHERE Id = 1 OR Id = 3;
UPDATE Employee_Payroll SET Gender = 'M' WHERE Name = 'Kumar' OR Salary = 800000;

--UC7 find sum, average, min, max and number of male and female employees
--FIND SUM 
SELECT SUM(Salary) FROM Employee_Payroll; --TOTAL SALARY
SELECT SUM(Salary) FROM Employee_Payroll WHERE Gender = 'M' GROUP BY Gender; 
SELECT SUM(Salary) FROM Employee_Payroll WHERE Gender = 'F' GROUP BY Gender; 
--FIND AVERAGE
SELECT AVG(Salary) FROM Employee_Payroll; --TOTAL AVRAGE
SELECT AVG(Salary) FROM Employee_Payroll WHERE Gender = 'M' GROUP BY Gender;
SELECT AVG(Salary) FROM Employee_Payroll WHERE Gender = 'F' GROUP BY Gender;
--FIND MAXIMUM
SELECT MAX(Salary) FROM Employee_Payroll;--OVERALL MAXIMUN SALARY
SELECT MAX(Salary) FROM Employee_Payroll WHERE Gender = 'M' GROUP BY Gender;
SELECT MAX(Salary) FROM Employee_Payroll WHERE Gender = 'F' GROUP BY Gender;
--FIND MIMIMUM
SELECT MIN(Salary) FROM Employee_Payroll;--OVERALL MINIMUN SALARY
SELECT MIN(Salary) FROM Employee_Payroll WHERE Gender = 'M' GROUP BY Gender;
SELECT MIN(Salary) FROM Employee_Payroll WHERE Gender = 'F' GROUP BY Gender;
--COUNT
SELECT COUNT(Id) FROM Employee_Payroll
SELECT COUNT(Gender) FROM Employee_Payroll WHERE Gender = 'M' GROUP BY Gender;
SELECT COUNT(Gender) FROM Employee_Payroll WHERE Gender = 'F' GROUP BY Gender;

--UC8 extend employee_payroll add phone, address and department
ALTER TABLE Employee_Payroll ADD Phone_No BIGINT;
ALTER TABLE Employee_Payroll ADD Address varchar(350) DEFAULT 'INDIA';
ALTER TABlE Employee_Payroll ADD Department varchar(90) NOT NULL DEFAULT 'ENGINEER';
SELECT * FROM Employee_Payroll;

--UC9 Employee_payroll table to have Basic Pay, Deductions, Taxable Pay, Income Tax, Net Pay
ALTER TABLE Employee_Payroll ADD Basic_Pay FLOAT NOT NULL DEFAULT 100000;
ALTER TABLE Employee_Payroll ADD Deductions FLOAT NOT NULL DEFAULT 10000;
ALTER TABLE Employee_Payroll ADD Taxable_Pay FLOAT NOT NULL DEFAULT 1000;
ALTER TABLE Employee_Payroll ADD Income_Tax FLOAT NOT NULL DEFAULT 100;
ALTER TABLE Employee_Payroll ADD Net_Pay FLOAT NOT NULL DEFAULT 100000;
SELECT * FROM Employee_Payroll;

--UC10
UPDATE Employee_Payroll SET Department = 'SALES' WHERE Name = 'Amit';
INSERT INTO Employee_Payroll VALUES('Amit',30000,'2019-06-07','M',7864646455,'SRE','Marketing',0.0,0.0,0.0,30000);
INSERT INTO Employee_Payroll VALUES('Amit',30000,'2019-06-07','M',7864646455,'SRE','Marketing',10,10,10,10,30000);

CREATE TABLE Demo_Table(
Id int PRIMARY KEY IDENTITY(1,1));

--UC11 DELET ENTIRE TABLE
DROP TABLE Demo_Table;

--UC12 DELETE A ROW
DELETE FROM Employee_Payroll WHERE Id = 4;
--CURD
--C=CREATE
--U=UPDATE
--R=RETRIVE
--D=DELETE


--ER DIAGRAM
CREATE TABLE Department(
Dept_ID int NOT NULL,
Name VARCHAR(100),
Dept_Name VARCHAR(50),
CONSTRAINT FK FOREIGN KEY (Dept_ID) REFERENCES Employee_Payroll(ID)
);
INSERT INTO Department(Dept_ID,Name,Dept_Name)
VALUES(1,'Amit','Sales'),
(1,'Amit','Marketing');

SELECT * FROM Department;