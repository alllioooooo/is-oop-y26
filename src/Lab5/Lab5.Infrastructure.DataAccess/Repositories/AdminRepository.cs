using Lab5.Domain.Abstractions.Admins;
using Lab5.Domain.Abstractions.Repositories;
using Lab5.Domain.Models.Admins;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly string _connectionString;

    public AdminRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IAdmin?> FindAdminByUsernameAsync(string username)
    {
        const string sql = @"
            SELECT admin_id, username, password
            FROM admins
            WHERE username = @username;";

        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync().ConfigureAwait(false);

        await using var command = new NpgsqlCommand();
        command.Connection = connection;
        command.CommandText = sql;
        command.Parameters.AddWithValue("@username", username);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync().ConfigureAwait(false))
            return null;

        return new Admin(reader.GetInt64(0), reader.GetString(1), reader.GetString(2));
    }

    public async Task AddAdminAsync(IAdmin admin)
    {
        const string sql = @"
            INSERT INTO admins (admin_id, username, password)
            VALUES (@AdminId, @Username, @Password);";

        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync().ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@UserId", admin.Id);
        command.Parameters.AddWithValue("@Username", admin.Username);
        command.Parameters.AddWithValue("@Password", admin.Password);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task<bool> UpdateAdminPasswordAsync(string username, string newPassword)
    {
        const string sql = @"
            UPDATE admins
            SET password = @Password
            WHERE username = @Username;";

        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync().ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@Username", username);
        command.Parameters.AddWithValue("@Password", newPassword);

        int affectedRows = await command.ExecuteNonQueryAsync().ConfigureAwait(false);

        return affectedRows > 0;
    }
}