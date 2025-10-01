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
    Rigidbody rb;
    [SerializeField] Canvas MinigameScene; //i have never wanted to tell a piece of text to end its own life before but that might change RIGHT HERE APPARENTLY
    [SerializeField] GameObject Mousey;
    Vector3 playerPosition;
    void Update()
    {

       if (InInteractArea&&Input.GetKeyDown(KeyCode.Space)&&MinigameOn==false)
        {
            miniGame = Instantiate(MinigameScene);
            MinigameOn= true;
            playerPosition = transform.position;
           Debug.Log("you interacted with the thingy");
           
        }

       if(miniGame==null)
        {
            return;
        }


       if (MinigameOn)
        {
            InInteractArea = false;
            transform.position = playerPosition;

        }
        if (miniGame.GetComponent<TimingMinigame>())
        {
            if (miniGame.GetComponent<TimingMinigame>().currentPoints == miniGame.GetComponent<TimingMinigame>().pointRequirement)
            {
                Debug.Log("You DID IT :D");
                MinigameOn = false;
                Destroy(miniGame.gameObject);
                MinigamesWon++;
            }
        }
        else if (miniGame.GetComponent<MatchingMinigame>())
        {

        }
    }

    void OnTriggerEnter(Collider other) //minigame trigger & appear
    {
        if (other.CompareTag("MinigameObject"))
        {
            InInteractArea = true;
            MinigameScene = other.GetComponent<MinigameChange>().GetCanvas();
        }
        
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MinigameObject"))
        {
            InInteractArea =false;
            MinigameScene = null;
        }
              
    }
}
