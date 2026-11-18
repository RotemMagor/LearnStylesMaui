using LearnStylesMaui.ViewModels;
using Microsoft.Maui.Controls;

namespace LearnStylesMaui.Views
{
    public partial class ConvertersDemoPage : ContentPage
    {
        public ConvertersDemoPage(ConvertersDemoViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
