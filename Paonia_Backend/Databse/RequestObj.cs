using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Paonia_Backend.Databse
{
    public class LoginRequest
    {
        public string EmployeeId { get; set; }
        public string Password { get; set; }
    }
    public class UserModel
    {

        public int Id { get; set; }
        public string EmployeeId { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string firstName { get; set; }

        [Display(Name = "Middle name")]
        public string middleName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string lastname { get; set; }

        [Required]
        [Display(Name = "DateofBirth")]
        public DateTime DateofBirth { get; set; }


        [Display(Name = "Age")]
        public int? Age { get; set; }

        [Required]
        [Display(Name = "JoiningDate")]
        public DateTime JoiningDate { get; set; }

       

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "PersonalEmailID")]
        public string PersonalEmailID { get; set; }

        [Required]
        [Display(Name = "ContactNumber")]
        public string ContactNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "CompanyEmailID")]
        public string CompanyEmailID { get; set; }


        [Display(Name = "EmergencyContactName")]
        public string EmergencyContactName { get; set; }

        [Display(Name = "EmergencyContactNumber")]
        public string EmergencyContactNumber { get; set; }

        
        [Display(Name = "EmergencyContactRelation")]
        public string EmergencyContactRelation { get; set; }

        [Required]
        [Display(Name = "Designation")]
        public string Designation { get; set; }

        [Required]
        [Display(Name = "EmployeeType")]
        public string EmployeeType { get; set; }

        [Required]
        [Display(Name = "IsActive")]
        public string IsActive { get; set; }

    }



    public class LeaveReq
    {

        public int Id { get; set; }

        public string EmployeeId { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Middle name")]
        public string middleName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string lastname { get; set; }

        

        [DataType(DataType.EmailAddress)]
        [Display(Name = "SenderEmailID")]
        public string SenderEmailID { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "ReceiverName")]
        public string ReceiverName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "ReceiverEmailID")]
        public string ReceiverEmailID { get; set; }

        [Required]
        [Display(Name = "LeaveStart")]
        public DateTime LeaveStart { get; set; }

        [Required]
        [Display(Name = "LeaveEnd")]
        public DateTime LeaveEnd { get; set; }

        [Required]
        [Display(Name = "LeaveType")]
        public string LeaveType { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }


        [Display(Name = "Status")]
        public string Status { get; set; }

    }

}