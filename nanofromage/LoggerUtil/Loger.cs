using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace LoggerUtil
{
    public class Loger
    {

        #region StaticVariables
        #endregion

        #region Constants
            public const String SEPARATOR = " : ";
            public const String ALERT = "Alert ";
            public const String MODE = "Mode ";
            public const String FOLDER = "nanofromage.txt";
        #endregion

        #region Variables
        private Notifier notifier;
        private int offsetX = 0;
        private int offsetY = 150;
        #endregion

        #region Attributs
        private List<Alert> alert;
            private List<Mode> mode;
        #endregion

        #region Properties
            public List<Alert> Alert
            {
                get { return alert; }
                set { alert = value; }
            }

            public List<Mode> Mode
            {
                get { return mode; }
                set { mode = value; }
            }
        #endregion

        #region Constructors
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="alert"></param>
            /// <param name="mode"></param>
            public Loger(List<Alert> alert, List<Mode> mode)
            {
                this.alert = alert;
                this.mode = mode;
            }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions

            /// <summary>
            /// Log structure
            /// </summary>
            /// <param name="tag"></param>
            /// <param name="currentClass"></param>
            /// <param name="content"></param>
            public void Log(String tag, Object currentClass, String content)
            {
                Log(tag + SEPARATOR + currentClass + SEPARATOR + content);
            }

            /// <summary>
            /// Alert and mode display function
            /// </summary>
            /// <param name="content"></param>
            public void Log(string content)
            {
                foreach (var item in Alert)
                {
                    switch (item)
                    {
                        case LoggerUtil.Alert.CONSOLE:
                            LogInConsole(LogType.ALERT, content);
                            break;
                        case LoggerUtil.Alert.TOAST:
                            LogToast();
                            break;
                        case LoggerUtil.Alert.MESSAGE_BOX:
                            LogMessageBox(LogType.ALERT, content);
                            break;
                        case LoggerUtil.Alert.OVERLAY:
                            break;
                        case LoggerUtil.Alert.NONE:
                            break;
                        default:
                            break;
                    }
                }

                foreach (var item in Mode)
                {
                    switch (item)
                    {
                        case LoggerUtil.Mode.CONSOLE:
                            LogInConsole(LogType.MODE, content);
                            break;
                        case LoggerUtil.Mode.EXTERNAL:
                            break;
                        case LoggerUtil.Mode.CURRENT_FOLDER:
                            LogInFolder(FOLDER, content);
                            break;
                        case LoggerUtil.Mode.TEMP_FOLDER:
                            LogInTempFolder();
                            break;
                        case LoggerUtil.Mode.NONE:
                            break;
                        default:
                            break;
                    }
                }

            }
            
            /// <summary>
            /// Write log in a temporary file
            /// </summary>
            private void LogInTempFolder()
            {

            }

            /// <summary>
            /// Pop up structure
            /// </summary>
            /// <param name="logType"></param>
            /// <param name="content"></param>
            private void LogMessageBox(LogType logType, String content)
            {
                System.Windows.MessageBox.Show(ALERT + SEPARATOR + content);
            }
            
            /// <summary>
            /// Log in console structure switch mode and alert
            /// </summary>
            /// <param name="logType"></param>
            /// <param name="content"></param>
            private void LogInConsole(LogType logType, String content)
            {

                switch (logType)
                {
                    case LogType.MODE:
                        Console.WriteLine(MODE + SEPARATOR + content);
                        break;
                    case LogType.ALERT:
                        Console.WriteLine(ALERT + SEPARATOR + content);
                        break;
                    default:
                        break;
                }

            }
            
            /// <summary>
            /// Make the toast success display
            /// </summary>
            public void LogToast()
            {
                notifier = new Notifier(cfg =>
                {
                    cfg.PositionProvider = new WindowPositionProvider(
                        parentWindow: Application.Current.MainWindow,
                        corner: Corner.BottomCenter,
                        offsetX: offsetX,
                        offsetY: offsetY);

                    cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                        notificationLifetime: TimeSpan.FromSeconds(5),
                        maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                    cfg.Dispatcher = Application.Current.Dispatcher;
                    cfg.DisplayOptions.TopMost = false;
                    cfg.DisplayOptions.Width = 250;
                });
            }

            /// <summary>
            /// Make the toast error display
            /// </summary>
            public void LogToastError()
            {
                notifier = new Notifier(cfg =>
                {
                    cfg.PositionProvider = new WindowPositionProvider(
                        parentWindow: Application.Current.MainWindow,
                        corner: Corner.BottomCenter,
                        offsetX: offsetX,
                        offsetY: offsetY - 60);

                    cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                        notificationLifetime: TimeSpan.FromSeconds(5),
                        maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                    cfg.Dispatcher = Application.Current.Dispatcher;
                    cfg.DisplayOptions.TopMost = false;
                    cfg.DisplayOptions.Width = 250;
                });
            }

            /// <summary>
            /// Dispose the toast
            /// </summary>
            public void OnUnloaded()
            {
                notifier.Dispose();
            }

            /// <summary>
            /// Display an information toast
            /// </summary>
            /// <param name="message"></param>
            public void ShowInformation(string message)
            {
                LogToast();
                notifier.ShowInformation(message);
            }

            /// <summary>
            /// Display a success toast
            /// </summary>
            /// <param name="message"></param>
            public void ShowSuccess(string message)
            {
                LogToast();
                notifier.ShowSuccess(message);
            }

            /// <summary>
            /// Clear specific toast message
            /// </summary>
            /// <param name="msg"></param>
            internal void ClearMessages(string msg)
            {
                LogToast();
                notifier.ClearMessages(msg);
            }
            
            /// <summary>
            /// Display an error toast
            /// </summary>
            /// <param name="message"></param>
            public void ShowError(string message)
            {
                LogToastError();
                notifier.ShowError(message);
            }

            /// <summary>
            /// Write log in a folder
            /// </summary>
            /// <param name="folder"></param>
            /// <param name="content"></param>
            private void LogInFolder(String folder, String content)
            {
                System.IO.StreamWriter sw = System.IO.File.AppendText(FOLDER);
            }
            #endregion

        #region Events
        #endregion







    }
}
