using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api1.Api1Model.Models;

namespace Api1.Api1Model.Data.Config
{
    internal class JoinAConfig : IEntityTypeConfiguration<JoinA>
    {
        public void Configure(EntityTypeBuilder<JoinA> builder)
        {
            builder
                .ToTable("T_JOIN_A")
                .HasKey(keyExpression => keyExpression.JoinAId);
        }
    }
}