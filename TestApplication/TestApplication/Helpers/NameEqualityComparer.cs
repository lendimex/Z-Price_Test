using System.Collections.Generic;
using TestApplication.Models;

namespace TestApplication.Helpers
{
    public class NameEqualityComparer : IEqualityComparer<FilterViewModel>
    {
        public bool Equals(FilterViewModel x, FilterViewModel y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(FilterViewModel obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}