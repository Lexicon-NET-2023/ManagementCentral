using ManagementCentral.Shared.Domain;
using System.Text.Json;

namespace ManagementCentral.Client.Components
{
    public partial class DailyStats
    {
        public List<Device> DeviceList { get; set; } = new List<Device>();

        public string responseData = string.Empty;

        public string ErrorMessage = string.Empty;

        public int NumberOfDevice { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //var authState = await authenticationStateTask;
            //if (!authState.User.IsInRole("Admin")) 
            //{
            //    return;
            //}

            try
            {
                var response = await Http.GetAsync("/devices");

                if (response.IsSuccessStatusCode)
                {
                    responseData = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        PropertyNameCaseInsensitive = true,
                    };

                    DeviceList = (List<Device>)JsonSerializer.Deserialize<IEnumerable<Device>>(responseData, options)!;
                    NumberOfDevice = DeviceList.Count;
                }
                else
                {
                    ErrorMessage = "Could not get data from API! " + response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            await base.OnInitializedAsync();

        }
    }
}
