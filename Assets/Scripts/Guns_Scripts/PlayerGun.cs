using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [Header("Managers")]

    [SerializeField] Transform Muzzle;
    [SerializeField] Animator animator;

    [Header("General Gun Stats")]
    [SerializeField] public List<GameObject> bulletsPrefabs = new List<GameObject>();
    GameObject BulletPrefab;
    private float ShotCoolDown;
    private float ShootSpdMult;
    public bool isShooting;
    private float LastShotTime;

    [Header("Normal Gun")]
    [SerializeField] private float normalShotCoolDown;
    [SerializeField] private float normalShootSpdMult = 2;
    public List<GameObject> normalBullets = new List<GameObject>();

    [Header("Fast Gun")]
    [SerializeField] private float smallShotCoolDown;
    [SerializeField] private float smallShootSpdMult = 3;
    public List<GameObject> fastBullets = new List<GameObject>();

    [Header("Big Gun")]
    [SerializeField] private float bigShotCoolDown;
    [SerializeField] private float bigShootSpdMult = 1;
    public List<GameObject> bigBullets = new List<GameObject>();

    private void Start()
    {
        BulletPrefab = bulletsPrefabs[0];
        ShotCoolDown = normalShotCoolDown;
        ShootSpdMult = normalShootSpdMult;
    }

    void Update()
    {
        WeaponChange();
        ShootHandler();
    }

    private void ShootHandler()
    {
        if (Input.GetAxis("Fire1") > 0 && Time.time - LastShotTime >= ShotCoolDown)
        {
            animator.SetBool("isShooting", true);
            animator.SetFloat("PotFirSpd", ShootSpdMult);

            GameObject currentBullet = null;

            switch (ShootSpdMult)
            {
                case 2:
                    currentBullet = GetBullet(BulletTypes.Potato);
                    break;
                case 3:
                    currentBullet = GetBullet(BulletTypes.Carrot);
                    break;
                case 1:
                    currentBullet = GetBullet(BulletTypes.Watermelon);
                    break;
            }

            currentBullet.transform.position = Muzzle.position;
            currentBullet.transform.rotation = Muzzle.rotation;
            currentBullet.SetActive(true);
            LastShotTime = Time.time;
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }

    GameObject GetBullet(BulletTypes bulletType)
    {
        GameObject newBullet = null;

        switch (bulletType)
        {
            case BulletTypes.Potato:

                foreach (GameObject bullet in normalBullets)
                {
                    if (!bullet.activeSelf) return bullet;
                }
                newBullet = Instantiate(BulletPrefab);
                normalBullets.Add(newBullet);

                break;

            case BulletTypes.Carrot:

                foreach (GameObject bullet in fastBullets)
                {
                    if (!bullet.activeSelf) return bullet;
                }
                newBullet = Instantiate(BulletPrefab);
                fastBullets.Add(newBullet);

                break;

            case BulletTypes.Watermelon:

                foreach (GameObject bullet in bigBullets)
                {
                    if (!bullet.activeSelf) return bullet;
                }
                newBullet = Instantiate(BulletPrefab);
                bigBullets.Add(newBullet);

                break;
        }

        newBullet.SetActive(false);
        return newBullet;
    }

    private void WeaponChange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BulletPrefab = bulletsPrefabs[0];
            ShotCoolDown = normalShotCoolDown;
            ShootSpdMult = normalShootSpdMult;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BulletPrefab = bulletsPrefabs[1];
            ShotCoolDown = smallShotCoolDown;
            ShootSpdMult = smallShootSpdMult;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            BulletPrefab = bulletsPrefabs[2];
            ShotCoolDown = bigShotCoolDown;
            ShootSpdMult = bigShootSpdMult;
        }
    }
}

public enum BulletTypes
{
    Potato,
    Carrot,
    Watermelon
}