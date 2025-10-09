using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class TimingMinigame : MonoBehaviour
{
    public int pointRequirement = 5;
    public int currentPoints = 0;
    private bool UpperActiveThingy;
    private bool LowerActiveThingy;
    private GameObject Dave;
    public PlayerScript player;
    [SerializeField] GameObject Bar;
    [SerializeField] Component UpperThingy;
    [SerializeField] Component LowerThingy;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerScript>();
        player.gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("MiniGame");
    }

    void Update()
    {
        if (player.MinigameInteractA > 0) print("Pressed A");
        if (UpperActiveThingy&& player.MinigameInteractA > 0 &&Dave!=null) 
        {
            currentPoints++;
            Dave.GetComponent<Image>().color = Color.green;
            Dave.GetComponent<Collider2D>().enabled = false;
        }
        else if (LowerActiveThingy&& player.MinigameInteractB > 0 && Dave != null)
        {
            currentPoints++;
            Dave.GetComponent<Image>().color = Color.green;
            Dave.GetComponent<Collider2D>().enabled = false;
        }
    

//WHAT DO YOU WANT FORM MEEE YOU IDIOTIC CABBAGE YOU GRAOUND BEEF FOOL YOUJ UGLY LINE OF TEXT WITH NO JOB YOYU UGLY UNNATRACTIVE DBIHYFGSTYIUDHFCTUGYHFDRETFUYGIHDCFYTUGIHFCWDRTYG I HATE YOU 
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if(UpperThingy)
    //    Debug.Log("entered timing point");
    //    //If button press seperated into 2 
    //    Dave = other.gameObject;
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    ActiveThingy=false;
    //    Dave = null;
    //}

    public void SetUpper(bool state,GameObject obj)
    {
        UpperActiveThingy = state;
        Dave=obj;
    }
    public void SetLower(bool state, GameObject obj)
    {
        LowerActiveThingy = state;
        Dave = obj;
    }
}