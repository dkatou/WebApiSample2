using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api1.Api1Model.Models;

namespace Api1.Api1Model.Data.Config
{
    /// <summary>
    /// PostChildの定義を書くクラス
    /// </summary>
    internal class PostChildConfig : IEntityTypeConfiguration<PostChild>
    {
        public void Configure(EntityTypeBuilder<PostChild> builder)
        {
            // テーブル名と主キーを設定する
            builder
                .ToTable("T_POST_CHILD")
                .HasKey(keyExpression => keyExpression.PostChildId);

            // 外部キーを設定する
            builder
                .HasOne(navigationName => navigationName.Post)
                .WithMany(navigationName => navigationName.PostChilds)
                .HasForeignKey(foreignKeyPropertyNames => foreignKeyPropertyNames.PostId)
                .HasConstraintName("FK01_T_POST_CHILD_T_POST");
        }
    }
}