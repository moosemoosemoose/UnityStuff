using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public static class LoreSystem 
{
  

   public static string loadLore(string loreName)
   {
        string path = Application.persistentDataPath + "/" + loreName + ".txt";
        string lore = "";

        if(File.Exists(path))
        { 
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader( stream );
            lore = reader.ReadToEnd();
            stream.Close();
            return lore;
            
        }
        else
        {
            Debug.LogError("File Not Found in " + path);
            return null;
        }
   }

}
