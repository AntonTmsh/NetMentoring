using System;
using System.IO;

namespace Epam.NetMentoring.Disposable
{
    public class MemoryStreamLogger: IDisposable 
    {
        private FileStream memoryStream;
        private StreamWriter streamWriter;

        public MemoryStreamLogger()
        {
            memoryStream = new FileStream(@"\log.txt", FileMode.OpenOrCreate);
            streamWriter = new StreamWriter(memoryStream);
        }

        public void Log(string message)
        {
            streamWriter.Write(message);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (memoryStream != null) memoryStream.Dispose();
                if (streamWriter != null) streamWriter.Dispose();
            }
        }

    }
}