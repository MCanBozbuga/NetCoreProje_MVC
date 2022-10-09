using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ProjectContext>, IProductDal
    {
        private readonly ProjectContext context;

        //Buraya join vb. işlemler yapılabilir.
        public EfProductDal(ProjectContext context) : base(context)
        {
            this.context = context;
        }

        public List<ProductDetailDto> GetProductDetails()
        {

            var result = from p in context.Products
                         join c in context.Categories
                         on p.CategoryId equals c.Id
                         select new ProductDetailDto
                         {
                             ProductId = p.Id,
                             ProductName = p.ProductName,
                             CategoryName = c.CategoryName,
                             UnitsInStock = p.UnitsInStock,
                             UnitPrice = p.UnitPrice,
                             Status = p.Status,
                             Description = p.Description,
                             ImagePath = p.ImagePath,
                             CreateDate = p.CreatedDate,
                             UpdateDate = p.ModifiedDate,
                             DeleteData = p.DeletedDate,

                             
                         }; //Sonucu bu kolonlara göre ver
            return result.ToList();

        }
    }
}
