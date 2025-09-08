using UnityEngine;
using UnityEngine.UI;
public class TimingMinigame : MonoBehaviour
{
    public int pointRequirement;
    public int currentPoints = 0;
    private bool ActiveThingy;
    private GameObject Dave;
    void Update()
    {
        if (ActiveThingy&&Input.GetKeyDown(KeyCode.Space)) {
            currentPoints++;
            Dave.GetComponent<Image>().color = Color.green;
            Dave.GetComponent<Collider2D>().enabled = false;
        }
    

        if (currentPoints == pointRequirement) Debug.Log("You DID IT :D"); //WHAT DO YOU WANT FORM MEEE YOU IDIOTIC CABBAGE YOU GRAOUND BEEF FOOL YOUJ UGLY LINE OF TEXT WITH NO JOB YOYU UGLY UNNATRACTIVE DBIHYFGSTYIUDHFCTUGYHFDRETFUYGIHDCFYTUGIHFCWDRTYG I HATE YOU 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entered timing point");
        //If button press seperated into 2 
        ActiveThingy = true;
        Dave = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        ActiveThingy=false;
        Dave = null;
    }
}