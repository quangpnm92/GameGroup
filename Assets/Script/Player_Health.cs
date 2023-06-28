using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public float health;
    public float maxhealth;
    public Image healthBar;
    // Start is called before the first frame update

    private Animator animator;
    private Rigidbody2D rb;
    [SerializeField] public Text healthText;

    [SerializeField] private AudioSource deathSound;

    private void Start()
    {
        maxhealth = health;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthText.text = "100%";

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            healthBar.fillAmount = Mathf.Clamp(health / maxhealth, 0, 1);
            healthText.text = health + "%";

            if (health <= 0)
            {
                Die();
            }
        }
    }
    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        deathSound.Play();
        animator.SetTrigger("death");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
