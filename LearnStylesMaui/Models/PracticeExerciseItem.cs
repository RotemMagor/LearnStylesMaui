using System;

namespace LearnStylesMaui.Models
{
    /// <summary>
    /// מודל נתונים עבור משימת התרגול של התלמידים.
    /// </summary>
    public class PracticeExerciseItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DifficultyStars { get; set; } // 1 עד 5
        public bool IsCompleted { get; set; }
        public double Score { get; set; }
    }
}
