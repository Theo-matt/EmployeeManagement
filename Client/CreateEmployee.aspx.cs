using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Client.EmployeeService;

namespace Client
{
    public partial class CreateEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetEmployee_Click(object sender, EventArgs e)
        {
            EmployeeService.EmployeeServiceClient client = new EmployeeService.EmployeeServiceClient();
            EmployeeService.Employee employee = client.GetEmployee(Convert.ToInt32(txtId.Text));

            //EmployeeService.IEmployeeService client = new EmployeeService.EmployeeServiceClient();
            //EmployeeService.EmployeeRequest request = new EmployeeService.EmployeeRequest("AXG120ABC", Convert.ToInt32(txtId.Text));
            //EmployeeService.EmployeeInfo employee =  client.GetEmployee(request);

            if (employee.Type == EmployeeService.EmployeeType.FullTimeEmployee)
            {
                txtAnnualSalary.Text = ((EmployeeService.FullTimeEmployee) employee).AnnualSalary.ToString();
                //txtAnnualSalary.Text = employee.AnnualSalary.ToString();
                trAnnualSalary.Visible = true;
                trHourlyPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else
            {

                //txtHourlyPay.Text = employee.HourlyPay.ToString();
                //txtHoursWorked.Text = employee.HoursWorked.ToString();
                txtHourlyPay.Text = ((EmployeeService.PartTimeEmployee)employee).HourlyPay.ToString();
                txtHoursWorked.Text = ((EmployeeService.PartTimeEmployee)employee).HoursWorked.ToString();
                trAnnualSalary.Visible = false;
                trHourlyPay.Visible = true;
                trHoursWorked.Visible = true;
            }

            EmployeeTypeDropDown.SelectedValue = ((int)employee.Type).ToString();

            txtName.Text = employee.Name;
            txtGender.Text = employee.Gender;
            txtDateOfBirth.Text = employee.DateOfBirth.ToShortDateString();
            txtCity.Text = employee.City;
            confirmActionLabel.Text = "Employee Retrieved";
        }

        protected void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            EmployeeService.EmployeeServiceClient client = new EmployeeService.EmployeeServiceClient();
            EmployeeService.Employee employee = null; // new EmployeeService.Employee();

            if(EmployeeTypeDropDown.SelectedValue == "-1")
            {
                confirmActionLabel.Text = "Please Select Employee Type";
            }
           
            if (((EmployeeService.EmployeeType)Convert.ToInt32(EmployeeTypeDropDown.SelectedValue)) == EmployeeService.EmployeeType.FullTimeEmployee)
            {


                //employee.Type = EmployeeService.EmployeeType.FullTimeEmployee;
                employee = new EmployeeService.FullTimeEmployee
                {

                    Id = Convert.ToInt32(txtId.Text),
                    Name = txtName.Text,
                    Gender = txtGender.Text,
                    City = txtCity.Text,
                    DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text),
                    Type = EmployeeService.EmployeeType.FullTimeEmployee,
                    AnnualSalary = Convert.ToDecimal(txtAnnualSalary.Text),
                };

                //employee.AnnualSalary = Convert.ToDecimal(txtAnnualSalary.Text);


                client.SaveEmployee(employee);
                confirmActionLabel.Text = "Employee saved successfully";
            }
            else if (((EmployeeService.EmployeeType)Convert.ToInt32(EmployeeTypeDropDown.SelectedValue)) == EmployeeService.EmployeeType.PartTimeEmployee)
            {
                employee = new EmployeeService.PartTimeEmployee
                {

                    Id = Convert.ToInt32(txtId.Text),
                    Name = txtName.Text,
                    Gender = txtGender.Text,
                    City = txtCity.Text,
                    DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text),
                    Type = EmployeeService.EmployeeType.FullTimeEmployee,
                    HourlyPay = Convert.ToDecimal(txtHourlyPay.Text),
                    HoursWorked = Convert.ToInt32(txtHoursWorked.Text)
            };
                //employee.Type = EmployeeService.EmployeeType.PartTimeEmployee;
                //((EmployeeService.PartTimeEmployee)employee).HourlyPay = Convert.ToDecimal(txtHourlyPay.Text);
                //((EmployeeService.PartTimeEmployee)employee).HoursWorked = Convert.ToInt32(txtHoursWorked.Text);

                client.SaveEmployee(employee);
                confirmActionLabel.Text = "Employee saved successfully";
            }


                //employee.Id = Convert.ToInt32(txtId.Text);
                //employee.Name = txtName.Text;
                //employee.Gender = txtGender.Text;
                //employee.City = txtCity.Text;
                //employee.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);

                //client.SaveEmployee(employee);
                //confirmActionLabel.Text = "Employee saved successfully";

        }

        protected void EmployeeTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(EmployeeTypeDropDown.SelectedValue == "-1")
            {
                trAnnualSalary.Visible = false;
                trHourlyPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else if (EmployeeTypeDropDown.SelectedValue == "1")
            {
                trAnnualSalary.Visible = true;
                trHourlyPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else if (EmployeeTypeDropDown.SelectedValue == "2")
            {
                trAnnualSalary.Visible = false;
                trHourlyPay.Visible = true;
                trHoursWorked.Visible = true;
            }
        }
    }
}