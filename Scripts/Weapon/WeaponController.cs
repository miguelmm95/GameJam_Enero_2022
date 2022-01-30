using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public AudioSource gunSound;
    public bool isShooting;

    public BulletController bullet;
    public float bulletSpeed;
    public int bulletDamage;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    void Update(){
        if(isShooting){
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                gunSound.Play();
                shotCounter = timeBetweenShots;
                Instantiate(bullet, firePoint.position, firePoint.rotation);
            }
        }else{
            shotCounter = 0;
        }
    }
}
