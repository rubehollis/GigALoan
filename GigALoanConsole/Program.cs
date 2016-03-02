using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GigALoanModel;
using GigALoan_DAL;

namespace GigALoanConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();

            var colleges = svc.GetColleges();

            foreach (var o in colleges)
            {
                Console.WriteLine(string.Format("{0}: {1}", o.CollegeID, o.CollegeName));
            }
            Console.ReadKey();
        }
    }
}
