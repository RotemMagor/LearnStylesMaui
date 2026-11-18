using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace LearnStylesMaui.ViewModels
{
    /// <summary>
    /// ViewModel עבור מסך הדגמת ממירי ערכים (Converters Demo).
    /// </summary>
    public class ConvertersDemoViewModel : BaseViewModel
    {
        private bool _isItemActive = true;
        private double _currentScore = 85.0;
        private double _celsiusTemperature = 25.0;
        private string _studentNoteInput = "הגיש את כל המטלות בזמן.";

        public bool IsItemActive
        {
            get => _isItemActive;
            set
            {
                if (_isItemActive == value) return;
                _isItemActive = value;
                OnPropertyChanged();
            }
        }

        public double CurrentScore
        {
            get => _currentScore;
            set
            {
                double rounded = Math.Round(value, 0);
                if (_currentScore == rounded) return;
                _currentScore = rounded;
                OnPropertyChanged();
            }
        }

        public double CelsiusTemperature
        {
            get => _celsiusTemperature;
            set
            {
                double rounded = Math.Round(value, 1);
                if (_celsiusTemperature == rounded) return;
                _celsiusTemperature = rounded;
                OnPropertyChanged();
            }
        }

        public string StudentNoteInput
        {
            get => _studentNoteInput;
            set
            {
                if (_studentNoteInput == value) return;
                _studentNoteInput = value;
                OnPropertyChanged();
            }
        }

        public ICommand ToggleActiveCommand { get; }
        public ICommand SetScoreCommand { get; }
        public ICommand ClearNoteCommand { get; }

        public ConvertersDemoViewModel()
        {
            ToggleActiveCommand = new Command(() =>
            {
                IsItemActive = !IsItemActive;
            });

            SetScoreCommand = new Command<string>((scoreStr) =>
            {
                if (double.TryParse(scoreStr, out double val))
                {
                    CurrentScore = val;
                }
            });

            ClearNoteCommand = new Command(() =>
            {
                StudentNoteInput = string.Empty;
            });
        }
    }
}
