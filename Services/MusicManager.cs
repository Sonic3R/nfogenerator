using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MusicManager
    {
        private const string _ftpAddress = "ftp://nl3572.dediseedbox.com/";
        private const string _ftpUser = "Sonic3R";
        private const string _ftpPass = "Pascal123_";

        public static string Load(string folder = "")
        {
            FtpWebResponse response = GetResponseFromFtp(folder, WebRequestMethods.Ftp.ListDirectory);

            // The following streams are used to read the data returned from the server.
            Stream responseStream = null;
            StreamReader readStream = null;
            try
            {
                responseStream = response.GetResponseStream();
                readStream = new StreamReader(responseStream, System.Text.Encoding.UTF8);

                if (readStream != null)
                {
                    // Display the data received from the server.
                    return readStream.ReadToEnd();
                }

                return null;
            }
            finally
            {
                if (readStream != null)
                {
                    readStream.Close();
                }

                if (response != null)
                {
                    response.Close();
                }
            }
        }

        public static void DownloadFile(string path)
        {
            FtpWebResponse response = GetResponseFromFtp(path, WebRequestMethods.Ftp.DownloadFile);

            // The following streams are used to read the data returned from the server.
            Stream responseStream = null;
            Stream fileStream = null;
            try
            {
                responseStream = response.GetResponseStream();
                fileStream = File.Create(@"D:\Downloads\" + Path.GetFileName(path));

                if (fileStream != null)
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, read);
                    }
                }
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }

                if (response != null)
                {
                    response.Close();
                }
            }
        }

        /// <summary>
        /// Gets the response from FTP.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private static FtpWebResponse GetResponseFromFtp(string path, string ftpMode)
        {
            var serverUri = new Uri(_ftpAddress.TrimEnd('/') + "/" + path.Trim('/'));

            // The serverUri should start with the ftp:// scheme.
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return null;
            }

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Method = ftpMode;
            request.EnableSsl = true;
            request.Credentials = new NetworkCredential(_ftpUser, _ftpPass);

            // Get the ServicePoint object used for this request, and limit it to one connection.
            // In a real-world application you might use the default number of connections (2),
            // or select a value that works best for your application.

            ServicePoint sp = request.ServicePoint;
            sp.ConnectionLimit = 1;

            return (FtpWebResponse)request.GetResponse();
        }
    }
}
