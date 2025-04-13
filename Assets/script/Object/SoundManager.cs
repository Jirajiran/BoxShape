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
            int randomIndex = UnityEngine.Random.Range(0, soundClips.Length); // �� UnityEngine.Random
            AudioClip randomClip = soundClips[randomIndex];
            audioManager.GetComponent<AudioSource>().PlayOneShot(randomClip);
        }
    }



    // ���¡������͵�ͧ���������§�������
    public void PlayRandomSoundEffect()
    {
        if (!audioManager.GetComponent<AudioSource>().isPlaying) // ��Ǩ�ͺ���������§�ҡ AudioSource
        {
            PlayRandomSound();
        }
    }
}
