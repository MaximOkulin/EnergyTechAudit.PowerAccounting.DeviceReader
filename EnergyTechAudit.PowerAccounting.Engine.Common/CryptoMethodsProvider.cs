using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Interfaces;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common
{
    public class CryptoMethodsProvider : ICryptoMethodsProvider
    {
        /// <summary>
        /// Вычисляет хэш строки преобразуя в строку формате Base64
        /// </summary>
        /// <param name="source">Входная строка</param>
        /// <returns>Строка в формате Base64</returns>
        public string GetHashString(string source)
        {
            using (var sha = new SHA256Cng())
            {
                var buffer = Encoding.Unicode.GetBytes(source);
                var hash = sha.ComputeHash(buffer);
                return Convert.ToBase64String(hash);
            }
        }

        /// <summary>
        /// Зашифрование буфера алгоритмом AES128 за стороне SQL Server 
        /// с использованием ключа БД, который зашифрован сертификатом БД и мастер ключом БД
        /// </summary>
        /// <param name="clearText">Буфер открытого текста</param>
        /// <returns></returns>
        public byte[] ProtectData(byte[] clearText)
        {

            var encryptedText = new byte[1024];

            string connectionString = ConfigurationManager
                .ConnectionStrings["DatabaseContext"]
                .ConnectionString;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandTimeout = 60;

                    var query = "EXEC [Programmability].[EncryptData] @clearText, @encryptedText OUT;";
                    sqlCommand.CommandText = query;
                    sqlCommand.Parameters.AddRange
                        (
                            new[]
                            {
                                new SqlParameter(SqlParameterResources.ClearText, clearText),
                                new SqlParameter(SqlParameterResources.EncryptedText, encryptedText)
                                {
                                    Direction = ParameterDirection.InputOutput
                                }
                            }
                        );

                    sqlCommand.ExecuteNonQuery();

                    encryptedText = (byte[])sqlCommand.Parameters[SqlParameterResources.EncryptedText].Value;
                }
            }

            return encryptedText;
        }

        public byte[] UnprotectData(byte[] encryptedText)
        {

            var clearText = new byte[1024];

            string connectionString = ConfigurationManager
                .ConnectionStrings["DatabaseContext"]
                .ConnectionString;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandTimeout = 60;

                    var query = "EXEC [Programmability].[DecryptData] @encryptedText,  @clearText OUT;";
                    sqlCommand.CommandText = query;
                    sqlCommand.Parameters.AddRange
                        (
                            new[]
                            {
                                new SqlParameter(SqlParameterResources.EncryptedText, encryptedText),
                                new SqlParameter(SqlParameterResources.ClearText, clearText)
                                {
                                    Direction = ParameterDirection.InputOutput
                                }
                            }
                        );

                    sqlCommand.ExecuteNonQuery();
                    clearText = (byte[])sqlCommand.Parameters[SqlParameterResources.ClearText].Value;

                }
            }

            return clearText;
        }
    }
}
