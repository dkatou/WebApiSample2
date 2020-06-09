using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api1.Api1Model.Models;

namespace Api1.Api1Model.Data.Config
{
    /// <summary>
    /// Viewerの定義を行うクラス
    /// </summary>
    internal class ViewerConfig : IEntityTypeConfiguration<Viewer>
    {
        public void Configure(EntityTypeBuilder<Viewer> builder)
        {
            // テーブル名と主キーを設定する
            builder
                .ToTable("T_VIEWER")
                .HasKey(keyExpression => keyExpression.Id);

            // 外部キーを設定する
            builder
                .HasOne(navigationName => navigationName.Blog)
                .WithMany(navigationName => navigationName.Viewers)
                .HasForeignKey(foreignKeyPropertyNames => foreignKeyPropertyNames.BlogId)
                .HasConstraintName("FK01_T_VIEWER_T_BLOG");
        }
    }
}