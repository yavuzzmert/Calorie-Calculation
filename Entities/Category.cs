using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public ICollection<Food> Foods { get; set; }

        public Category()
        {
            Foods = new HashSet<Food>();
            IsActive = true;
        }
    }
}
