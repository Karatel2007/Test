using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubish : MonoBehaviour
{
    [SerializeField] private int price;
    public int GetProfit()
    {
        return price;
    }
}
