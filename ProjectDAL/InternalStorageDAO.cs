using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL
{
    public class InternalStorageDAO
    {
        readonly IRepository<InternalStorage> _repo;

        public InternalStorageDAO() {
            _repo = new ProjectRepository<InternalStorage>();
        }

        public async Task<List<InternalStorage>> GetAll() {
            return await _repo.GetAll();
        }

        public async Task<InternalStorage> GetById(int id) {
            return (await _repo.GetOne(part => part.Id == id))!;
        }

        public async Task<int> Add (InternalStorage newInternalStorage)
        {
            return (await _repo.Add(newInternalStorage)).Id;
        }

        public async Task<int> Delete (int? id)
        {
            return await _repo.Delete((int)id!);
        }

    }
}
