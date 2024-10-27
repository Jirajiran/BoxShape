using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] soundClips;

    AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void PlayRandomSound()
    {
        if (soundClips.Length > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, soundClips.Length); // ใช้ UnityEngine.Random
            AudioClip randomClip = soundClips[randomIndex];
            audioManager.GetComponent<AudioSource>().PlayOneShot(randomClip);
        }
    }



    // เรียกใช้เมื่อต้องการเล่นเสียงที่สุ่ม
    public void PlayRandomSoundEffect()
    {
        if (!audioManager.GetComponent<AudioSource>().isPlaying) // ตรวจสอบการเล่นเสียงจาก AudioSource
        {
            PlayRandomSound();
        }
    }
}
