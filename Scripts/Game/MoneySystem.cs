using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MoneySystem : MonoBehaviour, ISaveable
{
    public static MoneySystem Instance { get; private set; }

    private const string MONEY_SAVE_KEY = "money";
   
    [SerializeField] private TextMeshProUGUI moneyText2;
    [SerializeField] private int money;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Load();
        SaveManager.Instance.AddNewSaveable(this);
    }

    private void Update()
    {
        moneyText2.text = money.ToString();
        
        
    }
    public void SpendMoney(int count)
    {
        
        if (money >= count) 
        {
            money -= count;
        }
        else 
        { 
            print("Your have not enagh money"); 
        }
    }
    public void AddMoney(int count)
    {
        money += count;
        
    }

    public int GetMoney()
    {
        return money;
    }

    public void Save()
    {
        ES3.Save(MONEY_SAVE_KEY, money);
    }

    public void Load()
    {
        if (ES3.KeyExists(MONEY_SAVE_KEY))
            money = ES3.Load<int>(MONEY_SAVE_KEY);
    }
}