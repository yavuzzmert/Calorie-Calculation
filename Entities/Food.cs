using Core;


namespace Entities
{
    public class Food : BaseEntity
    {
        public string FoodName { get; set; }

        public string Description { get; set; }

        public double Calorie { get; set; }

        public virtual ICollection<MealFood> MealFoods { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Food()
        {
            IsActive = true;
            MealFoods = new HashSet<MealFood>();
        }
    }
}
