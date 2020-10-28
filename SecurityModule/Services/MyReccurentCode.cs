using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace SecurityModule.Services
{
    public class MyReccurentCode : IHostedService, IDisposable
    {
        private readonly IHostEnvironment _environment;
        private readonly ILogger<MyReccurentCode> _logger;
        private Timer timer;

        public MyReccurentCode(IHostEnvironment environment, ILogger<MyReccurentCode> logger)
        {
            this._environment = environment;
            this._logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogWarning("Ejecutado al iniciar la app...");
            timer = new Timer(WriteInTextFile, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        private void WriteInTextFile(object state)
        {
            var path = @$"{_environment.ContentRootPath}\wwwroot\recordatorio.txt";
            using (StreamWriter writer = new StreamWriter(path, append: true))
            {
                writer.WriteLine($"Darianny no te quiere: {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogWarning("Ejecutado al apagar el server...");
            timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
