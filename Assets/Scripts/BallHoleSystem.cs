using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BallHoleSystem : MonoBehaviour
{
    private GameObject wichhole;
    public float xPos, yPos;
    public int holechecktrig;

    void Start()
    {
        wichhole = GameObject.FindGameObjectWithTag("HoleDetectTag");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == wichhole.gameObject.tag)
        {
            xPos = this.gameObject.transform.position.x;
            yPos = this.gameObject.transform.position.y;
            holechecktrig = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == wichhole.gameObject.tag)
        {
            holechecktrig = 0;
        }
    }
}
