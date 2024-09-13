namespace CurrencyAPITestMAUI
{
    public partial class MainPage : ContentPage
    {
        CurrencyAPIService service = new CurrencyAPIService();

        public MainPage()
        {
            InitializeComponent();
            PickerCurrency.ItemsSource = new[] {"GBP","NZD","USD","JPY" };

        }
        private async void OnCounterClicked(object sender, EventArgs e)
        {
            LabelOutput.Text = "Fetching result...";
            if (!float.TryParse(EntryConvertValue.Text, out float result))
            {
                await DisplayAlert("Invalid!", "Please enter a valid number", "Ok");
            }
            
            CurrencyResponseModel response = await service.Convert(result, PickerCurrency.SelectedItem.ToString() ?? "USD");
            LabelOutput.Text = $"AUD${response.query.amount} to {response.query.to} = {response.result}";


        }

    }

}
