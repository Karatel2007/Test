using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private bool freeDoor;
     private bool buyBuilding;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Open()
    {
        if (freeDoor || buyBuilding)
        {
            animator.SetTrigger("Open");
        }
        
    }
    public void BuyKeyForDoor()
    {
         buyBuilding = true;
    }
}
