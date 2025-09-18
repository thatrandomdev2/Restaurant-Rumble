using UnityEngine;

public class MinigameChange : MonoBehaviour
{
    [SerializeField] Canvas NewMiniGame;
    
    public Canvas GetCanvas() { return NewMiniGame; }
   
}
