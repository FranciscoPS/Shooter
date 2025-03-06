using UnityEngine;

public class PlayerHPController : MonoBehaviour
{
    public static PlayerHPController Instance;
    [SerializeField] Animator animator;
    [SerializeField] UIManager uIManager;
    [SerializeField] int MaxHP;
    int currentHP;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {

        currentHP = MaxHP;
        uIManager.UpdateHPText(currentHP);
    }

    public void ReducePlayerHP(int dmg)
    {
        animator.SetTrigger("gotHit");

        currentHP = currentHP - dmg;
        if (currentHP > 0)
        {
            uIManager.UpdateHPText(currentHP);
        }
        else
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        gameObject.SetActive(false);
        uIManager.EnableGameOver(true);
        InputManager.PlayerInput.gameObject.SetActive(false);
        EnemySpawner.Instance.DeactivateSpawner();
    }
}
