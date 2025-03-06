using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float maxHP;
    [SerializeField] private float moveSpd;
    [SerializeField] public int damageToPlayer;

    private float currentHP;
    private int direction = -1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
    }

    private void Update()
    {
        Move();
    }

    public void ReduceHP(float damage)
    {
        if (currentHP > 0)
        {
            ScoreManager.instance.addScore(20);
            currentHP = currentHP - damage;
        }
        else
        {
            Kill();
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(direction * moveSpd, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHPController.Instance.ReducePlayerHP(damageToPlayer);
            gameObject.SetActive(false) ;
        }
        else if (collision.gameObject.CompareTag("Wall")) 
        {
            direction *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y); // Invierte el sprite
        }
    }
}
