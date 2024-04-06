using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTravel : MonoBehaviour
{
    public GameObject Light;

    public float launchDistance = 5f;
    public float speed = 10f;

    void start() {
        // Light = Resources.Load<GameObject>("Light");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Light)
            LaunchProjectile();
    }

    void LaunchProjectile()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        GameObject projectile = Instantiate(Light, transform.position, Quaternion.identity);
        StartCoroutine(MoveProjectile(projectile, mousePosition));
    }

    System.Collections.IEnumerator MoveProjectile(GameObject projectile, Vector3 targetPosition)
    {
        Vector3 startPosition = projectile.transform.position;
        Vector3 direction = (targetPosition - startPosition).normalized;
        float elapsedTime = 0;
        float distance = (targetPosition - startPosition).magnitude;
        float travelTime = distance / speed;

        while (elapsedTime < travelTime)
        {
            projectile.transform.position = Vector3.MoveTowards(projectile.transform.position, targetPosition, speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(projectile);
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     SpriteRenderer otherSpriteRenderer = other.GetComponent<SpriteRenderer>();
    //     Color color = otherSpriteRenderer.color;
    //     changeTrailColor(color);
    //     Debug.Log("Hit: " + other.name);
    // }

    // void    changeTrailColor(Color color) {
    //     Gradient gradient = new Gradient();
        
    //     float time = Mathf.Clamp01((Time.time - timeOfLastChange) / trailRenderer.time);
    //     timeOfLastChange = Time.time;

    //     GradientColorKey[] colorKeys = new GradientColorKey[2];
    //     colorKeys[0] = new GradientColorKey(trailRenderer.startColor, 0f);
    //     colorKeys[1] = new GradientColorKey(color, time);

    //     GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
    //     alphaKeys[0] = new GradientAlphaKey(trailRenderer.startColor.a, 0f);
    //     alphaKeys[1] = new GradientAlphaKey(color.a, time);

    //     gradient.SetKeys(colorKeys, alphaKeys);
    //     trailRenderer.colorGradient = gradient;
    // }

}
