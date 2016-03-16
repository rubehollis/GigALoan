using GigALoanModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GigALoan_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetName()
        {
            return "First Web Service";
        }

        public string GetFirstCollege()
        {
            using (GigALoan_DAL.DB_42039_gigEntities context = new GigALoan_DAL.DB_42039_gigEntities())
            {
                var college = context.SPRT_Colleges.First();

                return college.CollegeName;
            }
        }

        public List<DTO_College> GetColleges()
        {
            List<DTO_College> returnList = new List<DTO_College>();
            using(GigALoan_DAL.DB_42039_gigEntities context = new GigALoan_DAL.DB_42039_gigEntities())
            {
                var list = context.SPRT_Colleges.Take(10).ToList();

                foreach(var c in list)
                {
                    var college = new DTO_College();

                    college.CollegeID = c.CollegeID;
                    college.CollegeName = c.CollegeName;

                    returnList.Add(college);
                }

                return returnList;
            }
        }
    }
}
