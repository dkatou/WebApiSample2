using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api1.Api1Model.Models;

namespace Api1.Api1Model.Data.Config
{
    /// <summary>
    /// Noteの定義を書くクラス
    /// </summary>
    internal class NoteConfig : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            // テーブル名と主キーを設定する
            builder
                .ToTable("T_NOTE")
                .HasKey(keyExpression => keyExpression.NoteId);

            // 外部キーを設定する
            builder
                .HasOne(navigationName => navigationName.Blog)
                .WithMany(navigationName => navigationName.Notes)
                .HasForeignKey(foreignKeyPropertyNames => foreignKeyPropertyNames.BlogId)
                .HasConstraintName("FK01_T_NOTE_T_BLOG");
        }
    }
}