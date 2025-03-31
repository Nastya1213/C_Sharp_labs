using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_db
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string EquipmentType { get; set; }
        public string EquipmentModel { get; set; }
        public string Status { get; set; }
        public string ProblemDescription { get; set; }
        public string ClientName { get; set; }
    }
}
