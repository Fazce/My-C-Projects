/**
 * Project Name: Inventory Management System
 * Description: A simple console application to manage product inventory.
 * Programmer Name: Daniel Nguyen
 * Date: 2025-5-12
 */
using System;
using System.Collections.Generic;

class Program
{
    List<string> inventoryItems = new List<string>();
    
    static void Main(string[] args) {
        Inventory inventory = new Inventory();
        bool running = true; 
        Console.WriteLine("Welcome to the Inventory Management System!");

        while (running) {
            Console.WriteLine("1. Add a product");
            Console.WriteLine("2. Update stock");
            Console.WriteLine("3. View inventory");
            Console.WriteLine("4. Remove a product");
            Console.WriteLine("5. Exit");
            Console.Write("Please select an option: ");
            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    Console.Write("Enter product name: ");
                    string productName = Console.ReadLine();
                    Console.Write("Enter product price: ");
                    double productPrice = double.Parse(Console.ReadLine());
                    Console.Write("Enter product quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    inventory.AddProduct(productName, productPrice, quantity);
                    break;
                case "2":
                    Console.Write("Enter product name to update: ");
                    string updateItemName = Console.ReadLine();
                    Console.Write("Enter quantity change (positive to add, negative to remove): ");
                    int quantityChange = int.Parse(Console.ReadLine());
                    inventory.UpdateStock(updateItemName, quantityChange);
                    break;
                case "3":
                    inventory.ViewInventory();
                    break;
                case "4":
                    Console.Write("Enter product name to remove: ");
                    string removeItemName = Console.ReadLine();
                    inventory.RemoveProduct(removeItemName);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }
}
