using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PagesAndFaceEvaluator
{
    public static class ConfigHelper
    {
        public enum ConfigKey
        {
            LastPath, AID, WholeTime
        }

        public static string GetValue(string key)
        {
            bool mistake = false;
            try {

                string[] lines = System.IO.File.ReadAllLines("settings.config");

                switch (key)
                {
                    case "AID":
                            return GetValueFromLine(lines[0]);
                    case "LastPath":
                        {
                            return GetValueFromLine(lines[1]);
                        }
                    case "WholeTime":
                        {
                            return GetValueFromLine(lines[2]);
                        }
                    default:
                        {
                            mistake = true;
                            break;
                        }
                }
            }
            catch
            {
                mistake = true;
            }

            if (mistake)
            {
                 MessageBox.Show("Nepodarilo sa prečítať config súbor", "Chyba");
            }
            return null;
        }

        private static string GetValueFromLine(string line)
        {
            string[] parts = line.Split(':');
            if (parts.Length == 2)
                return parts[1];
            else
                return null;
        }

        private static string ChangeValueInLine(string line, string value)
        {
            string[] parts = line.Split(':');
            if (parts.Length == 2)
            {
                parts[1] = value;
                string response = parts[0] + ":" + parts[1];
                return response;
            }
            else
                return null;
        }

        public static bool ChangeValue(string key, string newValue)
        {
            bool mistake = false;

            string[] lines = System.IO.File.ReadAllLines("settings.config");
            
            switch (key)
            {
                case "AID":
                    {
                        string line = ChangeValueInLine(lines[0], newValue);
                        if (line == null)
                            mistake = true;
                        else
                            lines[0] = line;
                        break;
                    }
                case "LastPath":
                    {
                        string line = ChangeValueInLine(lines[1], newValue);
                        if (line == null)
                            mistake = true;
                        else
                            lines[1] = line;
                        break;
                    }
                case "WholeTime":
                    {
                        string line = ChangeValueInLine(lines[2], newValue);
                        if (line == null)
                            mistake = true;
                        else
                            lines[2] = line;
                        break;
                    }
                default:
                    {
                        mistake = true;
                        break;
                    }
            }

            if (mistake)
            {
                MessageBox.Show("Nepodarilo sa prečítať config súbor", "Chyba");
                return false;
            }
            else
            {
                try
                {
                    System.IO.File.WriteAllLines("settings.config", lines);
                    return true;
                }
                catch {
                    MessageBox.Show("Nepodarilo sa zmeniť hodnotu v konfiguračnom súbore", "Chyba");
                    return false;
                }
            }
        }
    }
}
