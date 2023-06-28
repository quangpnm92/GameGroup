using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyArrow : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;

    private float timer;
    public float damage;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10) 
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player_Health>().health -= 20;          
            Destroy(this.gameObject);

            collision.gameObject.GetComponent<Player_Health>().healthBar.fillAmount = Mathf.Clamp(collision.gameObject.GetComponent<Player_Health>().health / collision.gameObject.GetComponent<Player_Health>().maxhealth, 0, 1);
            collision.gameObject.GetComponent<Player_Health>().healthText.text = collision.gameObject.GetComponent<Player_Health>().health + "%";

            if (collision.gameObject.GetComponent<Player_Health>().health <= 0)
            {
                collision.gameObject.GetComponent<Player_Health>().Die();
            }
        }
    }
}
