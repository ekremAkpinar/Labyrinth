using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    // Deklaration Rigidbody des Characters
    private Rigidbody rb;
    // Deklaration Animation des Characters
    private Animator anim;
    // Deklaration der einzelnen Wände
    public Collider wand1;
    public Collider wand2;
    public Collider wand3;
    public Collider wand4;
    public Collider wand5;
    public Collider wand6;
    public Collider wand7;
    public Collider wand8;
    public Collider wand9;
    public Collider wand10;
    public Collider wand11;
    public Collider wand12;
    public Collider wand13;
    public Collider wand14;
    public Collider wand15;  
    // Deklaration eines Treffers mit der Wand
    private bool wandtreffer;
    // Deklaration eines GameManagers
    private GameManager gameManager;


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




     private void OnCollisionEnter(Collision collider)
     {
        // Bei bestimmten Wänden um eine Rechtsdrehung zu erzeugen
           if (collider.collider == wand3.GetComponent<Collider>() && wandtreffer == true || 
               collider.collider == wand4.GetComponent<Collider>() && wandtreffer == true || 
               collider.collider == wand9.GetComponent<Collider>() && wandtreffer == true || 
               collider.collider == wand10.GetComponent<Collider>() && wandtreffer == true || 
               collider.collider == wand12.GetComponent<Collider>() && wandtreffer == true)
           {
            // Drehung nach rechts
            transform.Rotate(0.0f, 90.0f, 0.0f);
            // Treffer mit der Wand
            wandtreffer = true;
        }

        // Bei bestimmten Wänden um eine Rechtsdrehung zu erzeugen und danach eine Linksdrehung zu bestimmen
        else if (collider.collider == wand5.GetComponent<Collider>() && wandtreffer == true || 
                    collider.collider == wand6.GetComponent<Collider>() && wandtreffer == true || 
                    collider.collider == wand7.GetComponent<Collider>() && wandtreffer == true ||
                    collider.collider == wand8.GetComponent<Collider>() && wandtreffer == true)
           {
            // Drehung nach rechts
            transform.Rotate(0.0f, 90.0f, 0.0f);
            // Treffer mit der Wand für eine Linksdrehung
            wandtreffer = false;
        }

        // Bei bestimmten Wänden um eine Linksdrehung zu erzeugen
        else if (collider.collider == wand1.GetComponent<Collider>() || 
                 collider.collider == wand5.GetComponent<Collider>() && wandtreffer == false ||
                 collider.collider == wand6.GetComponent<Collider>() && wandtreffer == false || 
                 collider.collider == wand7.GetComponent<Collider>() && wandtreffer == false)
           {
            // Drehung nach Links
               transform.Rotate(0.0f, -180.0f, 0.0f);
            // Treffer mit Wand
               wandtreffer = true;
           }


         }


 
        
    }




