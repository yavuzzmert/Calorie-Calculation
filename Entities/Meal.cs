using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Meal : BaseEntity
    {
        public string MealName { get; set; }

        public virtual ICollection<MealFood> MealFoods { get; set; }

        public Meal()
        {
            IsActive = true;
            MealFoods = new HashSet<MealFood>();
        }
    }
}
