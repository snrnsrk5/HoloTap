using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManger : MonoBehaviour
{
    public AudioSource[] musicList = null;
    public int i = 0;
    bool userFalse = false;
    private void Awake()
    {
        OnPlay();
    }

    private void Update()
    {
        if (musicList[i].isPlaying == false)
        {
            if(userFalse == false)
            {
                if (i == 6)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
                OnPlay();

            }
        }
    }
    private void OnPlay()
    {
        userFalse = false;
        musicList[i].Play();
    }
    public void Play()
    {
        if (userFalse == true)
        {
            musicList[i].Play();
            userFalse = false;
        }
    }
    public void Random()
    {
        if (userFalse == true)
        {
            musicList[i].Play();
            userFalse = false;
        }
    }
    public void Pause()
    {
        userFalse = true;
        musicList[i].Pause();
    }
    public void Next()
    {
        userFalse = true;
        musicList[i].Stop();
        if (i == 6)
        {
            i = 0;
        }
        else
        {
            i++;
        }
        musicList[i].Play();
        userFalse = false;
    }
    public void Back()
    {
        userFalse = true;
        musicList[i].Stop();
        if (i == 0)
        {
            i = 6;
        }
        else
        {
            i--;
        }
        musicList[i].Play();
        userFalse = false;
    }
}
