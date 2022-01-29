using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 weaponPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition.x -= weaponPosition.x;
        mousePosition.y -= weaponPosition.y;
        float weaponAngle = Mathf.Atan2(mousePosition.y,mousePosition.x) * Mathf.Rad2Deg;

        if(transform.position.x > Camera.main.ScreenToWorldPoint(Input.mousePosition).x){
            transform.rotation = Quaternion.Euler(new Vector3(180f,0f,-weaponAngle));
        }else{
            transform.rotation = Quaternion.Euler(new Vector3(0f,0f,weaponAngle));
        }
    }
}
