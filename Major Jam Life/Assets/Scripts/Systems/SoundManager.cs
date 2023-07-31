using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource sounds;

    public AudioClip clickSFX;
    public AudioClip paperSound;
    public AudioClip pencilScribble;
    public AudioClip stampSFX;
    public AudioClip badpot;
    public AudioClip goodpot;
    public AudioClip mehpot;
    public AudioClip menuTheme;
    public AudioClip levelTheme;

    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponent<AudioSource>();
    }

    public void PlayClickSFX()
    {
        AudioSource.PlayClipAtPoint(clickSFX, transform.position);
    }

    public void PlayPaperSound()
    {
        AudioSource.PlayClipAtPoint(paperSound, transform.position);
    }

    public void PlayPencilScribble()
    {
        AudioSource.PlayClipAtPoint(pencilScribble, transform.position);
    }

    public void PlayStampSFX()
    {
        AudioSource.PlayClipAtPoint(stampSFX, transform.position);
    }

    public void PlayBadPot()
    {
        AudioSource.PlayClipAtPoint(badpot, transform.position);
    }

    public void PlayGoodPot()
    {
        AudioSource.PlayClipAtPoint(goodpot, transform.position);
    }

    public void PlayMehPot()
    {
        AudioSource.PlayClipAtPoint(mehpot, transform.position);
    }

    public void PlayMenuTheme()
    {
        sounds.clip = menuTheme;
        sounds.loop = true;
        sounds.Play(); 
    }

    public void PlayLevelTheme()
    {
        sounds.clip = levelTheme;
        sounds.loop = true;
        sounds.Play();
    }
}
