using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RobloxPlayerBot
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("Cookies.txt")) {
                Console.WriteLine("Unable To Find Cookies.txt, Make Sure You Have A File Called Cookies.txt, where you have all your cookies on each line");
                Console.Read();
                return;
            }


            System.Net.WebClient wb = new System.Net.WebClient();
            Console.WriteLine("Make SUre To Run https://wearedevs.net/d/Multiple%20RBX%20Games");
            Console.WriteLine("Get Free Robux At https://bloxbux.net");
            Console.WriteLine("Enter You Wait Time Before opening the next roblox game - in seconds: ");

            string inputt = Console.ReadLine();
            int AA = Convert.ToInt32(inputt + "000");

            Console.WriteLine(AA);

            Console.WriteLine("Enter Your Place ID: ");

            string input = Console.ReadLine();

            
            new Thread(() =>
            {
                using (FileStream fileStream = File.OpenRead("Cookies.txt"))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
                    {

                        string linee;
                        while ((linee = streamReader.ReadLine()) != null)
                        {
                            Thread.Sleep(AA);

                            string Cookie = ".ROBLOSECURITY=" + linee;
                            wb.Headers["Cookie"] = Cookie;
                            wb.Headers["User-Agent"] = "Roblox/WinInet";
                            wb.Headers["Referer"] = "https://www.roblox.com/develop";
                            wb.Headers["RBX-For-Gameauth"] = "true";
                            string auth_ticket = wb.DownloadString("https://www.roblox.com/game-auth/getauthticket");

                            WebClient wbb = new WebClient();

                            wbb.Headers["Cookie"] = Cookie;
                            if (wbb.DownloadString("http://www.roblox.com/mobileapi/userinfo").Contains("ThumbnailUrl"))
                            {
                                JsonReader Reader = JsonConvert.DeserializeObject<JsonReader>(wbb.DownloadString("http://www.roblox.com/mobileapi/userinfo"));
                                Console.WriteLine("Joining Game With " + Reader.UserName);
                                Random rn = new Random();
                                int Randomm = rn.Next(1000000, 10000000);
                                string url = "roblox-player:1+launchmode:play+gameinfo:" + auth_ticket + "+launchtime:" + Randomm + "+placelauncherurl:https%3A%2F%2Fassetgame.roblox.com%2Fgame%2FPlaceLauncher.ashx%3Frequest%3DRequestGame%26browserTrackerId%3D" + Randomm + "%26placeId%3D" + input + "%26isPlayTogetherGame%3Dfalse+browsertrackerid:" + Randomm + "+robloxLocale:en_us+gameLocale:en_us";
                                System.Diagnostics.Process.Start(url);
                            }
                            else
                            {
                                Console.WriteLine("Failed To Join Game");
                            }
                        }
                    }
                }
            }).Start();
        }
    }
}
