
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
                var result = datamodel.AddUpdateEmployeeDetails(req.Id, req.EmployeeId, req.firstName, req.middleName, req.lastname, req.DateofBirth, req.Age, req.JoiningDate, req.IdentificationNumberType,
                                                     req.IdentificationNumber, req.Gender, req.password, req.PersonalEmailID, req.ContactNumber, req.CompanyEmailID, req.EmergencyContactName,
                                                     req.EmergencyContactNumber, req.Designation, req.EmployeeType, req.IsActive);

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


    }
}
