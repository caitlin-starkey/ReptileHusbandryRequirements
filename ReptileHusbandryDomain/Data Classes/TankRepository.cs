using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReptileHusbandryDomain;

namespace ReptileHusbandryConsole
{
    public partial class TankRepository
    {
        public static List<Tank> GetAll()
        {
            return new List<Tank>
            {
                new Tank
                {
                    //TankID = 1,
                    GallonSize = 60,
                    PriceUSD = 239.00M
                },
                new Tank
                {
                    //TankID = 2,
                    GallonSize = 120,
                    PriceUSD = 299.00M
                },
                new Tank
                {
                    //TankID = 3,
                    GallonSize = 120,
                    PriceUSD = 310.00M
                },
                new Tank
                {
                    //TankID = 4,
                    GallonSize = 55,
                    PriceUSD = 12.39M
                },

            };
        }
    }
}