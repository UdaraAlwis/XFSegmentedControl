Segmented Button Control for Xamarin.Forms!
===========

Segmented Button Control for Xamarin.Forms (Android, iOS, UWP) with awesome features, such as dynamically adding or removing Tab Button elements, setting Colors, and Selected Index at run time with full native look and feel. Built from pure Xamarin.Forms, lightweight, no custom renders nor platform implementations, and it's awesome! ;)

<img src="https://github.com/UdaraAlwis/XFSegmentedControl/blob/master/nuget/screenshots/iOS.gif"  height="90" /> <img src="https://github.com/UdaraAlwis/XFSegmentedControl/blob/master/nuget/screenshots/Android.gif"  height="90" /> <img src="https://github.com/UdaraAlwis/XFSegmentedControl/blob/master/nuget/screenshots/UWP.gif"  height="90" />

Setting it up:

* Grab it on NuGet: https://www.nuget.org/packages/Udara.Plugin.XFSegmentedControl/ [![NuGet](https://img.shields.io/nuget/v/Udara.Plugin.XFSegmentedControl.svg?label=NuGet)](https://www.nuget.org/packages/Udara.Plugin.XFSegmentedControl/)
* Just install in your Xamarin.Forms PCL/.NET Net Standard  project, you're good to go! (no need to install in the platform projects) because it's that awesome and lightweight! :D 


#### XAML Set up

```xaml
xmlns:xfsegmentedcontrol="clr-namespace:Udara.Plugin.XFSegmentedControl;assembly=Udara.Plugin.XFSegmentedControl"
```

```xaml
<xfsegmentedcontrol:SegmentedControl
	x:Name="SegmentedControl1"
	PrimaryColor="White"
	SecondaryColor="Black"
	SelectedTabIndex="2"
	SelectedTabIndexChanged="SegmentedControl1_SelectedTabIndexChanged">
	<xfsegmentedcontrol:SegmentedControl.TabButtonsSource>
		<x:Array Type="{x:Type x:String}">
			<x:String>Tab 1</x:String>
			<x:String>Tab 2</x:String>
			<x:String>Tab 3</x:String>
			<x:String>Tab 4</x:String>
		</x:Array>
	</xfsegmentedcontrol:SegmentedControl.TabButtonsSource>
</xfsegmentedcontrol:SegmentedControl>
```

#### SelectedTabIndexChanged Event

```csharp
private void SegmentedControl1_SelectedTabIndexChanged
		(object sender, SelectedTabIndexEventArgs e)
{
	Label1.Text 
		= $"Currently selected - Tab {e.SelectedTabIndex + 1}";
}
```

#### Bindable Properties

```TabButtonsSource```: Gets or sets Item Source of Tabs, type of IEnumerable<string> 

```SelectedTabIndex```: Gets or sets the current selected Tab/Button/Segment index, type of int

```PrimaryColor```: Gets or sets the Primary color of the element, type of Color

```SecondaryColor```: Gets or sets the Secondary color of the element, type of Color

#### Event Handler / Command

Fires when the selected Tab/Button/Segment is changed

```SelectedTabIndexChanged```: Gets SelectedTabIndexEventArgs contains updated index, SelectedTabIndex, type of int

```SelectedTabIndexChangedCommand```: Gets the updated index as a param, type of int

How I built it?
---------------

A Segmented Button Control, or as some call it Grouped Button Control, or Tabbed Button Control or some even call the Rocker Control, is what I'm gonna share with yol today, built 100% from Xamarin.Forms!

Yeah such a platform specific UI element, right out of Xamarin.Forms without a single line of native code, how's that even? Well if you've been following my blog for a while, you know that I'm all about pushing them limits of any given platform and achieve the impossibru! ;)

Started this off as a fun experientant implementation which blew into a fool-proof awesomeness which I have broken into two parts, Simple and Advanced implementation in my blog!

Part 1: Simple Segmented Button Control in pure Xamarin.Forms!
---------------

A very simple Segmented Button Control which has two Tab Button elements but with cool features such as setting Text, Colors and SelectedIndex, etc... And most of all with full looks and feel of a native Segmented Button control!

> Read the full blog post: https://theconfuzedsourcecode.wordpress.com/2018/07/09/a-segmented-control-in-pure-xamarin-forms/

<img src="https://github.com/UdaraAlwis/XFSegmentedControl/blob/master/screenshots/SimpleSegmentedControlAndroidGIF.gif"  height="315" /> <img src="https://github.com/UdaraAlwis/XFSegmentedControl/blob/master/screenshots/SimpleSegmentedControliOSGIF.gif"  height="315" />



Part 2: Advanced Segmented Button Control in pure Xamarin.Forms!
---------------

An advanced Segmented Button Control which has awesome features such as dynamically adding or removing Tab Button elements, setting Colors, and Selected Tab index at run time with full native features and looks and feel!

> Read the full blog post: https://theconfuzedsourcecode.wordpress.com/2018/08/02/advanced-segmented-button-control-in-pure-xamarin-forms/

<img src="https://github.com/UdaraAlwis/XFSegmentedControl/blob/master/screenshots/AdvSegmentedControlAndroidGIF.gif"  height="350" /> <img src="https://github.com/UdaraAlwis/XFSegmentedControl/blob/master/screenshots/AdvSegmentedControliOSGIF.gif"  height="350" />

**more awesome stuff...**

just to show how powerful this awesomeness is, I cooked up bit of a cool demo right here running on iOS and Android!

<img src="https://github.com/UdaraAlwis/XFSegmentedControl/blob/master/screenshots/AdvSegmentedControliOSGIF1.gif"  width="250" /> <img src="https://github.com/UdaraAlwis/XFSegmentedControl/blob/master/screenshots/AdvSegmentedControliOSGIF2.gif"  width="250" />

<img src="https://github.com/UdaraAlwis/XFSegmentedControl/blob/master/screenshots/AdvSegmentedControlAndroidGIF1.gif"  width="250" /> <img src="https://github.com/UdaraAlwis/XFSegmentedControl/blob/master/screenshots/AdvSegmentedControlAndroidGIF2.gif"  width="250" />

**FULLY DYNAMIC | ADDING/REMOVE TABS | SWITCHING COLORS  | SWITCHING TAB** 




