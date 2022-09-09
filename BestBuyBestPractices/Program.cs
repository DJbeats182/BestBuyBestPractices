using BestBuyBestPractices;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;



var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

#region Departments Section
//var departmentRepo = new DapperDepartmentRepository(conn);

//departmentRepo.InsertDepartment("DJ's new Department");

//var departments = departmentRepo.GetAllDepartments();

//foreach (var department in departments)
//{
//    Console.WriteLine(department.DepartmentID);
//    Console.WriteLine(department.Name);
//    Console.WriteLine();    
//}
#endregion

var productRepository = new DapperProductRepository(conn);

var productToUpdate = productRepository.GetProduct(940);


//productToUpdate.Name = "UPDATED!!!!";
//productToUpdate.Price = 12.99;
//productToUpdate.CategoryID = 1;
//productToUpdate.StockLevel = 1000;
//productToUpdate.OnSale = false;

productRepository.UpdateProduct(productToUpdate);

var products = productRepository.GetAllProducts();

int num = 0;

foreach (var product in products)
{
    Console.WriteLine($"Name: {product.Name}");
    Console.WriteLine($"Price: {product.Price}");
    Console.WriteLine($"Category: {product.CategoryID}");
    Console.WriteLine($"StockLevel: {product.StockLevel}");
    Console.WriteLine($"Product ID: {product.ProductID}");
    Console.WriteLine($"OnSale: {product.OnSale}");
    Console.WriteLine();
    num++;
}

Console.WriteLine($"There are {num} products in this list");
