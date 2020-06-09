using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api1.Api1Model.Models;

namespace Api1.Api1Model.Data.Config
{
    /// <summary>
    /// Personの定義を書くクラス
    /// </summary>
    internal class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // テーブル名と主キーを設定する
            builder
                .ToTable("T_PERSON")
                .HasKey(keyExpression => new { keyExpression.PersonId, keyExpression.PersonFirstName, keyExpression.PersonLastName });
        }
    }
}