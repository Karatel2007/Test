using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BuyerAgent : MonoBehaviour
{

    private List<GameObject> shopPoints;
    [SerializeField] private ShopDataSO shopData;
    private Animator animator;
    private NavMeshAgent agent;
    private Transform target;
    public bool isStopped = false;
    private int randomIndex;
    private int currentWayPointIndex = 0;

    

    private void Start()
    {
        animator= GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        shopPoints = GameObject.FindGameObjectsWithTag("PointsToShop").ToList();
        target = shopPoints[currentWayPointIndex].transform;
        
    }

    private void Update()
    {

        if (isStopped)
        {
            agent.SetDestination(transform.position);
            if (ShopPlace.itemIndexInCollider == randomIndex) 
            { 
                CompleteRequest();
            }          
        }
        else
        {
            animator.SetBool("Walk", true);
            agent.SetDestination(target.position);

            if (Vector3.Distance(transform.position, target.position) < 0.3f)
            {
                currentWayPointIndex++;

                if (currentWayPointIndex >= shopPoints.Count - 1)
                {
                    BuyerSpawner.Instance.DestroyBuyer();
                    BuyerSpawner.Instance.SpawnBuyer();

                }
                target = shopPoints[currentWayPointIndex].transform;
            }
        }
        
    }
    
    public void CompleteRequest()
    {
        Destroy(ShopPlace.itemPrefab);
        MoneySystem.Instance.AddMoney(shopData.items[randomIndex].price);
        Walk();
        ShopPlace.itemIndexInCollider = -1;
        ComputerManager.Instance.ClearItemImage();
        PlayerController.Instance.isHolding= false;
    }
    public void CanselPurches()
    {
        Walk();
        ShopPlace.itemIndexInCollider = -1;
        ComputerManager.Instance.ClearItemImage();
        
    }

    public void GiveRequest()
    {
        randomIndex = Random.Range(0, shopData.items.Count);
        ComputerManager.Instance.SetItemImage(shopData.items[randomIndex].icon);
        
    }
    public void StopWalking()
    {
        isStopped = true;
        animator.SetBool("Walk", false);

    }
    public void Walk()
    {
        isStopped = false;
        animator.SetBool("Walk", true);
    }
}
