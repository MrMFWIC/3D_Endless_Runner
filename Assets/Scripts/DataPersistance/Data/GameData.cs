using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData : MonoBehaviour
{
    public int coinWallet;
    public bool[] levelsUnlocked;

    // The values in this constructor will be the default values for a new save game
    // The game starts with this when there is no data to load
    public GameData()
    {
        this.coinWallet = 0;
        this.levelsUnlocked = new bool[3] { true, false, false};
    }
}
