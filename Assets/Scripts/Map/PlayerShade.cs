using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShade : MonoBehaviour
{
    public Transform player;
    public SpriteRenderer shadeSprite;
    public float shadeRadius = 2.0f; // Adjust as needed
    
    void Update()
    {
        // Position the shade sprite around the player
        shadeSprite.transform.position = player.position;
        
        // Scale the shade sprite
        shadeSprite.transform.localScale = new Vector3(shadeRadius, shadeRadius, 1.0f);
        
        // Ensure shade sprite is behind player sprite
        shadeSprite.sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder - 1;
    }
}
