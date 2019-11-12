using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGravity : MonoBehaviour {
    CircleCollider2D circle2d;
    Collider2D col2d;
    PlayerController player;

	// Use this for initialization
	void Start () {
        player = GameDirector.Get().player;
        circle2d = GetComponent<CircleCollider2D>();
        col2d = player.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update () {
        if (circle2d.IsTouching(col2d))
        {
            Vector2 sub = player.transform.position - transform.position;
            player.rotateGravity = Mathf.Atan2(sub.y, sub.x) * Mathf.Rad2Deg - 90;
            Debug.Log("Sub:" + sub + ", Rot:" + player.rotateGravity);
        }
	}
}
