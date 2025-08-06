﻿using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using SQLitePCL;


namespace Application.ErrorCatalog
{
    public interface IErrorsCatalogService
    {
        ErrorModel? GetErrorByCode(CodePropertyNamePair codePropertyNamePair);
    }

    public class ErrorCatalogService : IErrorsCatalogService
    {
        private readonly Dictionary<string, ErrorModel> _errors;

        public ErrorCatalogService(IOptions<ErrorCatalogConfigurations> errorsCatalogConfigurations)
        {
            Batteries.Init();
            var configurations = errorsCatalogConfigurations.Value;
            var dbPath = configurations.SourceFile;
            using (var connection = new SqliteConnection($"Data Source={dbPath};Mode=ReadOnly;"))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT ErrorCode, ErrorMessage, PropertyName FROM ErrorsCatalog";
                    _errors = new Dictionary<string, ErrorModel>();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var error = new ErrorModel
                            {
                                ErrorCode = reader.GetString(0),
                                ErrorMessage = reader.GetString(1),
                                PropertyName = reader.GetString(2)
                            };
                            _errors[error.ErrorCode] = error;
                        }
                    }
                }
            }
        }

        public ErrorModel? GetErrorByCode(CodePropertyNamePair codePropertyNamePair)
        {
            var existError = _errors.TryGetValue(codePropertyNamePair.ErrorCode, out var error);
            if (existError)
            {
                return error;
            }

            return new ErrorModel
            {
                ErrorCode = ErrorConstants.Generic00000,
                ErrorMessage = "Not documented error",
                PropertyName = codePropertyNamePair.PropertyName
            };
        }
    }
}
