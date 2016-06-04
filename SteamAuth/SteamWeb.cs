using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Http;

namespace SteamAuth
{
    public class SteamWeb
    {
        /// <summary>
        /// Perform a mobile login request
        /// </summary>
        /// <param name="url">API url</param>
        /// <param name="method">GET or POST</param>
        /// <param name="data">Name-data pairs</param>
        /// <param name="cookies">current cookie container</param>
        /// <returns>response body</returns>
        public static string MobileLoginRequest(string url, string method, Dictionary<string,string> data = null, CookieContainer cookies = null, Dictionary<string, string> headers = null)
        {
            return Request(url, method, data, cookies, headers, APIEndpoints.COMMUNITY_BASE + "/mobilelogin?oauth_client_id=DE45CD61&oauth_scope=read_profile%20write_profile%20read_client%20write_client");
        }

        public static string Request(string url, string method, Dictionary<string, string> data = null, CookieContainer cookies = null, Dictionary<string, string> headers = null, string referer = APIEndpoints.COMMUNITY_BASE)
        {
            using (HttpClientHandler handler = new HttpClientHandler() { CookieContainer = cookies, AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip })
            {
                using (HttpClient client = new HttpClient(handler) { BaseAddress = new Uri(url) })
                {
                    HttpResponseMessage resp = null;

                    HttpRequestMessage req = new HttpRequestMessage(method == "POST" ? HttpMethod.Post : HttpMethod.Get, url);
                    if (data != null && data.Any())
                    {
                        if (method != "GET")
                            try
                            {
                                req.Content = new FormUrlEncodedContent(data);  // Adding POST data
                            }
                            catch (Exception) { }
                        else
                            foreach (var _data in data)                     // If request is GET we add data to URL
                                req.RequestUri = req.RequestUri.AddQueryParameter(_data.Key, _data.Value);
                    }

                    req.Headers.UserAgent.ParseAdd("Mozilla/5.0 (Linux; U; Android 4.1.1; en-us; Google Nexus 4 - 4.1.1 - API 16 - 768x1280 Build/JRO03S) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30");

                    try
                    {
                        var task = Task.Run( async () => await client.SendAsync(req) );
                        task.Wait();
                        resp = task.Result;
                    }
                    catch (Exception) { }
                    if (resp == null)
                        return null;
                    var taskread = Task.Run(async () => await resp.Content.ReadAsStringAsync());
                    taskread.Wait();
                    return taskread.Result;
                }
            }
        }
        public static async Task<string> RequestAsync(string url, string method, Dictionary<string, string> data = null, CookieContainer cookies = null, Dictionary<string, string> headers = null, string referer = APIEndpoints.COMMUNITY_BASE)
        {
            using (HttpClientHandler handler = new HttpClientHandler() { CookieContainer = cookies, AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip })
            {
                using (HttpClient client = new HttpClient(handler) { BaseAddress = new Uri(url) })
                {
                    HttpResponseMessage resp = null;

                    HttpRequestMessage req = new HttpRequestMessage(method == "POST" ? HttpMethod.Post : HttpMethod.Get, url);
                    if (data != null && data.Any())
                    {
                        if (method != "Get")
                            try
                            {
                                req.Content = new FormUrlEncodedContent(data);  // Adding POST data
                            }
                            catch (Exception) { }
                        else
                            foreach (var _data in data)                     // If request is GET we add data to URL
                                req.RequestUri = req.RequestUri.AddQueryParameter(_data.Key, _data.Value);
                    }

                    req.Headers.UserAgent.ParseAdd("Mozilla/5.0 (Linux; U; Android 4.1.1; en-us; Google Nexus 4 - 4.1.1 - API 16 - 768x1280 Build/JRO03S) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30");

                    try
                    {
                        resp = await client.SendAsync(req).ConfigureAwait(false);
                    }
                    catch (Exception) { }
                    return await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
            }
        }
    }
    public static class UriExtensions
    {
        public static Uri AddQueryParameter(this Uri uri, string name, object value)
        {
            var builder = new UriBuilder(uri);
            if (builder.Query != null && builder.Query.Length > 1)
            {
                builder.Query = string.Format("{0}&{1}={2}", builder.Query.Substring(1), name, value);
            }
            else
            {
                builder.Query = string.Format("{0}={1}", name, value);
            }
            return builder.Uri;
        }
    }
}
