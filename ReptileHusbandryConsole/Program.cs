// See https://aka.ms/new-console-template for more information
using ReptileHusbandryConsole;
using ReptileHusbandryData;
using ReptileHusbandryDomain;
using ReptileHusbandryDomain.Data_Classes;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

using (HusbandryContext context2 = new HusbandryContext())
{
    context2.Database.EnsureCreated();
    //"cheaty" method of making database, best only used for demo purposes. looks to see if db exists, makes it if it doesn't.
}

HusbandryContext context = new HusbandryContext();
//saves me from having to make a context in every method in Program.cs

//GetReptiles();
//AddReptiles();
AddReptilesList();
GetReptiles();
//GetTanks();
//AddTanks();
AddTanksList();
GetTanks();
ReptileQuery();
PriceQuery();

void AddReptiles()
{
    var reptile = new Reptile { Name = "hermann's tortoise", SizeGallons = 180 };
    context.Reptiles.Add(reptile);
    context.SaveChanges();
    //allows one to add a reptile to the database manually
}
void AddReptilesList()
{
    var reptiles = ReptileRepository.GetAll();
    context.Reptiles.AddRange(reptiles);
    context.SaveChanges();
    //adds the list of reptiles from ReptileRepository.cs to the Reptiles database
}
void GetReptiles()
{
    var reptiles = context.Reptiles.ToList();
    foreach (var reptile in reptiles)
    {
        Console.WriteLine(reptile.Name);
    }
    //writes all existing reptiles in the database in the console. does not show tank size requirement because the plan is to
    //eventually have all of the numerous requirements a pet reptile needs associated with each one and writing them all to
    //console each time would be extremely cluttered. this is what the specific pet query is for.
}

void AddTanks()
{
    var tank = new Tank { GallonSize = 55, PriceUSD = 12.39M };
    context.Tanks.Add(tank);
    context.SaveChanges();
    //allows one to manually add a tank to the database
}
void AddTanksList()
{
    var tanks = TankRepository.GetAll();
    context.Tanks.AddRange(tanks);
    context.SaveChanges();
    //adds the list of tanks from TanksRepository.cs to the Tanks database
}
void GetTanks()
{
    var tanks = context.Tanks.FromSqlRaw("select * from tanks").ToList();
    foreach (var tank in tanks)
    {
        Console.WriteLine(tank.GallonSize + ", " + tank.PriceUSD);
    }
    //writes all existing tanks in the database in the console using a SQL query
}
void ReptileQuery()
{
    Console.WriteLine("Type the name of the pet you'd like to see more information about.");
    var reptiles = context.Reptiles.Where(s => s.Name == Console.ReadLine()).ToList();
        {
            foreach(var value in reptiles)
            {
            Console.WriteLine("An adult " + value.Name + " requires " + value.SizeGallons + " gallons of tank space.");
            }
        };
    //method allows user to query needs for a specific pet
}
void PriceQuery()
{
    Console.WriteLine("Type the name of the pet you'd like to see tank pricing information about.");
    var reptiles = context.Reptiles.Where(r => r.Name == Console.ReadLine()).ToList();
    {
        foreach (var value in reptiles)
        {
            var sizeNeeded = (from tankSize in context.Reptiles
                              from tank in context.Tanks
                              where tankSize.SizeGallons == tank.GallonSize
                              select new
                              {
                                  GallonSize = tank.GallonSize,
                                  PriceUSD = tank.PriceUSD,
                              }).OrderBy(s => s.PriceUSD).ToList();
            foreach (var price in sizeNeeded)
            {
                Console.WriteLine("A " + price.GallonSize + " gallon tank costs $" + price.PriceUSD + ".");
            }
        }
    }
    //This should join the databases by finding the size requirement of the reptile from the user input name,
    //matching that with a size in the tanks database, and finding the tank price(s) from the tank database
}