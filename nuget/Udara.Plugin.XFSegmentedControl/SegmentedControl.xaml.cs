
using System;
using System.Collections;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Udara.Plugin.XFSegmentedControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SegmentedControl : ContentView
    {
        public static readonly BindableProperty PrimaryColorProperty
            = BindableProperty.Create(
                nameof(PrimaryColor),
                typeof(Color),
                typeof(SegmentedControl),
                Color.CornflowerBlue,
                propertyChanged: (bindable, value, newValue) =>
                {
                    foreach (var tabButton in ((SegmentedControl)bindable).TabButtonHolder.Children)
                    {
                        ((TabButton)tabButton).UpdateTabButtonColors(((Color)newValue),
                            ((SegmentedControl)bindable).SecondaryColor);

                        ((TabButton)tabButton).UpdateTabButtonState(
                            ((SegmentedControl)bindable).SelectedTabIndex);
                    }
                },
                defaultBindingMode: BindingMode.TwoWay);

        public Color PrimaryColor
        {
            get { return (Color)GetValue(PrimaryColorProperty); }
            set { SetValue(PrimaryColorProperty, value); }
        }


        public static readonly BindableProperty SecondaryColorProperty
            = BindableProperty.Create(
                nameof(SecondaryColor),
                typeof(Color),
                typeof(SegmentedControl),
                Color.White,
                propertyChanged: (bindable, value, newValue) =>
                {
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        ((SegmentedControl)bindable).FrameView.BorderColor = ((Color)newValue);
                    }

                    foreach (var tabButton in ((SegmentedControl)bindable).TabButtonHolder.Children)
                    {
                        ((TabButton)tabButton).UpdateTabButtonColors(
                            ((SegmentedControl)bindable).PrimaryColor, ((Color)newValue));

                        ((TabButton)tabButton).UpdateTabButtonState(
                            ((SegmentedControl)bindable).SelectedTabIndex);
                    }
                },
                defaultBindingMode: BindingMode.TwoWay);

        public Color SecondaryColor
        {
            get { return (Color)GetValue(SecondaryColorProperty); }
            set { SetValue(SecondaryColorProperty, value); }
        }


        public static readonly BindableProperty SelectedTabIndexProperty
            = BindableProperty.Create(
                nameof(SelectedTabIndex),
                typeof(int),
                typeof(SegmentedControl),
                0, BindingMode.TwoWay,
                propertyChanged: (bindable, value, newValue) =>
                {
                    ((SegmentedControl)bindable).SendSelectedTabIndexChangedEvent();

                    foreach (var tabButton in ((SegmentedControl)bindable).TabButtonHolder.Children)
                        ((TabButton)tabButton).UpdateTabButtonState(((SegmentedControl)bindable).SelectedTabIndex);
                });

        public int SelectedTabIndex
        {
            get { return (int)GetValue(SelectedTabIndexProperty); }
            set { SetValue(SelectedTabIndexProperty, value); }
        }


        public static readonly BindableProperty TabButtonsSourceProperty
            = BindableProperty.Create(
                nameof(TabButtonsSource),
                typeof(IEnumerable),
                typeof(SegmentedControl),
                null,
        propertyChanged: OnTabButtonsPropertyChanged,
        defaultBindingMode: BindingMode.TwoWay);

        public IEnumerable TabButtonsSource
        {
            get { return (IEnumerable)GetValue(TabButtonsSourceProperty); }
            set { SetValue(TabButtonsSourceProperty, value); }
        }

        static void OnTabButtonsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                // handle new items

                ((SegmentedControl)bindable).TabButtonHolder.Children?.Clear();

                int index = 0;
                foreach (var item in (IEnumerable)newValue)
                {
                    var newTab = new TabButton(
                        item.ToString(),
                        index,
                        ((SegmentedControl)bindable).PrimaryColor,
                        ((SegmentedControl)bindable).SecondaryColor,
                        (index == ((SegmentedControl)bindable).SelectedTabIndex));

                    newTab.TabButtonClicked += (sender, args) =>
                    {
                        ((SegmentedControl)bindable).SelectedTabIndex = ((TabButton)sender).TabIndex;
                    };

                    Grid.SetColumn(newTab, index++);

                    ((SegmentedControl)bindable).TabButtonHolder.Children.Add(newTab);
                }

                if (((SegmentedControl)bindable).SelectedTabIndex >
                    ((SegmentedControl)bindable).TabButtonHolder.Children.Count - 1)
                {
                    ((SegmentedControl)bindable).SelectedTabIndex = 0;
                }
            }
            else
            {
                ((SegmentedControl)bindable).TabButtonHolder.Children?.Clear();
            }
        }

        public SegmentedControl()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
            {
                FrameView.BorderColor = SecondaryColor;
            }
        }

        public event EventHandler<SelectedTabIndexEventArgs> SelectedTabIndexChanged;

        public ICommand SelectedTabIndexChangedCommand { get; set; }

        /// <summary>
        /// Invoke the SelectedTabIndexChanged event
        /// for whoever has subscribed so they can
        /// use it for any reative action
        /// </summary>
        private void SendSelectedTabIndexChangedEvent()
        {
            var eventArgs = new SelectedTabIndexEventArgs();
            eventArgs.SelectedTabIndex = SelectedTabIndex;

            SelectedTabIndexChanged?.Invoke(this, eventArgs);

            if (SelectedTabIndexChangedCommand !=null &&
                    SelectedTabIndexChangedCommand.CanExecute(SelectedTabIndex))
            {
                SelectedTabIndexChangedCommand.Execute(SelectedTabIndex);
            }
        }
    }
}