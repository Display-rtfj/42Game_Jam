using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Script : MonoBehaviour
{

    public GameObject background;
    public List<GameObject> objects;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnObjects();
        }
    }

    void spawnObjects()
    {
        Vector3 size = background.transform.localScale;
        float width = size.x - 0.5f;
        float height = size.y - 0.5f;
        int count = objects.Count - 1;
        while (count >= 0)
        {
            var circle = objects[count];
            float x = Random.Range(-width / 2 + circle.transform.localScale.x / 2, width / 2 - circle.transform.localScale.x / 2);
            float y = Random.Range(-height / 2 + circle.transform.localScale.y / 2, height / 2 - circle.transform.localScale.y / 2);
            Vector3 position = new Vector3(x, y, 1);
            Collider2D colliderX = Physics2D.OverlapCircle(position, circle.transform.localScale.x / 2);
            Collider2D colliderY = Physics2D.OverlapCircle(position, circle.transform.localScale.y / 2);
            if (colliderX == null && colliderY == null)
            {
                Instantiate(circle, position, Quaternion.identity, transform);
                count--;
            }
        }
    }
}
