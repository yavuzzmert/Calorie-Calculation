using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.FoodViewModels
{
	public class FoodCreateVM
	{
		public string FoodName { get; set; }

		public double Calorie { get; set; }

		public DateTime CreateOn => DateTime.Now;
	}
}
