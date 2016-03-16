using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GigALoanModel;
using GigALoan_DAL;
// Hello, my name is Ryan
// And this is Alyssa\//my name is not nick

    //FORK CHANGE by GigALoanTest
    //demonstrating forking, cloning, changing, 
    //committing, pushing, and merge/pull requests

    // FORK CHANGE

    // FORK CHANGE 2

    //fork testing commit
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
