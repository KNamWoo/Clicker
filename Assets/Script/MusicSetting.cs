using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicSetting : GameManager
{//Audio 관련 코드 : https://url.kr/e73cos
    // Start is called before the first frame update
    public float SF_value;

    public AudioSource BGMAS;//BGMAudioSource
    public AudioSource SFXAS;
    public AudioClip audioClip;

    public Slider bgmVolSet;
    public Slider sfxVolSet;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            SoundLoad();
            bgmVolSet.value = BGM_value;
            sfxVolSet.value = SFX_value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BGM_value = bgmVolSet.value;
        BGMAS.volume = BGM_value;

        SFX_value = sfxVolSet.value;
        SFXAS.volume = SFX_value;
    }
}