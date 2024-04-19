using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : MonoBehaviour
{
    [SerializeField] private int deliverTime;
    private static int moneyForWrongDeliverl = 100;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DeliveryBox box))
        {
            if (box.deliveryDestination == gameObject)
            {
                MoneySystem.Instance.AddMoney(box.DeliveringBoxPrice());
                Destroy(other.gameObject, deliverTime);
                gameObject.SetActive(false);
            }
            else
            {
                MoneySystem.Instance.SpendMoney(moneyForWrongDeliverl);
                moneyForWrongDeliverl = moneyForWrongDeliverl * 2;
                Destroy(other.gameObject, deliverTime);
                print("you are wrong");
            }

            box.GetComponent<Rigidbody>().isKinematic = true;
            box.GetComponent<Collider>().enabled = false;
        }
    }
}
