using ReactNative.Bridge;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using Windows.ApplicationModel;
using Windows.System.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls;

namespace ReactNative.Modules.KCKeepAwake
{
    public class KCKeepAwakeModule : ReactContextNativeModuleBase
    {
        ReactContext reactContext = null;
        private DisplayRequest dispRequest = null;

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
        public void activate()
        {
            dispRequest = new DisplayRequest();
            dispRequest.RequestActive();
        }

        [ReactMethod]
        public void deactivate()
        {
            dispRequest = new DisplayRequest();
            dispRequest.RequestRelease();
        }
    }
}
