using Repository.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class ProductRepositoryADO : IProductRepository
    {

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            List<Product> lst = new List<Product>();
            //CONECTAR A BD
            //TRAER REGISTROS DE TABLA - PRODUCTOS --- SE REALIZA CON EL SINGLETON
            var dt = DataHelper.GetInstance().ExecuteSP("SP_Recuperar_Productos");

            foreach (DataRow row in dt.Rows)
            {
                // MAPEAR           
                Product p = new Product();
                p.Codigo = (int)row["codigo"];
                p.Nombre = Convert.ToString(row["n_producto"]);
                p.Precio = (double)row["precio"];
                p.Stock = (int)row["stock"];
                p.Activo = (bool)row["esta_activo"];
                lst.Add(p);
            }
            return lst;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
