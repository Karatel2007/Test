using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasHole : MonoBehaviour
{
    private Image progresBar;
    private float gas;


    private void Update()
    {
        if(progresBar != null)
        {
            progresBar.fillAmount = gas;
        }

        if (gas >= 1)
        {
            GetComponent<MeshRenderer>().material.color= Color.green;
            GetComponentInParent<CarAgent>().Drive();
            MoneySystem.Instance.AddMoney(100);
            progresBar.fillAmount = 0;
            gas= 0;
        }
    }

    public void FillGas(float gasAmmount)
    {
        progresBar = ProgresBar.Instance.GetBar();
        gas += gasAmmount;
    }
}
