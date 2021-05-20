using System;

namespace Stock_Management
{
    public class Category : BaseEntity
    {
        public string Name{ get; set; }
        public Category(int id, string name)
        {
            Id = id;

            Created_at = DateTime.Now;
            
            Name = name;
        }

         public static string CategoryToString(Category category)
        {
            string categoryDetails = $"{category.Id}\t{category.Created_at}\t{category.Name}";
            return categoryDetails;
        } 

        // public string CategoryToString()
        // {
        //    return $"{Id}\t{Created_at}\t{Name}";
        // }
        internal static Category Parse(string categoryDetails)
        {
            var categoryDetail = categoryDetails.Split('\t');

            int id = int.Parse(categoryDetail[0]);

            DateTime Created_at = DateTime.Parse(categoryDetail[1]);

            Category category = new Category(id, categoryDetail[2]);

            return category;
        }
    }
}