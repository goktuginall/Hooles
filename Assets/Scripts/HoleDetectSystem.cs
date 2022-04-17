using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleDetectSystem : MonoBehaviour
{
    public int checkthehole;
    public float xPose, yPose;
    public Collider2D[] findhole;
    private int LastHole;
    public int LvlCmpltSystem;

    void Start()
    {
        LastHole = findhole.Length;
        LvlCmpltSystem = 0;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for(int i = 0; i < findhole.Length; i++)
        {
            if(collision == findhole[i])
            {
                xPose = findhole[i].gameObject.transform.position.x;
                yPose = findhole[i].gameObject.transform.position.y;
                checkthehole = 1;
            }
        }
        if (collision == findhole[findhole.Length - 1])
        {
            LvlCmpltSystem = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        checkthehole = 0;
    }
}
