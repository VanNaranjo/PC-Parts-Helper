using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ProjectDAL;

namespace ProjectViewModels
{
    public class GPUViewModel
    {
        private readonly GPUDAO _dao;
        public string? name { get; set; }

        public decimal? price { get; set; }

        public string? chipset { get; set; }

        public decimal memory { get; set; }

        public int? core_clock { get; set; }

        public int? boost_clock { get; set; }

        public string? color { get; set; }

        public int? length { get; set; }

        public GPUViewModel() { 
            _dao = new GPUDAO();
        }

        public async Task<List<GPUViewModel>> GetAll()
        {
            List<GPUViewModel> allVms = new();

            try
            {
                List<GPU> allGPUs = await _dao.GetAll();

                foreach(GPU gpu in allGPUs)
                {
                    GPUViewModel gpuVm = new()
                    {
                        name = gpu.name,
                        price = gpu.price,
                        chipset = gpu.chipset,
                        memory = gpu.memory,
                        core_clock = gpu.core_clock,
                        boost_clock = gpu.boost_clock,
                        color = gpu.color,
                        length = gpu.length
                    };
                    allVms.Add(gpuVm);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
            }
            return allVms;
        }

    }
}
