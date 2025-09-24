using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class IngredientSelect : MonoBehaviour
{
    MinigameTrigger MinigameOn;
    MinigameTrigger minigame;
    Vector2 moveInput;
    [SerializeField] float movementSpeed;
    void Update()
    {
        if (MinigameOn && minigame.GetComponent<MatchingMinigame>()) { Transform.Position += (new Vector2(moveInput.x, moveInput.y) * movementSpeed * Time.deltaTime); }
        
    }
    // I NEED AN ENTIRELY SEPERATE MOVE SYSTEM WTF
}
