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
     //TimingMinigame currentPoints;
     //TimingMinigame pointRequirement;
    public bool InInteractArea;
    public bool MinigameOn;
    public int MinigamesWon;
    public Canvas miniGame;
    [SerializeField] Canvas MinigameScene; //i have never wanted to tell a piece of text to end its own life before but that might change RIGHT HERE APPARENTLY
    void Update()
    {
        
       if (InInteractArea&&Input.GetKeyDown(KeyCode.Space)&&MinigameOn==false)
        {
            miniGame = Instantiate(MinigameScene);
            MinigameOn= true;
           Debug.Log("you interacted with the thingy");

           
        }

       if(miniGame==null)
        {
            return;
        }
       

       if (MinigameOn)
        {
            InInteractArea = false;
        }

        if (miniGame.GetComponent<TimingMinigame>().currentPoints == miniGame.GetComponent<TimingMinigame>().pointRequirement)
        {
        Debug.Log("You DID IT :D");
        MinigameOn = false;
            Destroy(miniGame.gameObject);
            MinigamesWon ++;
        } 
    }

    void OnTriggerEnter(Collider other) //minigame trigger & appear
    {
        if (other.CompareTag("MinigameObject"))
        {
            InInteractArea = true;
        }
        
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MinigameObject"))
        {
            InInteractArea =false;
        }
              
    }
}
