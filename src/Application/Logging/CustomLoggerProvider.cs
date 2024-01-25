using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logging;

public class CustomLoggerProvider : ILoggerProvider
{
    private readonly CustomLoggerProviderConfiguration _loggerConfig;
    private readonly ConcurrentDictionary<string, CustomLooger> loggers = 
        new ConcurrentDictionary<string, CustomLooger>();

    public CustomLoggerProvider(CustomLoggerProviderConfiguration loggerConfig)
    {
        _loggerConfig = loggerConfig;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return loggers.GetOrAdd(categoryName, nome => new CustomLooger(nome, _loggerConfig));
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
