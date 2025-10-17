using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float startTime = 60f; // Time in seconds
    private float currentTime;

    [Header("UI References")]
    public TextMeshProUGUI timerText; // Assign your TMP text in Inspector

    [Header("Scene Settings")]
    [Tooltip("Name of the scene to load when the timer reaches zero. Leave blank to reload the current scene.")]
    public string sceneToLoad = ""; 

    [Header("Options")]
    public bool autoStart = true;
    public bool countDown = true;

    private bool isRunning = false;

    void Start()
    {
if (timerText == null)
    {
        // Try to find a TextMeshProUGUI in the scene (or child)
        timerText = GetComponentInChildren<TextMeshProUGUI>();
        if (timerText == null)
            timerText = FindObjectOfType<TextMeshProUGUI>();
    }

        currentTime = startTime;
        if (autoStart)
            StartTimer();
    }

    void Update()
    {
        if (!isRunning) return;

        if (countDown)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                StopTimer();
                OnTimerEnd();
            }
        }
        else
        {
            currentTime += Time.deltaTime;
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void StartTimer() => isRunning = true;
    public void StopTimer() => isRunning = false;
    public void ResetTimer()
    {
        currentTime = startTime;
        UpdateTimerDisplay();
    }

	public void AddTime(float amount)
	{
  	  currentTime += amount;
	}

    private void OnTimerEnd()
    {
        Debug.Log("Timer finished — unloading scene!");

        if (string.IsNullOrEmpty(sceneToLoad))
        {
            // Reload current scene
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
        else
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}