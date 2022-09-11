using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Zone", menuName = "SO/Zone", order = 1)]
public class ZoneSO : ScriptableObject
{
    public string zoneName;
    public Sprite zoneIconSprite;
    public Sprite zoneBgSprite;
    [Space]
    public EnemySO[] enemies;
    public ChestSO chest;
    public Vector2 experience;
    public Vector2 gold;
    [Space]
    public Sprite expSprite;
    public Sprite goldSprite;
    [Space]
    [Range(0f, 1f)] public float percentageEnemy;
    [Range(0f, 1f)] public float percentageChest;
    [Range(0f, 1f)] public float percentageExp;
    [Range(0f, 1f)] public float percentageGold;
}
