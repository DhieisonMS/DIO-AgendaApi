using Microsoft.EntityFrameworkCore;

using src.entities;

namespace src.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options): base(options)
        {}

        public DbSet<AgendaTask>AgendaTasks{get; set;}
    }
}