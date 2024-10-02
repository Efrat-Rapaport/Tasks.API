using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class TaskModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public bool? Completed { get; set; }

    public DateTime? EndDate { get; set; }

    public string? TaskType { get; set; }

    public bool IsRecurring { get; set; }

    public string? Description { get; set; }

    public bool Archived { get; set; }
}
