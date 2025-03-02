using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] float maxHP;
    [SerializeField] private float moveSpd;
    [SerializeField] private float dmg;

    float currentHP;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
    }

    private void Update()
    {
        Move();
    }

    public void ReduceHP()
    {
        if (currentHP > 0)
        {
            currentHP--;
        }
        else
        {
            Kill();
        }
    }

    public void ReduceSmallHP()
    {
        if (currentHP > 0)
        {
            currentHP = currentHP - 0.5f;
        }
        else
        {
            Kill();
        }
    }

    public void ReduceBigHP()
    {
        if (currentHP > 0)
        {
            currentHP = currentHP - 4f;
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
        rb.linearVelocity = new Vector2(-1 * moveSpd, 0);
    }
}
