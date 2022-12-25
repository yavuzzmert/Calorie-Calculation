using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.MealViewModels
{
    public class MealUpdateVM
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public DateTime UpdateOn => DateTime.Now;
    }
}
