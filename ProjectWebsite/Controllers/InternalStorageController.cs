using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectViewModels;

namespace ProjectWebsite.Controllers
{
    [Route("api/[controller]")]
    public class InternalStorageController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                InternalStorageViewModel viewModel = new();
                List<InternalStorageViewModel> allInternalStorage = await viewModel.GetAll();
                return Ok(allInternalStorage);
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
