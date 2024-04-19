using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopResourse : MonoBehaviour
{
    public int index;
    [SerializeField] private int priceToBuy;


    public void BuyItem()
    {       
        MoneySystem.Instance.SpendMoney(priceToBuy);
    }

}
