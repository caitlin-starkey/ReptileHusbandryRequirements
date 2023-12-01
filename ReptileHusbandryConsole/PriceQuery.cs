using ReptileHusbandryDomain.Data_Classes;
using ReptileHusbandryDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReptileHusbandryConsole
{
    public class PriceQuery
    {
        public List<ReptileTank> InnerJoinQuery()
        {
            List<ReptileTank> list;
            List<Reptile> reptiles = ReptileRepository.GetAll();
            List<Tank> tanks = TankRepository.GetAll();
            list = (from rep in reptiles
                    join tank in tanks
                    on rep.SizeGallons equals tank.GallonSize
                    select new ReptileTank
                    {
                        GallonSize = tank.GallonSize,
                        PriceUSD = tank.PriceUSD,
                    }).OrderBy(s => s.GallonSize).ToList();
            return list;
        }
        public void Print(List<ReptileTank> reptanks)
        {
            foreach (ReptileTank reptank in reptanks)
            {
                Console.WriteLine("A " + reptank.GallonSize + " tank costs $" + reptank.PriceUSD + ".");
            }
            //method performs a join but doesn't do it via the tables so it isn't currently used
        }
    }
}
