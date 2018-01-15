using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Timers;

namespace Logger
{


    public class FileCompare : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            FileInfo fi1 = x as FileInfo;
            FileInfo fi2 = y as FileInfo;
            return fi1.LastWriteTime.CompareTo(fi2.LastWriteTime);
        }
    }

    public enum LogType
    {
        NOTUSE,
        ERROR,
        WARRING,
        DEBUG,
        INFO
    }

    public class LoggerClass
    {
        private static Object fileLock = new Object();   //for thread-sync,the object MUST be "private static object",or it will cause interlock or lock failure.
        private static System.Timers.Timer fileWriterTimer = null;
        private Queue<string> m_strLogMsg = new Queue<string>(); 
        private static bool bLog = false;
        private static string logDir = @".\\Log";
        private static string logFilename = "ECS.Log";
        StreamWriter sr = null;
        private static uint logFileCount = 30;

        private static LoggerClass __logger = null;

        public static LoggerClass Inst()
        {
            if (__logger == null)
            {
                __logger = new LoggerClass(true);
            }
            return __logger;
        }


        public LoggerClass(bool isLogger)
        {  
            bLog = isLogger;
            if(isLogger)
            {
                fileWriterTimer = new System.Timers.Timer(1000);
                InitialfileWtrierTimer();
            }
        }

        public void InitialfileWtrierTimer()
        {
            fileWriterTimer.Elapsed += new System.Timers.ElapsedEventHandler(fileWriteThread);
            fileWriterTimer.AutoReset = true;
            fileWriterTimer.Enabled = true;
        }

        public void WriteFile(string funcName, LogType logType, string Desc)
        {
            if (!bLog)
                return;
            lock (fileLock)
            {
                StringBuilder strLogMsg = new StringBuilder();
                strLogMsg.Append(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                strLogMsg.Append("   ");
                strLogMsg.Append(funcName);
                strLogMsg.Append("   ");
                strLogMsg.Append(Desc);
                strLogMsg.AppendLine();
                m_strLogMsg.Enqueue(strLogMsg.ToString());
                strLogMsg.Remove(0, strLogMsg.Length);
                strLogMsg = null;
            }
        }

        /// <summary>
        /// 验证当前要操作的日志文件是否存在，并返回完整的路径。
        /// </summary>
        /// <param name="logFileCompletePath">返回要操作的日志文件完整路径</param>
        /// <returns>存在返回True，不存在返回False</returns>
        public static bool LogFileExists(out string logFileCompletePath)
        {
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);

            DirectoryInfo di = new DirectoryInfo(logDir);
            string strFilter = "*.log";
            FileInfo[] files = di.GetFiles(strFilter);
            int filesCount = files.Length;

            if (filesCount >= logFileCount)
            {
                FileCompare fc = new FileCompare();
                Array.Sort(files, fc);
                int i = 0;
                while (filesCount-- >= logFileCount)
                {
                   files[i].Delete();
                    i++;
                }
            }
            logFileCompletePath = string.Format(@"{0}\{1}", logDir, logFilename);

            if (System.IO.File.Exists(logFileCompletePath))
                return true;
            else
                return false;
        }

        public void fileWriteThread(object source, System.Timers.ElapsedEventArgs e)
        {
            fileWriterTimer.Enabled = false;
            string logFilePath = string.Empty;
            try
            {
                if (LogFileExists(out logFilePath))
                    sr = System.IO.File.AppendText(logFilePath);
                else
                    using (sr = System.IO.File.CreateText(logFilePath))
                    {
                        sr.WriteLine("Log Created Date:" + "  " + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                FileInfo curFileInfo = new FileInfo(logFilePath);
                if (curFileInfo.Length > 1024 * 1024 * 30 )
                {
                    if (sr != null)
                        sr.Close();

                    File.Move(logFilePath, logDir + "\\" + "FA " + System.DateTime.Now.ToString("yyyyMMdd HHmmss") + ".log");

                    using (sr = File.CreateText(logFilePath))
                    {
                        sr.WriteLine("Log Created Date:" + "  " + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                }
                lock (fileLock)
                {
                    for (int i = 0; i < m_strLogMsg.Count && i < 200; i++)
                    {
                        sr.Write(m_strLogMsg.Dequeue());  //Write log message
                    }
                }
            }
            catch { }
            finally
            {
                if (sr != null)
                {
                    try
                    {
                        sr.Close();
                    }
                    catch (System.Exception ex)
                    {
                    	
                    }
                   
                    sr = null;
                    fileWriterTimer.Enabled = true;

                }
            }
        }

        public void WriteExceptionLog(System.Exception ex, string personInfo)
        {
            try
            {
                string body = "UnhandledException:\n";
                body +=
                "Message: \n" + ex.Message + "\n\n" +
                "Data: \n" + ex.Data + "\n\n" +
                "Call Stack: \n" + ex.StackTrace + "\n\n" +
                "Source: \n" + ex.Source;
                WriteFile("[LinkECS] Error Happened ", LogType.ERROR, body);
                if (personInfo.Length != 0)
                {
                    WriteFile("[LinkECS] Error Happened ", LogType.ERROR, personInfo);
                }
            }
            catch (System.Exception e)
            {
                return;
            }

        }
     }
}