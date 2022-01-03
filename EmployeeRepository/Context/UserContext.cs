using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using EmployeeModels;

namespace EmployeeRepository.Context
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<RegisterModel> User { get; set; }
        public DbSet<EmployeeDetails> Detail { get; set; }

    }
}
