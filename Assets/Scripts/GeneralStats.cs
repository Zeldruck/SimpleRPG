using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralStats : MonoBehaviour
{
    private CharacterManager cManager;
    
    private  int level;
    private int maxExp;
    public int baseMaxExp;
    [SerializeField] [Range(0.01f, 1f)] private float difficultyCursor;
    public int exp;
    [Space]
    public int maxHealth;
    public int health { get; private set; }

    public int gold { get; private set; }
    
    public delegate void OnLevelUp();
    public event OnLevelUp onLevelUp;

    public void Initialization(CharacterManager _cManager)
    {
        cManager = _cManager;
        
        // Load datas
        
        // TEMP
        level = 1;
        CalculateNextLevelExperience();
        health = maxHealth;
        UIAdventureManager.instance.RefreshHealth(health/(float)maxHealth, health + " / " + maxHealth);
        UIAdventureManager.instance.RefreshExperience(exp/(float)maxExp, (maxExp-exp).ToString());
        UIAdventureManager.instance.RefreshGold(gold.ToString());
        UIAdventureManager.instance.RefreshLevel(level.ToString());
    }

    public void AddHealth(int _aHealth)
    {
        if (_aHealth <= 0)
        {
            Debug.Log("Wrong function, use RemoveHealth instead.");
            return;
        }
        
        health += _aHealth;

        if (health > maxHealth) health = maxHealth;
        
        // Animation health bar
        // Refresh health text
        
        // if adventure page then refresh
        
        //Debug
        UIAdventureManager.instance.RefreshHealth(health/maxHealth, health + " / " + maxHealth);
    }
    
    public void RemoveHealth(int _rHealth)
    {
        if (_rHealth <= 0)
        {
            Debug.Log("Wrong function, use AddHealth instead.");
            return;
        }
        
        health -= _rHealth;

        if (health <= 0)
        {
            health = 0;
            
            // Death
        }
        
        // Animation health bar
        // Refresh health text
        
        // if adventure page then refresh
        
        //Debug
        UIAdventureManager.instance.RefreshHealth(health/maxHealth, health + " / " + maxHealth);
    }

    public void AddExperience(int _aExp)
    {
        if (_aExp <= 0f)
        {
            Debug.Log("Wrong function, use RemoveExperience instead.");
            return;
        }

        exp += _aExp;

        if (exp >= maxExp)
        {
            LevelUp();
        }
        
        // Animation exp bar
        
        // if adventure page then refresh
        
        //Debug
        UIAdventureManager.instance.RefreshExperience(exp/(float)maxExp, (maxExp-exp).ToString());
    }
    
    public void RemoveExperience(int _rExp)
    {
        if (_rExp <= 0f)
        {
            Debug.Log("Wrong function, use AddExperience instead.");
            return;
        }

        exp -= _rExp;

        if (exp < 0f)
        {
            LevelDown();
        }
        
        // Animation exp bar
    }

    public void AddGold(int _golds)
    {
        if (_golds <= 0f) return;

        gold += _golds;
        
        // if adventure page then refresh
        
        //Debug
        UIAdventureManager.instance.RefreshGold(gold.ToString());
    }

    public void RemoveGold(int _golds)
    {
        if (_golds <= 0f) return;

        gold -= _golds;
        
        // if adventure page then refresh
        
        //Debug
        UIAdventureManager.instance.RefreshGold(gold.ToString());
    }
    
    public void LevelUp()
    {
        int nbLevelUp = 0;
        
        while (exp >= maxExp)
        {
            exp -= maxExp;
            
            level++;
            nbLevelUp++;
            
            CalculateNextLevelExperience();

            onLevelUp?.Invoke();
        }
        
        // Regen health ?
        AddHealth(maxHealth);
        
        // Animation level up
        // Text nb level up set to nbLevelUp
        
        // if adventure page then refresh ui
        
        //DEBUG
        UIAdventureManager.instance.RefreshLevel(level.ToString());
    }

    public void LevelDown()
    {
        int nbLevelDown = 0;
        
        while (exp < 0f)
        {
            exp = maxExp - Mathf.Abs(exp);
            
            level--;
            nbLevelDown++;
            
            CalculateNextLevelExperience();
        }
        
        // Animation level down
        // Text nb level down set to nbLevelUp
        
        // if adventure page then refresh ui
        
        //DEBUG
        UIAdventureManager.instance.RefreshLevel(level.ToString());
    }

    private void CalculateNextLevelExperience()
    {
        maxExp = (int)((level * level) * baseMaxExp * difficultyCursor);
    }
}
