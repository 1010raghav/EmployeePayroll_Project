using EmployeeManager.Interface;
using EmployeeModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeNote.Controller
{
    
    public class EmpController : ControllerBase
    {
        private readonly IEmpManager manager;

        public EmpController(IEmpManager manager)
        {
            this.manager = manager;
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
                var message = await this.manager.AddEmployeeDetails(EmployeeDetails);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string> { Status = true, Message = "Employee Details Added Successfully", Data = message.ToString() });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = "Employee Details Are NOT Added" });
                }
            }
            catch (Exception ex)
            {
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
        public async Task<IActionResult> Delete(int deleteData)
        {
            try
            {
                var message = await this.manager.Delete(deleteData);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string> { Status = true, Message = "Data Deleted Successfully", Data = message.ToString() });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = "Data Delete Unsuccessful" });
                }
            }
            catch (Exception ex)
            {
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
        public async Task<IActionResult> EditDetails(EmployeeDetails employee)
        {
            try
            {
                var message = await this.manager.Edit(employee);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string> { Status = true, Message = "Information Edited Successfully", Data= message.ToString() });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = "Error Information Editing UnSuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message=ex.Message });
            }
        }

        [HttpGet]
        [Route("api/GetData")]
        public  IActionResult GetDetails(EmployeeDetails Getemployee)
        {
            try
            {
                IEnumerable<EmployeeDetails> message = this.manager.Get(Getemployee);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string> { Status = true, Message = "Employee Details viewed Successfully", Data = message.ToString() });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = "Cannot view Employee Details" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }

    }
}
