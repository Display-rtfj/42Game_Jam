using UnityEngine;

public class BaseEnemy : MonoBehaviour, IAcion
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

    public void Action(Color color)
    {
        GameMenu.deads(1);
        GameMenu.score(10);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<IAcion>()?.Action(Color.black);
    }

}
