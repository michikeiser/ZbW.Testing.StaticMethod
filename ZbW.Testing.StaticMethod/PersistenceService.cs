namespace ZbW.Testing.StaticMethod
{
    using System;

    internal class PersistenceService
    {
        public PersistenceService()
        {
            File = new FileTestable();
        }

        internal FileTestable File { private get; set; }

        public void MoveFile(string sourcePath, string targetPath)
        {
            try
            {
                File.Move(sourcePath, targetPath);
            }
            catch (Exception e)
            {
                throw new CouldNotMoveFileException("Das System konnte das File nicht verschieben.", e);
            }
        }
    }
}