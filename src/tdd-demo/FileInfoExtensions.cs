using System;

namespace tdd_demo
{
    public static class FileInfoExtensions
    {
        public static string BaseName(this System.IO.FileInfo fileInfo) 
        {
            var charCount = fileInfo.Name.Length - fileInfo.Extension.Length;
            var result = fileInfo.Name.Substring(0, charCount);
            return result;
        }
    }
}