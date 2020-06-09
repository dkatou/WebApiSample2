using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api1.Api1Model.Models;

namespace Api1.Api1Model.Data.Config
{
    /// <summary>
    /// Postの定義を書くクラス
    /// </summary>
    internal class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            // テーブル名と主キーを設定する
            builder
                .ToTable("T_POST")
                .HasKey(keyExpression => keyExpression.PostId);

            // 外部キーを設定する
            builder
                .HasOne(navigationName => navigationName.Blog)
                .WithMany(navigationName => navigationName.Posts)
                .HasForeignKey(foreignKeyPropertyNames => foreignKeyPropertyNames.BlogId)
                .HasConstraintName("FK01_T_POST_T_BLOG");
        }
    }
}