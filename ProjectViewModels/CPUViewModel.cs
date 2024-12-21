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
    public class CPUViewModel
    {
        private readonly CPUDAO _dao;
        public int Id {  get; set; }
        public string? name { get; set; }
        public decimal? price { get; set; }
        public int core_count { get; set; }
        public decimal? boost_clock {  get; set; }
        public int tdp {  get; set; }
        public string? graphics { get; set; }
        public string? smt {  get; set; }

        public CPUViewModel() { 
            _dao = new CPUDAO();
        }

        public async Task<List<CPUViewModel>> GetAll()
        {
            List<CPUViewModel> allVms = new();
            try
            {
                List<CPU> allCPUs = await _dao.GetAll();

                foreach(CPU cpu in allCPUs)
                {
                    CPUViewModel cpuVm = new()
                    {
                        Id = cpu.Id,
                        name = cpu.name,
                        price = cpu.price,
                        core_count = cpu.core_count,
                        boost_clock = cpu.boost_clock,
                        tdp = cpu.tdp,
                        graphics = cpu.graphics,
                        smt = cpu.smt

                    };
                    allVms.Add(cpuVm);
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
