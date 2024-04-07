using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IAcion
{
    void Action(Color color);
}

public class PlayerMovement : MonoBehaviour
{
    public float    speed = 5.0f;
    public float    xInput;
    public float    yInput;
    public float    orbitRadius = 1;
    public float    orbitSpeed = 50f;
    public GameObject      power;
    private int colorSelect = 0;
    public List<Color> colors;

    public GameObject Ilumination;

    void Start()
    {
        // addChildrenOrbit();
    }

    void addChildrenOrbit() {
        int numberOfChildren = transform.childCount;
        for (int i = 0; i < numberOfChildren; i++)
        {
            Transform child = transform.GetChild(i);
            // child.gameObject.AddComponent<RayToMouse>();
            // child.gameObject.AddComponent<LineRenderer>();
            child.gameObject.AddComponent<CircleCollider2D>();
            OrbitMovement orbitScript = child.gameObject.AddComponent<OrbitMovement>();

            orbitScript.orbitRadius = this.orbitRadius;
            orbitScript.orbitSpeed = this.orbitSpeed;
            orbitScript.initialAngleDegrees = (360f / numberOfChildren) * i;
        }

    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && power)
            InstantiatePower();
         xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(xInput, yInput, 0);

        movementDirection.Normalize();
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        // if (movementDirection != Vector3.zero)
        // {
        //     // Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        //     // transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, speed * Time.deltaTime);
        // }
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        Ilumination.transform.position = transform.position;

        if (Input.GetKeyDown(KeyCode.E))
        {
            colorSelect++;
            if (colorSelect >= colors.Count)
                colorSelect = 0;
        }
    }


    private void InstantiatePower()
    {
        if (!power)
            return;
        GameObject  gameObject = Instantiate(power, transform.position, Quaternion.identity);
        gameObject.GetComponent<attack>()?.SetColor(colors[colorSelect]);
    }
}
