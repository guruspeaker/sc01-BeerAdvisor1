using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Linq;
using System;

namespace sc01_BeerAdvisor1
{
	[Activity(Label = "Beer Advisor", MainLauncher = true)]

	public class MainActivity : Activity

	{
		// instantiate a variable of data type BeerExpert
		private BeerExpert myExpert = new BeerExpert();
		private string finalstring = "";

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// get reference to UI Controls
			Spinner beerColor = FindViewById<Spinner>(Resource.Id.beer_color);
			TextView brands = FindViewById<TextView>(Resource.Id.beer_brands);
			Button btnRecBeer = FindViewById<Button>(Resource.Id.btn_find_beer);
			beerColor.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(BeerColor_ItemSelected);



			// find out what color has been selected in the spinner

			// List<string> myBrandList = myExpert.getBrands(beerColor.GetPositionForView); 

			// Button Delegate

			btnRecBeer.Click += delegate
			{
				finalstring = null;
				string toast = string.Format("Here's your list of {0} beers. Please drink responsibly!", beerColor.SelectedItem.ToString());
				Toast.MakeText(this, toast, ToastLength.Long).Show();
				List<string> myBrandList = myExpert.getBrands(beerColor.SelectedItem.ToString());
				foreach (var x in myBrandList)
				{
					//brands += string.Join(brands, myBrandList
					//finalstring = string.Join(finalstring, x,System.Environment.NewLine," ");
					finalstring += x + System.Environment.NewLine;
				}
				brands.Text = finalstring;


			};
			// format the string from the list

			// TextView - display formatted string

		}

		private void BeerColor_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			//throw new System.NotImplementedException();
			TextView brands = FindViewById<TextView>(Resource.Id.beer_brands);

			brands.Text = Resources.GetString(Resource.String.textBrands);
			//"@string/textBrands";
		}
	}
}

