using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy/Data")]
public class EnemyData : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public Color color;
    public int level;
    public float speed;

}
