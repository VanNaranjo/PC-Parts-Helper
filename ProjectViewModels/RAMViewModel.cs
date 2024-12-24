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
    public class RAMViewModel
    {
        private readonly RAMDAO _dao;
        public int Id { get; set; }
        public string? name { get; set; }

        public decimal? price { get; set; }

        public string? speed { get; set; }

        public string? modules { get; set; }
        public decimal? price_per_gb { get; set; }

        public string? color { get; set; }

        public decimal first_word_latency { get; set; }

        public decimal cas_latency { get; set; }

        public RAMViewModel()
        {
            _dao = new RAMDAO();
        }

        public async Task<List<RAMViewModel>> GetAll()
        {
            List<RAMViewModel> allVms = new();
            try
            {
                List<RAM> allRAMs = await _dao.GetAll();
                foreach (RAM ram in allRAMs) {

                    RAMViewModel ramVm = new()
                    {
                        Id = ram.Id,
                        name = ram.name,
                        price = ram.price,
                        speed = ram.speed,
                        modules = ram.modules,
                        price_per_gb = ram.price_per_gb,
                        color = ram.color,
                        first_word_latency = ram.first_word_latency,
                        cas_latency = ram.cas_latency
                    };
                    allVms.Add(ramVm);
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
