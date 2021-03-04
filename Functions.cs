using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ProjectGenerator.data;
using System.Collections.Generic;

namespace ProjectGenerator
{
    public static class Functions
    {
        public static Projects[] GetDataJSON()
        {
            return JsonConvert.DeserializeObject<List<Projects>>(ReadFile(@"data\projects.json")).ToArray();
        }

        public static Projects[] GetDefDataJSON()
        {
            return JsonConvert.DeserializeObject<List<Projects>>(ReadFile(@"data\projects_def.json")).ToArray();
        }

        public static void SaveDataJSON(List<Projects> data)
        {
            string json = JsonConvert.SerializeObject(data.ToArray(), Formatting.Indented);
            File.WriteAllText(GetDir() + @"\data\projects.json", json);
        }

        public static string ReadFile(string furl)
        {
            try
            {
                using (StreamReader strreader = new StreamReader(GetDir() + @"\" + furl))
                {
                    return strreader.ReadToEnd();
                }

                // return File.ReadAllText(GetDir() + @"\" + furl);
            } 
            catch (FileNotFoundException e)
            {
                return e.Message;
            }
        }

        public static async Task<string> ReadFileAsync(string furl)
        {
            try
            {
                using (StreamReader strreader = new StreamReader(GetDir() + @"\" + furl))
                {
                    return await strreader.ReadToEndAsync();
                }
            }
            catch (FileNotFoundException e)
            {
                return e.Message;
            }
        }

        public static void ExecuteFile(string furl, string wdir)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = furl;
            proc.StartInfo.WorkingDirectory = wdir;
            proc.StartInfo.Verb = "runas";
            //proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }

        public static string GetDir()
        {
            return @"C:\Users\Luis\Documents\Visual Studio 2019\Projects\ProjectGenerator";
            //return Path.GetDirectoryName(Application.ExecutablePath);
            //return Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        }

        public static void StartScript(string filename)
        {
            var dirscr = GetDir() + @"\scripts\";
            var filescr = dirscr + filename;

            if(File.Exists(filescr))
            {
                ExecuteFile(filescr, dirscr);
            }
            else
            {
                MessageBox.Show(string.Format("File {0} not found, pls locate it.", filescr));
            }
        }

        public static void ViewDoc(string url)
        {
            FormViewDoc fvd = new FormViewDoc(url);
            fvd.Show();
        }

        public static string GetIcon(string cboitem)
        {
            string ico;
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string curpth = Path.GetFullPath(Path.Combine(RunningPath, @"..\..\"));

            if (cboitem.Contains("Blazor"))
            {
                ico = @"/Resources/icons/blazor.ico";
            }
            else if (cboitem.Contains("ASP NET Core"))
            {
                if (cboitem.Contains("Angular"))
                {
                    ico = @"/Resources/icons/aspnetcoreangular.ico";
                }
                else
                {
                    ico = @"/Resources/icons/aspnetcore.ico";
                }
            }
            else if (cboitem.Contains("Console"))
            {
                ico = @"/Resources/icons/consoleapp.ico";
            }
            else if (cboitem.Contains("Angular"))
            {
                ico = @"/Resources/icons/angular.ico";
            }
            else if (cboitem.Contains("React"))
            {
                ico = @"/Resources/icons/react.ico";
            }
            else if (cboitem.Contains("Vue"))
            {
                ico = @"/Resources/icons/vuejs.ico";
            }
            else if (cboitem.Contains("NativeScript"))
            {
                ico = @"/Resources/icons/nativescript.ico";
            }
            else if (cboitem.Contains("Flutter"))
            {
                ico = @"/Resources/icons/flutter.ico";
            }
            else
            {
                ico = @"/Resources/icons/winformsapp.ico";
            }

            return curpth + ico;
        }
    }
}
