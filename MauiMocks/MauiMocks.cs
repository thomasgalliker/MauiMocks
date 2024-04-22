using System.Reflection;

namespace Microsoft.Maui
{
    public static class MauiMocks
    {
        private static readonly object lockObj = new object();
        private static bool isInitialized;

        public static bool IsInitialized
        {
            get
            {
                lock (lockObj)
                {
                    return isInitialized;
                }
            }
        }

        public static void Init()
        {
            lock (lockObj)
            {
                if (!isInitialized)
                {
                    var application = new MockApplication();
                    application.Handler = new MockApplicationHandler();
                    application.Handler.SetMauiContext(new MockMauiContext());

                    Application.SetCurrentApplication(application);
                    DispatcherProvider.SetCurrent(new MockDispatcherProvider());

                    DeviceDisplay.SetCurrent(new MockDeviceDisplay());
                    DeviceInfo.SetCurrent(new MockDeviceInfo());

                    isInitialized = true;
                }
            }
        }

        public static void Reset()
        {
            lock (lockObj)
            {
                if (isInitialized)
                {
                    Application.SetCurrentApplication(null);
                    DispatcherProvider.SetCurrent(null);

                    DeviceDisplay.SetCurrent(null);
                    DeviceInfo.SetCurrent(null);
                    isInitialized = false;
                }
            }
        }

        public static class DeviceDisplay
        {
            public static void SetCurrent(IDeviceDisplay deviceDisplay)
            {
                var arguments = new object[] { deviceDisplay };
                InvokeStaticMethod(typeof(Microsoft.Maui.Devices.DeviceDisplay), "SetCurrent", arguments);
            }
        }

        public static class DeviceInfo
        {
            public static void SetCurrent(IDeviceInfo deviceInfo)
            {
                var arguments = new object[] { deviceInfo };
                InvokeStaticMethod(typeof(Microsoft.Maui.Devices.DeviceInfo), "SetCurrent", arguments);
            }
        }

        private static void InvokeStaticMethod(Type targetType, string methodName, object[] parameters)
        {
            var deviceDisplaySetCurrentMethodInfo = targetType
                .GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic);

            if (deviceDisplaySetCurrentMethodInfo == null)
            {
                throw new MissingMethodException(targetType.Name, nameof(methodName));
            }

            deviceDisplaySetCurrentMethodInfo.Invoke(null, parameters);
        }
    }
}