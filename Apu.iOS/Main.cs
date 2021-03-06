﻿using System;
using System.Collections.Generic;
using System.Linq;
using CoreLocation;
using Foundation;
using UIKit;

namespace Apu.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            var manager = new CLLocationManager();
            manager.RequestWhenInUseAuthorization();
            manager.RequestAlwaysAuthorization();


            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}