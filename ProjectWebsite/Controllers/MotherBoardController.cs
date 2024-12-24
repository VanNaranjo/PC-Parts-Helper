using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectViewModels;

namespace ProjectWebsite.Controllers
{
    [Route("api/[controller]")]
    public class MotherBoardController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                MotherBoardViewModel viewModel = new();
                List<MotherBoardViewModel> allMotherBoards = await viewModel.GetAll();
                return Ok(allMotherBoards);
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
