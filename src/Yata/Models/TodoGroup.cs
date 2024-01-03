using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yata.Models;

public class TodoGroup
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Color { get; set; }

    [Ignore]
    public Color? ThemeColor { get; set; }

    [Ignore]
    public List<Todo>? UncheckedTodos { get; set; }

    [Ignore]
    public List<Todo>? CheckedTodos { get; set; }

    [Ignore]
    public bool IsUncheckedTodosVisible { get; set; } = true;

    [Ignore]
    public bool IsCheckedTodosVisible { get; set; } = false;
}
