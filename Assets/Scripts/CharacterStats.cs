using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private CharacterManager cManager;
    
    public int lastingPoints { get; private set; }
    
    public int attack { get; private set; }
    public int defense { get; private set; }
    public int speed { get; private set; }

    public int attackPoints;
    public int defensePoints;
    public int speedPoints;
    [Space]
    [SerializeField] private int pointsPerlevel;
    
    public void Initialization(CharacterManager _cManager)
    {
        cManager = _cManager;

        cManager.generalStats.onLevelUp += OnLevelUp;
    }
    
    public void AddAttackPoint()
    {
        if (lastingPoints <= 0) return;

        lastingPoints--;
        attackPoints++;
        
        // calculate new attack
        // refresh texts
    }
    
    public void AddDefensePoint()
    {
        if (lastingPoints <= 0) return;

        lastingPoints--;
        defensePoints++;
        
        // calculate new defense
        // refresh texts
    }
    
    public void AddSpeedPoint()
    {
        if (lastingPoints <= 0) return;

        lastingPoints--;
        speedPoints++;
        
        // calculate new speed
        // refresh texts
    }

    private void OnLevelUp()
    {
        lastingPoints += pointsPerlevel;
        
        // refresh texts
    }
}
