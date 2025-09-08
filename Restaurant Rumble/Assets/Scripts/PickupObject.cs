using UnityEngine;

[CreateAssetMenu(fileName = "Pickup Object", menuName = "My Assets/Pickup Object", order = 1)]
public class PickupObject : ScriptableObject
{
    public enum PickupObjectType 
    {
        Milk, 
        Dough, 
        Apple
    };

    public PickupObjectType pickupObjectType;
    public Sprite UISprite;

}

