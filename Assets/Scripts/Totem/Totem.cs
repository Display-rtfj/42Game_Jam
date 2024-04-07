using System;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Totem : MonoBehaviour, IAcion
{
    public bool activated = false;
    private Light2D light2D;
    public float startTime = -1f;
    private Color color;
    public GameObject border;
    public static Action tokenAcive;

    // Function to check if x seconds have passed since last checked time
    bool HasTimePassed(float seconds)
    {
        if (startTime < 0f)
        {
            // Timer hasn't started yet, start it now
            startTime = Time.time;
            return false; // Return false on the first call
        }
        else
        {
            float elapsedTime = Time.time - startTime;
            return elapsedTime >= seconds;
        }
    }

    void Start()
    {
        light2D = GetComponent<Light2D>();
        light2D.enabled = false;
        border.SetActive(false);
    }

    void Update()
    {
        if (light2D.enabled && HasTimePassed(5))
                Destroy(gameObject);
    }

    public Color GetColor() { return color; }

    public void SetColor(Color color)
    {
        this.color = color;
        GetComponent<SpriteRenderer>().color = color;
    }


    public void Action(Color color, GameObject target)
    {
        if (!light2D.enabled)
        {
            tokenAcive.Invoke();
            border.SetActive(true);
            light2D.color = this.color;
            light2D.enabled = true;
            target.GetComponent<IAcion>()?.SetColor(this.color);
        }
    }
}