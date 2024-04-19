using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCollider : MonoBehaviour
{
    [SerializeField] private float alfaTreshold = 0.1f;

    private void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = alfaTreshold;

    }

}
