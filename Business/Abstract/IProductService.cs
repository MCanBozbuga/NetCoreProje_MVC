using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface  IProductService
    {
        IEnumerable<Product> GetAllProducts();
        List<ProductDetailDto> GetProductDetails();

        void CreateProduct(Product product);
        //Delete
        void DeleteProduct(Product product);
        //Update
        void UpdateProduct(Product product);
        //Get
        Product Get(int id);
    }
}
