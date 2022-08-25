using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceOrganizing.Sql
{
    public sealed partial class Store
    {
        private readonly StoreOptions storeOptions;

        public Store(IOptions<StoreOptions> storeOptions)
        {
            this.storeOptions = storeOptions.Value;
        }

        private static T SafeCast<T>(object value)
        {
            if(value == DBNull.Value)
            {
                return default(T);
            }
            else
            {
                return (T)value;
            }
        }
    }
}
