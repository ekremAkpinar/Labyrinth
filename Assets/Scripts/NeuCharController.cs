using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuCharController : MonoBehaviour
{
    // Neuer Text
    // Deklaration Rigidbody des Characters
    private Rigidbody rb;
    // Deklaration Animation des Characters
    private Animator anim;
    // Deklaration eines GameManagers
    private GameManager gameManager;
    // Zugriff auf das GameObject ZielEffect
    public GameObject ZielEffect;
    // Zugriff auf einen Raycast vom Character (Abstandsvektor zur Wand)
    public Transform raycast;


    private void Awake()
    {
        // Zugriff auf K?rper des Characters
        rb = GetComponent<Rigidbody>();
        // Zugriff auf Animation
        anim = GetComponent<Animator>();
        // Auf das Objekte (Klasse) GameManager zugreifen
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        // Wenn das Spiel nicht startet zurück zum Anfang
        if (!gameManager.gameStarted)
            return;
        // Wenn das Spiel startet
        else
            // Position des K?rpers = ..... + Vorw?rts * 2 * pro Sekunde
            rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
        // Triggere den Animator auf "gameStarted"
        anim.SetTrigger("gameStarted");

    }
    private void Update()
    {
        // Erhalte eine Information bei einem Treffer von einem Raycast
        RaycastHit hit;
        // Wenn(Bewege den Raycast mit dem Character vorwärts und gebe bei einer Länge von 3f "hit aus") passiert
        if (Physics.Raycast(raycast.position, transform.forward, out hit, 3f))
        {
            // Drehe den Character um 90° Grad nach rechts
            transform.Rotate(0.0f, 90f, 0f);
            // Wenn(Bewege den Raycast mit dem Character vorwärts und gebe bei einer Länge von 3f "hit aus") wieder passiert
            // (Also Wand auch auf der rechten Seite)
            if (Physics.Raycast(raycast.position, transform.forward, out hit, 3f))
            {
                // Drehe den Character um 180° zurück (Also Links von der Ursprungsposition)
                transform.Rotate(0.0f, -180f, 0f);
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        // Falls das getriggerte Objekt den Tag "Ziel" hat 
        if (other.tag == "Ziel")
        {

            // Spawne ZielEffect an der Position des getriggerten Object
            GameObject g = Instantiate(ZielEffect, other.transform.position, Quaternion.identity);
            // Zestöre das GameObject g nach 5f
            Destroy(g, 5f);
            
        }
    }

}

    
