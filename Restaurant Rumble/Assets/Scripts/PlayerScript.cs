using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // Movement Variables

    [SerializeField] float movementSpeed;
    Vector2 moveInput;
    float sprint;
    Rigidbody rb;
    public Animator animator;
    public float MinigameInteractA;
    public float MinigameInteractB;
    // Inventory Variables

    [SerializeField] GameObject pickupPopUp;
    PopUpScript popUpScript;
    public List<PickupObject> pickupObjects = new List<PickupObject>();
    Vector3 distanceToNearestObject;
    Vector3 distanceToNearestCustomer;
    GameObject nearestGameObject;
    GameObject nearestCustomer;
    bool isNearAnyObject;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        popUpScript = pickupPopUp.GetComponent<PopUpScript>();
    }
    void Update()
    {
        // Moves the player
        // this movement makes it so that the player doesn't collide

        if (sprint == 0) { transform.position += (new Vector3(moveInput.x, 0, moveInput.y) * movementSpeed * Time.deltaTime); }

        else if (sprint == 1) { transform.position += (new Vector3(moveInput.x, 0, moveInput.y) * movementSpeed * Time.deltaTime * 1.5f); }

        animator.SetFloat("Speed", moveInput.magnitude); 

        print(moveInput.magnitude);

        // Detects whether there are pickup objects close enough to enable the pickup pop up

        nearestGameObject = GetClosestObject("Object");
        nearestCustomer = GetClosestObject("Customer");

        if (nearestGameObject != null && pickupObjects.Count <= 2)
        {
            distanceToNearestObject = nearestGameObject.transform.position - transform.position;

            if (distanceToNearestObject.magnitude < 3f)
            {
                popUpScript.popUpEnabled = true;
            }
            else
            {
                popUpScript.popUpEnabled = false;
            }
        }
        else
        {
            nearestGameObject = null;
            popUpScript.popUpEnabled = false;
        }

        if (nearestCustomer != null && pickupObjects.Count != 0)
        {
            distanceToNearestCustomer = nearestCustomer.transform.position - transform.position;
        }
        else
        {
            nearestCustomer = null;
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

        if (distanceToNearestCustomer.magnitude <3f && nearestCustomer !=null && pickupObjects.Count !=0)
        {
            nearestCustomer.GetComponent<CustomerPF>().isServed = true;
            GetComponentInParent<PlayerInteract>().currentMoneys += 5;
            pickupObjects.RemoveAt(0);
            return;
        }
    }

    public void OnMinigameInteractA(InputValue value)
    {
        MinigameInteractA = value.Get<float>();
    }

    public void OnMinigameInteractB(InputValue value)
    {
        MinigameInteractB = value.Get<float>();
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
