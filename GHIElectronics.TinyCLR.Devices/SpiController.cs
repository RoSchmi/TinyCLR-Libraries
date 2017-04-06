﻿using GHIElectronics.TinyCLR.Devices.Spi.Provider;

namespace GHIElectronics.TinyCLR.Devices.Spi {
    public sealed class SpiController {
        private ISpiControllerProvider provider;

        internal SpiController(ISpiControllerProvider provider) => this.provider = provider;

        public static SpiController GetDefault() => LowLevelDevicesController.DefaultProvider.SpiControllerProvider != null ? new SpiController(LowLevelDevicesController.DefaultProvider.SpiControllerProvider) : null;

        public SpiDevice GetDevice(SpiConnectionSettings settings) => new SpiDevice(settings, this.provider.GetDeviceProvider(new ProviderSpiConnectionSettings(settings)));

        public static SpiController[] GetControllers(ISpiProvider provider) {
            var providers = provider.GetControllers();
            var controllers = new SpiController[providers.Length];

            for (var i = 0; i < providers.Length; i++)
                controllers[i] = new SpiController(providers[i]);

            return controllers;
        }
    }
}
