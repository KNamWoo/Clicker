using System.Collections;
using System.Collections.Generic;
//using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicSetting : MonoBehaviour
{//Audio : https://url.kr/e73cos
    // Start is called before the first frame update
    public AudioSource BGMAS;//BGMAudioSource
    public AudioSource SFXAS;
    public AudioClip start_bgm;
    public AudioClip home_bgm;
    public AudioClip dungeon_bgm;
    
    public AudioClip coin_sfx;
    public AudioClip attack_sfx;

    public Slider bgmVolSet;
    public Slider sfxVolSet;

    public float bgmvol;
    public float sfxvol;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0/* || SceneManager.GetActiveScene().buildIndex == 2*/) {
            GameManager.instance.SoundLoad();
            bgmVolSet.value = GameManager.instance.BGM_value;
            sfxVolSet.value = GameManager.instance.SFX_value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BGMAS.volume = bgmvol;
        bgmvol = bgmVolSet.value;

        SFXAS.volume = sfxvol;
        sfxvol = sfxVolSet.value;
    }

    public void Save() {
        GameManager.instance.BGM_value = bgmvol;
        GameManager.instance.SFX_value = sfxvol;
        GameManager.instance.SoundSave();
    }

    public void Back(){
        bgmVolSet.value = GameManager.instance.BGM_value;
        sfxVolSet.value = GameManager.instance.SFX_value;
    }
}