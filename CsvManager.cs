using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TextTowerProject
{
    public interface ICvsManager
    {
        void PushText(string text);
        string PopText();
        void ClearText();
    }

    public class CvsManager : ICvsManager
    {
        private dynamic _count;
        private string _documentFolderPath;
        private string _path;

        public CvsManager()
        {
            this._count = "";
            this._documentFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this._path = this._documentFolderPath + @"\TextTower.csv";

            while (File.Exists(this._path))
            {
                if (this._count.GetType().Equals(typeof(System.String)))
                    this._count = 2;
                else
                    this._count++;
                
                this._path = this._documentFolderPath + string.Format(@"\TextTower{0}.csv", this._count);
            }
        }

        public void PushText(string text)
        {
            List<string> textLines = new List<string>() {text};
            File.AppendAllLines(this._path, textLines);
        }

        public string PopText()
        {
            List<string> lines = File.ReadAllLines(this._path).ToList();
            int lastLine = lines.Count - 1;
            string removed = lines[lastLine];
            
            lines.RemoveAt(lastLine);
            File.WriteAllLines(this._path, lines.ToArray());

            return removed;
        }

        public void ClearText()
        {
            string[] lines = new string[] {""};
            File.WriteAllLines(this._path, lines);
        }
    }
}