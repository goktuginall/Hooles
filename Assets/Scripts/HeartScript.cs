using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartScript : MonoBehaviour
{
    public int checheckanim, counter;
    public Collider2D triggerTarget;
    private Animator ThisObjAnim;
    public Text counterText;
    private AudioSource heartSound;

    void Start()
    {
        ThisObjAnim = this.gameObject.GetComponent<Animator>();
        heartSound = this.gameObject.GetComponent<AudioSource>();
        checheckanim = 0;
    }

    private void FixedUpdate()
    {
        if (checheckanim == 1)
        {
            ThisObjAnim.SetInteger("heartexp", 0);
            this.gameObject.SetActive(false);
            counter = int.Parse(counterText.text);
            counter++;
            counterText.text = counter.ToString();
        }
        else
        {
            checheckanim = 0;
            this.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == triggerTarget)
        {
            ThisObjAnim.SetInteger("heartexp", 1);
            heartSound.Play();
        }
    }
}
