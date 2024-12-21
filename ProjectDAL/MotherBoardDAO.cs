using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL
{
    public class MotherBoardDAO
    {
        readonly IRepository<MotherBoard> _repo;

        public MotherBoardDAO() {
            _repo = new ProjectRepository<MotherBoard>();
        }

        public async Task<List<MotherBoard>> GetAll() { 
            return await _repo.GetAll();
        }

        public async Task<MotherBoard> GetOne(int id) {
            return (await _repo.GetOne(part => part.Id == id))!;
        }

        public async Task<int> Add(MotherBoard newMotherBoard)
        {
            return (await _repo.Add(newMotherBoard)).Id;
        }

        public async Task<int> Delete(int? id)
        {
            return await _repo.Delete((int)id!);
        }

    }
}
