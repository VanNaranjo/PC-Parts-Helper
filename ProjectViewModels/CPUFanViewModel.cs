using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ProjectDAL;
using Microsoft.Identity.Client;

namespace ProjectViewModels
{
    public class CPUFanViewModel
    {
        private readonly CPUFanDAO _dao;
        public int Id { get; set; }
        public string? name { get; set; }
        public decimal? price { get; set; }
        public string? rpm { get; set; }

        public string? noise_level { get; set; }

        public string? color { get; set; }

        public int? size { get; set; }

        public CPUFanViewModel() { 
            _dao = new CPUFanDAO();
        }

        public async Task<List<CPUFanViewModel>> GetAll()
        {
            List<CPUFanViewModel> allVms = new();
            try
            {
                List<CPUFan> allCPUFans = await _dao.GetAll();
                foreach (CPUFan cpufan in allCPUFans)
                {
                    CPUFanViewModel cpuFanVm = new()
                    {
                        Id = cpufan.Id,
                        name = cpufan.name,
                        price = cpufan.price,
                        rpm = cpufan.rpm,
                        noise_level = cpufan.noise_level,
                        color = cpufan.color,
                        size = cpufan.size

                    };
                    allVms.Add(cpuFanVm);
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
