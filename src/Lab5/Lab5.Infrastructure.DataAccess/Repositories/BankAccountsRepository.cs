using Lab5.Domain.Abstractions.BankAccounts;
using Lab5.Domain.Abstractions.Repositories;
using Lab5.Domain.Models.BankAccounts;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class BankAccountsRepository : IBankAccountsRepository
{
    private readonly string _connectionString;

    public BankAccountsRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IBankAccount?> FindAccountByUserIdAsync(long userId)
    {
        const string sql = @"
        SELECT user_id, account_number, account_pincode
        FROM bank_accounts
        WHERE user_id = @UserId;";

        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync().ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@UserId", userId);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync().ConfigureAwait(false))
            return null;

        return new BankAccount(
            reader.GetInt64(0),
            reader.GetInt64(1),
            reader.GetInt64(2));
    }

    public async Task AddAccountAsync(IBankAccount account)
    {
        const string sql = @"
        INSERT INTO bank_accounts (user_id, account_number, account_pincode)
        VALUES (@UserId, @AccountNumber, @AccountPincodee);";

        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync().ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@UserId", account.UserId);
        command.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);
        command.Parameters.AddWithValue("@AccountPincode", account.Pincode);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task<IBankAccount?> FindAccountByNumberAsync(long accountNumber)
    {
        const string sql = @"
        SELECT user_id, account_number, account_pincode
        FROM bank_accounts
        WHERE account_number = @AccountNumber;";

        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync().ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@AccountNumber", accountNumber);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync().ConfigureAwait(false))
            return null;

        return new BankAccount(
            reader.GetInt64(0),
            reader.GetInt64(1),
            reader.GetInt64(2));
    }
}