using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombScript : MonoBehaviour
{
    [SerializeField]
    private Collider2D targetObj;
    public int checkbombanim;
    private Animator bombanim;
    private AudioSource expaudio;
    [SerializeField]
    private Text HeartCalctTextField;
    private int HeartCounter;
    // Start is called before the first frame update
    void Start()
    {
        bombanim = this.gameObject.GetComponent<Animator>();
        expaudio = this.gameObject.GetComponent<AudioSource>();
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == targetObj)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 4;
            bombanim.SetInteger("expcheck", 1);
            expaudio.Play();
            int.TryParse(HeartCalctTextField.text, out HeartCounter);
        }
    }

    public void ExplotionRepeatGame()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        bombanim.SetInteger("expcheck", 0);
        if (checkbombanim > 0)
        {
            if (HeartCounter > 0)
            {
                HeartCounter = HeartCounter - 1;
            }
            HeartCalctTextField.text = HeartCounter.ToString();
            checkbombanim = 0;
        }
    }
}
