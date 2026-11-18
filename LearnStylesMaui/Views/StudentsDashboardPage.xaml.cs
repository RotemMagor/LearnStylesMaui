using LearnStylesMaui.ViewModels;
using Microsoft.Maui.Controls;

namespace LearnStylesMaui.Views
{
    public partial class StudentsDashboardPage : ContentPage
    {
        public StudentsDashboardPage(StudentsDashboardViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
