using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MulakatLab.Domain;

namespace MulakatLab.Infrastructure.Persistence;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("tickets");

        builder.HasKey(t=>t.Id);

        builder.Property(t=>t.Title).IsRequired().HasMaxLength(200);

        builder.Property(t=>t.Status).HasConversion<string>().HasMaxLength(20);

        builder.HasIndex(t=>t.TicketNumber).IsUnique();
    }
}