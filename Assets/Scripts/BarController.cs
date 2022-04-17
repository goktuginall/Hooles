using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    private float movevalue, BarUpLastPos, BarDownLastPos;
    private bool DownControlScore;
    public float rotmultipler, movemultipler, BarScoreTopLimit;
    public GameObject getvalueobj;
    private HoleDetectSystem getvaluescript;
    private float maxSolAxis, maxSagAxis, maxYukariAxis, maxAssagiAxis;
    private int solAxis, sagAxis, yukariAxis, assagiAxis, gmScore;
    private AudioSource MoveSound;
    [SerializeField] private Text GameSocreText;


    void Start()
    {
        maxSolAxis = 0.14f;
        maxSagAxis = -0.14f;
        maxAssagiAxis = -2.8f;
        maxYukariAxis = 3.5f;
        getvaluescript = getvalueobj.gameObject.GetComponent<HoleDetectSystem>();
        MoveSound = this.gameObject.GetComponent<AudioSource>();
        gmScore = 0;
        BarUpLastPos = this.gameObject.transform.position.y;
        DownControlScore = false;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        LoseControl();
        GameSocreText.text = gmScore.ToString();
        if (solAxis == 1)
        {
            if (this.transform.rotation.z < maxSolAxis)
            {
                movevalue = Time.deltaTime * rotmultipler;
                this.transform.Rotate(Vector3.forward * movevalue, Space.World);
            }
            else
            {
                TurnSoundControl(0);
            }
        }

        if(sagAxis == 1)
        {
            if (this.transform.rotation.z > maxSagAxis)
            {
                movevalue = Time.deltaTime * rotmultipler;
                this.transform.Rotate(Vector3.back * movevalue, Space.World);
            }
            else
            {
                TurnSoundControl(0);
            }
        }

        if (yukariAxis == 1)
        {
            if(this.transform.position.y < maxYukariAxis)
            {
                movevalue = Time.deltaTime * movemultipler;
                this.transform.Translate(Vector2.up * movevalue, Space.World);
                if (this.gameObject.transform.position.y > BarUpLastPos)
                {
                    gmScore += 3;
                    BarUpLastPos = this.gameObject.transform.position.y;
                    if (this.gameObject.transform.position.y > BarScoreTopLimit)
                    {
                        DownControlScore = true;
                        BarDownLastPos = this.gameObject.transform.position.y;
                    };
                }
            }
            else
            {
                UpSoundControl(0);
            }
        }

        if (assagiAxis == 1)
        {
            if (this.transform.position.y > maxAssagiAxis)
            {
                movevalue = Time.deltaTime * movemultipler;
                this.transform.Translate(Vector2.down * movevalue, Space.World);
                if (DownControlScore == true)
                {
                    if (this.gameObject.transform.position.y < BarDownLastPos)
                    {
                        gmScore += 3;
                        BarDownLastPos = this.gameObject.transform.position.y;
                    }
                }
            }
            else
            {
                DownSoundControl(0);
            }
        }
    }

    private void LoseControl()
    {
        if (getvaluescript.checkthehole == 1)
        {
            if (this.gameObject.transform.position.y > -3)
            {
                this.gameObject.transform.position -= new Vector3(0, 0.18f, 1f);
            }
        }
    }

    private void UpSoundControl(int Uvalue)
    {
        if (Uvalue == 1)
        {
            if (!MoveSound.isPlaying)
            {
                MoveSound.pitch = 0.7f;
                MoveSound.Play();
            }
        }
        else
        {
            MoveSound.Stop();
        }
    }

    private void DownSoundControl(int Dvalue)
    {
        if (Dvalue == 1)
        {
            if (!MoveSound.isPlaying)
            {
                MoveSound.pitch = 1f;
                MoveSound.Play();
            }
        }
        else
        {
            MoveSound.Stop();
        }
    }

    private void TurnSoundControl(int Tvalue)
    {
        if (Tvalue == 1)
        {
            if (!MoveSound.isPlaying)
            {
                MoveSound.pitch = 1.5f;
                MoveSound.Play();
            }
        }
        else
        {
            MoveSound.Stop();
        }
    }

    public void solAxisFunc(int value)
    {
        solAxis = value;
        TurnSoundControl(value);
    }

    public void sagAxisFunc(int value)
    {
        sagAxis = value;
        TurnSoundControl(value);
    }

    public void yukariAxisFunc(int value)
    {
        yukariAxis = value;
        UpSoundControl(value);
    }

    public void assagiAxisFunc(int value)
    {
        assagiAxis = value;
        DownSoundControl(value);
    }
}
