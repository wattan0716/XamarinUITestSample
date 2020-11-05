using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

using NUnit.Framework;

using Xamarin.UITest;
using Xamarin.UITest.Queries;

using Mobile.UITest.Core;

namespace MobileUITest
{
    public class Tests
    {
        [Test]
        public void EntryTest()
        {
            var stopWatch = Stopwatch.StartNew();
            // できる限り高速化
            AppDriver.Instance.App.ScrollDownTo(c => c.Marked("TestEntry"), c => c.Class("PageRenderer"), strategy:ScrollStrategy.Gesture, swipePercentage: 0.9, swipeSpeed: 1000);
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed.ToString(@"hh\:mm\:ss"));
            AppDriver.Instance.App.EnterText(c => c.Marked("TestEntry"), "UITest");
            AppDriver.Instance.App.PressEnter();
            Assert.AreEqual("UITest", AppDriver.Instance.App.Query(c => c.Marked("TestEntry")).FirstOrDefault().Text);
        }
    }
}
