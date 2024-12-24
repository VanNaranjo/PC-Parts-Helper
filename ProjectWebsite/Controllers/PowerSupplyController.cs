using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectViewModels;

namespace ProjectWebsite.Controllers
{
    [Route("api/[controller]")]
    public class PowerSupplyController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                PowerSupplyViewModel viewModel = new();
                List<PowerSupplyViewModel> allPowerSupply = await viewModel.GetAll();
                return Ok(allPowerSupply);
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
