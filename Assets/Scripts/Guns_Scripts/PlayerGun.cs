using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] Transform Muzzle;
    GameObject BulletPrefab;
    [SerializeField] Animator animator;

    float ShootSpdMult; //Para animaciones
    float ShootCD;

    bool isShooting;

    float LastShotTime;
    List<GameObject> BulletsPool = new List<GameObject>();
    [SerializeField] List<GameObject> bulletsPrefab = new List<GameObject>();

    private void Start()
    {
        BulletPrefab = bulletsPrefab[0];
        ShootCD = 0.35f;
        ShootSpdMult = 2;
    }

    // Update is called once per frame
    void Update()
    {
        WeaponChange();
        ShootHandler();
    }

    private void ShootHandler()
    {
        if (Input.GetAxis("Fire1") > 0 && Time.time - LastShotTime >= ShootCD)
        {
            animator.SetBool("isShooting", true);
            animator.SetFloat("PotFirSpd", ShootSpdMult);
            //animator.SetTrigger("shoot");
            GameObject Bullet = GetBullet();

            Bullet.transform.position = Muzzle.position;
            Bullet.transform.rotation = Muzzle.rotation;
            Bullet.SetActive(true);
            LastShotTime = Time.time;
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }

    GameObject GetBullet()
    {
        /*foreach (GameObject Bullet in BulletsPool)
        {
            if (!Bullet.activeSelf) return Bullet;
        }*/
        GameObject NewBullet = Instantiate(BulletPrefab);
        NewBullet.SetActive(false);
        /*BulletsPool.Add(NewBullet);*/
        return NewBullet;
    }

    private void WeaponChange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))   //Para activar el lanza papas
        {
            BulletPrefab = bulletsPrefab[0];
            ShootCD = 0.35f;
            ShootSpdMult = 2;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))  //Para activar el lanza Zanahorias
        {
            BulletPrefab = bulletsPrefab[1];
            ShootCD = 0.2f;
            ShootSpdMult = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            BulletPrefab = bulletsPrefab[2];
            ShootCD = 0.6f;
            ShootSpdMult = 1;
        }
    }
}
