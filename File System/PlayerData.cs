using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int hubPoint;
    public int[] charactersUnlocked = new int[6];
    public int currentCharacter;
    public float[] bestTimeLevel = new float[9];
    public float bestTimeTotal;
    public int[] loreUnlocked = new int[10];
    public int numberOfDeaths;

    public PlayerData(Player player)
    {
        hubPoint = player.hubPoint;
        charactersUnlocked = player.charactersUnlocked;
        currentCharacter = player.currentCharacter;
        bestTimeLevel = player.bestTimeLevel;
        bestTimeTotal = player.bestTimeTotal;
        loreUnlocked = player.loreUnlocked;
        numberOfDeaths = player.numberOfDeaths;

    }
}
