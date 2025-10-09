using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class MatchingMinigame : MonoBehaviour
{
    MinigameTrigger MinigameOn;
    public List<string> Desiredingredients = new List<string>();
    public string[] Placedingredients = { "one", "two", "three", "four", "five", "six", "seven" };
    public GameObject[] Availableingridients;
    
    //UGHHHH WHAT AM I DOING

    void Start()
    {
   //     Availableingridients = Placedingredients;

        GenerateDesiredingridients();
        foreach (string s in Desiredingredients)
        {
            Debug.Log(s);
            
        }
        
    }
    void GenerateDesiredingridients()
    {
        int random = Random.Range(1, 6);
    //   foreach(GameObject.FindGameObjectWithTag("ingredients") in Availableingridients)
        {
     //       Desiredingredients.Add(s);
        }
        for (int i = 0; i < Availableingridients.Length - random; i++) 
        {
            int index = Random.Range(0, Desiredingredients.Count);
            Desiredingredients.RemoveAt(index);
        }
        

    }

    
}
