using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Deklaration einer Zielkoordinate
    public Transform target;

    // Deklaration eines Abstandvektors
    private Vector3 offset;

    private void Awake()
    {
        // Abstand der Kamera = Position von der Kamera - Position des Ziels(Character)
        offset = transform.position - target.transform.position;
    }

    private void LateUpdate()
    {
        // Aktualisiere immer die neue Position vom Ziel zum Offset
        Vector3 newPosition = target.transform.position + offset;
        // Neue Position der Kamera ist der neue Vektor
        transform.position = newPosition;
        
    }

}
