## NavigationDrawer for WPF
![](https://github.com/Redouane64/WPFNavigationDrawer/blob/master/sample.gif)

## Usage
```xaml
<Window xmlns:controls="clr-namespace:NavigationDrawerControlForWPF.Controls"
		...>
	<Grid>
		<controls:NavigationDrawer MenuWidth="180" IsMenuOpen="False">
			<controls:NavigationDrawer.MenuHeader>

				<!-- Your menu header contents here -->

			</controls:NavigationDrawer.MenuHeader>	
			<controls:NavigationDrawer.Menu>

				<!-- Your menu items contents here -->

			</controls:NavigationDrawer.Menu>
			<controls:NavigationDrawer.Content>

				<!-- Your main window contents here-->

			</controls:NavigationDrawer.Content>
		</controls:NavigationDrawer>
	</Grid>
</Window>
```
