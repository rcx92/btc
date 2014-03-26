using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Btcchina
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            publicK.Text = "d48f1a78-a10d-4a9e-a16c-90ecbf5ef581";
        }

        string accessKey = "";
        string secretKey = "";
        string method;
        string param;
        string param2;
        string id;
        bool buyed;
        private string buy(double price)
        {
            method = "buyOrder2";
            id = "1";
            param = price.ToString("f2") + ",20,CNYLTC";
            param2 = price.ToString("f2") + ",20,\"CNYLTC\"";
            return run();
        }

        private string sell(double price)
        {
            method = "sellOrder2";
            id = "1";
            param = price.ToString("f2") + ",25,CNYLTC";
            param2 = price.ToString("f2") + ",25,\"CNYLTC\"";
            return run();
        }

        private bool cancel(int id)
        {
            //method = "cancelOrder";
            //id.param = id.ToString();
            return false;
        }

        private void work()
        {
            buyed = false;
            /*while (!stop)
            {
                double price = getPrice(0);
                Console.WriteLine(price);
                if (price < 97.56)
                {
                    buyed = true;
                    buy(price + 0.00);
                    break;
                }
                Thread.Sleep(5000);
            }*/

            while (!stop)
            {
                try
                {
                    double price = getPrice(1);
                    if (price > 105.00)
                    {
                        sell(price - 0.05);
                        return;
                    }
                    Console.WriteLine("running");
                    Thread.Sleep(5000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        private double getPrice(int x)
        {

            WebRequest request = WebRequest.Create("https://data.btcchina.com/data/ticker?market=cnyltc");

            request.Method = "GET";
            WebResponse response = request.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream());

            string responseData = responseReader.ReadToEnd();
            responseReader.Close();
            response.Close();
            //data2 = new ResponseData();
            ResponseData data2 = JSON.parse<ResponseData>(responseData);
            buyBox.Text = data2.ticker.buy.ToString();
            sellBox.Text = data2.ticker.sell.ToString();
            if (x == 0) return data2.ticker.sell;
            else
                return data2.ticker.buy;
        }



        private string run()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            // Enter your personal API access key and secret here
            TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1);
            long milliSeconds = Convert.ToInt64(timeSpan.TotalMilliseconds * 1000);
            string tonce = Convert.ToString(milliSeconds);
            NameValueCollection parameters = new NameValueCollection() { 
                { "tonce", tonce },
                { "accesskey", accessKey },
                { "requestmethod", "post" },
                { "id", id },
                { "method", method },
                { "params", param }
            };
            string paramsHash = GetHMACSHA1Hash(secretKey, BuildQueryString(parameters));
            string base64String = Convert.ToBase64String(
                Encoding.ASCII.GetBytes(accessKey + ':' + paramsHash));
            string url = "https://api.btcchina.com/api_trade_v1.php";
            string postData = "{\"method\": \"" + method + "\", \"params\": [" + param2 + "], \"id\": " + id + "}";

            string result = SendPostByWebRequest(url, base64String, tonce, postData);
            return result;
        }



        public static string SendPostByWebRequest(string url, string base64,
                                                string tonce, string postData)
        {
            WebRequest webRequest = WebRequest.Create(url);
            if (webRequest == null)
            {
                Console.WriteLine("Failed to create web request for url: " + url);
                return "";
            }

            byte[] bytes = Encoding.ASCII.GetBytes(postData);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json-rpc";
            webRequest.ContentLength = bytes.Length;
            webRequest.Headers["Authorization"] = "Basic " + base64;
            webRequest.Headers["Json-Rpc-Tonce"] = tonce;
            try
            {
                // Send the json authentication post request
                using (Stream dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(bytes, 0, bytes.Length);
                    dataStream.Close();
                }
                // Get authentication response
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }

        private static string BuildQueryString(NameValueCollection parameters)
        {
            List<string> keyValues = new List<string>();
            foreach (string key in parameters)
            {
                keyValues.Add(key + "=" + parameters[key]);
            }
            return String.Join("&", keyValues.ToArray());
        }

        private static string GetHMACSHA1Hash(string secret_key, string input)
        {
            HMACSHA1 hmacsha1 = new HMACSHA1(Encoding.ASCII.GetBytes(secret_key));
            MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(input));
            byte[] hashData = hmacsha1.ComputeHash(stream);

            // Format as hexadecimal string.
            StringBuilder hashBuilder = new StringBuilder();
            foreach (byte data in hashData)
            {
                hashBuilder.Append(data.ToString("x2"));
            }
            return hashBuilder.ToString();
        }
        private volatile bool stop = true;
        private void Begin_Click(object sender, EventArgs e)
        {
            if (stop)
            {
                stop = false;
                accessKey = publicK.Text;
                secretKey = secretK.Text;
                Thread workerThread = new Thread(work);
                workerThread.Start();
            }
        }

        private void end_Click(object sender, EventArgs e)
        {
            stop = true;
        }
    }
}
