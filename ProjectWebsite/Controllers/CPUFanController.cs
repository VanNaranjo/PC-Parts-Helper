using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectViewModels;

namespace ProjectWebsite.Controllers
{
    [Route("api/[controller]")]
    
    public class CPUFanController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                CPUFanViewModel viewModel = new();
                List<CPUFanViewModel> allCPUFans = await viewModel.GetAll();
                return Ok(allCPUFans);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
