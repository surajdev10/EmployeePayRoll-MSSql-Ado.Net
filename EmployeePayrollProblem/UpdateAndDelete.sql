CREATE PROCEDURE SPUpdateDataInDB(
@EmployeeName VARCHAR(30),
@EmployeeAddress VARCHAR(100),
@PhoneNo VARCHAR(16)
)
AS BEGIN
UPDATE Employeepayroll SET EmployeeAddress=@EmployeeAddress,PhoneNo=@PhoneNo WHERE EmployeeName=@EmployeeName
END
select * from Employeepayroll

--Delete
CREATE PROCEDURE SPDeleteDataFromDB(
@EmployeeName VARCHAR(30)
)
AS BEGIN
DELETE FROM Employeepayroll WHERE EmployeeName=@EmployeeName
END