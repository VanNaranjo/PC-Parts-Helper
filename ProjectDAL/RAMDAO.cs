using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL
{
    public class RAMDAO
    {
        readonly IRepository<RAM> _repo;

        public RAMDAO()
        {
            _repo = new ProjectRepository<RAM>();
        }

        public async Task<List<RAM>> GetAll() { 
            return await _repo.GetAll();
        }

        public async Task<RAM> GetOne(int id)
        {
            return (await _repo.GetOne(part => part.Id == id))!;
        }

        public async Task<int> Add(RAM newRAM)
        {
            return (await _repo.Add(newRAM)).Id;
        }

        public async Task<int> Delete(int? id)
        {
            return await _repo.Delete((int)id!);
        }

    }
}
