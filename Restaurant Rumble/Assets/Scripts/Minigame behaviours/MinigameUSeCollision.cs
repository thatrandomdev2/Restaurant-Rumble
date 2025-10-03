using UnityEngine;

public class MinigameUSeCollision : MonoBehaviour
{
    [SerializeField] TimingMinigame TM;

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("UpMiniInteractPart"))
        {
            TM.SetUpper(true, collision.gameObject);
            //Debug.Log("Upper Works!");
        }
        else if (collision.CompareTag("LowMiniInteractPart"))
        {
            TM.SetLower(true, collision.gameObject);
           // Debug.Log("Lower Works!");
        }
    }

     void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("UpMiniInteractPart"))
        {
            TM.SetUpper(false, null);
        }
        else if (collision.CompareTag("LowMiniInteractPart"))
        {
            TM.SetLower(false, null);
        }
    }
}
