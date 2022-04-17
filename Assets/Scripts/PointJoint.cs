using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointJoint : MonoBehaviour
{
    public GameObject joint;
    private float xPosy, yPosy, zPosy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xPosy = this.gameObject.transform.position.x;
        yPosy = joint.gameObject.transform.position.y;
        zPosy = this.gameObject.transform.position.z;
        this.gameObject.transform.position = new Vector3(xPosy, yPosy, zPosy);
    }
}
