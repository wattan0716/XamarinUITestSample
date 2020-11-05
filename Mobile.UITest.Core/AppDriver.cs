using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Mobile.UITest.Core
{
    public class AppDriver : Singleton<AppDriver>
    {
        private IApp app;

        public IApp App
        {
            get
            {
                if (app == null)
                {
                    app = AppFactory.CreateApp();
                }
                return app;
            }
            set { app = value; }
        }

        public void Dispose()
        {
            if (App != null)
            {
                App = null;
            }
        }

        public FileInfo ScreenShot(string title)
        {
            return App.Screenshot(title);
        }

        public void Tap(Func<AppQuery, AppQuery> query)
        {
            App.Tap(query);
        }

        public void Repl()
        {
            App.Repl();
        }

        public void Print()
        {
            App.Print.Tree();
        }

        public void SelectList(int index = 0)
        {
            App.Tap(c => c.Class("ListView").Child().Index(index));
        }

        public bool IsEntry(Func<AppQuery, AppQuery> query)
        {
            Console.WriteLine(App.Query(query).FirstOrDefault().Class);
            return App.Query(query).FirstOrDefault().Class.Contains("EntryRenderer");
        }

        public bool IsLabel(Func<AppQuery, AppQuery> query)
        {
            Console.WriteLine(App.Query(query).FirstOrDefault().Class);
            return App.Query(query).FirstOrDefault().Class.Contains("LabelRenderer");
        }
    }
}
