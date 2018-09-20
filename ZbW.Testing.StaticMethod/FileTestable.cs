namespace ZbW.Testing.StaticMethod
{
    using System.IO;

    internal class FileTestable
    {
        public virtual void Move(string sourceFileName, string destFileName)
        {
            File.Move(sourceFileName, destFileName);
        }
    }
}