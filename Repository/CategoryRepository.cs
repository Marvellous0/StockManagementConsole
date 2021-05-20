using System;
using System.Collections.Generic;
using System.IO;

namespace Stock_Management
{
    public class CategoryRepository
    {
        public static List<Category> Categories = new List<Category>();   
        public CategoryRepository()
        {
            WriteFileToCategory();
        }

        public void AddCategory(Category category)
        {
            Categories.Add(category);
        }
        public Category FindCategoryById(int id)
        {
            foreach (var category in Categories)
            {
                if (category.Id == id)
                {
                    return category;
                }
            }
            return null;
        }
        public void RemoveCategory(Category category)
        {
            Categories.Remove(category);
        }
        public static List<Category> GetAllCategories()
        {
            return Categories;
        }

        public static void WriteCategoryToList()
        {
            try
            {
                string[] categorysInFile = File.ReadAllLines("files//Category.txt");

                foreach (string category in categorysInFile)
                {
                    var itemCategory = Category.Parse(category);

                    Categories.Add(itemCategory);
                }
            }
            catch (IOException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public static void WriteFileToCategory()
        {
            List<string> categoryDetails = new List<string>();

            foreach (var category in Categories)
            {
                categoryDetails.Add(Category.CategoryToString(category));
            }

            File.WriteAllLines("files//Category.txt", categoryDetails);
        }
    }
}