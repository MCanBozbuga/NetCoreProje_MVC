using Core.DataAccess;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        // Buraya Produc'a ait örnek olarak detaylarını listeleme gibi metotlar yazabiliriz.
        // IEntityRepository içerisnde CRUD işlemlerini yaptık.
        List<ProductDetailDto> GetProductDetails();


    }
}
