using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace Pdbc.Shopping.Data.Interceptors
{
    public class DatabaseCommandInterceptor : DbCommandInterceptor
    {
        public override InterceptionResult<DbCommand> CommandCreating(CommandCorrelatedEventData eventData, InterceptionResult<DbCommand> result)
        {
            return base.CommandCreating(eventData, result);
        }

        public override DbCommand CommandCreated(CommandEndEventData eventData, DbCommand result)
        {
            return base.CommandCreated(eventData, result);
        }

        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            return base.ReaderExecuting(command, eventData, result);
        }

        //public InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
        //{
        //    throw new NotImplementedException();
        //}

        //public InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
        //{
        //    throw new NotImplementedException();
        //}

        //public ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result,
        //    CancellationToken cancellationToken = new CancellationToken())
        //{
        //    throw new NotImplementedException();
        //}

        //public ValueTask<InterceptionResult<object>> ScalarExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<object> result,
        //    CancellationToken cancellationToken = new CancellationToken())
        //{
        //    throw new NotImplementedException();
        //}

        //public ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<int> result,
        //    CancellationToken cancellationToken = new CancellationToken())
        //{
        //    throw new NotImplementedException();
        //}

        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            return base.ReaderExecuted(command, eventData, result);
        }

        //public object ScalarExecuted(DbCommand command, CommandExecutedEventData eventData, object result)
        //{
        //    throw new NotImplementedException();
        //}

        //public int NonQueryExecuted(DbCommand command, CommandExecutedEventData eventData, int result)
        //{
        //    throw new NotImplementedException();
        //}

        //public ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result,
        //    CancellationToken cancellationToken = new CancellationToken())
        //{
        //    throw new NotImplementedException();
        //}

        //public ValueTask<object> ScalarExecutedAsync(DbCommand command, CommandExecutedEventData eventData, object result,
        //    CancellationToken cancellationToken = new CancellationToken())
        //{
        //    throw new NotImplementedException();
        //}

        //public ValueTask<int> NonQueryExecutedAsync(DbCommand command, CommandExecutedEventData eventData, int result,
        //    CancellationToken cancellationToken = new CancellationToken())
        //{
        //    throw new NotImplementedException();
        //}

        //public void CommandFailed(DbCommand command, CommandErrorEventData eventData)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task CommandFailedAsync(DbCommand command, CommandErrorEventData eventData,
        //    CancellationToken cancellationToken = new CancellationToken())
        //{
        //    throw new NotImplementedException();
        //}

        //public InterceptionResult DataReaderDisposing(DbCommand command, DataReaderDisposingEventData eventData,
        //    InterceptionResult result)
        //{
        //    throw new NotImplementedException();
        //}




















        //static readonly ConcurrentDictionary<DbCommand, DateTime> CommandTimings = new ConcurrentDictionary<DbCommand, DateTime>();

        ////private readonly DatabaseCallsByRequestInfo _databaseCallsByRequestInfo;
        ////private readonly ILog _log = LogManager.GetLogger<DatabaseCommandInterceptor>();


        ////public static void RegisterDatabaseCallsInterception()
        ////{
        ////    var configuration = true
        ////    if (configuration.LogDatabaseCommands)
        ////    {
        ////        DbInterception.Add(new DatabaseCommandInterceptor());
        ////    }
        ////}

        ////private DatabaseCallsByRequestInfo _databaseCallsByRequestInfo => Container.Resolve<DatabaseCallsByRequestInfo>();
        ////private ISplunkLogger SplunkLogger => Container.Resolve<ISplunkLogger>();




        ///// <summary>
        ///// This method is called after a call to <see cref="M:System.Data.Common.DbCommand.ExecuteNonQuery" />  or
        ///// one of its async counterparts is made. The result used by Entity Framework can be changed by setting
        ///// <see cref="P:System.Data.Entity.Infrastructure.Interception.DbCommandInterceptionContext`1.Result" />.
        ///// </summary>
        ///// <param name="command">The command being executed.</param>
        ///// <param name="interceptionContext">Contextual information associated with the call.</param>
        ///// <remarks>
        ///// For async operations this method is not called until after the async task has completed
        ///// or failed.
        ///// </remarks>
        //public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        //{
        //    LogCommand(command, interceptionContext, "NonQuery");
        //}



        ///// <summary>
        ///// This method is called after a call to <see cref="M:System.Data.Common.DbCommand.ExecuteReader(System.Data.CommandBehavior)" /> or
        ///// one of its async counterparts is made. The result used by Entity Framework can be changed by setting
        ///// <see cref="P:System.Data.Entity.Infrastructure.Interception.DbCommandInterceptionContext`1.Result" />.
        ///// </summary>
        ///// <param name="command">The command being executed.</param>
        ///// <param name="interceptionContext">Contextual information associated with the call.</param>
        ///// <remarks>
        ///// For async operations this method is not called until after the async task has completed
        ///// or failed.
        ///// </remarks>
        //public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        //{
        //    LogCommand(command, interceptionContext, "Query");
        //}

        ///// <summary>
        ///// This method is called after a call to <see cref="M:System.Data.Common.DbCommand.ExecuteScalar" /> or
        ///// one of its async counterparts is made. The result used by Entity Framework can be changed by setting
        ///// <see cref="P:System.Data.Entity.Infrastructure.Interception.DbCommandInterceptionContext`1.Result" />.
        ///// </summary>
        ///// <param name="command">The command being executed.</param>
        ///// <param name="interceptionContext">Contextual information associated with the call.</param>
        ///// <remarks>
        ///// For async operations this method is not called until after the async task has completed
        ///// or failed.
        ///// </remarks>
        //public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        //{
        //    LogCommand(command, interceptionContext, "Scalar");
        //}


        //private void LogCommand<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext, String type)
        //{
        //    var statementInfo = _databaseCallsByRequestInfo.EnlistCommand(command, interceptionContext);

        //    DateTime startTime;
        //    TimeSpan duration;
        //    if (CommandTimings.TryRemove(command, out startTime))
        //    {
        //        duration = DateTime.Now - startTime;
        //    }
        //    else
        //    {
        //        duration = TimeSpan.Zero;
        //    }

        //    var item = new
        //    {
        //        Flow = "Sql",
        //        SqlType = type,
        //        Command = command.CommandText,
        //        Statement = statementInfo.Statement,
        //        IsUnique = statementInfo.IsUnique,
        //        Milliseconds = duration.TotalMilliseconds,
        //        ExecutionCorrect = interceptionContext.Exception == null,
        //        ExceptionMessage = interceptionContext.Exception?.Message,
        //        OriginalExceptionMessage = interceptionContext.OriginalException?.Message

        //    };

        //    SplunkLogger.LogForFlow("Sql", item);
        //}

        ///// <summary>
        ///// This method is called before a call to <see cref="M:System.Data.Common.DbCommand.ExecuteNonQuery" /> or
        ///// one of its async counterparts is made.
        ///// </summary>
        ///// <param name="command">The command being executed.</param>
        ///// <param name="interceptionContext">Contextual information associated with the call.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        //{
        //    // No action before execution
        //    // LogCommand(command);
        //    OnStart(command);
        //}

        ///// <summary>
        ///// This method is called before a call to <see cref="M:System.Data.Common.DbCommand.ExecuteReader(System.Data.CommandBehavior)" /> or
        ///// one of its async counterparts is made.
        ///// </summary>
        ///// <param name="command">The command being executed.</param>
        ///// <param name="interceptionContext">Contextual information associated with the call.</param>
        //public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        //{
        //    OnStart(command);
        //}
        ///// <summary>
        ///// This method is called before a call to <see cref="M:System.Data.Common.DbCommand.ExecuteScalar" /> or
        ///// one of its async counterparts is made.
        ///// </summary>
        ///// <param name="command">The command being executed.</param>
        ///// <param name="interceptionContext">Contextual information associated with the call.</param>
        //public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        //{
        //    OnStart(command);
        //}

        //private static void OnStart(DbCommand command)
        //{
        //    CommandTimings.TryAdd(command, DateTime.Now);
        //}

    }
}
