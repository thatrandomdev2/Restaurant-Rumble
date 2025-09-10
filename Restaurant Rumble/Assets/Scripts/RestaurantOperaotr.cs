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
        Instantiate(Customer);
        new WaitForSeconds(4 * playerInteract.customerInflux);
        yield return null;
    }
}
