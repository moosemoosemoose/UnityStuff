using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loreItem : MonoBehaviour
{
    public int loreID;
    public string textLabel;
    public string pathName;
    public bool unlocked;

    public loreItem(int ID, string label, string path, bool unlock)
    {
        loreID = ID;
        textLabel = label;
        pathName = path;
        unlocked = unlock;
    }
}
