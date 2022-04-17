using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarScript : MonoBehaviour
{
    private float Value1, Value2, value3;
    [SerializeField]
    private GameObject BarValue;
    [SerializeField]
    private Sprite scrollimg1, scrollimg2, scrollimg3, scrollimg4;
    // Start is called before the first frame update
    void Start()
    {
        Value1 = 0.27530f;
        Value2 = 0.57530f;
        value3 = 0.87530f;
    }

    // Update is called once per frame
    void Update()
    {
        if (BarValue.gameObject.GetComponent<Scrollbar>().value < Value1)
        {
            this.gameObject.GetComponent<Image>().sprite = scrollimg1;
        }
        else if (BarValue.gameObject.GetComponent<Scrollbar>().value > Value1 && BarValue.gameObject.GetComponent<Scrollbar>().value < Value2)
        {
            this.gameObject.GetComponent<Image>().sprite = scrollimg2;
        }
        else if(BarValue.gameObject.GetComponent<Scrollbar>().value > Value2 && BarValue.gameObject.GetComponent<Scrollbar>().value < value3)
        {
            this.gameObject.GetComponent<Image>().sprite = scrollimg3;
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = scrollimg4;
        }
    }
}
