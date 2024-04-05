using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public EnemyData data;
    private GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        var renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = data.sprite;
        renderer.color = data.color;

    }

    void Update()
    {
        Movimenent();
    }

    private void Movimenent()
    {
        if (target != null)
        {
            var direction = target.transform.position - transform.position;
            transform.position += direction.normalized * data.speed * Time.deltaTime;
        }
    }
}
