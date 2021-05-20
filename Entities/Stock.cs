using System;

namespace Stock_Management
{
    public class Stock : BaseEntity
    {
        public int Category_Id;
        public string Name { get; set; }
        public double CostPrice { get; set; }
        public double SellingPrice { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public string Variation { get; set; }

    public Stock(int id, string name , double costPrice, double sellingPrice, string sKU, int quantity, string variation, int category_Id)
        {
            Id = id;
            Created_at = DateTime.Now;
            Name = name;
            CostPrice = costPrice;
            SellingPrice = sellingPrice;
            SKU = sKU;
            Quantity = quantity;
            Variation = variation;
            Category_Id = category_Id;
        }

        public static string StockToString(Stock stock)
        {
            string stockDetails = $"{stock.Id}\t{stock.Created_at}\t{stock.Name}\t{stock.CostPrice}\t{stock.SellingPrice}\t{stock.SKU}\t{stock.Quantity}\t{stock.Variation}\t{stock.Category_Id}";

            return stockDetails;
        }

        public static Stock Parse(string stockDetails)
        {
            string[] stockDetail = stockDetails.Split("\t");

            int id = Convert.ToInt32(stockDetail[0]);
            DateTime Created_at = Convert.ToDateTime(stockDetail[1]);
            string name = stockDetail[2];
            double costPrice = Convert.ToDouble(stockDetail[3]);
            double sellingPrice = Convert.ToDouble(stockDetail[4]);
            string sKU = stockDetail[5];
            int quantity = Convert.ToInt32(stockDetail[6]);
            string variation = stockDetail[7];
            int category_Id = Convert.ToInt32(stockDetail[8]);

            Stock stock = new Stock(id, name, costPrice, sellingPrice, sKU, quantity, variation, category_Id);
            return stock;
        }
    }
}