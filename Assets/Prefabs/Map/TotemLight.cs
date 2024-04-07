using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemLight : MonoBehaviour
{

    private void OntriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Light"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
