using LearnStylesMaui.ViewModels;
using Microsoft.Maui.Controls;

namespace LearnStylesMaui.Views
{
    public partial class StylesDemoPage : ContentPage
    {
        public StylesDemoPage(StylesDemoViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
