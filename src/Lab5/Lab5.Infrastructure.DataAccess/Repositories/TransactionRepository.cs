using Lab5.Domain.Abstractions.Repositories;
using Lab5.Domain.Abstractions.Transactions;
using Lab5.Domain.Models.Transactions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly string _connectionString;

    public TransactionRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task AddTransactionAsync(ITransaction transaction)
    {
        const string sql = @"
        INSERT INTO transactions (account_number, account_transaction)
        VALUES (@AccountNumber, @AccountTransaction);";

        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync().ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@AccountNumber", transaction.AccountNumber);
        command.Parameters.AddWithValue("@AccountTransaction", transaction.AccountTransaction);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<ITransaction>> FindTransactionsByAccountNumberAsync(long accountNumber)
    {
        const string sql = @"
        SELECT account_number, account_transaction
        FROM transactions
        WHERE account_number = @AccountNumber;";

        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync().ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@AccountNumber", accountNumber);

        var transactions = new List<ITransaction>();

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            transactions.Add(new Transaction(
                reader.GetInt64(0),
                reader.GetInt64(1)));
        }

        return transactions;
    }
}