using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MinigameTrigger : MonoBehaviour
{
    // game 1 is timing 
    //game 2 is matching 
    //game 3 is ordering 
    // game 4 is balancing
    [SerializeField] Collider InteractArea;
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) //minigame trigger & appear
    {
        Debug.Log ("you interacted with the thingy");
    }
}
