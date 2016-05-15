using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Timers;

namespace TriggerService
{
    public partial class DataUpdateService : ServiceBase
    {
        private Timer _timer;
        public DataUpdateService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {            
            _timer = new Timer(1000 * 5);
            _timer.Elapsed += (sender, args1) => { UpdateData(); };
            _timer.AutoReset = false;
            _timer.Start();
        }

        protected override void OnStop()
        {
            _timer.Stop();
        }

        private void UpdateData()
        {
            _timer.Stop();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:60136");
                    var result = client.PostAsJsonAsync("system/update", new StringContent(string.Empty)).Result;
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
            }
            
            _timer.Start();
        }
    }
}
