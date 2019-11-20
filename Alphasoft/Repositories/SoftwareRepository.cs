using Alphasoft.Data;
using Alphasoft.IRepositories;
using Alphasoft.Models;
using Microsoft.EntityFrameworkCore;
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
        public List<Software> GetAllWithSoftware()
        {
            return Context.Softwares.Include(x => x.SoftwareCategory).ToList();
        }

       

   
    }
}
