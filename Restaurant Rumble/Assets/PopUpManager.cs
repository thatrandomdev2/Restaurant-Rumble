using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    public Transform targetWorldObject;
    public RectTransform uiElementRectTransform;

    void Update()
    {
        if (targetWorldObject != null && uiElementRectTransform != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(targetWorldObject.position);

            uiElementRectTransform.position = screenPos;// - new Vector3(600,400,0);
        }
    }
}