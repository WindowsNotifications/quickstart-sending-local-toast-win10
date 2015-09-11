using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using Windows.Foundation;

namespace ClassLibrary
{
    [DataContract]
    public class MyArguments : Dictionary<string, string>
    {
        public string SerializeToString()
        {
            return string.Join("&", this.Select(pair => UrlEncode(pair.Key) + "=" + UrlEncode(pair.Value)));
        }

        private static string UrlEncode(string str)
        {
            return WebUtility.UrlEncode(str);
            
            // Alternatively, Uri.EscapeDataString(str).Replace("%20", "+") can be used if WebUtility isn't available
        }

        public static MyArguments Deserialize(string args)
        {
            var decoder = new WwwFormUrlDecoder(args);

            MyArguments answer = new MyArguments();

            foreach (var pair in decoder)
            {
                answer[pair.Name] = pair.Value;
            }

            return answer;
        }
    }
}
