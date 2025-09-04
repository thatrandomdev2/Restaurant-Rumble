using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RestaurantFunc : MonoBehaviour
{
    [SerializeField] double customerInflux = 1;
    [SerializeField] double customerSatisf = 1;
    [SerializeField] int currentMoneys;
    [SerializeField] int startingMoneys = 100;



    [SerializeField] int currentSupply;
    int startingSupply = 16;
    private void Start()
    {
        currentMoneys = startingMoneys;
        currentSupply = startingSupply;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("supplyInteractable"))
        {
            StartCoroutine(PurchaseSupply());
        }
        else if (other.CompareTag("moneyInteractable"))
        {
            // start the minigame sequence; if lost, do nothing; if won:
            // if lost, customer satisfaction -.02;
            if (currentSupply < 2) return;
            currentSupply -= 2;
            customerSatisf += .1;
            customerInflux += .05;
            print("hath been completeted");
        }
    }

    public IEnumerator PurchaseSupply()
    {
        if (currentMoneys < 10) yield break;
        currentSupply += 4;
        currentMoneys -= 10;
        yield return new WaitForSeconds(1);
    }
}
