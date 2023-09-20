using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadMeneger 
{
    public static MainSave Load()
    {
        if(!FilePath.Exist(FilePath.FullPath(Constants.SAVE_FILE)))
            return new MainSave();
        
        string json = File.ReadAllText(FilePath.FullPath( Constants.SAVE_FILE));
        MainSave myObject = JsonUtility.FromJson<MainSave>(json);
        return myObject;
    }
}
