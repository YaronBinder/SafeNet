using System;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace UserSide
{
    partial class Server
    {
        private class BlockingCycle
        {
            public static string hostsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts");

            /// <summary>
            /// Run a while loop to check for new blocking URLs
            /// And to apply blocking by time
            /// </summary>
            public static async void CheckFiles()
            {
                string hostsFile = File.ReadAllText(hostsPath);
                while (true)
                {
                    // if the hosts file was alternate, it will be erased and rewrite
                    if (!File.ReadAllText(hostsPath).Equals(hostsFile))
                        File.WriteAllText(hostsPath, string.Empty);

                    // directories in current directory
                    string[] directories = Directory.GetDirectories(Directory.GetCurrentDirectory());

                    // loop on each diectory
                    foreach (string directory in directories)
                    {
                        // files in the current directory
                        string[] files = Directory.GetFiles(directory);

                        // loo[ on each file
                        foreach (string file in files)
                        {
                            try
                            {
                                // using FileStream to try to open the file
                                // if the file is already opened, we continue to the catch { }
                                using FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.None);
                                // if the file isn't open, we closing it
                                stream.Close();

                                // get the content of the file as plan text
                                string list = File.ReadAllText(file);
                                // blocking list by time
                                if (file.Contains("timed"))
                                {
                                    // extrude the timing from the file
                                    string blockingTime = list.Split("|")[0].Trim();

                                    // extrude the blocking list from the file
                                    string blockingList = list.Split("|")[1].Trim();

                                    // beggining time to block
                                    DateTime startTime = new DateTime(long.Parse(blockingTime.Split('>')[0]));

                                    // end time to block
                                    DateTime endTime = new DateTime(long.Parse(blockingTime.Split('>')[1]));

                                    // format the time to get solid time such 18:35 -> 1835
                                    long now = DateTime.Now.Hour * 100 + DateTime.Now.Minute;
                                    long start = startTime.Hour * 100 + startTime.Minute;
                                    long end = endTime.Hour * 100 + endTime.Minute;

                                    // get the directory name, which is the user name
                                    string userName = Path.GetFileName(Path.GetDirectoryName(file));

                                    // normal blocking time when the start time is smaller
                                    // than the end time
                                    if (now >= start && now < end)
                                        WriteBlockingList.TextAppend(blockingList.Split("\n"));

                                    // for allow surfing instead of blocking
                                    // for instance: 16:00 to 15:00
                                    // you can surf from 15:00 to 15:59
                                    else if (now >= start && now > end && end < start)
                                        WriteBlockingList.TextAppend(blockingList.Split("\n"));

                                    // when the user surfing is into the late hours of the night
                                    // for example 20:30 to 02:30 and the now time is 00:25
                                    // the access will be blocked
                                    else if (now <= start && now < end && end < start)
                                        WriteBlockingList.TextAppend(blockingList.Split("\n"));

                                    // earse the content of the hosts file
                                    else WriteBlockingList.RemoveListFromHosts(blockingList, userName); 
                                }

                                // regular blocking list
                                else
                                {
                                    string[] fileContent = File.ReadAllLines(file);
                                    WriteBlockingList.TextAppend(fileContent);
                                }
                            }
                            catch { }
                        }
                    }

                    // in order to check if the hosts file was changed
                    // the var hostsFile get the most recent hosts file content
                    hostsFile = File.ReadAllText(hostsPath);

                    // delay the loop for 10 seconds
                    await Task.Delay(10000);
                }
            }
        }
    }
}
