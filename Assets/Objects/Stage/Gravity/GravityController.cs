using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {
    public float gravityAngle;

    void OnTriggerEnter2D(Collider2D collision)
    {
        var ctrl = collision.gameObject.GetComponent<PlayerController>();
        if (ctrl != null)
            ctrl.rotateGravity = gravityAngle;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //var ctrl = collision.gameObject.GetComponent<PlayerController>();
        //if (ctrl != null)
        //    ctrl.rotateGravity = 0;
    }
}
