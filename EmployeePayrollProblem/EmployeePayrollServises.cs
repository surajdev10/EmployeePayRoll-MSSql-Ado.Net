﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollProblem
{
    public class EmployeePayrollServises
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Service;";
        public string AddEmployeeInDB(EmployeePayroll employeePayroll)
        {
            SqlConnection sQLConnection = new SqlConnection(connectionString);
            try
            {
                using (sQLConnection)
                {
                    sQLConnection.Open();
                    SqlCommand command = new SqlCommand("SPAddNewEmployee", sQLConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", employeePayroll.ID);
                    command.Parameters.AddWithValue("@EmployeeName", employeePayroll.Name);
                    command.Parameters.AddWithValue("@Gender", employeePayroll.Gender);
                    command.Parameters.AddWithValue("@PhoneNO", employeePayroll.PhoneNumber);
                    command.Parameters.AddWithValue("@EmployeeAddress", employeePayroll.Address);
                    command.Parameters.AddWithValue("@StartDate", employeePayroll.Start);
                    int result = command.ExecuteNonQuery();
                    sQLConnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Employee Added Successfully");
                        return "Employee Added Successfully";
                    }
                    else
                    {
                        Console.WriteLine("No Data found");
                        return "No Data found";
                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public string RetrieveEntriesFromEmployeePayDB()
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                List<EmployeePayroll> employee = new List<EmployeePayroll>();
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPRetrieveAllDetails", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            EmployeePayroll emp = new EmployeePayroll();
                            emp.Id = dr.GetInt32(0);
                            emp.Name = dr.GetString(1);
                            emp.Salary = dr.GetInt64(2);
                            emp.Start = dr.GetDateTime(3);
                            emp.Gender = dr.GetString(4);
                            emp.Phone_No = dr.GetInt64(5);
                            emp.Address = dr.GetString(6);
                            employee.Add(emp);
                        }
                        Console.WriteLine("ID" + " " + "Name" + "  " + "Salary" + "  " + "Start" + "  " + "Gender" + "  " + "  " + "PhoneNumber" + "" + "Address");
                        foreach (var data in employee)
                        {
                            Console.WriteLine(data.Id + " " + data.Name + " " + data.Salary + " " + data.Start + " " + data.Gender + " " + data.Phone_No + " " + data.Address);
                        }
                        return "Retrive SucessFull";
                    }
                    else
                    {
                        Console.WriteLine("No Database Found");
                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public string UpdateDataInDatabase(EmployeePayroll employeePayroll)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPUpdateDataInDB", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", employeePayroll.Name);
                    command.Parameters.AddWithValue("@EmployeeAddress", employeePayroll.Address);
                    command.Parameters.AddWithValue("@PhoneNo", employeePayroll.PhoneNumber);
                    int result = command.ExecuteNonQuery();
                    sqlconnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Employee Updated Successfully");
                        return "Employee Updated Successfully";
                    }
                    else
                        Console.WriteLine("No DataBase found");
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public string DeleteDataFromDatabase(string name)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPDeleteDataFromDB", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", name);
                    int result = command.ExecuteNonQuery();
                    sqlconnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Employee Deleted Successfully");
                        return "Employee Deleted Successfully";
                    }
                    else
                        Console.WriteLine("No DataBase found");
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}

