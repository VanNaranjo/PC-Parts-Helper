using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL
{
    public class CPUDAO
    {
        readonly IRepository<CPU> _repo;

        public CPUDAO() { 
            _repo = new ProjectRepository<CPU>();
        }

        public async Task<List<CPU>> GetAll() { 
            return await _repo.GetAll();
        }

        public async Task<CPU> GetById(int id)
        {
            return (await _repo.GetOne(part => part.Id == id))!;
        }

        public async Task<int> Add(CPU newCPU)
        {
            return (await _repo.Add(newCPU)).Id;
        }

        public async Task<int> Delete(int? id)
        {
            return await _repo.Delete((int)id!);
        }

    }
}
