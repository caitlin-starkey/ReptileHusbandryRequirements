using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReptileHusbandryDomain.Data_Classes
{
    public partial class ReptileRepository
    {
        public static List<Reptile> GetAll()
        {
            return new List<Reptile>
                {
                    new Reptile
                    {
                        //ReptileID = 1,
                        Name = "bearded dragon",
                        SizeGallons = 120
                    },
                    new Reptile
                    {
                        //ReptileID = 2,
                        Name = "leopard gecko",
                        SizeGallons = 50
                    },
                    new Reptile
                    {
                        //ReptileID = 3,
                        Name = "ball python",
                        SizeGallons = 120
                    },
                    new Reptile
                    {
                        //ReptileID = 4,
                        Name = "box turtle",
                        SizeGallons = 55
                    },
                    new Reptile
                    {
                        //ReptileID = 5,
                        Name = "Hermann's tortoise",
                        SizeGallons = 180
                    },
                };
        }
    }
}
