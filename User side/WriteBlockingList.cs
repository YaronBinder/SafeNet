using System;
using System.IO;

namespace UserSide
{
    partial class Server
    {
        private class WriteBlockingList
        {
            private const string localIP = "\n" + "127.0.0.1 ";
            private static readonly string hostsPath = Path.Combine(
                                                        Environment.GetFolderPath(
                                                        Environment.SpecialFolder.System), 
                                                        @"drivers\etc\hosts");

            /// <summary>
            /// Write and execute CMD commands
            /// </summary>
            /// <param name="list">List of the URLs to block</param>
            public static void Write(string list)
            {
                // prevent of creating new directory for commands
                if (list.Length > 5)
                {
                    string user = list.Split("|")[0].Trim();
                    string currentDirectory = Directory.GetCurrentDirectory() + "\\" + user;
                    if (!Directory.Exists(currentDirectory))
                        Directory.CreateDirectory(currentDirectory).Attributes |= FileAttributes.Hidden;

                    // if the manager want to clear the blocking list
                    if (list.Contains("clear"))
                    {
                        string blockingPath = currentDirectory +
                            $"\\{(list.Contains("timed") ? "timed " : "")}blocking list.txt";
                        string blockingList = File.ReadAllText(blockingPath).Trim();
                        RemoveListFromHosts(blockingList, user);
                        File.WriteAllText(blockingPath, string.Empty.Trim());
                    }

                    // if the manager want to create timed blocking list
                    else if (list.Contains('>'))
                    {
                        string time = list.Split("|")[1].Trim();
                        string[] blockingList = list.Split("|")[2].Trim().Split("\n");
                        string formatedList = FormatedList(blockingList, user);
                        string completeFile = time + "|\n" + formatedList;
                        File.WriteAllText(currentDirectory + "\\timed blocking list.txt", completeFile.Trim());
                    }

                    // if the manager want to write new blocking list
                    else
                    {
                        string[] blockingList = list.Split("|")[1].Trim().Split("\n");
                        string formatedList = FormatedList(blockingList, user).Trim();
                        File.WriteAllText(currentDirectory + "\\blocking list.txt", formatedList);
                        TextAppend(formatedList.Split("\n"));
                    }
                }

                // restart the computer after 3 second
                if (list == "rst")
                    RunCommand("shutdown /r /t 30");

                // force restart the computer after 3 second
                else if (list == "frst")
                    RunCommand("shutdown /r /f");

                // lock compiter
                else if (list == "lock")
                    RunCommand("rundll32.exe user32.dll,LockWorkStation");

                // turn off the computer
                else if (list == "off")
                    RunCommand("shutdown /s /t 15");

                // abort any action / command
                else if (list == "abort")
                    RunCommand("shutdown /a");
                
            }

            /// <summary>
            /// Remove lines from a hosts file, given that the user name is exist in it
            /// And given the lines exist in the blocking list file
            /// </summary>
            /// <param name="list">The reference list to remove lines from the hosts file</param>
            /// <param name="user">The name of the user that want to remove their lines</param>
            public static void RemoveListFromHosts(string list, string user)
            {
                string hostsFile = File.ReadAllText(hostsPath);
                foreach (string line in hostsFile.Split("\n"))
                    foreach (string url in list.Split("\n"))
                        if (line == url && line.Contains(user))
                            hostsFile = hostsFile.Replace(url, string.Empty.Trim());
                File.WriteAllText(hostsPath, hostsFile.Trim());
            }

            /// <summary>
            ///Format the list to all the conventional ways to write
            ///successful url to block in the host file
            /// </summary>
            /// <param name="list">The list to be formatted</param>
            /// <param name="user">The name of the user that want to format the lines</param>
            /// <returns>Complete and trim formatted list</returns>
            public static string FormatedList(string[] list, string user)
            {
                string wholeText = "";
                foreach (string line in list)
                {
                    wholeText += localIP + line + $" #{user}";
                    if (line.Contains("http://"))
                        wholeText += localIP + line.Split("http://")[1] + $" #{user}";
                    if (line.Contains("https://"))
                        wholeText += localIP + line.Split("https://")[1] + $" #{user}";
                    if (line.Contains("www."))
                        wholeText += localIP + line.Split("www.")[1] + $" #{user}";
                }
                return wholeText.Trim();
            }

            /// <summary>
            /// Append lines from a string array
            /// Given the lines isn't already in the hosts file
            /// </summary>
            /// <param name="blockingList">List of URLs to add to the hosts file</param>
            public static void TextAppend(string[] blockingList)
            {
                string[] hostsFile = File.ReadAllLines(hostsPath);
                foreach (string line in blockingList)
                {
                    bool isExist = false;
                    foreach (string host in hostsFile)
                    {
                        if (host == line) { isExist = true; break; }
                    }
                    if (!isExist && line.Length > 1)
                    {
                        File.AppendAllText(hostsPath, "\n" + line.Trim());
                    }
                }
            }
        }
    }
}
