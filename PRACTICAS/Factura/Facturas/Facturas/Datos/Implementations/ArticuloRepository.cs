using Facturas.Datos.Interfaces;
using Facturas.Datos.Utils;
using Facturas.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturas.Datos.Implementations
{
    public class ArticuloRepository : IArticuloRepository
    {
        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Articulo> GetAll()
        {
            List<Articulo> lst = new List<Articulo>();
            DataTable dt = new DataTable();
            dt = DataHelper.GetInstance().ExecuteSPGet("sp_get_all_articulos", null);
            foreach (DataRow dr in dt.Rows)
            {
                Articulo articulo = new Articulo();
                articulo.IdArticulo = Convert.ToInt32(dr["id_articulo"]);
                articulo.Nombre = Convert.ToString(dr["nombre"]);
                articulo.PrecioUnitario = Convert.ToDouble(dr["precio_unitario"]);
                lst.Add(articulo);
            }
            return lst;
        }

        public Articulo GetById(int id)
        {
            Articulo articulo = new Articulo();
            DataTable dt = new DataTable();
            List<Parametro> list = new List<Parametro>();
            list.Add(new Parametro("@id_articulo", id));

            dt = DataHelper.GetInstance().ExecuteSPGet("sp_get_articulo_id", list);
            foreach (DataRow dr in dt.Rows)
            {
                articulo.IdArticulo = Convert.ToInt32(dr["id_articulo"]);
                articulo.Nombre = Convert.ToString(dr["nombre"]);
                articulo.PrecioUnitario = Convert.ToDouble(dr["precio_unitario"]);                
            }
            return articulo;
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
