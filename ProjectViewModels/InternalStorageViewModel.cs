using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ProjectDAL;

namespace ProjectViewModels
{
    public class InternalStorageViewModel
    {
        private readonly InternalStorageDAO _dao;
        public int Id { get; set; }
        public string? name { get; set; }

        public decimal? price { get; set; }

        public decimal capacity { get; set; }

        public decimal? price_per_gb { get; set; }

        public string? type { get; set; }

        public int? cache { get; set; }

        public string? form_factor { get; set; }

        public string? _interface { get; set; }

        public InternalStorageViewModel()
        {
            _dao = new InternalStorageDAO();
        }

        public async Task<List<InternalStorageViewModel>> GetAll()
        {
            List<InternalStorageViewModel> allVms = new();
            try
            {
                List<InternalStorage> allInternalStorages = await _dao.GetAll();

                foreach(InternalStorage internalstorage in allInternalStorages)
                {
                    InternalStorageViewModel internalstorageVm = new()
                    {
                        Id = internalstorage.Id,
                        name = internalstorage.name,
                        price = internalstorage.price,
                        capacity = internalstorage.capacity,
                        price_per_gb = internalstorage.price_per_gb,
                        type = internalstorage.type,
                        cache = internalstorage.cache,
                        form_factor = internalstorage.form_factor,
                        _interface = internalstorage._interface

                    };
                    allVms.Add(internalstorageVm);
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
