using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lore : MonoBehaviour
{
    public string loreEntry;
    public Text LoreBoxText;
    

    public void readLore(string loreEntry)
    {
        LoreBoxText.text = LoreSystem.loadLore(loreEntry);
    }
}
