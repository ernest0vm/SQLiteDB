
using SQLiteDB.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SQLiteDB.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
            UpdateList();
        }

        private void Add_Text(object sender, RoutedEventArgs e)
        {
            ViewModel.AddtoDataBase(Input_Box.Text);
            UpdateList();
        }

        public void UpdateList()
        {
            Output.ItemsSource = ViewModel.Grab_Entries();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.EditPage));
        }
    }
}
