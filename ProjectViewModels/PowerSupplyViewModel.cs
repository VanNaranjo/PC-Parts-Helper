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
    public class PowerSupplyViewModel
    {
        private readonly PowerSupplyDAO _dao;
        public int Id { get; set; }
        public string? name { get; set; }

        public decimal? price { get; set; }

        public string? type { get; set; }

        public string? efficiency { get; set; }

        public int wattage { get; set; }

        public string? modular { get; set; }

        public string? color { get; set; }

        public PowerSupplyViewModel()
        {
            _dao = new PowerSupplyDAO();
        }

        public async Task<List<PowerSupplyViewModel>> GetAll()
        {
            List<PowerSupplyViewModel> allVms = new();
            try
            {
                List<PowerSupply> allPowerSupply = await _dao.GetAll();

                foreach(PowerSupply powerSupply in allPowerSupply)
                {
                    PowerSupplyViewModel powerSupplyVm = new()
                    {
                        Id = powerSupply.Id,
                        name = powerSupply.name,
                        price = powerSupply.price,
                        type = powerSupply.type,
                        efficiency = powerSupply.efficiency,
                        wattage = powerSupply.wattage,
                        modular = powerSupply.modular,
                        color = powerSupply.color
                    };
                    allVms.Add(powerSupplyVm);
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
