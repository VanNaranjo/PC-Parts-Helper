using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL
{
    public class CPUFanDAO
    {
        readonly IRepository<CPUFan> _repo;

        public CPUFanDAO() { 
            _repo = new ProjectRepository<CPUFan>();
        }

        public async Task<List<CPUFan>> GetAll() { 
            return await _repo.GetAll();
        }

        public async Task<CPUFan> GetById(int id)
        {
            return (await _repo.GetOne(part => part.Id == id))!;
        }

        public async Task<int> Add(CPUFan newCPUFan)
        {
            return (await _repo.Add(newCPUFan)).Id;
        }

        public async Task<int> Delete(int? id)
        {
            return await _repo.Delete((int)id!);
        }
    }
}
