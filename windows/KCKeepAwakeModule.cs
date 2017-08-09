using ReactNative.Bridge;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls;

namespace ReactNative.Modules.KCKeepAwake
{
    public class KCKeepAwakeModule : ReactContextNativeModuleBase
    {
        ReactContext reactContext = null;
        private Windows.System.Display.DisplayRequest dispRequest = null;

        public KCKeepAwakeModule(ReactContext reactContext)
            : base(reactContext)
        {
            this.reactContext = reactContext;
        }

        public override string Name
        {
            get
            {
                return "KCKeepAwake";
            }
        }

        [ReactMethod]
        async void activate()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (dispRequest == null)
                {
                    dispRequest = new Windows.System.Display.DisplayRequest();
                    dispRequest.RequestActive();
                }
            });
        }

        [ReactMethod]
        async void deactivate()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (dispRequest != null)
                {
                    dispRequest = new Windows.System.Display.DisplayRequest();
                    dispRequest.RequestRelease();
                }
            });
        }
    }
}
