using Dapper;
using Microsoft.Data.SqlClient;
using ProjectMap.WebApi.Models;

namespace ProjectMap.WebApi.Repositories
{
    public class Environment2DRepository : IEnvironment2DRepository
    {
        private readonly string sqlConnectionString;

        public Environment2DRepository(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }
        
        public async Task<Environment2D> InsertAsync(Environment2D environment2D)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                var environmentId = await sqlConnection.ExecuteAsync("INSERT INTO [Environment2D] (Id, Name, MaxHeight, MaxLength, UserId) VALUES (@Id, @Name, @MaxHeight, @MaxLength, @UserId)", environment2D);
                return environment2D;
            }
        }

        public async Task<Environment2D?> ReadAsync(Guid id)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                return await sqlConnection.QuerySingleOrDefaultAsync<Environment2D>("SELECT * FROM [Environment2D] WHERE Id = @Id", new { id });
            }
        }

        public async Task<IEnumerable<Environment2D>> ReadAsync(string id)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                return await sqlConnection.QueryAsync<Environment2D>("SELECT * FROM [Environment2D] WHERE UserId = @Id");
            }
        }
        public async Task UpdateAsync(Environment2D environment)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                await sqlConnection.ExecuteAsync("UPDATE [Environment2D] SET " +
                                                 "Name = @Name, " +
                                                 "MaxHeight = @Maxheight, " +
                                                 "MaxLength = @MaxLength"
                                                 , environment);

            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                await sqlConnection.ExecuteAsync("DELETE FROM [Environment2D] WHERE Id = @Id", new { id });
            }
        }

    }
}
