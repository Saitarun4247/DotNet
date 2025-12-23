// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
public class Computer
{
    public string Processor { get; set; }
    public int RamSize { get; set; }
    public int HardDiskSize { get; set; }
    public int GraphicCard { get; set; }
}
public class Desktop : Computer
{
    public int MonitorSize { get; set; }
    public int PowerSupplyVolt { get; set; }
    public double DesktopSizeCalculation()
    {
        int processorCost = 0;
        if (Processor == "i3")
            processorCost = 1500;
        else if (Processor == "i5")
            processorCost = 3000;
        else if (Processor == "i7")
            processorCost = 4500;

        double price =
            processorCost + (RamSize * 200) + (HardDiskSize * 1500) +
            (GraphicCard * 2500) + (MonitorSize * 250) + (PowerSupplyVolt * 20);
        return price;
    }
}

public class Laptop : Computer
{
    public int DisplaySize { get; set; }
    public int BatteryVolt { get; set; }
    public double LaptopPriceCalculation()
    {
        int processorCost = 0;
        if (Processor == "i3")
            processorCost = 2500;
        else if (Processor == "i5")
            processorCost = 5000;
        else if (Processor == "i7")
            processorCost = 6500;

        double price =
            processorCost + (RamSize * 200) + (HardDiskSize * 1500) +
            (GraphicCard * 2500) + (DisplaySize * 250) + (BatteryVolt * 20);
        return price;
    }
}
public class Program
{
    public static void Main()
    {
        Console.WriteLine("1.Desktop");
        Console.WriteLine("2.Laptop");
        Console.WriteLine("1.Desktop");
        Console.WriteLine("2.Laptop");
        Console.WriteLine("Choose the option");
        int choice = int.Parse(Console.ReadLine());
        if (choice == 1)
        {
            Desktop d = new Desktop();
            Console.WriteLine("enter the processor");
            d.Processor = Console.ReadLine();
            Console.WriteLine("enter the ram size");
            d.RamSize = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the hard disk size");
            d.HardDiskSize = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the graphic card size");
            d.GraphicCard = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the monitor size");
            d.MonitorSize = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the power supply volt");
            d.PowerSupplyVolt = int.Parse(Console.ReadLine());
            Console.WriteLine("Desktop price is " +
                d.DesktopSizeCalculation());
        }
        else if (choice == 2)
        {
            Laptop l = new Laptop();
            Console.WriteLine("enter the processor");
            l.Processor = Console.ReadLine();
            Console.WriteLine("enter the ram size");
            l.RamSize = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the hard disk size");
            l.HardDiskSize = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the graphic card size");
            l.GraphicCard = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the display size");
            l.DisplaySize = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the battery volt");
            l.BatteryVolt = int.Parse(Console.ReadLine());
            Console.WriteLine("Laptop price is " +
                l.LaptopPriceCalculation());
        }
    }
}
