using Autofac;
using StackOverflow.Infrastructure.DbContexts;
using StackOverflow.Infrastructure.Repositories;
using StackOverflow.Infrastructure.Services;
using StackOverflow.Infrastructure.UnitOfWorks;

namespace StackOverflow.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public InfrastructureModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<StackOverflowUnitOfWork>().As<IStackOverflowUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<QuestionRepository>().As<IQuestionRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<QuestionService>().As<IQuestionService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CommentRepository>().As<ICommentRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CommentService>().As<ICommentService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AnswerRepository>().As<IAnswerRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<AnswerService>().As<IAnswerService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
