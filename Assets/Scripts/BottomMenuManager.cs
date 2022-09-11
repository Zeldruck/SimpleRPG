using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomMenuManager : MonoBehaviour
{
    public static BottomMenuManager instance;
    
    [SerializeField] private GameObject homePage;
    [SerializeField] private GameObject adventurePage;
    [SerializeField] private GameObject settingsPage;

    private void Awake()
    {
        instance = this;
    }

    public void CloseAllPages()
    {
        homePage.SetActive(false);
        adventurePage.SetActive(false);
        settingsPage.SetActive(false);
    }
    
    public void OpenHomePage()
    {
        CloseAllPages();
        //Close home pages
        
        homePage.SetActive(true);
    }

    public void OpenAdventurePage()
    {
        CloseAllPages();
        //Close home pages
        
        AdventureManager.instance.OpenAdventurePage();
        adventurePage.SetActive(true);
    }

    public void OpenSettingsPage()
    {
        CloseAllPages();
        //Close home pages

        settingsPage.SetActive(true);
    }
}
