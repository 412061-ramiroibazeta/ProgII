using Repository.Data;
using Repository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class ProductServices
    {
        private IProductRepository _repository;
        public ProductServices()
        {
            _repository = new ProductRepositoryADO();
        }
        public List<Product> GetProducts()
        {
            return _repository.GetAll();
        }
    }
}
