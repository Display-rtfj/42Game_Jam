using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoresItem {
    public string name;
    public int score;
}


[CreateAssetMenu(fileName = "New Score", menuName = "Score/Data")]
public class ScoreData : ScriptableObject
{
    public ScoresItem[]   scores = new ScoresItem[10];
}
