using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Domain
{
    public class Budget
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public int Expiration { get; set; }
        public List<DetailBudget> Details { get; set; }

        public Budget()
        {
            Details = new List<DetailBudget>();
        }

        public void AddDetail(DetailBudget detail)
        {
            Details.Add(detail);
        }
        public void RemoveDetail(int index)
        {
            Details.RemoveAt(index);
        }
        public double Total()
        {
            double total = 0;
            foreach (DetailBudget detail in Details)
            {
                total = detail.Subtotal();
            }
            return total;
        }
    }
}
