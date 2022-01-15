// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Raghavendra Narendra Wandre"/>
// ----------------------------------------------------------------------------------------------------------
namespace EmployeeNote.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EmployeeManager.Interface;
    using EmployeeModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    
    public class EmpController : ControllerBase
    {
        private readonly IEmpManager manager;
        private readonly ILogger<EmpController> logger;

        public EmpController(IEmpManager manager, ILogger<EmpController> logger)
        {
            this.manager = manager;
            this.logger = logger;
        }

        /// <summary>
        /// This method is used for post the employee details in the web application
        /// </summary>
        /// <param name="EmployeeDetails">EmployeeDetails contains the information about the employee</param>
        /// <returns>This methods returns IActionResult for uploading Employee Details</returns>
        [HttpPost]
        [Route("api/AddEmployeeDetails")]
        public async Task<IActionResult> AddEmployeeDetails([FromBody] EmployeeDetails EmployeeDetails)
        {
            try
            {
                this.logger.LogInformation(EmployeeDetails.FullName + " typing for new user");
                var message = await this.manager.AddEmployeeDetails(EmployeeDetails);
                if (message != null)
                {
                    this.logger.LogInformation(EmployeeDetails.FullName + " has Successfully Registered New User");
                    return this.Ok(new { Status = true, Message = "Employee Details Added Successfully", Data = message });
                }
                else
                {
                    this.logger.LogInformation(EmployeeDetails.FullName + "Failed to Registered New User");
                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = "Employee Details Are NOT Added" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation(EmployeeDetails.FullName + " had Exception while Registered New User");
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// This method is used for delete the employee details in the web application
        /// </summary>
        /// <param name="deleteData"dataDetails deletes the information about the employee</param>
        /// <returns>This methods returns IActionResult for Delete Employee Details</returns>
        [HttpDelete]
        [Route("api/deleteData")]
        public async Task<IActionResult> Delete(int EmployeeID)
        {
            try
            {
                this.logger.LogInformation(EmployeeID + " typing to delete the data");
                var message = await this.manager.Delete(EmployeeID);
                if (message != null)
                {
                    this.logger.LogInformation(EmployeeID + " has Successfully deleted the data");
                    return this.Ok(new { Status = true, Message = "Data Deleted Successfully", Data = message });
                }
                else
                {
                    this.logger.LogInformation(EmployeeID + "Failed to deleted the data");
                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = "Data Delete Unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation(EmployeeID + " had Exception While deleting the data");
                return this.NotFound(new ResponseModel<string> { Status = false, Message=ex.Message });
            }
        }

        /// <summary>
        ///  This method is used for edit the employee details in the web application
        /// </summary>
        /// <param name="employee">employee edits the information about the employee </param>
        /// <returns>This methods returns IActionResult for Edit Employee Details</returns>
        [HttpPut]
        [Route("api/editData")]
        public async Task<IActionResult> EditDetails(int EmployeeID,string FullName,string Gender, int Salary,int StartDate,string Department)
        {
            try
            {
                this.logger.LogInformation(EmployeeID + " Typnig to Edit the Data");
                var message = await this.manager.Edit(EmployeeID,FullName,Gender,Salary,StartDate,Department);
                if (message !=null)
                {
                    this.logger.LogInformation(EmployeeID + " has Successfully Edited the data");
                    return this.Ok(new { Status = true, Message = "Information Edited Successfully", Data= message});
                }
                else
                {
                    this.logger.LogInformation(EmployeeID + " Failed to Edit the data");
                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = "Error Information Editing UnSuccessful" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation(EmployeeID + " had Exception while Editing the data");
                return this.NotFound(new ResponseModel<string> { Status = false, Message=ex.Message });
            }
        }

        /// <summary>
        ///  This method is used for geting the employee details in the web application
        /// </summary>
        /// <param name="employee">employee gets the information about the employee </param>
        /// <returns>This methods returns IActionResult for Getting Employee Details</returns>
        [HttpGet]
        [Route("api/GetData")]
        public  IActionResult GetDetails()
        {
            try
            {
                this.logger.LogInformation(" Typnig for get the data");
                IEnumerable<EmployeeDetails> message = this.manager.Get();
                if (message != null)
                {
                    this.logger.LogInformation(" has Successfully Got the data");
                    return this.Ok(new { Status = true, Message = "Employee Details viewed Successfully", Data = message });
                }
                else
                {
                    this.logger.LogInformation( " Failed to get the data");
                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = "Cannot view Employee Details" });
                }
            }
            catch (Exception ex)
            { 
                this.logger.LogError(" had Exception While getting the data");
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }
    }
}
