using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public EnemyData data;
    public GameObject target;

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
