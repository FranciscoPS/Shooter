using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] Transform Muzzle;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] float ShootCD;
    [SerializeField] Animator animator;

    float LastShotTime;
    List<GameObject> BulletsPool = new List<GameObject>();



    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && Time.time - LastShotTime >= ShootCD)
        {
            animator.SetTrigger("shoot");
            GameObject Bullet = GetBullet();
            Bullet.transform.position = Muzzle.position;
            Bullet.SetActive(true);
            LastShotTime = Time.time;
        }
    }

    GameObject GetBullet()
    {
        foreach (GameObject Bullet in BulletsPool)
        {
            if (!Bullet.activeSelf) return Bullet;
        }
        GameObject NewBullet = Instantiate(BulletPrefab);
        NewBullet.SetActive(false);
        BulletsPool.Add(NewBullet);
        return NewBullet;
    }
}
