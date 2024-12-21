using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL
{
    public class PowerSupplyDAO
    {
        readonly IRepository<PowerSupply> _repo;

        public PowerSupplyDAO() {
            _repo = new ProjectRepository<PowerSupply>();
        }

        public async Task<List<PowerSupply>> GetAll() { 
            return await _repo.GetAll();
        }

        public async Task<PowerSupply> GetOne(int id)
        {
            return (await _repo.GetOne(part => part.Id == id))!;
        }

        public async Task<int> Add(PowerSupply newPowerSupply) {
            return (await _repo.Add(newPowerSupply)).Id;
        }

        public async Task<int> Delete(int? id)
        {
            return await _repo.Delete((int)id!);
        }

    }
}
