using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsScript : MonoBehaviour
{
    public int chkanim, starcounter;
    public Collider2D targetTrigger;
    private Animator staranim;
    public Text starcounterText;
    private AudioSource starsSound;
    // Start is called before the first frame update
    void Start()
    {
        staranim = this.gameObject.GetComponent<Animator>();
        starsSound = this.gameObject.GetComponent<AudioSource>();
        chkanim = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (chkanim == 1)
        {
            staranim.SetInteger("starExp", 0);
            this.gameObject.SetActive(false);
            starcounter = int.Parse(starcounterText.text);
            starcounter++;
            starcounterText.text = starcounter.ToString();
        }
        else
        {
            chkanim = 0;
            this.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == targetTrigger)
        {
            staranim.SetInteger("starExp", 1);
            starsSound.Play();
        }
    }
}
