using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InfiniteMap : MonoBehaviour
{

    public Camera mainCamera;
    public GameObject background;
    void Update()
    {
        CheckCameraEdges();
    }

    private void CheckCameraEdges()
    {
        // Get the camera's viewport coordinates
        Vector3 cameraMin = mainCamera.ViewportToWorldPoint(Vector3.zero);
        Vector3 cameraMax = mainCamera.ViewportToWorldPoint(Vector3.one);

        Debug.Log("Camera min: " + cameraMin);
        Debug.Log("Camera max: " + cameraMax);
        Debug.Log("Background bounds: " + background.GetComponent<Renderer>().bounds);
        Debug.Log("Background min: " + background.GetComponent<Renderer>().bounds.min);
        Debug.Log("Background max: " + background.GetComponent<Renderer>().bounds.max);
        // Get the background's bounds
        Bounds backgroundBounds = background.GetComponent<Renderer>().bounds;

        // Check if the camera's edges are close to the background's edges
        bool isCloseToLeftEdge = cameraMin.x <= backgroundBounds.min.x;
        bool isCloseToRightEdge = cameraMax.x >= backgroundBounds.max.x;
        bool isCloseToTopEdge = cameraMax.y >= backgroundBounds.max.y;
        bool isCloseToBottomEdge = cameraMin.y <= backgroundBounds.min.y;

        // Do something based on the results
        if (isCloseToLeftEdge || isCloseToRightEdge || isCloseToTopEdge || isCloseToBottomEdge)
        {
            Debug.Log("Camera is close to the edge of the background");     
        }
    }
}

