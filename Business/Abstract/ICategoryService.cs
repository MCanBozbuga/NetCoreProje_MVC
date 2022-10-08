using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        List<CategoryDetailDto> GetCategoryDetails();
   
        void CreateCategory(Category category);
        //Delete
        void DeleteCategory(Category category);
        //Update
        void UpdateCategory(Category category);
        //Get
        Category Get(int id);
    }
}
