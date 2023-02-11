using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using Paonia_Backend.Databse;

namespace Paonia_Backend.Databse.DataModel
{
    public class AllDataModelDetails
    {
        PaoniaEntities PE = new PaoniaEntities();

        public ResponseObject AddUpdateEmployeeDetails(int? Id, string EmployeeId, string firstName, string middleName, string lastname, DateTime dateofBirth,
                                          int? age, DateTime joiningDate, string Gender, string password, string personalEmailID,
                                          string contactNumber, string companyEmailID, string emergencyContactName, string emergencyContactNumber, string emergencyContactRelation,
                                          string designation, string employeeType, string IsActive)
        {
            try
            {
                ObjectParameter statusCode = new ObjectParameter("StatusCode", typeof(int));
                ObjectParameter statusMessage = new ObjectParameter("StatusMessage", typeof(string));

                PE.AddUpdateEmployeeDetails(Id, EmployeeId, firstName, middleName, lastname, dateofBirth, age, joiningDate,
                    Gender, password, personalEmailID, contactNumber, companyEmailID, emergencyContactName, emergencyContactNumber, emergencyContactRelation, designation,
                    employeeType, IsActive, statusCode, statusMessage);

                var sc = Convert.ToInt32(statusCode.Value.ToString());
                var sm = statusMessage.Value.ToString();

                return new ResponseObject { StatusCode = sc, StatusMessage = sm };
            }
            catch (Exception ex)
            {
                return new ResponseObject { StatusCode = 0, StatusMessage = ex.InnerException == null ? ex.Message : ex.InnerException.InnerException.Message };
            }
        }


        public List<GetAllEmployees_Result> GetAllEmployees(int? Id)
        {
            var employeesList = PE.GetAllEmployees(Id).ToList();
            return employeesList;
        }

        public ResponseObject EmployeeLeaveRequest(int? Id, string EmployeeId, string firstName, string middleName, string lastname,  string SenderEmailID, string Password, string PhoneNumber, string ReceiverName, string ReceiverEmailID, DateTime LeaveStart,
                                            DateTime LeaveEnd, string LeaveType, string Description, string Status)
        {
            try
            {
                ObjectParameter statusCode = new ObjectParameter("StatusCode", typeof(int));
                ObjectParameter statusMessage = new ObjectParameter("StatusMessage", typeof(string));

                PE.AddUpdateEmployeeLeaveRequest(Id, EmployeeId, SenderEmailID, Password, PhoneNumber, ReceiverName, ReceiverEmailID,
                    LeaveStart, LeaveEnd, LeaveType, Description, Status, statusCode, statusMessage);

                var sc = Convert.ToInt32(statusCode.Value.ToString());
                var sm = statusMessage.Value.ToString();

                return new ResponseObject { StatusCode = sc, StatusMessage = sm };
            }
            catch (Exception ex)
            {
                return new ResponseObject { StatusCode = 0, StatusMessage = ex.InnerException == null ? ex.Message : ex.InnerException.InnerException.Message };
            }
        }



    }
}
