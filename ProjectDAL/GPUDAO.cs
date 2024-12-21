using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL
{
    public class GPUDAO
    {
        readonly IRepository<GPU> _repo;

        public GPUDAO() { 
            _repo = new ProjectRepository<GPU>();
        }

        public async Task<List<GPU>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<GPU> GetById(int id)
        {
            return (await _repo.GetOne(part => part.Id == id))!;
        }

        public async Task<int> Add(GPU newGPU)
        {
            return (await _repo.Add(newGPU)).Id;
        }

        public async Task<int> Delete(int? id)
        {
            return await _repo.Delete((int)id!);
        }


    }
}
