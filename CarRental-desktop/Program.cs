// See https://aka.ms/new-console-template for more information
using CarRental_desktop;

Console.WriteLine("Hello, World!");

try
{
    Statisztika stat = new Statisztika();
    stat.Olcsobb();
    stat.VanE26();
    stat.findbards();
    Console.WriteLine("Please write a licenpalte number: ");
    string licens = Console.ReadLine();
    stat.FindByLicens(licens);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}