using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    private bool hasLight = false;
    private GameObject myLight;
    public GameObject totemLight;
    public bool activated = false;

    public GameObject Map;
    public GameObject       playerLight;

    public background mapScript;
    private float startTime = -1f;

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
        
    }

    void Update()
    {
        if (activated && !hasLight)
        {
            myLight = Instantiate(totemLight, transform.position, Quaternion.identity);
            myLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = GetComponent<SpriteRenderer>().color;
            hasLight = true;
            mapScript.RestartCoroutine(playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius + 5f);
        }
        if (hasLight)
        {
            if (HasTimePassed(5))
            {
                Destroy(myLight);
                Destroy(gameObject);
            }
        }
    }
}