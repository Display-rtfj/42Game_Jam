using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayToMouse : MonoBehaviour
{
    public Camera           mainCamera; 
    private LineRenderer    lineRenderer;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        //     lineRenderer.enabled = !lineRenderer.enabled;
        // if (lineRenderer.enabled)
        //     CastRayTowardsMouse();
    }

    void CastRayTowardsMouse()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = mainCamera.WorldToScreenPoint(transform.position).z;

        Vector3 worldMousePos = mainCamera.ScreenToWorldPoint(mousePos);
        Vector3 direction = (worldMousePos - transform.position).normalized;

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + direction * 100); 

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity))
        {
            lineRenderer.SetPosition(1, hit.point);
        }
    }
}
