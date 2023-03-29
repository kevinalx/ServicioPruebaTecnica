using Dapper;
using System.Data;

namespace ServicioPruebaTecnica.Repository
{
    public class UserRepository
    {
        private readonly IDbConnection connection;

        public UserRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            const string sql = "SELECT * FROM Users";
            return await connection.QueryAsync<User>(sql);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            const string sql = "SELECT * FROM Users WHERE Id = @id";
            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { id });
        }

        public async Task<int> AddUserAsync(User user)
        {
            const string sql = @"
            INSERT INTO Users (Name, Email, PasswordHash)
            VALUES (@Name, @Email, @PasswordHash);
            SELECT SCOPE_IDENTITY();
        ";
            return await connection.ExecuteScalarAsync<int>(sql, user);
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            const string sql = @"
            UPDATE Users
            SET Name = @Name, Email = @Email, PasswordHash = @PasswordHash
            WHERE Id = @Id
        ";
            return await connection.ExecuteAsync(sql, user);
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            const string sql = "DELETE FROM Users WHERE Id = @id";
            return await connection.ExecuteAsync(sql, new { id });
        }
    }
}
