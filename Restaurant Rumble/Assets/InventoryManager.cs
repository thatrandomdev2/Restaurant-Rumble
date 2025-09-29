using UnityEngine;
using UnityEngine.InputSystem;

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
