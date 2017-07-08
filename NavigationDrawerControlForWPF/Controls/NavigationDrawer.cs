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
		public readonly static DependencyProperty MenuProperty;
		public readonly static DependencyProperty MenuHeaderProperty;
		public readonly static DependencyProperty ContentProperty;
		public readonly static DependencyProperty MenuBackgroundProperty;
		public readonly static DependencyProperty MenuWidthProperty;
		public readonly static DependencyProperty IsMenuOpenProperty;

		static NavigationDrawer()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationDrawer), new FrameworkPropertyMetadata(typeof(NavigationDrawer)));

			MenuProperty = DependencyProperty.Register("Menu", typeof(object), typeof(NavigationDrawer), null);
			MenuHeaderProperty = DependencyProperty.Register("MenuHeader", typeof(object), typeof(NavigationDrawer), null);
			ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(NavigationDrawer), null);
			MenuBackgroundProperty = DependencyProperty.Register("MenuBackground", typeof(Brush), typeof(NavigationDrawer), null);
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

		public Brush MenuBackground
		{
			get { return (Brush)GetValue(MenuBackgroundProperty); }
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
			set
			{
				SetValue(IsMenuOpenProperty, value);
				ChangeVisualState(false);
			}
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

		void menuDarkSurface_MouseDown(object sender, MouseButtonEventArgs e)
		{
			IsMenuOpen = false;
			ChangeVisualState(false);
		}

		void OpenMenuButton_Click(object sender, RoutedEventArgs e)
		{
			IsMenuOpen = true;
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
