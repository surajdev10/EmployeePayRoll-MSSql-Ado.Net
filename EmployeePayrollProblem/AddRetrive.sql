--RETRIVE DATA
CREATE PROCEDURE SPRetrieveAllDetails
AS BEGIN 
SELECT * FROM Employee_payroll
END
--Add Data
CREATE TABLE Employeepayroll(EmployeeId INT,
EmployeeName VARCHAR(40),
Gender varchar(6),
PhoneNo varchar(16),
EmployeeAddress VARCHAR(100),
StartDate DATE );

CREATE PROCEDURE SPAddNewEmployee(
@EmployeeId INT,
@EmployeeName VARCHAR(40),
@Gender varchar(6),
@PhoneNo varchar(16),
@EmployeeAddress VARCHAR(100),
@StartDate DATE 
)
AS BEGIN
INSERT INTO Employeepayroll VALUES(@EmployeeId,@EmployeeName,@Gender,@PhoneNo,@EmployeeAddress,@StartDate)
END

SELECT * FROM Employeepayroll;
SELECT * FROM Employee_Payroll;



--Update
CREATE PROCEDURE SPUpdateDataInDB(
@EmployeeName VARCHAR(30),
@EmployeeAddress VARCHAR(100),
@PhoneNo VARCHAR(16)
)
AS BEGIN
UPDATE Employeepayroll SET EmployeeAddress=@EmployeeAddress,PhoneNo=@PhoneNo WHERE EmployeeName=@EmployeeName
END


