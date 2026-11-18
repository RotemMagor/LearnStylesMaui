using System.Collections.ObjectModel;
using System.Windows.Input;
using LearnStylesMaui.Models;
using Microsoft.Maui.Controls;

namespace LearnStylesMaui.ViewModels
{
    /// <summary>
    /// ViewModel עבור מסך משימת התרגול של התלמידים.
    /// </summary>
    public class StudentExerciseViewModel : BaseViewModel
    {
        private string _studentName = "ישראל ישראלי";
        private int _testScore = 82;
        private int _difficultyStars = 4;
        private bool _isBonusEligible = true;
        private string _submissionFeedback = "מלאו את המשימות לפי ההוראות ובדקו את הממשק.";

        public string StudentName
        {
            get => _studentName;
            set
            {
                if (_studentName == value) return;
                _studentName = value;
                OnPropertyChanged();
            }
        }

        public int TestScore
        {
            get => _testScore;
            set
            {
                if (_testScore == value) return;
                _testScore = value;
                OnPropertyChanged();
            }
        }

        public int DifficultyStars
        {
            get => _difficultyStars;
            set
            {
                if (_difficultyStars == value) return;
                _difficultyStars = value;
                OnPropertyChanged();
            }
        }

        public bool IsBonusEligible
        {
            get => _isBonusEligible;
            set
            {
                if (_isBonusEligible == value) return;
                _isBonusEligible = value;
                OnPropertyChanged();
            }
        }

        public string SubmissionFeedback
        {
            get => _submissionFeedback;
            set
            {
                if (_submissionFeedback == value) return;
                _submissionFeedback = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PracticeExerciseItem> Tasks { get; } = new();

        public ICommand ToggleTaskCommand { get; }
        public ICommand ResetExerciseCommand { get; }

        public StudentExerciseViewModel()
        {
            ToggleTaskCommand = new Command<PracticeExerciseItem>((task) =>
            {
                if (task != null)
                {
                    task.IsCompleted = !task.IsCompleted;
                    int index = Tasks.IndexOf(task);
                    if (index >= 0)
                    {
                        Tasks[index] = new PracticeExerciseItem
                        {
                            Id = task.Id,
                            Title = task.Title,
                            Description = task.Description,
                            DifficultyStars = task.DifficultyStars,
                            IsCompleted = task.IsCompleted,
                            Score = task.Score
                        };
                    }
                    UpdateProgressFeedback();
                }
            });

            ResetExerciseCommand = new Command(() =>
            {
                TestScore = 80;
                DifficultyStars = 3;
                IsBonusEligible = false;
                SubmissionFeedback = "הנתונים אופסו לבדיקה חוזרת.";
            });

            InitTasks();
        }

        private void InitTasks()
        {
            Tasks.Add(new PracticeExerciseItem
            {
                Id = 1,
                Title = "משימה 1: יצירת ממיר כוכבי קושי (StarsConverter)",
                Description = "צרו בתיקיית Converters מחלקה הממירה מספר 1-5 למחרוזת כוכבים כגון '★★★☆☆'.",
                DifficultyStars = 2,
                IsCompleted = false
            });

            Tasks.Add(new PracticeExerciseItem
            {
                Id = 2,
                Title = "משימה 2: יצירת סגנון כרטיס מותאם אישית (StudentCustomCard)",
                Description = "הגדירו ב-CustomStyles.xaml סגנון Border עם מסגרת עגולה, צללית ורקע מותאם.",
                DifficultyStars = 3,
                IsCompleted = false
            });

            Tasks.Add(new PracticeExerciseItem
            {
                Id = 3,
                Title = "משימה 3: ירושת סגנון (BasedOn)",
                Description = "צרו סגנון כפתור אזהרה (WarningButton) שיורש מ-PrimaryButton ומשנה את צבע הרקע לכתום.",
                DifficultyStars = 2,
                IsCompleted = false
            });

            Tasks.Add(new PracticeExerciseItem
            {
                Id = 4,
                Title = "משימה 4: שילוב ה-Converter והסגנון במסך התרגול",
                Description = "קשרו את ה-Converter והסגנון החדשים שכתבתם לתוך ה-XAML של מסך זה.",
                DifficultyStars = 4,
                IsCompleted = false
            });
        }

        private void UpdateProgressFeedback()
        {
            int completedCount = 0;
            foreach (var t in Tasks)
            {
                if (t.IsCompleted) completedCount++;
            }

            SubmissionFeedback = $"השלמתם {completedCount} מתוך {Tasks.Count} משימות! המשיכו כך לקראת המבחן.";
        }
    }
}
