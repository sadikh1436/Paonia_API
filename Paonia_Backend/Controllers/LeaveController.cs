
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using log4net;
using Paonia_Backend.Databse;
using Paonia_Backend.Databse.DataModel;


namespace Paonia_Backend.Controllers
{

    [RoutePrefix("api/Leave")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LeaveController : ApiController
    {
        private PaoniaEntities PE = new PaoniaEntities();

        AllDataModelDetails datamodel = new AllDataModelDetails();

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        [Route("AddUpdateLeaveRequest")]

        [HttpPost]
        public HttpResponseMessage AddUpdateLeaveRequest(LeaveReq leavereq)
        {
            try
            {
                var result = datamodel.EmployeeLeaveRequest(leavereq.Id, leavereq.firstName, leavereq.middleName, leavereq.lastname, leavereq.EmployeeId, leavereq.SenderEmailID, leavereq.Password, leavereq.PhoneNumber,
                leavereq.ReceiverName, leavereq.ReceiverEmailID, leavereq.LeaveStart, leavereq.LeaveEnd, leavereq.LeaveType, leavereq.Description, leavereq.Status);

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


        [Route("GetLeaveslistByEmpId/{EmployeeId}")]

        [HttpGet]


        public HttpResponseMessage GetLeaveslistByEmpId(string EmployeeId)
        {
            try
            {
                var leavesList = PE.GetEmployeeLeavesListByEmpId(EmployeeId);

                if (leavesList == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid User Details");
                }
                else
                {

                    return Request.CreateResponse(HttpStatusCode.OK, new { LeaveDetails = leavesList, success = "Get Employee Leaves list Successfully" });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.InnerException == null ? ex.Message : ex.InnerException.Message, ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        [Route("GetLeaveslistById/{Id}")]

        [HttpGet]


        public HttpResponseMessage GetLeaveslistById(int? Id)
        {
            try
            {
                var allLeaves = PE.GetEmployeeLeavesListById(Id);

                if (allLeaves == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid User Details");
                }
                else
                {

                    return Request.CreateResponse(HttpStatusCode.OK, new { AllLeavesDetails = allLeaves, success = "Get All Employee Leaves list Successfully" });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.InnerException == null ? ex.Message : ex.InnerException.Message, ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        [Route("GetLeaveReceiverList/{Designation}")]
        [HttpGet]

        public HttpResponseMessage GetLeaveReceiverList(string Designation)
        {
            try
            {
                var leaveReceiverDetails = PE.GetLeaveReceiverList(Designation);

                if (leaveReceiverDetails == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid User");
                }
                else
                {

                    return Request.CreateResponse(HttpStatusCode.OK, new { ReceiverDetails = leaveReceiverDetails, success = "Get Admin Details Successfully" });
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
