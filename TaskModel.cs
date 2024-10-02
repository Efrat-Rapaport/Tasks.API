using System;

namespace Tasks.API.Models
{
    // המחלקה היא ציבורית (public), כך שהיא נגישה מכל מקום
    public class TaskModel
    {
        public int Id { get; set; }                // מזהה ייחודי
        public string Name { get; set; }           // שם המשימה
        public DateTime StartDate { get; set; }    // תאריך התחלה
        public bool Completed { get; set; }         // האם המשימה הושלמה
        public DateTime? EndDate { get; set; }      // תאריך סיום (אם יש)
        public string TaskType { get; set; }       // סוג המשימה
        public bool IsRecurring { get; set; }       // האם זו משימה מחזורית
        public string Description { get; set; }     // תיאור המשימה
        public bool Archived { get; set; }          // האם המשימה ארכובה
    }
}

