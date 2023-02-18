using System.Collections.Generic;

namespace Source.Serialization
{
    public interface IStorage
    {
        List<Folder> AllFolders {get;}
        void SaveFolder(Folder folderIndepe);
    }
}