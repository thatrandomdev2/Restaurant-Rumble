using TMPro;
using UnityEngine;

public class UiStats : MonoBehaviour
{
    PlayerInteract playerInteract;
    public TMP_Text moneyText;
    public TMP_Text supplyText;

    void Start()
    {
        playerInteract = GameObject.FindWithTag("Player").GetComponent<PlayerInteract>();
    }

    void Update()
    {
        moneyText.text = "Text changed by space key!";
        supplyText.text = "Text changed by space key!";
    }
}
