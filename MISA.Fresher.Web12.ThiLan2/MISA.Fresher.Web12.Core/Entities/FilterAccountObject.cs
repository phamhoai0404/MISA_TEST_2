
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MISA.Fresher.Web12.Core.Entities
{
    public class FilterAccountObject
    {
        public string? AccountObjectCode { get; set; }
        public string? ProvinceOrCity { get; set;}
        public string? District { get; set; }
        public string? WardOrCommune { get; set; }
    }
}
