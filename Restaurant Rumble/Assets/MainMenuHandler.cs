using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    public void LoadGame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void loadnewScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
