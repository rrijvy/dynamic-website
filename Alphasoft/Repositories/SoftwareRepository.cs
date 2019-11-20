using Alphasoft.Data;
using Alphasoft.IRepositories;
using Alphasoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alphasoft.Repositories
{
    public class SoftwareRepository:Repository<Software>,ISoftwareRepository
    {
        public SoftwareRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext Context
        {
            get
            {
                return _context as ApplicationDbContext;
            }
        }

        public Software GetSoftware()
        {
            return Context.Softwares.FirstOrDefault();
        }

        public List<Software> GetWithSoftware()
        {
            return Context.Softwares.ToList();
        }
    }
}
