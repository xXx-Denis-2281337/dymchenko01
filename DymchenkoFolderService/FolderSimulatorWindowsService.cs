using Dymchenko.Tools;
using System;
using System.ServiceModel;
using System.ServiceProcess;

namespace DymchenkoFolderService
{
    public class FolderSimulatorWindowsService : ServiceBase
    {
        internal const string CurrentServiceName = "FolderSimulatorService";
        internal const string CurrentServiceDisplayName = "Folder Simulator Service";
        internal const string CurrentServiceSource = "FolderSimulatorServiceSource";
        internal const string CurrentServiceLogName = "FolderSimulatorServiceLogName";
        internal const string CurrentServiceDescription = "Folder Simulator for learning purposes.";
        private ServiceHost _serviceHost = null;

        public FolderSimulatorWindowsService()
        {
            ServiceName = CurrentServiceName;
            try
            {
                AppDomain.CurrentDomain.UnhandledException += UnhandledException;
                Logger.Log("Initialization");
            }
            catch (Exception ex)
            {
                Logger.Log("Initialization", ex);
            }
        }

        protected override void OnStart(string[] args)
        {
            Logger.Log("OnStart");
            RequestAdditionalTime(120 * 1000);
            try
            {
                if (_serviceHost != null)
                    _serviceHost.Close();
            }
            catch
            {
            }
            try
            {
                _serviceHost = new ServiceHost(typeof(FolderSimulatorService));
                _serviceHost.Open();
            }
            catch (Exception ex)
            {
                Logger.Log("OnStart", ex);
                throw;
            }
            Logger.Log("Service Started");
        }

        protected override void OnStop()
        {
            Logger.Log("OnStop");
            RequestAdditionalTime(120 * 1000);
            try
            {
                _serviceHost.Close();
            }
            catch (Exception ex)
            {
                Logger.Log("Trying To Stop The Host Listener", ex);
            }
            Logger.Log("Service Stopped");
        }

        private void UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            var ex = (Exception)args.ExceptionObject;

            Logger.Log("UnhandledException", ex);
        }
    }
}
