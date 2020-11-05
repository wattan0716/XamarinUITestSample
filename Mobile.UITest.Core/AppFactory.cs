using Mobile.UITest.Core.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using Xamarin.UITest;

namespace Mobile.UITest.Core
{
    public class AppFactory
    {
        private static Platform platform = CommonUtil.GetAppConfigValue("Android", Platform.Android);

        private static string ApkFile => ConfigurationManager.AppSettings.Get("APKFile");

        /// <summary>
        /// AndroidまたはiOSオブジェクトを生成します
        /// </summary>
        /// <returns>AndroidまたはiOSオブジェクト</returns>
        public static IApp CreateApp() => (platform == Platform.Android) ? CreateAndroidApp() : CreateiOSApp();

        private static IApp CreateAndroidApp() => ConfigureApp.Android.ApkFile(ApkFile).EnableLocalScreenshots().StartApp();

        private static IApp CreateiOSApp() => ConfigureApp.iOS.StartApp();
    }
}
