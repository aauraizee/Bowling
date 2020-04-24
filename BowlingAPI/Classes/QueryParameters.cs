using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Classes
{
    public class QueryParameters
    {
        const int _maxSize = 20;
        private int _size = 10;

        public int Page { get; set; }
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = Math.Min(_maxSize, value);
            }
        }
    }
}
