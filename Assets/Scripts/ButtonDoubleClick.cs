using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDoubleClick : MonoBehaviour
{
    [SerializeField] private Sprite OnSprite, OffSprite;
    [SerializeField] private SoundManager SoundManager;
    [SerializeField] private SoundGenre SesTuru;
    private Button ThisButton;
    private int SfxChangeValue, MusicChangeValue;
    private enum SoundGenre
    {
        Music,
        Sfx,
    }
    void Start()
    {
        ThisButton = this.gameObject.GetComponent<Button>();
        if (SesTuru == SoundGenre.Music)
        {
            ThisButton.onClick.AddListener(MusicChangeSprite);
            if (SoundManager.MusicVariable == 0)
            {
                MusicChangeValue = 0;
                MusicChangeSprite();
            }
            else if (SoundManager.MusicVariable == 1)
            {
                MusicChangeValue = 1;
                MusicChangeSprite();
            }
        }
        else if (SesTuru == SoundGenre.Sfx)
        {
            ThisButton.onClick.AddListener(SfxChangeSprite);
            if (SoundManager.SfxVariable == 0)
            {
                SfxChangeValue = 0;
                SfxChangeSprite();
            }
            else if (SoundManager.SfxVariable == 1)
            {
                SfxChangeValue = 1;
                SfxChangeSprite();
            }
        }
    }
    private void MusicChangeSprite()
    {
        MusicChangeValue++;
        if (MusicChangeValue == 1)
        {
            ThisButton.image.sprite = OffSprite;
        }
        else if (MusicChangeValue == 2)
        {
            ThisButton.image.sprite = OnSprite;
            MusicChangeValue = 0;
        }
    }
    private void SfxChangeSprite()
    {
        SfxChangeValue++;
        if (SfxChangeValue == 1)
        {
            ThisButton.image.sprite = OffSprite;
        }
        else if (SfxChangeValue == 2)
        {
            ThisButton.image.sprite = OnSprite;
            SfxChangeValue = 0;
        }
    }
}
