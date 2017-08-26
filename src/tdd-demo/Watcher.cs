using System;

namespace tdd_demo
{
    public class Watcher
    {
        public virtual bool IsImplementationFile(string filename) {
            return !filename.Contains("Test");
        }

        public virtual string FindAssociatedTestFile(string filename) {
            var fileInfo = new System.IO.FileInfo(filename);
            return $"{fileInfo.BaseName()}.Tests.cs";
        }

        public void OnFileChanged(string fileName) 
        {
            string testFile = fileName;
            if (IsImplementationFile(fileName)) 
            {
                testFile = FindAssociatedTestFile(fileName);
            }
            RunTests(testFile);
        }

        public virtual void RunTests(string fileName) 
        {

        }
    }
}
