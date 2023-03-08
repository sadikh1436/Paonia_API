
using System;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Paonia_Backend.Databse;

using Paonia_Backend.Databse.DataModel;


namespace Paonia_Backend.Controllers
{
    [RoutePrefix("api/Employee")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class EmployeeController : ApiController
    {
        private PaoniaEntities PE = new PaoniaEntities();

        AllDataModelDetails datamodel = new AllDataModelDetails();

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [Route("AddUpdateEmployee")]

        [HttpPost]
        public HttpResponseMessage AddUpdateEmployee(UserModel req)
        {
            try
            {
                var result = datamodel.AddUpdateEmployeeDetails(req.Id, req.EmployeeId, req.firstName, req.middleName, req.lastname, req.DateofBirth, req.Age, req.JoiningDate, 
                                                      req.Gender, req.password, req.PersonalEmailID, req.ContactNumber, req.CompanyEmailID, req.EmergencyContactName,
                                                     req.EmergencyContactNumber, req.EmergencyContactRelation, req.Designation, req.EmployeeType, req.IsActive);

                var sc = Convert.ToInt32(result.StatusCode);

                if (sc > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { StatusMessage = result.StatusMessage });
                }
                else if (sc == -1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { StatusMessage = result.StatusMessage });
                }
                else if (sc == 0)
                {
                    Log.Fatal(result.StatusMessage);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { StatusMessage = result.StatusMessage });
                }
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { StatusMessage = "Internal Server Error" });
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.InnerException == null ? ex.Message : ex.InnerException.Message, ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException == null ? ex.Message : ex.InnerException.InnerException.Message);
            }
        }

        [Route("LoginEmployee")]
        [HttpPost]
        public HttpResponseMessage LoginEmployee(LoginRequest login)
        {


            try
            {
                var loginDetails = PE.Login(login.EmployeeId, login.Password);

                if (loginDetails == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid User details");
                }
                else
                {

                    return Request.CreateResponse(HttpStatusCode.OK, new { LoginDetails = loginDetails, success = "Employee Login Successfully" });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.InnerException == null ? ex.Message : ex.InnerException.Message, ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }

        }

        [Route("GetAllEmployees/{Id}")]

        [HttpGet]
        public HttpResponseMessage GetAllEmployees(int? Id)
        {
            try
            {
                var employeesList = datamodel.GetAllEmployees(Id);

                if (employeesList == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid User");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { AllEmployee = employeesList, status = "true" });

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.InnerException == null ? ex.Message : ex.InnerException.Message, ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        [Route("GetEmployeeInfoById/{EmployeeId}")]

        [HttpGet]
        public HttpResponseMessage GetEmployeeInfoById(string EmployeeId)
        {
            try
            {
                var result = datamodel.GetEmployeeInfoById(EmployeeId);

                if (result == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid UserId");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { UserDetails = result, success = "Get Employee Details Successfully" });
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.InnerException == null ? ex.Message : ex.InnerException.Message, ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }






        ///////////////     Setting Page ///////////////


        [Route("AddUpdateRoles")]

        [HttpPost]
        public HttpResponseMessage AddUpdateRoles(RoleReq req)
        {
            try
            {
                var result = datamodel.AddUpdateRoles(req.Id, req.RoleCode, req.RoleName, req.RoleStatus);

                var sc = Convert.ToInt32(result.StatusCode);

                if (sc > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { StatusMessage = result.StatusMessage });
                }
                else if (sc == -1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { StatusMessage = result.StatusMessage });
                }
                else if (sc == 0)
                {
                    Log.Fatal(result.StatusMessage);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { StatusMessage = result.StatusMessage });
                }
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { StatusMessage = "Internal Server Error" });
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.InnerException == null ? ex.Message : ex.InnerException.Message, ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException == null ? ex.Message : ex.InnerException.InnerException.Message);
            }
        }



        [Route("AddUpdateLeaveType")]

        [HttpPost]
        public HttpResponseMessage AddUpdateLeaveType(LeavetypeReq req)
        {
            try
            {
                var result = datamodel.AddUpdateLeaveType(req.Id, req.LeaveTypeCode, req.LeaveTypeName, req.LeaveTypeStatus);

                var sc = Convert.ToInt32(result.StatusCode);

                if (sc > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { StatusMessage = result.StatusMessage });
                }
                else if (sc == -1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { StatusMessage = result.StatusMessage });
                }
                else if (sc == 0)
                {
                    Log.Fatal(result.StatusMessage);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { StatusMessage = result.StatusMessage });
                }
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { StatusMessage = "Internal Server Error" });
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.InnerException == null ? ex.Message : ex.InnerException.Message, ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException == null ? ex.Message : ex.InnerException.InnerException.Message);
            }
        }



        [Route("AddUpdateEmpType")]

        [HttpPost]
        public HttpResponseMessage AddUpdateEmpType(EmptypeReq req)
        {
            try
            {
                var result = datamodel.AddUpdateEmpType(req.Id, req.EmpTypeCode, req.EmpTypeName, req.EmpTypeStatus);

                var sc = Convert.ToInt32(result.StatusCode);

                if (sc > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { StatusMessage = result.StatusMessage });
                }
                else if (sc == -1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { StatusMessage = result.StatusMessage });
                }
                else if (sc == 0)
                {
                    Log.Fatal(result.StatusMessage);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { StatusMessage = result.StatusMessage });
                }
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { StatusMessage = "Internal Server Error" });
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.InnerException == null ? ex.Message : ex.InnerException.Message, ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException == null ? ex.Message : ex.InnerException.InnerException.Message);
            }
        }

        [Route("GetRolesListById/{Id}")]

        [HttpGet]
        public HttpResponseMessage GetRolesListById(int? Id)
        {
            try
            {
                var rolesList = datamodel.GetRolesListById(Id);

                if (rolesList == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid User");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { AllRoles = rolesList, status = "true" });

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.InnerException == null ? ex.Message : ex.InnerException.Message, ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }


        [Route("GetLeaveTypesListById/{Id}")]

        [HttpGet]
        public HttpResponseMessage GetLeaveTypesListById(int? Id)
        {
            try
            {
                var leaveTypeList = datamodel.GetLeaveTypesListById(Id);

                if (leaveTypeList == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid User");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { AllLeaveTypes = leaveTypeList, status = "true" });

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.InnerException == null ? ex.Message : ex.InnerException.Message, ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }


        [Route("GetEmpTypesListById/{Id}")]

        [HttpGet]
        public HttpResponseMessage GetEmpTypesListById(int? Id)
        {
            try
            {
                var empTypeList = datamodel.GetEmpTypesListById(Id);

                if (empTypeList == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid User");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { AllEmpTypes = empTypeList, status = "true" });

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.InnerException == null ? ex.Message : ex.InnerException.Message, ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }



        ///////////////Setting Page ///////////////

    }
}
