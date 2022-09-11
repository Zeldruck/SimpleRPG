using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "SO/Enemy", order = 0)]
public class EnemySO : ScriptableObject
{
    public string enemyName;
    public Sprite enemySprite;
    public Color enemyTint;
    [Space]
    public Vector2 level;
    public Vector2 attack;
    public Vector2 defense;
    public Vector2 speed;
    [Space]
    public Vector2 experience;
}
