using System;
using System.Collections.Generic;
using Stock_Management.Services;

namespace Stock_Management
{
    public class Menu
    {
        CategoryService categoryService = new CategoryService();

        StockService stockService = new StockService();
        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("0. Exit. ");
            Console.WriteLine("1. Stock. ");
            Console.WriteLine("2. Category. ");
        }

        private void ShowCategoryMenu()
        {
            Console.Clear();
            Console.WriteLine("0. Back");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. List all Categories");
            Console.WriteLine("3. Update Category");
            Console.WriteLine("4. Delete Category");
            Console.WriteLine("5. Find Category By Id");
        }

        private void ShowStockMenu()
        {
            Console.Clear();
            Console.WriteLine("0. Back");
            Console.WriteLine("1. Add Stock");
            Console.WriteLine("2. List all Stock");
            Console.WriteLine("3. Update Stock");
            Console.WriteLine("4. Delete Stock");
            Console.WriteLine("5. Find Stock By Id");
        }

        public void MainMenu()
        {
            bool appRunning = true;

            do
            {
                ShowMenu();
                Console.WriteLine("Enter an option: ");
                string option = Console.ReadLine().Trim();

                switch (option)
                {
                    case "0":
                        appRunning = false;
                        break;

                    case "1":
                        StockMenu();
                        break;
                    case "2":
                        CategoryMenu();
                        break;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

            } while (appRunning);
        }

        public void PrintAllCategoryList()
        {

            List<Category> printAllCategoryLists = categoryService.ListAllCategories();
            foreach (var printAllCategoryList in printAllCategoryLists)
            {
                Console.WriteLine($"Id: {printAllCategoryList.Id}, Created_At: {printAllCategoryList.Created_at}, Name: {printAllCategoryList.Name}");
            }

            Console.WriteLine("Press any key to continue. ");
            Console.ReadKey();
        }

        public void DeleteCategory()
        {
            Console.WriteLine("Enter the Id of category you want to delete. ");
            int id = Convert.ToInt32(Console.ReadLine().Trim());

            Console.WriteLine("Are you sure you want to delete");
            string answer = Console.ReadLine().ToLower().Trim();

            if (categoryService.IsCategoryExistCategory(id))
            {
                categoryService.DeleteCategory(id);
                Console.WriteLine("Category deleted successfully. ");
            }

            else
            {
                Console.WriteLine("Category does not exist");
            }
        }
        private void CategoryMenu()
        {
            ShowCategoryMenu();
            Console.WriteLine("Enter an option: ");
            string option = Console.ReadLine().Trim();

            switch (option)
            {
                case "0":
                    break;
                case "1":
                    Console.Write("Enter Category by Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Category name: ");
                    string name = Console.ReadLine();
                    categoryService.AddCategory(id, name);
                    CategoryRepository.WriteFileToCategory();
                    break;

                case "2":
                    PrintAllCategoryList();
                    break;

                case "4":
                    DeleteCategory();
                    break;

                default:
                    break;
            }
        }

        private void StockMenu()
        {
            ShowStockMenu();
            Console.WriteLine("Enter an option: ");
            string option = Console.ReadLine().Trim();

            switch (option)
            {
                case "0":
                    break;

                case "1":
                    Console.Write("Enter Stock by Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Stock name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Stock cost price: ");
                    double costPrice = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter Stock selling price: ");
                    double sellingPrice = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter Stock SKU: ");
                    string sKU = Console.ReadLine();

                    Console.Write("Enter Stock quantity: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Stock variation: ");
                    string variation = Console.ReadLine();

                    ReshuffleMenu();
                    Console.WriteLine("Choose Category. ");
                    int category_Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("");

                    List<Stock> Stocks = stockService.ListAllStocks();
                    foreach (var stock in Stocks)
                    {
                        stock.Category_Id = category_Id;
                    }

                    stockService.AddStock(id, name, costPrice, sellingPrice, sKU, quantity, variation, category_Id);
                    StockRepository.WriteStockToFile();
                    break;

                case "2":
                    PrintAllStockList();
                    break;

                case "4":
                    DeleteStock();
                    break;
                    case "5":
                    
                    break;
                default:
                    break;
            }
        }

        public void PrintAllStockList()
        {

            List<Stock> Stocks = stockService.ListAllStocks();
            foreach (var stock in Stocks)
            {
                Console.WriteLine($"Id: {stock.Id}, Created_At: {stock.Created_at}, Name: {stock.Name}, CostPrice: {stock.CostPrice}, Selling Price: {stock.SellingPrice}, SKU: {stock.SKU}");
            }

            Console.WriteLine("Press any key to continue. ");
            Console.ReadKey();
        }

        public void DeleteStock()
        {
            Console.WriteLine("Enter the Id of stock you want to delete. ");
            int id = Convert.ToInt32(Console.ReadLine().Trim());

            Console.WriteLine("Are you sure you want to delete");
            string answer = Console.ReadLine().ToLower().Trim();

            if (stockService.IsStockExist(id))
            {
                stockService.DeleteStock(id);
                Console.WriteLine("Stock deleted successfully. ");
            }

            else
            {
                Console.WriteLine("Stock does not exist");
            }

        }

        private void ReshuffleMenu()
        {
            List<Category> printAllCategoryLists = categoryService.ListAllCategories();
            foreach (var printAllCategoryList in printAllCategoryLists)
            {
                Console.WriteLine($"{printAllCategoryList.Id}. {printAllCategoryList.Name} ");
            }
        }
    }
}