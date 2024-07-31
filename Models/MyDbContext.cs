using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using aznews.Areas.Admin.Models;
namespace aznews.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public DbSet<TblMenu> TblMenus { get; set; }
    public DbSet<TblPost> TblPosts { get; set; }
    public DbSet<AdminMenu> AdminMenus { get; set; }
    public DbSet<AdminUsers> AdminUsers { get; set; }
}
