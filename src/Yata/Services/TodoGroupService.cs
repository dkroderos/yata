using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yata.Models;

namespace Yata.Services;

public class TodoGroupService
{
    private static SQLiteAsyncConnection? Database;

    private static async Task Init()
    {
        if (Database is not null)
        {
            return;
        }

        string databaseFilename = "TodoGroupGroupsDB";
        string databasePath = Path.Combine(FileSystem.AppDataDirectory, databaseFilename);

        SQLite.SQLiteOpenFlags flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        Database = new SQLiteAsyncConnection(databasePath, flags);

        await Database.CreateTableAsync<TodoGroup>();
    }

    public static async Task AddTodoGroupAsync(TodoGroup todoGroup)
    {
        await Init();

        await Database!.InsertAsync(todoGroup);
    }

    public static async Task RemoveTodoGroupAsync(int id)
    {
        await Init();

        await Database!.DeleteAsync<TodoGroup>(id);
    }

    public static async Task<TodoGroup> GetTodoGroupAsync(int id)
    {
        await Init();

        var todoGroup = await Database!.GetAsync<TodoGroup>(id);

        return todoGroup;
    }

    public static async Task<IEnumerable<TodoGroup>> GetTodoGroupsAsync()
    {
        await Init();

        var todoGroup = await Database!.Table<TodoGroup>().ToListAsync();

        return todoGroup;
    }

    public static async Task UpdateTodoGroupAsync(TodoGroup todoGroup)
    {
        await Init();

        await Database!.UpdateAsync(todoGroup);
    }
}
