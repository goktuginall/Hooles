using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VariableData
{
    public int DataStarScore;
    public int DataLvlSocre;
    public int TotlCmpltScore;

    public VariableData(LevelManager levelData)
    {
        DataStarScore = levelData.GameStarScore;
        DataLvlSocre = levelData.GameLvlScore;
    }
}
