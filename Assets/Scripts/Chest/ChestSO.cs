using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chest", menuName = "SO/Chest", order = 2)]
public class ChestSO : ScriptableObject
{
    public Sprite chestSprite;
    public string chestName;
    [Space]
    public ChestItem[] items;
}

[Serializable]
public struct ChestItem
{
    public enum EChestItemType
    {
        Gold,
        Item,
        Material
    }

    public EChestItemType itemType;
    public ScriptableObject item;
    public int gold;
    [Space]
    [Range(0f, 1f)] public float percentage;
}