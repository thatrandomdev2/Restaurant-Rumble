using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject player;
    Vector3 targetPos;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        targetPos = transform.position;
    }
    void Update()
    {
        targetPos = Vector3.Lerp(targetPos, player.transform.position, 0.01f);
        transform.position = targetPos + new Vector3(0,10,-11);
    }
}
