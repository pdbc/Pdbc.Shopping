using Microsoft.Extensions.Configuration;

namespace Pdbc.Shopping.Data
{
    public class DataSettings
    {
        private readonly IConfiguration _config;

        public DataSettings(IConfiguration config)
        {
            _config = config;
        }

        public string DbConnectionString => _config.GetValue<bool>(DbConstants.UseAdminConnectionString)
            ? _config.GetConnectionString(DbConstants.AdminConnectionStringName)
            : _config.GetConnectionString(DbConstants.ConnectionStringName);

        public int SqlServerMaxRetryCount => _config.GetValue(DbConstants.MaxRetryCountValue, 20);
        public int SqlServerMaxDelay => _config.GetValue(DbConstants.MaxDelayValue, 500);
        public bool UseRetries => _config.GetValue(DbConstants.UseRetries, false);
    }
}