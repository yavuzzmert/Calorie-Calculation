using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class BaseEntity
    {
        //bir instance üretmediğimiz için abstract yapıyoruz ayrıca new'lemiyoruz artı bu sınıftan inherit vereceğimiz için

        public int ID { get; set; }
        public DateTime CreateOn { get; set; }

        public DateTime? UpdateOn { get; set; }

        public bool IsActive { get; set; }

    }
}
