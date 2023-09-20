using System.IO;
using UnityEngine;

public class SaveMeneger
{

    public static void SetNewSave(MainSave main)
    {
        Save(main);
    }
    public static void AddToSave(MainSave main)
    {
        MainSave myObject = LoadMeneger.Load();
        myObject += main;
        Save(myObject);
    }
    private static void Save(MainSave main)
    {
      
        string json = JsonUtility.ToJson(main, true);
        File.WriteAllText(FilePath.FullPath(Constants.SAVE_FILE), json);
    }

    
}
