using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------------Audio Source---------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------------Audio Clip---------------")]
    public AudioClip background;



    //public AudioClip gameover;

    //public AudioClip jumping;
    //public AudioClip dush001;
    //public AudioClip dush002;
    //public AudioClip dush003;

    //public AudioClip takeDamage;
    //public AudioClip scoreGive001;
    //public AudioClip scoreGive002;
    //public AudioClip DamageHurt001;
    //public AudioClip DamageHurt002;
    //public AudioClip DamageHurt003;
    //public AudioClip 

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}