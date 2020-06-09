using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api1.Api1Model.Models;

namespace Api1.Api1Model.Data.Config
{
    /// <summary>
    /// CompanyChildの定義を書くクラス
    /// </summary>
    internal class CompanyChildConfig : IEntityTypeConfiguration<CompanyChild>
    {
        public void Configure(EntityTypeBuilder<CompanyChild> builder)
        {
            // テーブル名と主キーを設定する
            builder
                .ToTable("T_COMPANY_CHILD")
                .HasKey(keyExpression => new { keyExpression.CompanyParentId, keyExpression.CompanyChildId });

            // 外部キーを設定する
            builder
                .HasOne(navigationName => navigationName.CompanyP)
                .WithMany(navigationName => navigationName.CompanyParentChilds)
                .HasForeignKey(foreignKeyPropertyNames => foreignKeyPropertyNames.CompanyParentId)
                .HasPrincipalKey(keyPropertyNames => keyPropertyNames.CompanyId)
                .HasConstraintName("FK01_T_COMPANY_CHILD_T_COMPANY");

            builder
                .HasOne(navigationName => navigationName.CompanyC)
                .WithMany(navigationName => navigationName.CompanyChildChilds)
                .HasForeignKey(foreignKeyPropertyNames => foreignKeyPropertyNames.CompanyChildId)
                .HasPrincipalKey(keyPropertyNames => keyPropertyNames.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK02_T_COMPANY_CHILD_T_COMPANY");
        }
    }
}