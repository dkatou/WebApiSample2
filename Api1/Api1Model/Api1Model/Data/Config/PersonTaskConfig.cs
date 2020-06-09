using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api1.Api1Model.Models;

namespace Api1.Api1Model.Data.Config
{
    /// <summary>
    /// PersonTaskの定義を書くクラス
    /// </summary>
    internal class PersonTaskConfig : IEntityTypeConfiguration<PersonTask>
    {
        public void Configure(EntityTypeBuilder<PersonTask> builder)
        {
            // テーブル名と主キーを設定する
            builder
                .ToTable("T_PERSON_TASK")
                .HasKey(keyExpression => new { keyExpression.PersonChargeId, keyExpression.TaskId });

            // 外部キーを設定する
            builder
                .HasOne(navigationName => navigationName.Person)
                .WithMany(navigationName => navigationName.PersonTasks)
                .HasForeignKey(foreignKeyPropertyNames => foreignKeyPropertyNames.PersonChargeId)
                .HasPrincipalKey(keyPropertyNames => keyPropertyNames.PersonId)
                .HasConstraintName("FK01_T_PERSON_TASK_T_PERSON");
        }
    }
}