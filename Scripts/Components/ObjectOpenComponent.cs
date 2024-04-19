using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOpenComponent : MonoBehaviour
{
    private Animator animator;
    

    private void Start()
    {
        
        animator = GetComponentInChildren<Animator>();      
    }

    private void OnTriggerEnter(Collider other)
    {
        SetOpenState(true, other);
        
    }

    private void OnTriggerExit(Collider other)
    {
        SetOpenState(false, other);
        
    }

    private void SetOpenState(bool state, Collider other)
    {
        if (other.TryGetComponent(out PlayerController controller))
        {
            
            animator.SetBool("Open", state);

        }
        
    }
}
