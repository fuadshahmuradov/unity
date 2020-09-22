using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int maxLevel;

    public PlayerData(GameSession gamesession)
    {
        maxLevel = gamesession.MaxLevel();
    }
}
