using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Transform tr;
    private Animation anim;

    private float h, v, r;

    void Start()
    {
        tr = GetComponent<Transform>(); //제너릭 Generic   GetComponent<T>()
        anim = GetComponent<Animation>(); //레거시 애니메이션
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(dir * Time.deltaTime * 8.0f);
        tr.Rotate(Vector3.up * Time.deltaTime * 200.0f * r);

        PlayerAnim();
    }

    void PlayerAnim()
    {
        if (v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.3f);
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.3f);
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade("RunR", 0.3f);
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade("RunL", 0.3f);
        }
        else
        {
            anim.CrossFade("Idle");
        }
    }

}
