using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChaplyginMVCProject.Models
{
    public class SortOptions
    {

        public bool? Id { get; set; }
        public bool? ContractNumber { get; set; }
        public bool? ContractDate { get; set; }
        public bool? Sum { get; set; }
        public bool? FullName { get; set; }
    }
}