using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this._categoryDal = categoryDal;
        }
        public void CreateCategory(Category category)
        {
            _categoryDal.Create(category);
        }

        public Category Get(int id)
        {
            return _categoryDal.Get(id);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryDal.GetAll().ToList();
        }

        public void DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
        }

        public List<CategoryDetailDto> GetCategoryDetails()
        {
            return _categoryDal.GetCategoriesDetail();
        }
    }
}
