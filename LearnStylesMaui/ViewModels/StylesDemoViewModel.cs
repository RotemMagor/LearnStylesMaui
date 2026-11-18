using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace LearnStylesMaui.ViewModels
{
    /// <summary>
    /// ViewModel עבור מסך הדגמת סגנונות (Styles Demo).
    /// </summary>
    public class StylesDemoViewModel : BaseViewModel
    {
        private bool _isActionEnabled = true;
        private int _clickCount = 0;
        private string _statusMessage = "הפקדים במצב פעיל (Enabled)";
        private string _currentAccentName = "סגול ברירת מחדל (Default Purple)";

        public bool IsActionEnabled
        {
            get => _isActionEnabled;
            set
            {
                if (_isActionEnabled == value) return;
                _isActionEnabled = value;
                OnPropertyChanged();
                StatusMessage = value ? "הפקדים במצב פעיל (Enabled)" : "הפקדים במצב מושבת (Disabled - שימו לב ל-VisualStateManager)";
                ((Command)TestClickCommand).ChangeCanExecute();
            }
        }

        public int ClickCount
        {
            get => _clickCount;
            set
            {
                if (_clickCount == value) return;
                _clickCount = value;
                OnPropertyChanged();
            }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                if (_statusMessage == value) return;
                _statusMessage = value;
                OnPropertyChanged();
            }
        }

        public string CurrentAccentName
        {
            get => _currentAccentName;
            set
            {
                if (_currentAccentName == value) return;
                _currentAccentName = value;
                OnPropertyChanged();
            }
        }

        public ICommand ToggleEnabledCommand { get; }
        public ICommand TestClickCommand { get; }
        public ICommand SwitchAccentColorCommand { get; }

        public StylesDemoViewModel()
        {
            ToggleEnabledCommand = new Command(() =>
            {
                IsActionEnabled = !IsActionEnabled;
            });

            TestClickCommand = new Command(
                execute: () =>
                {
                    ClickCount++;
                },
                canExecute: () => IsActionEnabled
            );

            SwitchAccentColorCommand = new Command<string>((colorName) =>
            {
                ChangeDynamicAccent(colorName);
            });
        }

        private void ChangeDynamicAccent(string? colorName)
        {
            if (Application.Current?.Resources == null) return;

            Color newColor;
            switch (colorName)
            {
                case "Teal":
                    newColor = Color.FromArgb("#00897B");
                    CurrentAccentName = "טורקיז (Teal Accent)";
                    break;
                case "Orange":
                    newColor = Color.FromArgb("#FB8C00");
                    CurrentAccentName = "כתום (Orange Accent)";
                    break;
                case "Navy":
                    newColor = Color.FromArgb("#1E3A8A");
                    CurrentAccentName = "כחול נייבי (Navy Accent)";
                    break;
                default:
                    newColor = Color.FromArgb("#512BD4");
                    CurrentAccentName = "סגול ברירת מחדל (Default Purple)";
                    break;
            }

            // עדכון המשאב הדינמי במילון המשאבים האפליקטיבי
            // פקדים שמשתמשים ב-DynamicResource יתעדכנו מיד בזמן ריצה!
            Application.Current.Resources["DynamicAccentColor"] = newColor;
        }
    }
}
