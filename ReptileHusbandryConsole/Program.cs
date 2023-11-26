// See https://aka.ms/new-console-template for more information
using ReptileHusbandryData;
using (HusbandryContext context =  new HusbandryContext())
{
    context.Database.EnsureCreated();
}

GetReptiles();

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