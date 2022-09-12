using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LiteDbDemo
{
	[ObservableObject]
	public partial class MainViewModel
	{
		public MainViewModel(IDataService dataService)
		{
			save = new AsyncRelayCommand(SaveForm);
            this.dataService = dataService;
        }

		[ObservableProperty]
		private string name;

        [ObservableProperty]
        private string company;

        [ObservableProperty]
        private string city;

		[ObservableProperty]
		private ICommand save;
        private readonly ISecureStorageService secureStorageService;
        private readonly IDataService dataService;

        public async Task SaveForm()
		{
			var person = new Person()
			{
				Id = Guid.NewGuid().ToString(),
				Name = Name,
				City = City,
				Company = Company
			};

			await dataService.Save(person);
		}
    }
}

