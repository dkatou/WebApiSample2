using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api1.Api1Model.Models;
using Api1.Api1Model.Data.Config;

namespace Api1.Api1Model.Data
{
    /// <summary>
    /// コンテキストクラス
    /// </summary>
    public class Api1Context : DbContext
    {
        /// <summary>
        /// マイグレーションする際にコンストラクタが必要
        /// </summary>
        /// <param name="options"></param>
        public Api1Context(DbContextOptions<Api1Context> options)
            : base(options)
        {
        }

        // 以下にDBSet<モデルクラス名>のプロパティをモデル分、書く
        // そうするとコンテキストクラスでモデルが扱える
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Note> Note{ get; set; }
        public DbSet<PostChild> PostChild { get; set; }
        public DbSet<Viewer> Viewer { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyChild> CompanyChild { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonTask> PersonTask { get; set; }
        public DbSet<JoinA> JoinA { get; set; }

        /// <summary>
        /// モデルクラスに記載できないDBの定義を書くメソッド
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // モデル毎に定義クラスを作成しmodelBuilderに追加していく
            modelBuilder.ApplyConfiguration(new BlogConfig());
            modelBuilder.ApplyConfiguration(new PostConfig());
            modelBuilder.ApplyConfiguration(new PostChildConfig());
            modelBuilder.ApplyConfiguration(new NoteConfig());
            modelBuilder.ApplyConfiguration(new ViewerConfig());
            modelBuilder.ApplyConfiguration(new CompanyConfig());
            modelBuilder.ApplyConfiguration(new CompanyChildConfig());
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new PersonTaskConfig());
            modelBuilder.ApplyConfiguration(new JoinAConfig());
        }
    }
}