using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public bool isShooting;

    public BulletController bullet;
    public float bulletSpeed;
    public int bulletDamage;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    void Update(){
        if(isShooting){

        }
    }
}
