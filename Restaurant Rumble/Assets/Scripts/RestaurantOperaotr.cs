using System.Collections;
using UnityEngine;

public class RestaurantOperaotr : MonoBehaviour
{
    private PlayerInteract playerInteract;
    public GameObject Customer;
    private void Update()
    {
        CustomerInstantiator();
    }
    void CustomerInstantiator()
    {
        CustomerPF[] allCustomers = FindObjectsOfType<CustomerPF>();
        if (allCustomers.Length <= 5)
        {
            StartCoroutine(CustomerSpawner());
        }
        return;
    }

    public IEnumerator CustomerSpawner()
    {
        if (playerInteract == null)
        {
            playerInteract = FindObjectOfType<PlayerInteract>();
            if (playerInteract == null)
            {
                Debug.LogError("PlayerInteract not found in the scene.");
                yield break;
            }
        }
        Instantiate(Customer);
        yield return new WaitForSeconds(4 * playerInteract.customerInflux);
    }
}
