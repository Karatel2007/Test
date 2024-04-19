using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DeliveryShop : MonoBehaviour
{
    [SerializeField] private ShopFornitureSO data;
    [SerializeField] private int refreshPrice;
    public static DeliveryShop Instance { get; private set; }

    public  List<GameObject> furnitures;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more then one DeliveryShop");
        }
        Instance = this;
    }
    public void RefreshItems()
    {
        if (furnitures != null && MoneySystem.Instance.GetMoney() >= refreshPrice)
        {
            foreach (GameObject furniture in furnitures)
            {
                Destroy(furniture.transform.GetChild(0).gameObject);
                if(furniture.GetComponent<ShopFornitureType>().GetFornitureIndex() == 0)
                {
                    int randomShelfIndex = Random.Range(0, data.shelfs.Count);
                    Instantiate(data.shelfs[randomShelfIndex].objects, furniture.transform);
                }
                if (furniture.GetComponent<ShopFornitureType>().GetFornitureIndex() == 1)
                {
                    int randomBookShelfIndex = Random.Range(0, data.bookShelfs.Count);
                    Instantiate(data.bookShelfs[randomBookShelfIndex].objects, furniture.transform);
                }

            }
            MoneySystem.Instance.SpendMoney(refreshPrice);
        }
        else
        {
            print("You are Loser");
        }
            
    }
    
}
