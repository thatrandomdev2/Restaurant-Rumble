using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // Movement Variables

    [SerializeField] float movementSpeed;
    Vector2 moveInput;
    float sprint;
    Rigidbody rb;

    // Inventory Variables

    [SerializeField] GameObject pickupPopUp;
    public List<PickupObject> pickupObjects = new List<PickupObject>();
    Vector3 distanceToNearestObject;
    GameObject nearestGameObject;

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

        // Detects whether there are pickup objects close enough to enable the pickup pop up

        nearestGameObject = GetClosestObject("Object");

        if (nearestGameObject != null && pickupObjects.Count <= 2)
        {
            distanceToNearestObject = nearestGameObject.transform.position - transform.position;

            if (distanceToNearestObject.magnitude < 3f)
            {
                pickupPopUp.SetActive(true);
            }
            else
            {
                pickupPopUp.SetActive(false);
            }
        }
        else
        {
            nearestGameObject = null;
            pickupPopUp.SetActive(false);
        }


        // Rotates player among movement direction

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
        if (distanceToNearestObject.magnitude < 3f && nearestGameObject != null && pickupObjects.Count <= 2)
        {
            pickupObjects.Add(nearestGameObject.GetComponent<Object>().pickupObject);
            Destroy(nearestGameObject);
        }
    }

    // Finds the nearest object of a tag to the parent of the script; returns null if no objects are found

    GameObject GetClosestObject(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

        if (objects.Length == 0) return null;

        Transform tMin = null;
        float minDist = Mathf.Infinity;
        GameObject closestObject = null;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in objects)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t.transform;
                closestObject = t;
                minDist = dist;
            }
        }
        return closestObject;
    }

    private void LateUpdate()
    {
        sprint = 0;
    }
}
