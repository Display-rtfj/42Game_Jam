using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class attack : MonoBehaviour
{

    public float            speed = 20f;
    private Color            color;
    private Vector3         direction;


    void Start()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        direction = (mousePos - transform.position).normalized;
    }

    void Update()
    {
        Camera mainCamera = Camera.main;

        if (!IsObjectVisible(mainCamera, transform.position))
            Destroy(gameObject);
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

    public Color GetColor() { return color; }

    public void SetColor(Color color)
    {
        this.color = color;
        GetComponent<Light2D>().color = color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<IAcion>()?.Action(color);
        Destroy(this.gameObject);
    }

}

