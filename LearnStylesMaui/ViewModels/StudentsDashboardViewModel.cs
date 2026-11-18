using System.Collections.ObjectModel;
using System.Windows.Input;
using LearnStylesMaui.Models;
using Microsoft.Maui.Controls;

namespace LearnStylesMaui.ViewModels
{
    /// <summary>
    /// ViewModel עבור כרטיס תלמידים משולב (הדגמת Styles + Converters יחד).
    /// </summary>
    public class StudentsDashboardViewModel : BaseViewModel
    {
        public ObservableCollection<StudentItem> Students { get; } = new();

        public ICommand TogglePresenceCommand { get; }
        public ICommand AddSampleStudentCommand { get; }

        public StudentsDashboardViewModel()
        {
            TogglePresenceCommand = new Command<StudentItem>((student) =>
            {
                if (student != null)
                {
                    student.IsPresent = !student.IsPresent;
                    // ריענון הצגת הפריט באוסף
                    int index = Students.IndexOf(student);
                    if (index >= 0)
                    {
                        Students[index] = new StudentItem
                        {
                            Id = student.Id,
                            FullName = student.FullName,
                            FinalGrade = student.FinalGrade,
                            IsPresent = student.IsPresent,
                            HasMissingAssignments = student.HasMissingAssignments,
                            SpecialNote = student.SpecialNote,
                            AvatarUrl = student.AvatarUrl
                        };
                    }
                }
            });

            AddSampleStudentCommand = new Command(() =>
            {
                Students.Add(new StudentItem
                {
                    Id = Students.Count + 1,
                    FullName = $"תלמיד חדש #{Students.Count + 1}",
                    FinalGrade = 88,
                    IsPresent = true,
                    HasMissingAssignments = false,
                    SpecialNote = "הצטרף לאחרונה לקבוצה."
                });
            });

            LoadSampleData();
        }

        private void LoadSampleData()
        {
            Students.Add(new StudentItem
            {
                Id = 1,
                FullName = "נועה כהן",
                FinalGrade = 95,
                IsPresent = true,
                HasMissingAssignments = false,
                SpecialNote = "הצטיינה בפרויקט הסופי."
            });

            Students.Add(new StudentItem
            {
                Id = 2,
                FullName = "איתי לוי",
                FinalGrade = 78,
                IsPresent = false,
                HasMissingAssignments = true,
                SpecialNote = "חסרה הגשת מעבדה 3."
            });

            Students.Add(new StudentItem
            {
                Id = 3,
                FullName = "מאיה אברהם",
                FinalGrade = 62,
                IsPresent = true,
                HasMissingAssignments = true,
                SpecialNote = string.Empty
            });

            Students.Add(new StudentItem
            {
                Id = 4,
                FullName = "דניאל גולדשטיין",
                FinalGrade = 45,
                IsPresent = false,
                HasMissingAssignments = true,
                SpecialNote = "דרוש תגבור לפני הבגרות."
            });
        }
    }
}
