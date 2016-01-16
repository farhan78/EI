using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        EIContext dbContext;

        public EIContext Init()
        {
            return dbContext ?? (dbContext = new EIContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
