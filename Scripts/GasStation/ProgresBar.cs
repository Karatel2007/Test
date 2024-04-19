using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgresBar : MonoBehaviour
{
    [SerializeField] private Gradient barGradient;

    public static ProgresBar Instance {get; private set; }
    private Image image;
    


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more tahan one PlayerController");
        }
        //Debug.Log(gameObject.name);
        Instance = this;
    }
    private void Start()
    {
        
        image= GetComponentInChildren<Image>();
        image.fillAmount = 0;
    }

    private void Update()
    {
        image.color = barGradient.Evaluate(image.fillAmount);
    }

    public Image GetBar() { return image; }
}
