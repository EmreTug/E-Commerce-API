using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Abstract
{
    public interface IProductService
    {
        List<Product> getAllProduct(PaginationParameters paginationParameters);

        Product getProductById(long id);

        Product getProductByName(string name);

        Product createProduct(Product product);

        Product updateProduct(Product product);

        bool deleteProduct(long id);
    }
}
