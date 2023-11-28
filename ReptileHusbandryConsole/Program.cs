// See https://aka.ms/new-console-template for more information
using ReptileHusbandryData;
using ReptileHusbandryDomain;
using System.Net.Http.Headers;
using (HusbandryContext context =  new HusbandryContext())


//GetReptiles();
//AddReptiles();
GetReptiles();
GetTanks();
AddTanks();
GetTanks();

void AddReptiles()
{
    var reptile = new Reptile { Name = "hermann's tortoise", SizeGallons = 180 };
    using var context = new HusbandryContext();
    context.Reptiles.Add(reptile);
    context.SaveChanges();
}
void GetReptiles()
{
    using var context = new HusbandryContext();
    var reptiles = context.Reptiles.ToList();
    foreach (var reptile in reptiles)
    {
        Console.WriteLine(reptile.Name);
    }
}
//cheaty way to make a database and should be edited later
void AddTanks()
{
    var tank = new Tank { SizeGallons = 55, PriceUSD = 12.39M };
    using var context = new HusbandryContext();
    context.Tanks.Add(tank);
    context.SaveChanges();
}
void GetTanks()
{
    using var context = new HusbandryContext();
    var tanks = context.Tanks.ToList();
    foreach (var tank in tanks)
    {
        Console.WriteLine(tank.SizeGallons + ", " + tank.PriceUSD);
    }
}