using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public EnemyData data;

    // Start is called before the first frame update
    void Start()
    {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = data.sprite;
        renderer.color = data.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
