using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using EmployeeService;

namespace EmployeeServiceHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(EmployeeService.EmployeeService)))
            {
                host.Open();
                Console.WriteLine("Host Started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
