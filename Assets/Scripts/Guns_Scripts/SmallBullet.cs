using UnityEngine;

public class SmallBullet : MonoBehaviour
{
    [SerializeField] float speed;
    private float direction = 1f;

    public void SetDirection(float newDirection)
    {
        direction = newDirection;
        transform.localScale = new Vector3(direction, 1, 1);
    }

    void Update()
    {
        transform.Translate(Time.deltaTime * speed * direction, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyManager>().ReduceSmallHP();
            gameObject.SetActive(false);
        }
    }
}
