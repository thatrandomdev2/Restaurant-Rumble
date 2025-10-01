using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    GameObject player;
    public GameObject selection;
    public PlayerScript playerScript;
    public GameObject[] inventorySlots;

    int currentSelected = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (playerScript.pickupObjects[i] != null)
            {
                inventorySlots[i].GetComponent<Image>().sprite = playerScript.pickupObjects[i].UISprite;
            }
            else 
            {
                inventorySlots[i].GetComponent<Image>().sprite = null;
            }
        }
    }

    void OnPrevious(InputValue value)
    {
        currentSelected--;
        if (currentSelected == -1)
        {
            currentSelected = 2;
        }
        SetSelection();
    }

    void OnNext(InputValue value) 
    {
        currentSelected++;
        if (currentSelected == 3) 
        {
            currentSelected = 0;
        }
        SetSelection();
    }

    void SetSelection() 
    {
        selection.transform.localPosition = new Vector2(-115 + (currentSelected*115), selection.transform.localPosition.y);
    }
}
