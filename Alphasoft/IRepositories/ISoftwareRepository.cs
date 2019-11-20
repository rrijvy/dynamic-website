using Alphasoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alphasoft.IRepositories
{
   public interface ISoftwareRepository:IRepository<Software>
    {
        List<Software> GetWithSoftware();
        Software GetSoftware();
    }
}
