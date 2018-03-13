using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.List.Models;

namespace Xamarin.List
{
	public partial class MainPage
	{
		private ObservableCollection<Contact> _contacts;

		private IEnumerable<Contact> GetContacts(string searchText = null)
		{
			if (string.IsNullOrWhiteSpace(searchText))
				return _contacts;

			return _contacts.Where(c => c.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0);
		}

		public MainPage()
		{
			InitializeComponent();
			_contacts = new ObservableCollection<Contact>()
			{
				new Contact { Name = "Milano, MI", Status = "Set 1, 2017 - Dec 12, 2017" },
				new Contact { Name = "Seregno, MB", Status = "Gen 1, 2018 - Feb 12, 2018" }
			};
			ListView.ItemsSource = _contacts;
		}

		private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			ListView.ItemsSource = GetContacts(e.NewTextValue);
		}

		private void MenuItem_OnClicked(object sender, EventArgs e)
		{
			_contacts.Remove((sender as MenuItem)?.CommandParameter as Contact);
		}

		private void ListView_OnRefreshing(object sender, EventArgs e)
		{
			_contacts = new ObservableCollection<Contact>
			{
				new Contact { Name = "Milano, MI", Status = "Set 1, 2017 - Dec 12, 2017" },
				new Contact { Name = "Seregno, MB", Status = "Gen 1, 2018 - Feb 12, 2018" }
			};
			ListView.ItemsSource = _contacts;

			ListView.EndRefresh();
		}
	}
}