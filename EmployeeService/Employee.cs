using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
//    [MessageContract(IsWrapped = true, WrapperName = "EmployeeRequestObject", WrapperNamespace = "http://thesoft.co/Employee")]
//    public class EmployeeRequest
//    {
//        public EmployeeRequest()
//        {

//        }

//        public EmployeeRequest(string licenceKey, int employeeId)
//        {
//            LicenceKey = licenceKey;
//            EmployeeId = employeeId;
//        }

//        [MessageHeader(Namespace= "http://thesoft.co/Employee")]
//        public string LicenceKey { get; set; }

//        [MessageBodyMember(Namespace = "http://thesoft.co/Employee")]
//        public int EmployeeId { get; set; }
//    }

    
//    /// <summary>
//    /// Employee response starts here
//    /// </summary>
//    [MessageContract(IsWrapped = true, WrapperName = "EmployeeInfoObject", WrapperNamespace = "http://thesoft.co/Employee")]
//    public class EmployeeInfo
//    {

//        public EmployeeInfo()
//        {

//        }

//        public EmployeeInfo(Employee employee)
//        {
//            Id = employee.Id;
//            Name = employee.Name;
//            Gender = employee.Gender;
//            DOB = employee.DateOfBirth;
//            Type = employee.Type;
//            if(Type == EmployeeType.FullTimeEmployee)
//            {
//                AnnualSalary = ((FullTimeEmployee) employee).AnnualSalary;
//            }
//            else
//            {
//                HourlyPay = ((PartTimeEmployee) employee).HourlyPay;
//                HoursWorked = ((PartTimeEmployee) employee).HoursWorked;
//            }
//        }

//        [MessageBodyMember(Order = 1, Namespace = "http://thesoft.co/Employee")]
//        public int Id { get; set; }

//        [MessageBodyMember(Order = 2, Namespace = "http://thesoft.co/Employee")]
//        public string Name { get; set; }

//        [MessageBodyMember(Order = 3, Namespace = "http://thesoft.co/Employee")]
//        public string Gender { get; set; }

//        [MessageBodyMember(Order = 4, Namespace = "http://thesoft.co/Employee")]
//        public DateTime DOB { get; set; }

//        [MessageBodyMember(Order = 5, Namespace = "http://thesoft.co/Employee")]
//        public EmployeeType Type { get; set; }

//        [MessageBodyMember(Order = 6, Namespace = "http://thesoft.co/Employee")]
//        public decimal AnnualSalary { get; set; }

//        [MessageBodyMember(Order = 7, Namespace = "http://thesoft.co/Employee")]
//        public decimal HourlyPay { get; set; }

//        [MessageBodyMember(Order = 8, Namespace = "http://thesoft.co/Employee")]
//        public int HoursWorked { get; set; }
//    }


    //[KnownType(typeof(FullTimeEmployee))]
    //[KnownType(typeof(PartTimeEmployee))]
    [DataContract(Namespace = "http://thesoft.oncode.com/Employee")]
    public class Employee
    {
        private int _id;
        private string _name;
        private string _gender;
        private string _city;
        private DateTime _dateOfBirth;


        [DataMember(Name="Id", Order = 1)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember(Order = 2)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember(Order = 3)]
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        [DataMember(Order = 4)]
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
            }
        }

        [DataMember(Order = 5)]
        public EmployeeType Type { get; set; }

        [DataMember(Order = 6)]
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

    }

    public enum EmployeeType
    {
        FullTimeEmployee = 1,
        PartTimeEmployee = 2
    }
}
