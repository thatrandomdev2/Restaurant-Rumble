using UnityEngine;

public class HItNRun : MonoBehaviour
{
    [SerializeField] float movespeed = 0.4f;
    float direction = 1;
    
    void Update()
    {
        transform.Translate(Vector2.left * movespeed * direction*Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MOVERIGHTNOW"))
        {
            direction = -1;
            Debug.Log("whar");
        }
        else if (other.CompareTag("MOVELEFTNOW"))
        {
            direction = 1;
        }
    }
}
