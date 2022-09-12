using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LiteDbDemo
{
	[ObservableObject]
	public partial class PersonListViewModel
	{
		public PersonListViewModel(IDataService dataService)
		{
            this.dataService = dataService;
        }

		[ObservableProperty]
		private ObservableCollection<Person> persons;

        private readonly IDataService dataService;

        public async Task LoadData()
		{
			var result = await dataService.GetAll();

			Persons = new ObservableCollection<Person>(result);
		}
	}
}

