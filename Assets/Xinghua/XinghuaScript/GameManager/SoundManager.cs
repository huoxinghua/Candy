using System;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private string bgmName;
    [SerializeField] private Sound[] bgm, sfx;
    [SerializeField] private AudioSource bgmSource, sfxSource;

    private void Start()
    {
        PlayBGM(bgmName);
    }
    private void PlayBGM(string name)
    {
        Sound s = Array.Find(bgm, x => x.name == name);

        if ( s != null)
        {
            bgmSource.clip = s.clip;
            bgmSource.Play();
        }
        else
        {
            Debug.Log("BGM not found");
        }
    }

    private void PlaySFX(string name)
    {
        Sound s = Array.Find(sfx, x => x.name == name);

        if (s != null)
        {
            sfxSource.PlayOneShot(s.clip);
        }
        else
        {
            Debug.Log("SFX not found");
        }
    }
}
