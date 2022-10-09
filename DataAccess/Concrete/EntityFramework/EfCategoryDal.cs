using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; // hata bu şekilde giderildi.

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ProjectContext>, ICategoryDal
    {
        private readonly ProjectContext context;

        public EfCategoryDal(ProjectContext context) : base(context)
        {
            this.context = context;
        }

        public List<CategoryDetailDto> GetCategoriesDetail()
        {
            var result = from c in context.Categories
                         join p in context.Products
                         on c.Id equals p.CategoryId
                         select new CategoryDetailDto
                         {
                             CategoryId = c.Id,
                             CategoryName = c.CategoryName,
                             Description = c.Description,
                             UnitsInStock = p.UnitsInStock,
                             ProductName = p.ProductName,
                             Status = c.Status,
                             CreateDate = c.CreatedDate,
                             UpdateDate = c.ModifiedDate,
                             DeleteData = c.DeletedDate,

                         };
            return result.ToList();
        }
    }
}
