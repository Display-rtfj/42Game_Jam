using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public interface IAcion
{
    void Action(Color color, GameObject target);
    void SetColor(Color color);
}

public class PlayerMovement : MonoBehaviour, IAcion
{
    public float    speed = 5.0f;
    public float    xInput;
    public float    yInput;
    public float    orbitRadius = 1;
    public float    orbitSpeed = 50f;
    public GameObject      power;
    public Color colorPower;
    public List<Color> colors;
    public int life = 1000;
    public int lifeMax = 1000;
    public Light2D lightHeader; 

    public GameObject Ilumination;

    public AudioClip audioClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = 0.15f;
        // addChildrenOrbit();
        GameMenu.life += (value) =>
        {
            life += value;
        };
        GameMenu.setLife(life);
        GameMenu.lifeMax(lifeMax);
        SetColor(colorPower);
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
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        Ilumination.transform.position = transform.position;

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            colorSelect++;
            if (colorSelect >= colors.Count)
                colorSelect = 0;
        }*/
    }


    private void InstantiatePower()
    {
        if (!power)
            return;
        GameObject  gameObject = Instantiate(power, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(audioClip);
        attack a = gameObject.GetComponent<attack>();
        if (a)
        {
            a.SetColor(colorPower);
            a.parent = this.gameObject;
        }
    
    }

    public void Action(Color color, GameObject target)
    {
        if (color == Color.black)
            GameMenu.life(-1);
    }

    public void SetColor(Color color)
    {
        colorPower = color;
        lightHeader.color = color;
    }
}
