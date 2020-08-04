using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Learn.Bll.EF
{
    public class SqlServerDbContext : DbContext, IDisposable
    {
        //public static readonly LoggerFactory SQLLoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });
        //private static ILoggerFactory Mlogger => new LoggerFactory()
        //        .AddDebug((categoryName, logLevel) => (logLevel == LogLevel.Information) && (categoryName == DbLoggerCategory.Database.Command.Name))
        //       .AddConsole((categoryName, logLevel) => (logLevel == LogLevel.Information) && (categoryName == DbLoggerCategory.Database.Command.Name));
        
        private string ConnectionString { get; set; }

        #region 构造函数
        private static SqlConnection GetEFConnctionString(string connString)
        {
            var obj = ConfigurationManager.ConnectionStrings[connString];
            SqlConnection con;
            if (obj != null)
            {
                con = new SqlConnection(obj.ConnectionString);
            }
            else
            {
                con = new SqlConnection(connString);
            }
            return con;
        }
        public SqlServerDbContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
        #endregion

        #region 重载
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EFLoggerProvider());
            optionsBuilder.UseLoggerFactory(loggerFactory).UseSqlServer(ConnectionString);//注册UseLoggerFactory ，

            //optionsBuilder.AddInterceptors(new CustomDbCommandInterceptor()).UseSqlServer(ConnectionString); //注册sql拦截，DbCommandInterceptor
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Assembly entityAssembly = Assembly.Load(new AssemblyName("Learn.Dal.Entity"));
            //IEnumerable<Type> typesToRegister = entityAssembly.GetTypes().Where(p => !string.IsNullOrEmpty(p.Namespace))
            //                                                             .Where(p => !string.IsNullOrEmpty(p.GetCustomAttribute<TableAttribute>()?.Name));
            //foreach (Type type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Model.AddEntityType(type);
            //}
            //foreach (var entity in modelBuilder.Model.GetEntityTypes())
            //{
            //    PrimaryKeyConvention.SetPrimaryKey(modelBuilder, entity.Name);
            //    //var currentTableName = modelBuilder.Entity(entity.Name).Metadata.Relational().TableName;  
            //    var currentTableName = modelBuilder.Entity(entity.Name).Metadata.GetTableName();
            //    modelBuilder.Entity(entity.Name).ToTable(currentTableName.ToLower());

            //    var properties = entity.GetProperties();
            //    foreach (var property in properties)
            //    {
            //        ColumnConvention.SetColumnName(modelBuilder, entity.Name, property.Name);
            //    }
            //} 
            //base.OnModelCreating(modelBuilder);

            string executingAssemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string mappingAssemblePath = Path.Combine(executingAssemblyDirectory, "Learn.Dal.Mapping.dll");

            if (!File.Exists(mappingAssemblePath))
                throw new Exception($"{mappingAssemblePath}文件不存在");

            Assembly asm = Assembly.LoadFile(mappingAssemblePath);

            var typesToRegister = asm.GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                object configurationInstance = Activator.CreateInstance(type);

                modelBuilder.AddConfiguration(type, configurationInstance);
            }
            //modelBuilder.AddConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);


        }
        #endregion
    }
}
