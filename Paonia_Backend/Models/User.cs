//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Paonia_Backend.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DateofBirth { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public string IdentificationNumberType { get; set; }
        public string IdentificationNumber { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string PersonalEmailID { get; set; }
        public string ContactNumber { get; set; }
        public string CompanyEmailID { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string Designation { get; set; }
        public string EmployeeType { get; set; }
        public string IsActive { get; set; }
    }
}
