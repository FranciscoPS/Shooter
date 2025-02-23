using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public void Kill()
    {
        gameObject.SetActive(false);
    }
}
