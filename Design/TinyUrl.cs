using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal.Design
{
    public class TinyUrl
    {
        // https://leetcode.com/discuss/interview-question/124658/Design-a-URL-Shortener-(-TinyURL-)-System/

        String alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Dictionary<String, String> map = new Dictionary<string, string>();
        Random rand = new Random();
        String key = null;

        public String getRand()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                sb.Append(alphabet[(rand.Next(62))]);
            }
            return sb.ToString();
        }

        public String encode(String longUrl)
        {
            // Key should be generate until found
            while (key == null || map.Keys.Contains(key))
            {
                key = getRand();
            }

            map.Add(key, longUrl);
            return "http://tinyurl.com/" + key;
        }

        public string decode(string shortUrl)
        {
            return map[(shortUrl.Replace("http://tinyurl.com/", ""))];
        }


        // Not required here but to convert integer into Base62
       public string idToShortURL(int n)
        {
            // Map to store 62 possible characters
            char[] map = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

            string shorturl = string.Empty;

            // Convert given integer id to a base 62 number
            while (n >0)
            {
                shorturl +=(map[n % 62]);
                n = n / 62;
            }

            // Reverse shortURL to complete base conversion
            

            return new string(shorturl.Reverse().ToArray());
        }

    }
}
