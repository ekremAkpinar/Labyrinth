using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Deklaration des Spielstandes
    public bool gameStarted;

    public void StartGame()
    {
        // Spielstart
        gameStarted = true;
        
    }

    public void EndGame()
    {
        // Lade Anfangszene bei Spielende
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        // Wenn die Returntaste gedrückt wird starte das Spiel
        if (Input.GetKeyUp(KeyCode.Return))
        {
            StartGame();
        }
        // Wenn die Spacetast gedrückt wird fange von neu an
        if (Input.GetKeyUp(KeyCode.Space))
        {
            EndGame();
        }
            


    }

}
