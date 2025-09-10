using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public float customerInflux = 1;
    [SerializeField] GameObject interactible;
    [SerializeField] float customerSatisf = 1;
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
            // start the minigame sequence; if lost, customer satisfaction -2; if won:
            // if (currentSupply < 2) return;
            currentSupply -= 2;
            customerSatisf += 1;
            customerInflux -= 1;
            Instantiate(interactible);
            print("hath been completeted");
        }
        else
        {
            return;
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
