using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    Vector2 moveInput;
    float sprint;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void Update()
    {
        // Moves the player

        if (sprint == 0) { transform.position += (new Vector3(moveInput.x, 0, moveInput.y) * movementSpeed * Time.deltaTime); }

        else if (sprint == 1) { transform.position += (new Vector3(moveInput.x, 0, moveInput.y) * movementSpeed * Time.deltaTime*1.5f); }

        print(sprint);


        // Rotate player among movement direction

        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y * -1, moveInput.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(transform.rotation.x, angle, transform.rotation.z);
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnSprint(InputValue value)
    {
        sprint = value.Get<float>();
    }

    void OnGrab(InputValue value) 
    {
        GameObject[] taggedObjectsArray = GameObject.FindGameObjectsWithTag("Object");

        Vector3 distanceToNearestObject = GetClosestEnemy(taggedObjectsArray).position - transform.position;

        //if (distanceToNearestObject)
        print(distanceToNearestObject.magnitude);

    }

    Transform GetClosestEnemy(GameObject[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t.transform;
                minDist = dist;
            }
        }
        return tMin;
    }

    private void LateUpdate()
    {
        sprint = 0;
    }
}
