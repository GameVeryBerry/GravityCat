using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public GameObject background;
    Bounds bounds;

    // Use this for initialization
    void Start () {
        bounds = background.GetComponent<BoxCollider2D>().bounds;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 size = max - min;
        Bounds cBounds = bounds;
        cBounds.Expand(-size);
        Vector3 closest = cBounds.ClosestPoint(player.transform.position);
        transform.position = new Vector3(closest.x, closest.y, transform.position.z);
	}
}
