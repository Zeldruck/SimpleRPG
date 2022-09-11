using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;
    
    public GeneralStats generalStats { get; private set; }
    public CharacterStats characterStats { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        generalStats = GetComponent<GeneralStats>();
        characterStats = GetComponent<CharacterStats>();
        
        generalStats.Initialization(this);
        characterStats.Initialization(this);
    }
}
