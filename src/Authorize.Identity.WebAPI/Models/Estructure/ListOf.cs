using System.Collections.Generic;

namespace Authorize.Identity.WebAPI.Models.Estructure
{
    public class ListOf<T> where T : class
    {
        public IEnumerable<T> Collection
        {
            get;
            set;
        }

        public int Total
        {
            get;
            set;
        }

        public ListOf(IEnumerable<T> collection, int total)
        {
            Collection = collection;
            Total = total;
        }
    }
}
