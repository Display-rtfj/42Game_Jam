using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMovement : MonoBehaviour
{
    public float orbitSpeed = 50f;
    public float orbitRadius = 1;
    public float initialAngleDegrees = 0f;

    private float orbitAngle;

    private void Start() {
        orbitAngle = initialAngleDegrees;

        float rad = orbitAngle * Mathf.Deg2Rad;

        Vector3 orbitPosition = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * orbitRadius;
        transform.localPosition = orbitPosition;
    }

    void Update()
    {
        orbitAngle += orbitSpeed * Time.deltaTime;

        float rad = orbitAngle * Mathf.Deg2Rad;

        Vector3 orbitPosition = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * orbitRadius;
        transform.localPosition = orbitPosition;
    }
}
