using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migration;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create table admins
        (
            admin_id bigint primary key generated always as identity,
            username text not null,
            password text not null
        );

        create table users
        (
            user_id bigint primary key generated always as identity,
            user_name text not null
        );

        create table bank_accounts
        (
            user_id bigint not null references users(user_id),
            account_number bigint primary key,
            account_pincode bigint not null
        );
        
        

        create table transactions
        (
            transaction_id bigint primary key,
            account_number bigint not null references bank_accounts(account_number),
            account_transaction bigint not null
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table if exists admins;
        drop table if exists users;
        drop table if exists bank_accounts;
        drop table if exists transactions;
        """;
}
