using System.Collections.Generic;
using System.Linq;
using WebApp.Core.AlertsParsers;
using WebApp.Core.Factories;
using WebApp.Database;
using WebApp.Repositories;

namespace WebApp.Core.Services
{
    public class AlertsService : IAlertsService
    {
        private readonly ISourcesRepository _sourcesRepository;
        private Dictionary<int, Source> _alertsSources;
        private Dictionary<int, IAlertsParser> _alertsParsers;

        public AlertsService(ISourcesRepository sourcesRepository)
        {
            _sourcesRepository = sourcesRepository;
            Initialize();
        }

        private void Initialize()
        {
            _alertsSources = _sourcesRepository.GetAll()
                .ToDictionary(s => s.Id);

            var parsersFactory = new AlertsParsersFactory();
            _alertsParsers = new Dictionary<int, IAlertsParser>();

            foreach (var source in _alertsSources)
            {
                IAlertsParser parser = parsersFactory.CreateParser(source.Value);
                _alertsParsers.Add(source.Key, parser);
            }
        }

        public IDictionary<int, IAlertsParser> GetAlertsParsers()
        {
            return _alertsParsers;
        }
    }
}
