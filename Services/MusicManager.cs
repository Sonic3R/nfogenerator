﻿using System;
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
            var serverUri = new Uri(_ftpAddress.TrimEnd('/') + "/" + folder.Trim('/'));

            // The serverUri should start with the ftp:// scheme.
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return null;
            }

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.EnableSsl = true;
            request.Credentials = new NetworkCredential(_ftpUser, _ftpPass);

            // Get the ServicePoint object used for this request, and limit it to one connection.
            // In a real-world application you might use the default number of connections (2),
            // or select a value that works best for your application.

            ServicePoint sp = request.ServicePoint;
            sp.ConnectionLimit = 1;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("The content length is {0}", response.ContentLength);
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
    }
}
