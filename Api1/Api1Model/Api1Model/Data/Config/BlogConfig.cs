using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api1.Api1Model.Models;

namespace Api1.Api1Model.Data.Config
{
    /// <summary>
    /// Blogの定義を書くクラス
    /// </summary>
    internal class BlogConfig : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            // テーブル名と主キーを設定する
            builder
                .ToTable("T_BLOG")
                .HasKey(keyExpression => keyExpression.BlogId);
        }
    }
}