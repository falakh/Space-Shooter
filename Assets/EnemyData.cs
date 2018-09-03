using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName ="Enemy",menuName ="EnemyData",order =1)]
public class EnemyData : ScriptableObject
{
    public Sprite enemySprite;
    public int health;
    public int shootRate;
}

