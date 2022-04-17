using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rigid;
    public GameObject ballintrigger;
    private HoleDetectSystem _checkthehole;
    public Collider2D otherObj, soundStopObj1, soundStopObj2;
    private int collisiondetecd, bigsmallsystem, bigballsystemcheck, triggerForSound;
    private float xPos, yPos;
    private AudioSource ballroll;

    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        ballroll = this.gameObject.GetComponent<AudioSource>();
        xPos = 0;
        yPos = 0;
        bigballsystemcheck = 0;
        _checkthehole = ballintrigger.gameObject.GetComponent<HoleDetectSystem>();
        triggerForSound = 1;
    }

    void Update()
    {
        if (bigballsystemcheck == 1)
        {
            bigsmallsystem = _checkthehole.checkthehole;
        }
    }

    void FixedUpdate()
    {
        if (rigid.velocity.normalized.x > 0.1f || rigid.velocity.normalized.x < -0.1f)
        {
            if (triggerForSound == 1)
            {
                if (!ballroll.isPlaying)
                {
                    ballroll.Play();
                }
            }
        }
        if (rigid.velocity.normalized.x < 0.1f && rigid.velocity.normalized.x > -0.1f || triggerForSound == 0)
        {
            ballroll.Stop();
        }

        if (rigid.angularVelocity < 0 && rigid.angularVelocity > -900f)
        {
            rigid.angularVelocity *= 1.13f;
        }
        if (rigid.angularVelocity > 0 && rigid.angularVelocity < 900f)
        {
            rigid.angularVelocity *= 1.13f;
        }

        if (collisiondetecd == 1)
        {
            rigid.gravityScale = 3f;
        }
        else
        {
            rigid.drag = 0;
            rigid.gravityScale = 5f;
        }

        if (this.gameObject.transform.localScale.x < 3f)
        {
            this.gameObject.transform.position = new Vector3(0, 5f, 1f);
            rigid.constraints = RigidbodyConstraints2D.None;
            this.gameObject.transform.localScale = new Vector3(30f, 30f, 1f);
            bigsmallsystem = 0;
            bigballsystemcheck = 0;
        }

        if (bigballsystemcheck == 1)
        {
            if (bigsmallsystem == 1)
            {
                xPos = _checkthehole.xPose;
                yPos = _checkthehole.yPose;
                this.gameObject.transform.position = new Vector3(xPos, yPos, 1);
                rigid.constraints = RigidbodyConstraints2D.FreezeAll;
                this.gameObject.transform.localScale -= new Vector3(1f, 1f, 0f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider == otherObj)
        {
            collisiondetecd = 1;
            bigballsystemcheck = 1;
        }

        if (collision.collider == soundStopObj1 || collision.collider == soundStopObj2)
        {
            triggerForSound = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider == otherObj)
        {
            collisiondetecd = 0;
        }

        if (collision.collider == soundStopObj1 || collision.collider == soundStopObj2)
        {
            triggerForSound = 1;
        }
    }
}
