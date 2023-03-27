using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{

    public Transform playerTransform;
    public float deathHeight = -10f;
    public Vector3 spawnPosition = new(0f, -3.6f, 0f);

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y < deathHeight)
        {
            //Spieler fältt aus der Welt
            Respawn();
        }
    }
    
    void Respawn()
    {
        playerTransform.position = spawnPosition;
    }
}
