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

    #region DTOs

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_CHLD_ClientImages
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int ImageID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int ClientID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageURL { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageUUID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public DTO_CORE_Clients CORE_Clients { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_CHLD_GigImages
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int ImageID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int GigID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageURL { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageUUID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public DTO_CORE_Gigs CORE_Gigs { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_CHLD_StudentImages
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int ImageID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int StudentID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageURL { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageUUID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public DTO_CORE_Students CORE_Students { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_CHLD_StudentLoans
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int LoanID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int StudentID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int CompanyID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<double> LoanAmount { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string AccountNum { get; set; }

        [System.Runtime.Serialization.DataMember]
        public DTO_SPRT_LoanCompanies SPRT_LoanCompanies { get; set; }

        [System.Runtime.Serialization.DataMember]
        public DTO_CORE_Students CORE_Students { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_CHLD_StudentReferences
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int RefID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> StudentID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> TypeID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.DateTimeOffset DateAdded { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string FirstName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string LastName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Email { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string PhoneNumber { get; set; }

        [System.Runtime.Serialization.DataMember]
        public DTO_CORE_Students CORE_Students { get; set; }

        [System.Runtime.Serialization.DataMember]
        public DTO_SPRT_GigTypes SPRT_GigTypes { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_CORE_Clients
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int ClientID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string FirstName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string LastName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.DateTime DateJoined { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Email { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Pass { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Gender { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string PhoneNumber { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<bool> Active { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.ICollection<DTO_CHLD_ClientImages> CHLD_ClientImages { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.ICollection<DTO_CORE_GigAlerts> CORE_GigAlerts { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_CORE_GigAlerts
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int AlertID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int ClientID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int TypeID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Title { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Comment { get; set; }

        [System.Runtime.Serialization.DataMember]
        public double PaymentAmt { get; set; }

        [System.Runtime.Serialization.DataMember]
        public double Long { get; set; }

        [System.Runtime.Serialization.DataMember]
        public double Lat { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.DateTime DateCreated { get; set; }

        [System.Runtime.Serialization.DataMember]
        public bool Active { get; set; }

        [System.Runtime.Serialization.DataMember]
        public DTO_CORE_Clients CORE_Clients { get; set; }

        [System.Runtime.Serialization.DataMember]
        public DTO_SPRT_GigTypes SPRT_GigTypes { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.ICollection<DTO_CORE_Gigs> CORE_Gigs { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_CORE_Gigs
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int GigID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int StudentID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int AlertID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.DateTime DateAccepted { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<System.DateTime> DateClosed { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<double> StudentRating { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<double> ClientRating { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string StudentComments { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ClientComments { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.ICollection<DTO_CHLD_GigImages> CHLD_GigImages { get; set; }

        [System.Runtime.Serialization.DataMember]
        public DTO_CORE_GigAlerts CORE_GigAlerts { get; set; }

        [System.Runtime.Serialization.DataMember]
        public DTO_CORE_Students CORE_Students { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_CORE_Students
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int StudentID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string FirstName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string LastName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.DateTime DateJoined { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Email { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Pass { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int MajorID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int CollegeID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Gender { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<bool> Employed { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Employer { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string PhoneNumber { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<bool> Active { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.ICollection<DTO_CHLD_StudentImages> CHLD_StudentImages { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.ICollection<DTO_CHLD_StudentLoans> CHLD_StudentLoans { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.ICollection<DTO_CHLD_StudentReferences> CHLD_StudentReferences { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.ICollection<DTO_CORE_Gigs> CORE_Gigs { get; set; }

        [System.Runtime.Serialization.DataMember]
        public DTO_SPRT_Colleges SPRT_Colleges { get; set; }

        [System.Runtime.Serialization.DataMember]
        public DTO_SPRT_Majors SPRT_Majors { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.ICollection<DTO_SPRT_GigTypes> SPRT_GigTypes { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_LOG_Events
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int LogID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<System.DateTime> DateLogged { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string LogMessage { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_SPRT_Colleges
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int CollegeID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string CollegeName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.ICollection<DTO_CORE_Students> CORE_Students { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_SPRT_GigCategories
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int CategoryID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Category { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.ICollection<DTO_SPRT_GigTypes> SPRT_GigTypes { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_SPRT_GigTypes
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int TypeID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string TypeName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int CategoryID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.ICollection<DTO_CHLD_StudentReferences> CHLD_StudentReferences { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.ICollection<DTO_CORE_GigAlerts> CORE_GigAlerts { get; set; }

        [System.Runtime.Serialization.DataMember]
        public DTO_SPRT_GigCategories SPRT_GigCategories { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.ICollection<DTO_CORE_Students> CORE_Students { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_SPRT_LoanCompanies
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int CompanyID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string CompanyName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string CompanyState { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.ICollection<DTO_CHLD_StudentLoans> CHLD_StudentLoans { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_SPRT_Majors
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int MajorID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string MajorName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.ICollection<DTO_CORE_Students> CORE_Students { get; set; }

        #endregion // Members
    }

    #endregion // DTOs

    #region Stored Procedure DTOs

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_PROC_GetClientImage_Result
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int ImageID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int ClientID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageURL { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageUUID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageName { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_PROC_GetClientImages_Result
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int ImageID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int ClientID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageURL { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageUUID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageName { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_PROC_GetGigImage_Result
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int ImageID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int GigID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageURL { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageUUID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageName { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_PROC_GetGigImages_Result
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int ImageID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int GigID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageURL { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageUUID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageName { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_proc_GetGigTypes_Result
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int typeid { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string TypeName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Category { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_proc_GetGigTypesByID_Result
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int TypeID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string TypeName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Category { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_proc_GetLoanCompanies_Result
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public string CompanyName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string CompanyState { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_PROC_GetStudentImage_Result
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int ImageID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int StudentID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageURL { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageUUID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageName { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_PROC_GetStudentImages_Result
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public int ImageID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public int StudentID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageURL { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageUUID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageName { get; set; }

        #endregion // Members
    }

    #endregion // Stored Procedure DTOs

    #region Stored Procedure Arguments

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_proc_AddClient_Args
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public string FirstName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string LastName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Email { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Pass { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Gender { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string PhoneNumber { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_PROC_AddClientImage_Args
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> ClientID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageURL { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageUUID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageName { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_proc_AddGigAlert_Args
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> ClientID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> TypeID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Title { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Comment { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<double> PaymentAmt { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<double> @long { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<double> Lat { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_PROC_AddGigImage_Args
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> GigID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageURL { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageUUID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageName { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_proc_AddStudent_Args
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public string FirstName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string LastName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Email { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Pass { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> MajorID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> CollegeID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Gender { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<bool> Employed { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Employer { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string PhoneNumber { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_PROC_AddStudentImage_Args
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> StudentID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageURL { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageUUID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ImageName { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_PROC_GetClientImage_Args
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> ClientID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> ImageID { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_PROC_GetClientImages_Args
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> ClientID { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_PROC_GetGigImage_Args
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> GigID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> ImageID { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_PROC_GetGigImages_Args
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> GigID { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_proc_GetGigTypesByID_Args
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> TypeID { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_PROC_GetStudentImage_Args
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> StudentID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> ImageID { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_PROC_GetStudentImages_Args
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> StudentID { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_proc_UpdateClient_Args
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> ClientID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string FirstName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string LastName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Email { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Pass { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Gender { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string PhoneNumber { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<bool> Active { get; set; }

        #endregion // Members
    }

    [System.Runtime.Serialization.DataContract]
    public partial class DTO_proc_UpdateStudent_Args
    {
        #region Members

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> StudentID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string FirstName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string LastName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Email { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Pass { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> MajorID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<int> CollegeID { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Gender { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<bool> Employed { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Employer { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string PhoneNumber { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Nullable<bool> Active { get; set; }

        #endregion // Members
    }

    #endregion // Stored Procedure Arguments
}
