using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAdventureManager : MonoBehaviour
{
    public static UIAdventureManager instance;
    
    private Image barHealth;
    private Text textHealth;
    private Image barExperience;
    private Text textExperience;
    private Text textGold;
    private Text textLevel;

    private Image bgZoneImage;
    private Text zoneText;
    private Image objectImage;
    private Text objectText;
    
    [SerializeField] private GameObject health;
    [SerializeField] private GameObject experience;
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject gold;
    [Space]
    [SerializeField] private GameObject bgGameobject;
    [Space]
    [SerializeField] private GameObject popupGeneral;
    [SerializeField] private GameObject popupEnemy;
    [SerializeField] private GameObject popupItem;
    [SerializeField] private GameObject popupChest;

    private void Awake()
    {
        instance = this;
    }

    public void SetZoneUI(ZoneSO _zone)
    {
        bgZoneImage = bgGameobject.GetComponent<Image>();
        zoneText = bgGameobject.transform.GetChild(1).GetComponent<Text>();
        objectImage = bgGameobject.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        objectText = bgGameobject.transform.GetChild(0).GetChild(1).GetComponent<Text>();

        zoneText.text = _zone.zoneName;
        bgZoneImage.sprite = _zone.zoneBgSprite;
    }

    public void ShowObjectUI(Sprite _objectSprite, string _objectText)
    {
        objectImage.sprite = _objectSprite;
        objectText.text = _objectText;
        
        objectImage.transform.parent.gameObject.SetActive(true);
    }

    public void HideObjectUI()
    {
        objectImage.transform.parent.gameObject.SetActive(false);
    }
    
    public void RefreshHealth(float _bar, string _text)
    {
        if (barHealth == null || textHealth == null)
        {
            barHealth = health.transform.GetChild(1).GetChild(1).GetComponent<Image>();
            textHealth = health.transform.GetChild(2).GetComponent<Text>();
        }
        
        barHealth.fillAmount = _bar;
        textHealth.text = _text;
    }
    
    public void RefreshExperience(float _bar, string _text)
    {
        if (barExperience == null || textExperience == null)
        {
            barExperience = experience.transform.GetChild(1).GetChild(1).GetComponent<Image>();
            textExperience = experience.transform.GetChild(2).GetComponent<Text>();
        }
        
        barExperience.fillAmount = _bar;
        textExperience.text = _text;
    }
    
    public void RefreshGold(string _text)
    {
        if (textGold == null)
        {
            textGold = gold.transform.GetChild(1).GetComponent<Text>();
        }

        textGold.text = _text;
    }
    
    public void RefreshLevel(string _text)
    {
        if (textLevel == null)
        {
            textLevel = level.transform.GetChild(1).GetComponent<Text>();
        }

        textLevel.text = _text;
    }
    
    public void OpenPopUpObject()
    {
        switch (AdventureManager.instance.objectType)
        {
            case AdventureManager.EObjectType.General:
                OpenPopUpGeneral();
                break;
            
            case AdventureManager.EObjectType.Enemy:
                OpenPopUpEnemy();
                break;

            case AdventureManager.EObjectType.Item:
                OpenPopUpItem();
                break;
            
            case AdventureManager.EObjectType.Chest:
                OpenPopUpChest();
                break;
        }
    }

    public void ClosePopUpObject()
    {
        popupChest.SetActive(false);
        popupEnemy.SetActive(false);
        popupGeneral.SetActive(false);
        popupItem.SetActive(false);
    }

    private void OpenPopUpGeneral()
    {
        popupGeneral.SetActive(true);
    }

    private void OpenPopUpEnemy()
    {
        popupEnemy.SetActive(true);
    }

    private void OpenPopUpItem()
    {
        popupItem.SetActive(true);
    }

    private void OpenPopUpChest()
    {
        popupChest.SetActive(true);
    }
}
