using Microsoft.AspNetCore.Mvc;
using ProjectViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebsite.Controllers
{
    [Route("api/[controller]")]
    public class PricingController : ControllerBase
    {
        public PricingController() { }

        [HttpGet("{price}/{purpose}")]
        public async Task<IActionResult> CalculateComponents(decimal price, string purpose)
        {
            decimal cpuBudget = price * 0.20M;
            decimal gpuBudget = price * 0.40M;
            decimal motherboardBudget = price * 0.15M;
            decimal ramBudget = price * 0.15M;
            decimal cpufanBudget = price * 0.08M;
            decimal psuBudget = price * 0.07M;

            CPUViewModel cpuViewModel = new();
            CPUFanViewModel cpuFanViewModel = new();
            GPUViewModel gpuViewModel = new();
            MotherBoardViewModel motherBoardViewModel = new();
            RAMViewModel ramViewModel = new();
            InternalStorageViewModel internalStorageViewModel = new();
            PowerSupplyViewModel powerSupplyViewModel = new();

            List<CPUViewModel> allCPUs = await cpuViewModel.GetAll();
            List<GPUViewModel> allGPUs = await gpuViewModel.GetAll();
            List<MotherBoardViewModel> allMotherboards = await motherBoardViewModel.GetAll();
            List<RAMViewModel> allRAMs = await ramViewModel.GetAll();
            List<CPUFanViewModel> allCoolers = await cpuFanViewModel.GetAll();
            List<PowerSupplyViewModel> allPSUs = await powerSupplyViewModel.GetAll();

            List<CPUViewModel> overBudgetCPUs = allCPUs
                .Where(cpu => cpu.price > cpuBudget &&
                              (purpose != "gaming" || (cpu.name == null || (!cpu.name.Contains("Xeon", StringComparison.OrdinalIgnoreCase) && !cpu.name.Contains("Threadripper", StringComparison.OrdinalIgnoreCase)))))
                .OrderBy(cpu => cpu.price - cpuBudget)
                .Take(2)
                .ToList();

            List<CPUViewModel> underBudgetCPUs = allCPUs
                .Where(cpu => cpu.price <= cpuBudget &&
                              (purpose != "gaming" || (cpu.name == null || (!cpu.name.Contains("Xeon", StringComparison.OrdinalIgnoreCase) && !cpu.name.Contains("Threadripper", StringComparison.OrdinalIgnoreCase)))))
                .OrderByDescending(cpu => cpu.price)
                .Take(3)
                .ToList();

            List<GPUViewModel> overBudgetGPUs = allGPUs
                .Where(gpu => gpu.price > gpuBudget &&
                              (purpose != "gaming" || (gpu.chipset == null || (!gpu.chipset.Contains("Radeon Pro", StringComparison.OrdinalIgnoreCase) && !gpu.chipset.Contains("Quadro RTX", StringComparison.OrdinalIgnoreCase)))))
                .OrderBy(gpu => gpu.price - gpuBudget)
                .Take(2)
                .ToList();

            List<GPUViewModel> underBudgetGPUs = allGPUs
                .Where(gpu => gpu.price <= gpuBudget &&
                              (purpose != "gaming" || (gpu.chipset == null || (!gpu.chipset.Contains("Radeon Pro", StringComparison.OrdinalIgnoreCase) && !gpu.chipset.Contains("Quadro RTX", StringComparison.OrdinalIgnoreCase)))))
                .OrderByDescending(gpu => gpu.price)
                .Take(3)
                .ToList();

            List<MotherBoardViewModel> overBudgetMotherboards = allMotherboards.Where(motherboard => motherboard.price > motherboardBudget)
                .OrderBy(motherboard => motherboard.price - motherboardBudget)  
                .Take(2) 
                .ToList();

            List<MotherBoardViewModel> underBudgetMotherboards = allMotherboards.Where(motherboard => motherboard.price <= motherboardBudget)
                .OrderByDescending(motherboard => motherboard.price) 
                .Take(3)  
                .ToList();

            List<RAMViewModel> overBudgetRAMs = allRAMs.Where(ram => ram.price > ramBudget)
                .OrderBy(ram => ram.price - ramBudget) 
                .Take(2) 
                .ToList();

            List<RAMViewModel> underBudgetRAMs = allRAMs.Where(ram => ram.price <= ramBudget)
                .OrderByDescending(ram => ram.price)  
                .Take(3)  
                .ToList();

            List<CPUFanViewModel> overBudgetCoolers = allCoolers.Where(cooler => cooler.price > cpufanBudget)
                .OrderBy(cooler => cooler.price - cpufanBudget) 
                .Take(2)
                .ToList();

            List<CPUFanViewModel> underBudgetCoolers = allCoolers.Where(cooler => cooler.price <= cpufanBudget)
                .OrderByDescending(cooler => cooler.price)  
                .Take(3) 
                .ToList();

            List<PowerSupplyViewModel> overBudgetPSUs = allPSUs.Where(psu => psu.price > psuBudget)
                .OrderBy(psu => psu.price - psuBudget)  
                .Take(2)  
                .ToList();

            List<PowerSupplyViewModel> underBudgetPSUs = allPSUs.Where(psu => psu.price <= psuBudget)
                .OrderByDescending(psu => psu.price)  
                .Take(3) 
                .ToList();


            var result = new
            {
                CPU = new { OverBudget = overBudgetCPUs, UnderBudget = underBudgetCPUs },
                GPU = new { OverBudget = overBudgetGPUs, UnderBudget = underBudgetGPUs },
                Motherboard = new { OverBudget = overBudgetMotherboards, UnderBudget = underBudgetMotherboards },
                RAM = new { OverBudget = overBudgetRAMs, UnderBudget = underBudgetRAMs },
                Cooler = new { OverBudget = overBudgetCoolers, UnderBudget = underBudgetCoolers },
                PSU = new { OverBudget = overBudgetPSUs, UnderBudget = underBudgetPSUs }
            };

            return Ok(result);

        }

    }
}
