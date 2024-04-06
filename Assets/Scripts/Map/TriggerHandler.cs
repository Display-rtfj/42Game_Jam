using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the trigger overlap involves the other GameObject
        if (other.CompareTag("Background"))
        {
            Debug.Log("Collision detected with Background!");
        }
    }
}