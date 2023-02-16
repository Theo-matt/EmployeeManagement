using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class EmployeeService : IEmployeeService
    {
        public Employee GetEmployee(int Id)
        {
            Employee employee = null;

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection conn = new SqlConnection(cs))
            {
                //SqlCommand cmd = conn.CreateCommand();
                SqlCommand cmd = new SqlCommand("spGetEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = Id;
                cmd.Parameters.Add(paramId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if ((EmployeeType)reader["EmployeeType"] == EmployeeType.FullTimeEmployee)
                    {
                        employee = new FullTimeEmployee
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            City = reader["City"].ToString(),
                            Type = EmployeeType.FullTimeEmployee,
                            AnnualSalary = Convert.ToDecimal(reader["AnnualSalary"])
                        };
                    }
                    else
                    {
                        employee = new PartTimeEmployee
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            City = reader["City"].ToString(),
                            Type = EmployeeType.PartTimeEmployee,
                            HourlyPay = Convert.ToDecimal(reader["HourlyPay"]),
                            HoursWorked = Convert.ToInt32(reader["HoursWorked"])
                        };
                    }
                }
            }

            return employee;
        }

        public void SaveEmployee(Employee employee)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand sqlCommand = new SqlCommand("spSaveEmployee", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.Add(new SqlParameter());
                SqlParameter parameterId = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = employee.Id
                };

                sqlCommand.Parameters.Add(parameterId);

                SqlParameter parameterName = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = employee.Name
                };

                sqlCommand.Parameters.Add(parameterName);

                SqlParameter parameterGender = new SqlParameter
                {
                    ParameterName = "@Gender",
                    Value = employee.Gender
                };

                sqlCommand.Parameters.Add(parameterGender);


                SqlParameter parameterDateOfBirth = new SqlParameter
                {
                    ParameterName = "@DateOfBirth",
                    Value = employee.DateOfBirth
                };

                sqlCommand.Parameters.Add(parameterDateOfBirth);

                SqlParameter parameterCity = new SqlParameter
                {
                    ParameterName = "@City",
                    Value = employee.City
                };

                sqlCommand.Parameters.Add(parameterCity);

                SqlParameter parameterEmployeeType = new SqlParameter
                {
                    ParameterName = "@EmployeeType",
                    Value = employee.Type
                };

                sqlCommand.Parameters.Add(parameterEmployeeType);

                if(employee.GetType() == typeof(FullTimeEmployee))
                //if(employee.Type == EmployeeType.FullTimeEmployee)
                {
                    SqlParameter parameterAnnualSalary = new SqlParameter
                    {
                        ParameterName = "@AnnualSalary",
                        //Value = employee.AnnualSalary
                        Value = ((FullTimeEmployee)employee).AnnualSalary
                    };

                    sqlCommand.Parameters.Add(parameterAnnualSalary);
                }
                else
                {
                    SqlParameter parameterHourlyPay = new SqlParameter
                    {
                        ParameterName = "@HourlyPay",
                        Value = ((PartTimeEmployee)employee).HourlyPay
                        //Value = employee.HourlyPay
                    };

                    sqlCommand.Parameters.Add(parameterHourlyPay);

                    SqlParameter parameterHoursWorked = new SqlParameter
                    {
                        ParameterName = "@HoursWorked",
                        Value = ((PartTimeEmployee)employee).HoursWorked
                        //Value= employee.HoursWorked 
                    };

                    sqlCommand.Parameters.Add(parameterHoursWorked);
                }

                con.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
