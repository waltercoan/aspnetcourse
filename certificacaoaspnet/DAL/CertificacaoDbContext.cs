using certificacaoaspnet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace certificacaoaspnet.DAL
{
    public class CertificacaoDbContext:DbContext
    {
        public CertificacaoDbContext()
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genres> Genres { get; set; }
    }
}