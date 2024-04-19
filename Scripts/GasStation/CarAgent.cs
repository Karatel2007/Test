using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class CarAgent : MonoBehaviour
{
    private List<GameObject> wayPoints;

    private NavMeshAgent agent;
    private Transform target;
    private bool isStopped = false;
    

    private int currentWayPointIndex = 0;
    private RotateComponent[] wheels;

    private void Start()
    {
        wheels = GetComponentsInChildren<RotateComponent>();
        agent = GetComponent<NavMeshAgent>();
        wayPoints = GameObject.FindGameObjectsWithTag("Points").ToList();
        target = wayPoints[currentWayPointIndex].transform;
    }

    private void Update()
    {
        if (isStopped)
        {
            agent.SetDestination(transform.position);
        }
        else
        {
           
            agent.SetDestination(target.position);
           
            if (Vector3.Distance(transform.position, target.position) < 3f)
            {
                currentWayPointIndex++;
                
                    if (currentWayPointIndex >= wayPoints.Count - 1)
                    {
                        CarSpawner.Instance.DestroyCar();
                        CarSpawner.Instance.SpawnCar();                     
                    }
                    
                
                
                target = wayPoints[currentWayPointIndex].transform;
            }
        }

       
    }

    public void Stop()
    {
        isStopped = true;
        foreach (RotateComponent wheel in wheels)
        {
            wheel.StopRotating();
        }
      
    }
    public void Drive()
    {
        isStopped = false;
        foreach (RotateComponent wheel in wheels)
        {
            wheel.ContinueRotating();
        }
        
    }

}
