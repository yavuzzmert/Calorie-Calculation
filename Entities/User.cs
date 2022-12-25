using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User : BaseEntity  
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserTypes UserTypes { get; set; } //enum olduğu için virtual ile ezmedik ve id koymadık

        public virtual  ICollection<MealFood> MealFoods { get; set; }

        public User()
        {
            IsActive = true;
            MealFoods = new HashSet<MealFood>();
        }
    }
}
