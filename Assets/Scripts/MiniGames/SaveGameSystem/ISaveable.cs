using System.Collections.Generic;

namespace SaveGame
{
    public interface ISaveable
    {
        Dictionary<string, object> GetDataForSave();
        void LoadData(Dictionary<string, object> savedData);
    }
}