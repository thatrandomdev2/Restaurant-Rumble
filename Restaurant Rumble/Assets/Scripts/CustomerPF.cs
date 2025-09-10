using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CustomerPF : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    [SerializeField] GameObject CurrentRestaurant;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = FindNextAvailableTarget();

    }

    private GameObject FindNextAvailableTarget()
    {
        GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Target");
        CustomerPF[] allCustomers = FindObjectsOfType<CustomerPF>();

        foreach (var candidate in allTargets)
        {
            bool claimed = false;
            foreach (var customer in allCustomers)
            {
                // only consider active customers who share the same CurrentRestaurant
                if (customer != this &&
                    customer.isActiveAndEnabled &&
                    customer.CurrentRestaurant == this.CurrentRestaurant &&
                    customer.target == candidate)
                {
                    claimed = true;
                    break;
                }
            }
            if (!claimed)
                return candidate;
        }
        return null;
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RestaurantTrigger"))
        {
            CurrentRestaurant = other.gameObject;
        }
    }
}
