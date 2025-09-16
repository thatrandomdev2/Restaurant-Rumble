using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    public bool popUpEnabled = false;
    public Transform targetWorldObject;
    public RectTransform uiElementRectTransform;

    void Update()
    {
        if (popUpEnabled) transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(0.8f,0.8f), 0.02f);
        else transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(0f, 0f), 0.02f);

        //transform.localScale = new Vector2(0.8f, transform.localScale.y);

        if (targetWorldObject != null && uiElementRectTransform != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(targetWorldObject.position);
            uiElementRectTransform.position = screenPos;
        }
    }
}
