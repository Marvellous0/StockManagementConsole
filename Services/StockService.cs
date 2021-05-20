using System.Collections.Generic;

namespace Stock_Management.Services
{
    public class StockService
    {
        StockRepository stockRepository = new StockRepository();
        public void AddStock(int id, string name, double costPrice, double sellingPrice, string sKU, int quantity, string variation, int category_Id)
        {
            Stock stock = new Stock(id, name, costPrice, sellingPrice, sKU, quantity, variation, category_Id);
            stockRepository.AddStock(stock);
        }

        public List<Stock> ListAllStocks()
        {
            return StockRepository.GetAllStocks();
        }

        public bool IsStockExist(int id)
        {
            Stock stock = stockRepository.FindStockById(id);

            if (stock == null)
            {
                return false;
            }
            return true;
        }

        public Stock FindStockById(int id)
        {
            return stockRepository.FindStockById(id);
        }

        public void DeleteStock(int id)
        {
            Stock stock = stockRepository.FindStockById(id);
            stockRepository.RemoveStock(stock);
        }
    }
}