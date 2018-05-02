using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public Loger(List<Alert> alert, List<Mode> mode)
            {
                this.alert = alert;
                this.mode = mode;
            }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
            public void Log(String tag, Object currentClass, String content)
            {
                Log(tag + SEPARATOR + currentClass + SEPARATOR + content);
            }

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

            private void LogInTempFolder()
            {

            }

            private void LogMessageBox(LogType logType, String content)
            {
                System.Windows.MessageBox.Show(ALERT + SEPARATOR + content);
            }

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

            private void LogToast()
            {


            }

            private void LogInFolder(String folder, String content)
            {
                System.IO.StreamWriter sw = System.IO.File.AppendText(FOLDER);
            }
        #endregion

        #region Events
        #endregion







    }
}
