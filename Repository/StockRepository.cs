using System;
using System.Collections.Generic;
using System.IO;

namespace Stock_Management
{
    public class StockRepository
    {
        public static List<Stock> Stocks = new List<Stock>();

        public StockRepository()
        {
            WriteStockToList();
        }

        public void AddStock(Stock stock)
        {
            Stocks.Add(stock);
        } 
        public void RemoveStock(Stock stock)
        {
            Stocks.Remove(stock);
        }
        public Stock FindStockById(int id)
        {
            foreach (var stock in Stocks)
            {
                if (stock.Id == id)
                {
                    return stock;
                }
            }
            return null;
        }

        public static List<Stock> GetAllStocks()
        {
            return Stocks;
        }

        public static void WriteStockToFile()
        {
            List<string> stockDetails = new List<string>();

            foreach (var stock in Stocks)
            {
                stockDetails.Add(Stock.StockToString(stock));
            }

            File.WriteAllLines("files//Stock.txt", stockDetails);
        }

        public static void WriteStockToList()
        {
            Stocks = new List<Stock>();

            string[] stocksInFile = File.ReadAllLines("files//Stock.txt");
            foreach (string stock in stocksInFile)
            {
                Stocks.Add(Stock.Parse(stock));
            }
        }
    }
}