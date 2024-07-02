using DevoraLimeArena.DB;
using DevoraLimeArena.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaTests.Repositories
{
    public class BaseRepositoryTest
    {

        protected ArenaDBContext _context;

        protected void initContext() {

            var options = new DbContextOptionsBuilder<ArenaDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

          
            _context = new ArenaDBContext(options);
        }
    }
}
