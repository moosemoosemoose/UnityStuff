using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int hubPoint;
    public int[] charactersUnlocked;
    public int currentCharacter;
    public float[] bestTimeLevel;
    public float bestTimeTotal;
    public int[] loreUnlocked;
    public int numberOfDeaths;
    public Text HubPointTextBox;
    public Text CharactersUnlockedTextBox;
    public Text BestRunTextBox;
    public Text LoreUnlockedTextBox;
    public Text NumberofDeathsTextBox;
    public Text LevelTimeTextBox;
    string charUnlockedString;
    string loreUnlockedString;
    string levelTimeString;
    
    

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    //put this on main menu only???
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        charUnlockedString = "";
        loreUnlockedString = "";
        levelTimeString = "";
        hubPoint = data.hubPoint;
        charactersUnlocked = data.charactersUnlocked;
        currentCharacter = data.currentCharacter;
        bestTimeLevel = data.bestTimeLevel;
        bestTimeTotal = data.bestTimeTotal;
        loreUnlocked = data.loreUnlocked;
        numberOfDeaths = data.numberOfDeaths;
        HubPointTextBox.text = hubPoint.ToString();
        BestRunTextBox.text = bestTimeTotal.ToString();
        NumberofDeathsTextBox.text = numberOfDeaths.ToString(); 

        foreach(int character in charactersUnlocked)
        {
            charUnlockedString = charUnlockedString  + character.ToString() + " ";
        }
        CharactersUnlockedTextBox.text = charUnlockedString;

        
        foreach(int lore in loreUnlocked)
        {
            loreUnlockedString = loreUnlockedString +  lore.ToString() + " ";
        }
        LoreUnlockedTextBox.text = loreUnlockedString;
        
        foreach(float levelTime in bestTimeLevel)
        {
            levelTimeString = levelTimeString  + levelTime.ToString("F3") + "\n";
        }
        LevelTimeTextBox.text = levelTimeString;
    }

    
}
