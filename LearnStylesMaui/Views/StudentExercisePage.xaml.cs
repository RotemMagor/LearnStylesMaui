using LearnStylesMaui.ViewModels;
using Microsoft.Maui.Controls;

namespace LearnStylesMaui.Views
{
    public partial class StudentExercisePage : ContentPage
    {
        public StudentExercisePage(StudentExerciseViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
