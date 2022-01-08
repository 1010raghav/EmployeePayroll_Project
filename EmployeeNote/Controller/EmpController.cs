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




        [HttpPost]
        [Route("api/AddEmployeeDetails")]
        public IActionResult AddEmployeeDetails([FromBody] EmployeeDetails EmployeeDetails)
        {
            try
            {
                var message = this.manager.AddEmployeeDetails(EmployeeDetails);
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

        
        

        [HttpDelete]
        [Route("api/deleteData")]
        public IActionResult Delete(int deleteData)
        {
            try
            {
                var message = this.manager.Delete(deleteData);
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


        [HttpPut]
        [Route("api/editData")]
        public IActionResult EditDetails(EmployeeDetails employee)
        {
            try
            {
                var message = this.manager.Edit(employee);
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
    }
}
