using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class ShopItemBar : MonoBehaviour
{
    public static Image image;
    
    private void Start()
    {

        image = GetComponentInChildren<Image>();
        image.fillAmount = 0;
    }
    
    public static Image GetBar() { return image; }

}
