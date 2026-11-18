using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LearnStylesMaui.ViewModels
{
    /// <summary>
    /// מחלקת בסיס עבור ViewModels המממשת את INotifyPropertyChanged באופן מפורש (Vanilla C# MVVM).
    /// שים לב: לפי הנחיות הפרויקט והבגרות, איננו משתמשים ב-SetProperty או מילת המפתח ref
    /// עד שהתלמידים שולטים באופן מלא במבנה המפורש של Property עם backing field ו-OnPropertyChanged.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
