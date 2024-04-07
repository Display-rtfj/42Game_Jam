using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{

    public float            speed = 20f;
    private Vector3         targetPosition;

    public GameObject       totemLight;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            return;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Totem"))
        {
            if(!other.GetComponent<Totem>().activated)
                other.GetComponent<Totem>().activated = true;
            Destroy(gameObject);
            return;
        }
    }
    private Vector3 direction;
    void Start()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        direction = (mousePos - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        Camera mainCamera = Camera.main;

        if (!IsObjectVisible(mainCamera, transform.position))
            Destroy(gameObject);
        // Vector3 direction = (targetPosition - transform.position).normalized;
        // transform.Translate(direction * speed * Time.deltaTime, Space.World);
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    bool IsObjectVisible(Camera camera, Vector3 worldPosition)
    {
        // Convert the world position of the object to screen space
        Vector3 screenPosition = camera.WorldToViewportPoint(worldPosition);

        // Check if the object's screen position is within the viewport
        return screenPosition.x >= 0 && screenPosition.x <= 1 &&
               screenPosition.y >= 0 && screenPosition.y <= 1 &&
               screenPosition.z > 0; // Ensure the object is in front of the camera
    }
}

