namespace LiteDbDemo;

public partial class PersonListView : ContentPage
{
    private readonly PersonListViewModel viewModel;

    public PersonListView(PersonListViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;

        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        MainThread.BeginInvokeOnMainThread(async () => await viewModel.LoadData());
    }
}
