using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

[assembly: XmlConfigurator(ConfigFile = "log4net.config")]

namespace BeanCannon.BusinessLogic.Core
{
	public static class Logger
	{
		public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		/*
		public static readonly FileInfo log4netConfigFile = new FileInfo("log4net.config");

		static Logger()
		{
			var traceLogsFolder = "TraceLogs";
			if (!Directory.Exists(traceLogsFolder))
			{
				Directory.CreateDirectory(traceLogsFolder);
			}
		}

		// TODO : Review
		public static ILog Log
		{
			get
			{
				var currentThread = Thread.CurrentThread;
				var currentThreadName = !String.IsNullOrEmpty(currentThread.Name) ?
					currentThread.Name :
					currentThread.ManagedThreadId.ToString();

				string repositoryName = currentThreadName + "Repository";

				ILoggerRepository[] allRepos = LogManager.GetAllRepositories();
				ILoggerRepository loggerRepository = allRepos.FirstOrDefault(x => x.Name == repositoryName);

				if (null == loggerRepository)
				{
					loggerRepository = LogManager.CreateRepository(repositoryName);
				}

				ThreadContext.Properties["ThreadName"] = currentThreadName;
				XmlConfigurator.Configure(loggerRepository, log4netConfigFile);

				ILog logger = LogManager.GetLogger(repositoryName, "DevelopmentLogger");

				return logger;
			}
		}
		//*/
	}
}
