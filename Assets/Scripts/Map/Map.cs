using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Script : MonoBehaviour
{

    public GameObject circle;
    public int count = 10;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnObjects();
            count = 10;
        }
    }

    void spawnObjects()
    {
        Vector3 size = transform.localScale;
        float width = size.x - 0.5f;
        float height = size.y - 0.5f;
        while (count > 0)
        {
            float x = Random.Range(-width / 2 + circle.transform.localScale.x / 2, width / 2 - circle.transform.localScale.x / 2);
            float y = Random.Range(-height / 2 + circle.transform.localScale.y / 2, height / 2 - circle.transform.localScale.y / 2);
            Vector3 position = new Vector3(x, y, 1);
            Collider2D collider = Physics2D.OverlapCircle(position, circle.transform.localScale.x / 2);
            if (collider == null)
            {
                GameObject newCircle = Instantiate(circle, position, Quaternion.identity, transform);
                newCircle.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                count--;
            }
        }
    }
}
