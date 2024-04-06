using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTravel : MonoBehaviour
{
    public GameObject       Light;
    public TrailRenderer    trailRenderer;
    public float            speed = 20f;
    private Vector3         targetPosition;

    void Start() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        targetPosition = mousePos;
    }

    void Update()
    {
        if (transform.position == targetPosition)
            Destroy(gameObject);
            // return ;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SpriteRenderer otherSpriteRenderer = other.GetComponent<SpriteRenderer>();
        Color color = otherSpriteRenderer.color;
        this.GetComponent<SpriteRenderer>().color = color;
        // this.GetComponent<halo>().color = color;
        trailRenderer.startColor = color;
        trailRenderer.endColor = color;
    }
}
