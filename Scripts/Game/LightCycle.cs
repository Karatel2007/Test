using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCycle : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private Gradient lightColor;

    private Light mainLight;

    private void Start()
    {
        mainLight = GetComponent<Light>();
    }

    private void Update()
    {
        transform.Rotate(Vector3.right * speed * Time.deltaTime);

        mainLight.color = lightColor.Evaluate(transform.eulerAngles.x /360);
        
        
    }
}
