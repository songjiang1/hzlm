using Learn.Util.Extension;
using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.IO;

public class LogHelper
{
    private static ILoggerRepository repository { get; set; }
    private static ILog _log;
    private static ILog log
    {
        get
        {
            if (_log == null)
            {
                Configure();
            }
            return _log;
        }
    }

    public static void Configure(string repositoryName = "NETCoreRepository", string configFile = "log4net.config")
    {
        repository = LogManager.CreateRepository(repositoryName);
        XmlConfigurator.Configure(repository, new FileInfo(configFile));
        _log = LogManager.GetLogger(repositoryName, "");
    }

    public static void Info(string msg)
    {
        log.Info(msg);
    }

    public static void Warn(string msg)
    {
        log.Warn(msg);
    }

    public static void Error(string msg)
    {
        log.Error(msg);
    }
    public static void Error(Exception ex)
    {
        if (ex != null)
        {
            log.Error(GetExceptionMessage(ex));
        }
    }
    private static string GetExceptionMessage(Exception ex)
    {
        string message = string.Empty;
        if (ex != null)
        {
            message += ex.Message;
            message += Environment.NewLine;
            Exception originalException = ex.GetOriginalException();
            if (originalException != null)
            {
                if (originalException.Message != ex.Message)
                {
                    message += originalException.Message;
                    message += Environment.NewLine;
                }
            }
            message += ex.StackTrace;
            message += Environment.NewLine;
        }
        return message;
    }
}