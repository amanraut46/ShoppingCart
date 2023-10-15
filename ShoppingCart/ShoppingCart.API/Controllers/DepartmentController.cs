using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.API.Services;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _departmentService;

        public DepartmentController(IDepartment departmentService)
        {
            this._departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _departmentService.GetAllDepartments());
        }

        //[HttpGet]
        //public async Task<IActionResult> Get(int id)
        //{
        //    return Ok(await _departmentService.GetDepartmentById(id));
        //}
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string name)
        {
            return Ok((await _departmentService.AddDepartment(name)).Item2);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, string department)
        {
            return Ok((await _departmentService.UpdateDepartment(id, department)).Item2);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok((await _departmentService.DeleteDepartment(id)).Item2);
        }
    }
}