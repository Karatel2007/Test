using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerManager : MonoBehaviour
{
    public static ComputerManager Instance { get; private set; }

    [SerializeField] private GameObject center;
    [SerializeField] private Image shopItemImage;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more than one Computer Manager");
        }
        Instance = this;       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            Cursor.lockState = CursorLockMode.Confined;
            
            center.SetActive(false);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            Cursor.lockState = CursorLockMode.Locked;
            center.SetActive(true);
        }
    }

    public void SetItemImage(Sprite sprite)
    {
        shopItemImage.sprite = sprite;
    }
    public void ClearItemImage()
    {
        shopItemImage.sprite = null;
    }
    public void BuyShopItem(int id)
    {
        BildingSystem.Instance.BuyBuilding(id);
        Cursor.lockState = CursorLockMode.Locked;
    }
    

}

