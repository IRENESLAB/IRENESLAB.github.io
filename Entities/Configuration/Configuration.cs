using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;

namespace Entities
{
    /// Singleton class that wraps all settings defined within the App.Config file with an explicit API
    /// </summary>
    public sealed class ConfigSettings
    {
        /// <summary>
        /// Implement Singleton --.NET static initialization is guaranteed to be thread-safe
        /// </summary>
        #region [Fields]

        private static readonly ConfigSettings configSettings = new ConfigSettings();

        #endregion

        #region Constructors + Destructors

        static ConfigSettings()
        {
        }

        private ConfigSettings()
        {
        }

        public static ConfigSettings Instance
        {
            get
            {
                return configSettings;
            }
        }

        #endregion

        #region [Public Properties]
        
        private string _connectionString = string.Empty;
        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = Configuration.GetConnectionString(Constants.ConnectionString) ;
                }

                return _connectionString;
            }
        }
        
        #endregion

    }
}
