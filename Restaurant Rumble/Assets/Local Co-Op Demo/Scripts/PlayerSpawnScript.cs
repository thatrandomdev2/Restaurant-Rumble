using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerSpawnScript : MonoBehaviour
{
    public Transform[] SpawnPoints;
    private int m_playerCount;

    public void OnPlayerJoined(PlayerScript playerInput)
    {
        playerInput.transform.position = SpawnPoints[m_playerCount].transform.position;
        
        m_playerCount++;
    }
}
