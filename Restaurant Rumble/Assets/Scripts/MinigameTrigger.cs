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
     TimingMinigame currentPoints;
     TimingMinigame pointRequirement;
    public bool InInteractArea;
    public bool MinigameOn;
    [SerializeField] Collider InteractArea;
    [SerializeField] Canvas MinigameScene; //i have never wanted to tell a piece of text to end its own life before but that might change RIGHT HERE APPARENTLY
    void Start()
    {
        MinigameOn = false; 
       
    }
    void Update()
    {
        
       if (InInteractArea&&Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(MinigameScene);
            InInteractArea = false;
            MinigameOn= true;
           Debug.Log("you interacted with the thingy");
            
        }
       else
        {
            return;
        }

        if (MinigameOn && currentPoints == pointRequirement)
        {
            Debug.Log("You DID IT :D");
            MinigameOn = false;
            MinigameScene.GetComponent<Canvas>().enabled= false;

        } 
    }

    void OnTriggerEnter(Collider other) //minigame trigger & appear
    {
        InInteractArea = true;
        
    }

    void OnTriggerExit(Collider other)
    {
      InInteractArea=true;  
    }
}
