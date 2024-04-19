using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabilityCheck : MonoBehaviour
{
    [SerializeField] private BoxCollider collider;
    private void Start()
    {
      
        Collider[] colliders = Physics.OverlapBox(collider.transform.position + collider.center, collider.size / 2);

        foreach (Collider item in colliders)
        {
            if (item.TryGetComponent(out Structure structure))
            {
                if (structure.GetStructureType() == StructureType.Wall)
                {
                    return;
                }

            }
        }

        Destroy(gameObject);
    }
   
}
