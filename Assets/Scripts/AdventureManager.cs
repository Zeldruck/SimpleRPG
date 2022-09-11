using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AdventureManager : MonoBehaviour
{
    public enum EObjectType
    {
        General,
        Enemy,
        Item,
        Chest
    }

    public static AdventureManager instance;
    
    [HideInInspector] public EObjectType objectType;
    private ScriptableObject soStepAdventure;
    private float ePerc;
    
    [SerializeField] private ZoneSO actualZone;
    [Space]
    [SerializeField] private GameObject attackButton;
    [SerializeField] private GameObject openButton;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetZone(actualZone);
    }

    public void OpenAdventurePage()
    {
        UIAdventureManager.instance.HideObjectUI();
        UIAdventureManager.instance.SetZoneUI(actualZone);
        UIAdventureManager.instance.ClosePopUpObject();
        CloseAllButtons();
    }
    
    public void SetZone(ZoneSO _zone)
    {
        actualZone = _zone;
        
        UIAdventureManager.instance.SetZoneUI(_zone);
    }

    public void LaunchAdventure()
    {
        float p = Random.Range(0f, 1f);
        
        if (soStepAdventure) soStepAdventure = null;
        if (attackButton.activeSelf) attackButton.SetActive(false);
        if (openButton.activeSelf) openButton.SetActive(false);

        if (actualZone.percentageEnemy > 0f && p <= actualZone.percentageEnemy)
        {
            EnemySO enemy = actualZone.enemies[Random.Range(0, actualZone.enemies.Length)];
            soStepAdventure = enemy;
            
            ePerc = Random.Range(0f, 1f);
            int eLevel = (int)Mathf.Lerp(enemy.level.x, enemy.level.y, ePerc);
            
            UIAdventureManager.instance.ShowObjectUI(enemy.enemySprite, enemy.enemyName + " lvl " + eLevel);

            objectType = EObjectType.Enemy;

            attackButton.SetActive(true);
        }
        else if (actualZone.percentageChest > 0f && p <= actualZone.percentageEnemy + actualZone.percentageChest)
        {
            soStepAdventure = actualZone.chest;
            
            UIAdventureManager.instance.ShowObjectUI(actualZone.chest.chestSprite, actualZone.chest.chestName);

            objectType = EObjectType.Chest;
            
            openButton.SetActive(true);
        }
        else if (actualZone.percentageExp > 0f && p <= actualZone.percentageChest + actualZone.percentageEnemy + actualZone.percentageExp)
        {
            int nbExp = (int)Random.Range(actualZone.experience.x, actualZone.experience.y);
            
            UIAdventureManager.instance.ShowObjectUI(actualZone.expSprite, nbExp + " experiences");
            
            objectType = EObjectType.General;
            
            CharacterManager.instance.generalStats.AddExperience(nbExp);
        }
        else if (actualZone.percentageGold > 0f && p <= actualZone.percentageChest + actualZone.percentageEnemy + actualZone.percentageExp + actualZone.percentageGold)
        {
            int nbGold = Random.Range((int)actualZone.gold.x, (int)actualZone.gold.y + 1);
            
            UIAdventureManager.instance.ShowObjectUI(actualZone.goldSprite, nbGold + " golds");
            
            objectType = EObjectType.General;
            
            CharacterManager.instance.generalStats.AddGold(nbGold);
        }
        else
        {
            objectType = EObjectType.General;
            
            // Nothing
            Debug.Log("Nothing");
        }
    }

    private void CloseAllButtons()
    {
        attackButton.SetActive(false);
        openButton.SetActive(false);
    }

    public void AttackEnemy()
    {
        // Start combat 
        // In combat manager
        
        //DEBUG
        EnemySO enemy = soStepAdventure as EnemySO;
        CharacterManager.instance.generalStats.AddExperience((int)Mathf.Lerp(enemy.experience.x, enemy.experience.y, ePerc));

        soStepAdventure = null;
        attackButton.SetActive(false);
    }

    public void OpenChest()
    {
        ChestSO chest = soStepAdventure as ChestSO;
        
        int nbItem = Random.Range(0, chest.items.Length); // Change percentage

        if (chest.items[nbItem].item != null)
        {
            // Item
            objectType = EObjectType.Item;
        }
        else
        {
            int nbGolds = chest.items[nbItem].gold;
            CharacterManager.instance.generalStats.AddGold(nbGolds);
            UIAdventureManager.instance.ShowObjectUI(null/*gold*/, nbGolds + " golds");
            objectType = EObjectType.General;
        }
        
        openButton.SetActive(false);
    }
}
