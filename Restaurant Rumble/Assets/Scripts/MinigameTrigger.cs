using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;

public class MinigameTrigger : MonoBehaviour
{
    // game 1 is timing 
    //game 2 is matching 
    //game 3 is ordering 
    // game 4 is balancing
    private bool InInteractArea;
    [SerializeField] Collider InteractArea;
    [SerializeField] Canvas MinigameScene; //i have never wanted to tell a piece of text to end its own life before but that might change RIGHT HERE APPARENTLY
    void Update()
    {
       if (InInteractArea&&Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("you interacted with the thingy");
        } 
    }

    void OnTriggerEnter(Collider other) //minigame trigger & appear
    {

        InInteractArea = true;
        
    }

    void OnTriggerExit(Collider other)
    {
      InInteractArea=false;  
    }
}
