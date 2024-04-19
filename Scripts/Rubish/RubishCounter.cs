using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubishCounter : MonoBehaviour
{
    [SerializeField] private int rubishUtilisationTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Rubish rubish))
        {
            MoneySystem.Instance.AddMoney(rubish.GetProfit());
            Destroy(other.gameObject, rubishUtilisationTime);
        }
        else
        {
            print("It is no rubish");
        }
    }
}
