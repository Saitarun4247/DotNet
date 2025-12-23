// See https://aka.ms/new-console-template for more information

using InterfaceDemoProj;
Console.WriteLine("Demo on Interfaces");
/*
IAdd m1 = new MathClass(); // Alok - Add
IAddSub m2 = new MathClass(); // Riya - Add
IAll m3 = new MathClass(); // Rajat - Add,Sub,Pro,Div*/

// Approach 1
Product pObj= new Product();

pObj.ProdID=101;
pObj.Name="Borosil Flask";
pObj.Price=850;

// Approach 2
// Object Intializer
Product pObj1 = new Product(){
    ProdID=102,
    Name="Luxon Marker",
    Price=25
};

List<Product> prodList =  new List<Product>()
{
    new Product(){ProdID=102,Name="Marker",Price=25},
    new Product(){ProdID=103,Name="Classmate Notebook",Price=45},
    new Product(){ProdID=104,Name="Duster",Price=15},
    new Product(){ProdID=105,Name="Pilot Pen",Price=20},
    new Product(){ProdID=106,Name="Cello Pen",Price=30}
};

foreach(var item in prodList)
{
    System.Console.WriteLine($"{item.ProdID}\t{item.Name}\t{item.Price}");
}

