using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologram : MonoBehaviour
{
    [SerializeField] private GameObject structurePrefab;
    [SerializeField] private LayerMask obstackleLayer;
    [SerializeField] private Color colorRegected;
    [SerializeField] private Color colorDefolt;
    [SerializeField] private StructureType structureType;

    private BoxCollider boxCollider;
    private MeshRenderer meshRenderer;

    private bool canBuild;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position + boxCollider.center, boxCollider.size / 2, transform.rotation, obstackleLayer);

        if (colliders.Length > 0)
        {
            meshRenderer.material.color = colorRegected;
            canBuild = false;
            
        }
        else
        {
            meshRenderer.material.color = colorDefolt;
            canBuild = true;
           
        }
        
    }
    public GameObject GetStructurePrefab()
    {  
        return structurePrefab; 
    }
    public bool CanBeBuilded()
    {
        return canBuild;
    }

    public StructureType GetStructureType()
    {
        return structureType;
    }


}
