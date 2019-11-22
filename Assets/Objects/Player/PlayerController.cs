using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 780f;
    float walkForce = 80f;
    float maxWalkSpeed = 5f;
    float threshold = .2f;

    float gravityScale = 3;
    public bool downForceEnabled = false;
    float downForce = 3;

    [SerializeField]
    ContactFilter2D filter2d;

    public float rotateGravity = 0;
    Vector2 localGravity
    {
        get
        {
            var gravityAngle = Quaternion.Euler(0, 0, rotateGravity);
            var gravityVector = gravityAngle * Vector2.down;
            return gravityVector * 9.8f * (gravityScale + (downForceEnabled ? downForce : 0));
        }
    }

    // Use this for initialization
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        rigid2D.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 回転
        float currentRotate = transform.eulerAngles.z;
        var playerAngleEuler = transform.eulerAngles;
        playerAngleEuler.z = Mathf.LerpAngle(currentRotate, rotateGravity, 0.15f);
        transform.eulerAngles = playerAngleEuler;

        var gravityAngle = Quaternion.Euler(0, 0, rotateGravity);
        var velocity = gravityAngle * this.rigid2D.velocity;
        float speedx = Mathf.Abs(velocity.x);
        var filter2dRot = filter2d;
        filter2dRot.useNormalAngle = false;
        //float min = Mathf.Repeat(filter2d.minNormalAngle + rotateGravity, 360);
        //float max = Mathf.Repeat(filter2d.maxNormalAngle + rotateGravity, 360);
        //filter2dRot.SetNormalAngle(Mathf.Min(min, max), Mathf.Max(min, max));
        bool onGrounds = rigid2D.IsTouching(filter2dRot);
        bool jumpButtonDown = Input.GetButtonDown("Jump");
        bool jumpButton = Input.GetButton("Jump");

        // キーコントロール
        int keyoffset = (int)((currentRotate + 45) / (360 / 4));
        // ジャンプ
        {
            if (jumpButtonDown && onGrounds)
            {
                this.animator.SetTrigger("JumpTrigger");
                this.animator.speed = 1f;
                this.rigid2D.AddForce(transform.up * this.jumpForce);

                var audio = GetComponent<AudioSource>();
                if (audio != null)
                    audio.Play();

                downForceEnabled = false;
            }
            if (!jumpButton)
                downForceEnabled = true;
            if (velocity.y <= 0.01f)
                downForceEnabled = false;
        }
        // 移動
        {
            float[] keyrotate = {
                Input.GetAxis("Vertical"),
                -Input.GetAxis("Horizontal"),
                -Input.GetAxis("Vertical"),
                Input.GetAxis("Horizontal")
            };
            float key = keyrotate[(keyoffset + 3 + 4) % 4];
            if (speedx < this.maxWalkSpeed)
                this.rigid2D.AddForce(transform.right * key * walkForce);
            if (key != 0)
                transform.localScale = new Vector3(key < 0 ? -1 : 1, 1, 1);
        }

        this.animator.SetBool("JumpEndFlag", onGrounds);

        if (!onGrounds || !this.animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Walk"))
            this.animator.speed = 1f;
        else
            this.animator.speed = speedx / 2f;
    }

    void FixedUpdate()
    {
        rigid2D.AddForce(localGravity * rigid2D.mass);
    }
}
