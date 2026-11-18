using System;

namespace LearnStylesMaui.Models
{
    /// <summary>
    /// מודל נתונים המייצג תלמיד לצורך הדגמת שילוב סגנונות וממירים.
    /// </summary>
    public class StudentItem
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int FinalGrade { get; set; }
        public bool IsPresent { get; set; }
        public bool HasMissingAssignments { get; set; }
        public string SpecialNote { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
    }
}
