using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class MatchingMinigame : MonoBehaviour
{
    MinigameTrigger MinigameOn;
    List<string> Desiredingredients = new List<string>();
    string[] Placedingredients = { "one", "two", "three", "four", "five", "six", "seven" };
    string[] Availableingridients = { "one", "two", "three", "four", "five", "six", "seven" };
    [SerializeField] GameObject Mousey;

    //UGHHHH WHAT AM I DOING

    void Start()
    {
        GenerateDesiredingridients();
        foreach (string s in Desiredingredients)
        {
            Debug.Log(s);
            Instantiate(Mousey,transform);
        }
        
    }
    void GenerateDesiredingridients()
    {
        int random = Random.Range(1, 6);
        foreach(string s in Availableingridients)
        {
            Desiredingredients.Add(s);
        }
        for (int i = 0; i < Availableingridients.Length - random; i++) 
        {
            int index = Random.Range(0, Desiredingredients.Count);
            Desiredingredients.RemoveAt(index);
        }
        

    }
}
