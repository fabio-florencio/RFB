using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RFB.Models;

namespace RFB.Data
{
    public class RFBContext : DbContext
    {
        public RFBContext (DbContextOptions<RFBContext> options)
            : base(options)
        {
        }

        public DbSet<Cnae> Cnae { get; set; } = default!;
        public DbSet<NaturezaJuridica> NaturezasJuridicas { get; set; } = default!;
        public DbSet<QualificacaoSocio> QualificacoesSocios { get; set; } = default!;
    }
}
