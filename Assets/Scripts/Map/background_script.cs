using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class background : MonoBehaviour
{
    public int width;
    public int height;
    public Tile backgroundTile;

    void Start()
    {
        PaintTilesUntilCameraEdges();
    }

    void Update()
    {
        PaintTilesUntilCameraEdges();
    }

    void PaintTilesUntilCameraEdges()
    {
        Camera mainCamera = Camera.main;
        Vector3 cameraPosition = mainCamera.transform.position;
        float cameraHeight = 2.56f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        Vector3 bottomLeft = cameraPosition - new Vector3(cameraWidth / 2.56f, cameraHeight / 2.56f);
        Vector3 topRight = cameraPosition + new Vector3(cameraWidth / 2.56f, cameraHeight / 2.56f);

        Tilemap tilemap = GetComponent<Tilemap>();

        for (int x = Mathf.FloorToInt(bottomLeft.x); x < Mathf.CeilToInt(topRight.x); x++)
        {
            for (int y = Mathf.FloorToInt(bottomLeft.y); y < Mathf.CeilToInt(topRight.y); y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                tilemap.SetTile(tilePosition, backgroundTile);
            }
        }
    }
}
