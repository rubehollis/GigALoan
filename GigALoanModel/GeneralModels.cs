using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GigALoanModel
{
    [DataContract]
    public class DTO_College
    {
        [DataMember]
        public int CollegeID { get; set; }
        [DataMember]
        public string CollegeName { get; set; }
    }
}
