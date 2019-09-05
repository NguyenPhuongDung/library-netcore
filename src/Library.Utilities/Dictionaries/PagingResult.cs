using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utilities.Dictionaries
{
    public class PagingResult<TEntity> where TEntity : class
    {
        public TEntity[] Items { get; set; }

        public bool HasMoreRecords { get; set; }

        public int Totals { get; set; }
    }
}
