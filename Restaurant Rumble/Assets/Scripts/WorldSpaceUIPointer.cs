using UnityEngine;

public class WorldSpaceUIPointer : MonoBehaviour
{
    public Transform targetWorldObject; // The object the UI element should point to/follow
    public RectTransform uiElementRectTransform; // The RectTransform of your UI element

    void Update()
    {
        if (targetWorldObject != null && uiElementRectTransform != null)
        {

            // Option 2: Make the UI element face the camera (common for billboards)
            // Assuming the UI element's local Z-axis should face the camera
            uiElementRectTransform.LookAt(Camera.main.transform.position);
            // Adjust rotation if needed, e.g., to correct for UI element's default orientation
            uiElementRectTransform.Rotate(0, 180, 0); // Example adjustment

            // Option 3: Position relative to the target with an offset
            // uiElementRectTransform.position = targetWorldObject.position + new Vector3(0, 1.5f, 0); // Example offset
        }
    }
}
