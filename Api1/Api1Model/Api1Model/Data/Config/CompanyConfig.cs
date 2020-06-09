using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api1.Api1Model.Models;

namespace Api1.Api1Model.Data.Config
{
    /// <summary>
    /// Companyの定義を書くクラス
    /// </summary>
    internal class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            // テーブル名と主キーを設定する
            builder
                .ToTable("T_COMPANY")
                .HasKey(keyExpression => keyExpression.CompanyId);
        }
    }
}