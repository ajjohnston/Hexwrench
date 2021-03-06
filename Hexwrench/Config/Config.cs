﻿using System;
using System.Collections.Generic;
using PCLStorage;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Hexwrench
{
    public class Config
    {
        public static Config Instance = new Config();

        private string filePath;
        private Dictionary<string, string> fileContents;
        private Config() { }

        public void Initialize(string path, int pollSeconds = 0)
        {
            filePath = path;
            readFile();
            if (pollSeconds > 0)
            {
                new System.Threading.Timer((e) => {
                    readFile();
                }, null, 0, (int)(TimeSpan.FromSeconds(pollSeconds).TotalMilliseconds));
            }
        }

        private void readFile()
        {
            try
            {
                IFolder localStorage = FileSystem.Current.LocalStorage;
                IFile file = localStorage.GetFileAsync(filePath).Result;
                string text = file.ReadAllTextAsync().Result;
                fileContents = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
            }
            catch (Exception)
            {
                fileContents = null;
            }
        }

        public string Get(string key)
        {
            if (fileContents != null)
            {
                string value;
                if (!fileContents.TryGetValue(key, out value))
                {
                    value = "";
                }
                return value;
            }
            else
            {
                return "";
            }
        }
    }
}
