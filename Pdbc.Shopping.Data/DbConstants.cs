namespace Pdbc.Shopping.Data
{
    public static class DbConstants
    {
        public const string DefaultSchemaName = "dbo";

        public const string MigrationsTableName = "__MigrationsHistory";

        public const string ConnectionStringName = "ShoppingDbContext";
        public const string AdminConnectionStringName = "AdminShoppingDbContext";


        public const string MaxRetryCountValue = "sqlServer:maxRetryCount";
        public const string MaxDelayValue = "sqlServer:maxDelay";
        public const string UseAdminConnectionString = "sqlServer:useAdminConnectionString";

        public const string MigrationsAssembly = "Pdbc.Shopping.Data";
        public static string UseRetries = "sqlServer:useRetries";
    }
}