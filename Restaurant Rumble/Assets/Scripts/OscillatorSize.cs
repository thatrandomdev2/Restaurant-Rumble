using UnityEngine;

public class OscillatorSize : MonoBehaviour
{

    [SerializeField] Vector3 movementVector;
    [SerializeField] float speed;

    Vector3 startSize;
    Vector3 endSize;
    float movementFactor;

    void Start()
    {
        startSize = transform.localScale;
        endSize = startSize + movementVector;
    }

    void Update()
    {
        movementFactor = Mathf.PingPong(Time.time * speed, 1f);
        transform.localScale = Vector3.Lerp(startSize, endSize, movementFactor);
    }
}
