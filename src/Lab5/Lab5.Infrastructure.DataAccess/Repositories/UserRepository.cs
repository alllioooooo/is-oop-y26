using Lab5.Domain.Abstractions.Repositories;
using Lab5.Domain.Abstractions.Users;
using Lab5.Domain.Models.Users;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IUser?> FindUserByUsernameAsync(string username)
    {
        const string sql = @"
        SELECT user_id, user_name
        FROM users
        WHERE user_name = @username;";

        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync().ConfigureAwait(false);

        await using var command = new NpgsqlCommand();
        command.Connection = connection;
        command.CommandText = sql;
        command.Parameters.AddWithValue("@username", username);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync().ConfigureAwait(false))
            return null;

        return new User(reader.GetInt64(0), reader.GetString(1));
    }

    public async Task AddUserAsync(IUser user)
    {
        const string sql = @"
        INSERT INTO users (user_id, user_name)
        VALUES (@UserId, @Username);";

        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync().ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@UserId", user.Id);
        command.Parameters.AddWithValue("@Username", user.Username);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}