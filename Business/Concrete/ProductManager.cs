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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            this._productDal = productDal;
        }
        public void CreateProduct(Product product)
        {
            _productDal.Create(product);
        }

        public void DeleteProduct(Product product)
        {
            _productDal.Delete(product);
        }

        public Product Get(int id)
        {
            return _productDal.Get(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
           return  _productDal.GetAll().ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }

        public void UpdateProduct(Product product)
        {
            _productDal.Update(product);
        }
    }
}
