using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assets.Source.Extension
{
    public static class HttpContentExtensions
    {
        public static Task ReadAsFileAsync(this HttpContent content, string filePath, bool overwrite)
        {
            //string pathname = Path.GetFullPath(filename);
            if (!overwrite && File.Exists(filePath))
            {
                throw new InvalidOperationException(string.Format("File {0} already exists.", filePath));
            }

            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
                return content.CopyToAsync(fileStream).ContinueWith(
                    (copyTask) =>
                    {
                        fileStream.Close();
                    });
            }
            catch
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }

                throw;
            }
        }
    }
}
