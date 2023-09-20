using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FilePath : MonoBehaviour
{
  public static string FullPath(string fileName)
    {
#if UNITY_EDITOR
        return Application.dataPath+fileName;

#elif UNITY_IOS
return Application.persistentDataPath+ fileName;
 
#elif UNITY_ANDROID
       
        return    Application.persistentDataPath+ fileName;
        
       
 
#endif
    }
    public static bool Exist(string path)
    {
        FileInfo f = new FileInfo(path);
        return f.Exists;
       
    }
}
