using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReptileHusbandryDomain
{
    public partial class ReptileTank
    {
        public int ReptileID { get; set; }
        public string Name { get; set; }
        public int SizeGallons { get; set; }
        public int? TankID { get; set; }
        public int? GallonSize { get; set; }
        public decimal? PriceUSD { get; set; }
    }
}
