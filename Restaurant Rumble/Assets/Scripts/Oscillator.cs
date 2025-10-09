using UnityEngine;

public class Oscillator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector;
    [SerializeField] float speed;

    Vector3 startPosition;
    Vector3 endPosition;
    float movementFactor;

    void Start()
    {
        startPosition = transform.localPosition;
        endPosition = startPosition + movementVector;
    }

    void Update()
    {
        movementFactor = Mathf.PingPong(Time.time * speed, 1f);
        transform.localPosition = Vector3.Lerp(startPosition, endPosition, movementFactor);
    }
}
