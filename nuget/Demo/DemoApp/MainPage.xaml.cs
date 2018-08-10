using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udara.Plugin.XFSegmentedControl;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<string> _tabSource;

        public MainPage()
        {
            InitializeComponent();

            _tabSource = new ObservableCollection<string>()
            {
                "Tab 1",
                "Tab 2",
                "Tab 3",
                "Tab 4",
                "Tab 5",
                "Tab 6",
                "Tab 7",
            };

            SegmentedControl1.TabButtonsSource = _tabSource;
        }
        
        private void SegmentedControl1_SelectedTabIndexChanged(object sender, SelectedTabIndexEventArgs e)
        {
            Label1.Text = $"Currently selected - Tab {e.SelectedTabIndex + 1}";
        }

        private void AddTabButton_OnClicked(object sender, EventArgs e)
        {
            _tabSource.Add($"Tab {_tabSource.Count + 1}");

            SegmentedControl1.TabButtonsSource = new ObservableCollection<string>(_tabSource);
        }

        private void RemoveTabButton_OnClicked(object sender, EventArgs e)
        {
            if (_tabSource.Count > 2)
                _tabSource.Remove(_tabSource.Last());

            SegmentedControl1.TabButtonsSource = new ObservableCollection<string>(_tabSource);
        }

        private void PrimaryColorButton_OnClicked(object sender, EventArgs e)
        {
            SegmentedControl1.PrimaryColor = ((Button)sender).BackgroundColor;

            Layout1.BackgroundColor = ((Button)sender).BackgroundColor;
        }

        private void SecondaryColorButton_OnClicked(object sender, EventArgs e)
        {
            SegmentedControl1.SecondaryColor = ((Button)sender).BackgroundColor;

            Label1.TextColor = ((Button)sender).BackgroundColor;
        }
    }
}
