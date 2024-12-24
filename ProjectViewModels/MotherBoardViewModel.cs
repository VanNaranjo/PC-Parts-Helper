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
    public class MotherBoardViewModel
    {
        private readonly MotherBoardDAO _dao;
        public int Id {  get; set; }
        public string? name { get; set; } 

        public decimal? price { get; set; }

        public string? socket { get; set; } 

        public string? form_factor { get; set; } 

        public int max_memory { get; set; }

        public int memory_slots { get; set; }

        public string? color { get; set; }

        public MotherBoardViewModel()
        {
            _dao = new MotherBoardDAO();
        }

        public async Task<List<MotherBoardViewModel>> GetAll()
        {
            List<MotherBoardViewModel> allVms = new();
            try
            {
                List<MotherBoard> allMotherBoards = await _dao.GetAll();

                foreach(MotherBoard motherBoard in allMotherBoards)
                {
                    MotherBoardViewModel motherBoardVm = new()
                    {
                        Id = motherBoard.Id,
                        name = motherBoard.name,
                        price = motherBoard.price,
                        socket = motherBoard.socket,
                        form_factor = motherBoard.form_factor,
                        max_memory = motherBoard.max_memory,
                        memory_slots = motherBoard.memory_slots,
                        color = motherBoard.color
                    };
                    allVms.Add(motherBoardVm);
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
