using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace NavigationDrawerControlForWPF.Controls
{
	[TemplatePart(Name = "PART_Menu", Type = typeof(Border))]
	[TemplatePart(Name = "PART_MenuDarkSurface", Type = typeof(Border))]
	[TemplatePart(Name = "PART_OpenMenuButton", Type = typeof(UIElement))]
	[TemplateVisualState(GroupName = "ViewStates", Name = "Normal")]
	[TemplateVisualState(GroupName = "ViewStates", Name = "MenuOpened")]
	public class NavigationDrawer : Control
	{
		public static DependencyProperty MenuProperty;
		public static DependencyProperty MenuHeaderProperty;
		public static DependencyProperty ContentProperty;
		public static DependencyProperty MenuBackgroundProperty;
		public static DependencyProperty MenuWidthProperty;
		public static DependencyProperty IsMenuOpenProperty;

		static NavigationDrawer()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationDrawer), new FrameworkPropertyMetadata(typeof(NavigationDrawer)));

			MenuProperty = DependencyProperty.Register("Menu", typeof(object), typeof(NavigationDrawer), null);
			MenuHeaderProperty = DependencyProperty.Register("MenuHeader", typeof(object), typeof(NavigationDrawer), null);
			ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(NavigationDrawer), null);
			MenuBackgroundProperty = DependencyProperty.Register("MenuBackground", typeof(Color), typeof(NavigationDrawer), null);
			MenuWidthProperty = DependencyProperty.Register("MenuWidth", typeof(double), typeof(NavigationDrawer), null);
			IsMenuOpenProperty = DependencyProperty.Register("IsMenuOpen", typeof(bool), typeof(NavigationDrawer), null);
		}

		public object Menu
		{
			get { return GetValue(MenuProperty); }
			set { SetValue(MenuProperty, value); }
		}

		public object MenuHeader
		{
			get { return GetValue(MenuHeaderProperty); }
			set { SetValue(MenuHeaderProperty, value); }
		}

		public object Content
		{
			get { return GetValue(ContentProperty); }
			set { SetValue(ContentProperty, value); }
		}

		public Color MenuBackground
		{
			get { return (Color)GetValue(MenuBackgroundProperty); }
			set { SetValue(MenuBackgroundProperty, value); }
		}

		public double MenuWidth
		{
			get { return (double)GetValue(MenuWidthProperty); }
			set { SetValue(MenuWidthProperty, value); }
		}

		public bool  IsMenuOpen
		{
			get { return (bool)GetValue(IsMenuOpenProperty); }
			set { SetValue(IsMenuOpenProperty, value); }
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			var openMenuButton = GetTemplateChild("PART_OpenMenuButton") as ButtonBase;
			var menuDarkSurface = GetTemplateChild("PART_MenuDarkSurface") as Border;

			if(openMenuButton != null)
			{
				openMenuButton.Click += new RoutedEventHandler(OpenMenuButton_Click);
			}
			if (menuDarkSurface != null)
			{
				menuDarkSurface.MouseDown += new MouseButtonEventHandler(menuDarkSurface_MouseDown);
			}

			ChangeVisualState(false);
		}

		public void OpenMenu()
		{
			IsMenuOpen = true;
			ChangeVisualState(false);
		}

		void menuDarkSurface_MouseDown(object sender, MouseButtonEventArgs e)
		{
			IsMenuOpen = !IsMenuOpen;
			ChangeVisualState(false);
		}

		void OpenMenuButton_Click(object sender, RoutedEventArgs e)
		{
			IsMenuOpen = !IsMenuOpen;
			ChangeVisualState(false);
		}

		protected void ChangeVisualState(bool useTransition)
		{
			if (!IsMenuOpen)
			{
				VisualStateManager.GoToState(this, "Normal", useTransition);
			}
			else
			{
				VisualStateManager.GoToState(this, "MenuOpened", useTransition);
			}
		}
	}
}
