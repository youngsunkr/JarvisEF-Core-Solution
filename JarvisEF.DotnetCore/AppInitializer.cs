using System;
using System.Collections.Generic;
using System.Text;

namespace JarvisEF.DotnetCore
{
    public class AppInitializer
    {
        private static volatile bool _appInitialized = false;
        private readonly AppSettings _settings;

        public AppInitializer(AppSettings settings) => _settings = settings;

        public void Initialize()
        {
            if (_appInitialized == false)
            {
                InitializeApp();
                _appInitialized = true;
            }
        }

        private void InitializeApp()
        {

        }
    }
}
