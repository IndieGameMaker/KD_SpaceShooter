using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    void OnCollisionEnter(Collision coll)
    {
        //if (coll.collider.tag == "BULLET")
        if (coll.collider.CompareTag("BULLET"))
        {
            Vector3 hitPoint = coll.GetContact(0).point;
            Vector3 _normal = -coll.GetContact(0).normal;
            Quaternion rot = Quaternion.LookRotation(_normal);

            // 스파크 이펙트 생성
            GameObject spark = Instantiate(sparkEffect, hitPoint, rot);
            Destroy(spark, 0.4f);

            Destroy(coll.gameObject);
        }
    }
}
