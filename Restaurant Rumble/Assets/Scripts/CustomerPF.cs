using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static CustomerPF;

public class CustomerPF : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    public bool isServed;
    public GameObject returnSpot;
    [SerializeField] GameObject CurrentRestaurant;

    private bool atTarget = false;
    private bool returning = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = FindNextAvailableTarget();
        if (target != null)
            agent.SetDestination(target.transform.position);

        isServed = false;
        atTarget = false;
        returning = false;
    }

    void Update()
    {
        if (!atTarget && target != null && !returning)
        {
            float dist = Vector3.Distance(transform.position, target.transform.position);
            if (dist < 0.5f)
            {
                atTarget = true;
                agent.isStopped = true;
            }
        }

        if (isServed && atTarget && !returning)
        {
            // set return spot and start returning
            returnSpot = FindNearestReturnSpot();
            if (returnSpot != null)
            {
                target = returnSpot;
                agent.isStopped = false;
                agent.SetDestination(returnSpot.transform.position);
                returning = true;
                atTarget = false;
            }
        }

        if (returning && returnSpot != null)
        {
            float dist = Vector3.Distance(transform.position, returnSpot.transform.position);
            if (dist < 0.5f)
            {
                agent.isStopped = true;
                Destroy(this.gameObject);
            }
        }
    }

    private GameObject FindNextAvailableTarget()
    {
        GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Target");
        CustomerPF[] allCustomers = FindObjectsOfType<CustomerPF>();
        GameObject nearest = null;
        float minDist = float.MaxValue;
        Vector3 currentPos = transform.position;

        foreach (var candidate in allTargets)
        {
            bool claimed = false;
            foreach (var customer in allCustomers)
            {
                if (customer != this &&
                    customer.isActiveAndEnabled &&
                    customer.CurrentRestaurant == this.CurrentRestaurant &&
                    customer.target == candidate &&
                    !customer.returning)
                {
                    claimed = true;
                    break;
                }
            }

            if (!claimed)
            {
                float dist = Vector3.Distance(currentPos, candidate.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    nearest = candidate;
                }
            }
        }

        return nearest;
    }

    private GameObject FindNearestReturnSpot()
    {
        GameObject[] returnSpots = GameObject.FindGameObjectsWithTag("ReturnSpot");
        if (returnSpots.Length == 0) return null;

        GameObject nearest = null;
        float minDist = float.MaxValue;
        Vector3 currentPos = transform.position;

        foreach (var spot in returnSpots)
        {
            float dist = Vector3.Distance(currentPos, spot.transform.position);
            if (dist < minDist)
            {
               
                minDist = dist;
                nearest = spot;
            }
    
        }
        return nearest;
    }

    private void OnTriggerEnter(Collider other)
    {
        CurrentRestaurant = other.gameObject;
    }
}
