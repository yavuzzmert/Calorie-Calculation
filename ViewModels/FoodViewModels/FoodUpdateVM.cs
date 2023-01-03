using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.FoodViewModels
{
	public class FoodUpdateVM
	{
		public int Id { get; set; }

		public string FoodName { get; set; }

		public double Calorie { get; set; }

		public DateTime UpdateOn => DateTime.Now;
	}
}
