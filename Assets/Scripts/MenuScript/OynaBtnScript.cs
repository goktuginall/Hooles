using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OynaBtnScript : MonoBehaviour
{
    private AudioSource buttonSound;
    // Start is called before the first frame update
    void Start()
    {
        buttonSound = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChngSahne()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void BtnSound()
    {
        buttonSound.Play();
    }
}
