using System.Collections.Generic;

namespace Stock_Management.Services
{
    public class CategoryService
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public void AddCategory(int id, string name)
        {
            Category category = new Category(id, name);

            categoryRepository.AddCategory(category);
        }

        public List<Category> ListAllCategories()
        {
            return CategoryRepository.GetAllCategories();
        }

        public bool IsCategoryExistCategory(int id)
        {
            Category category = categoryRepository.FindCategoryById(id);

           if(category == null)
           {
                return false;
            }
            return true;
        }

        public Category FindCategoryById(int id)
        {
            return categoryRepository.FindCategoryById(id);
        }

        public void DeleteCategory(int id)
        {
            Category category = categoryRepository.FindCategoryById(id);
            categoryRepository.RemoveCategory(category);
        }
    }
}