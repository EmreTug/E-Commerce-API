using Prasoft.Business.Abstract;
using Prasoft.DataAccess.Abstract;
using Prasoft.DataAccess.Concrete;
using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _ProductRepository;
        public ProductManager()
        {
            _ProductRepository = new ProductRepository();
        }
        public Product createProduct(Product product)
        {
            return _ProductRepository.createProduct(product);
        }

        public bool deleteProduct(long id)
        {
            return _ProductRepository.deleteProduct(id);
        }

        public List<Product> getAllProduct(PaginationParameters paginationParameters)
        {
            return _ProductRepository.getAllProduct(paginationParameters);
        }

        public Product getProductById(long id)
        {
            return _ProductRepository.getProductById(id);
        }

        public Product getProductByName(string name)
        {
            return _ProductRepository.getProductByName(name);
        }

        public Product updateProduct(Product product)
        {
            return _ProductRepository.updateProduct(product);
        }
    }
}
