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
            };

            SegmentedControl2.TabButtonsSource = _tabSource;
        }
        
        private void SegmentedControl1_SelectedTabIndexChanged(object sender, SelectedTabIndexEventArgs e)
        {
            switch (e.SelectedTabIndex)
            {
                case 0:
                    ContentView1.IsVisible = true;
                    ContentView2.IsVisible = false;
                    ContentView3.IsVisible = false;
                    ContentView4.IsVisible = false;
                    break;
                case 1:
                    ContentView1.IsVisible = false;
                    ContentView2.IsVisible = true;
                    ContentView3.IsVisible = false;
                    ContentView4.IsVisible = false;
                    break;
                case 2:
                    ContentView1.IsVisible = false;
                    ContentView2.IsVisible = false;
                    ContentView3.IsVisible = true;
                    ContentView4.IsVisible = false;
                    break;
                case 3:
                    ContentView1.IsVisible = false;
                    ContentView2.IsVisible = false;
                    ContentView3.IsVisible = false;
                    ContentView4.IsVisible = true;
                    break;
            }
        }

        private void AddTabButton_OnClicked(object sender, EventArgs e)
        {
            _tabSource.Add($"Tab {_tabSource.Count + 1}");

            SegmentedControl2.TabButtonsSource = new ObservableCollection<string>(_tabSource);
        }

        private void RemoveTabButton_OnClicked(object sender, EventArgs e)
        {
            if (_tabSource.Count > 2)
                _tabSource.Remove(_tabSource.Last());

            SegmentedControl2.TabButtonsSource = new ObservableCollection<string>(_tabSource);
        }

        private void PrimaryColorButton_OnClicked(object sender, EventArgs e)
        {
            SegmentedControl2.PrimaryColor = ((Button)sender).BackgroundColor;
        }

        private void SecondaryColorButton_OnClicked(object sender, EventArgs e)
        {
            SegmentedControl2.SecondaryColor = ((Button)sender).BackgroundColor;
        }
    }
}
