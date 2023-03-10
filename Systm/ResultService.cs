using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systm
{
    public class ResultService<T>
    {
        public ICollection<ErrorItem> ErrorItems { get; set; }

        public bool HasError { get { return ErrorItems.Count > 0; } }

        public ResultService()
        {
            ErrorItems = new List<ErrorItem>();
        }

        public T Data { get; set; }

        public List<T> ListData { get; set; }

        public void AddError(string errorType, string errorMessage)
        {
            ErrorItems.Add(
                    new ErrorItem { ErrorMessage = errorMessage, ErrorType = errorType }
                );
        }
    }
}
