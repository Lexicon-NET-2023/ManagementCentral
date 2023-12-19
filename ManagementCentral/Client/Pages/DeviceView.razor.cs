using ManagementCentral.Client.Services;
using ManagementCentral.Shared.Domain;

using Microsoft.AspNetCore.Components;

namespace ManagementCentral.Client.Pages
{
    public partial class DeviceView
    {
        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }

        [Parameter]
        public int DeviceId { get; set; }

        public Device Device { get; set; } = new Device();

        protected override void OnInitialized()
        {
            Device = DeviceDataService.GetDevice(DeviceId);
            base.OnInitialized();
        }

    }
}
