using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

//using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicSetting : MonoBehaviour
{//Audio : https://url.kr/e73cos
    // Start is called before the first frame update
    public AudioSource BGMAS;//BGMAudioSource
    public AudioSource SFXAS;
    public AudioClip[] bglist;
    
    public AudioClip coin_sfx;
    public AudioClip attack_sfx;

    public Slider bgmVolSet;
    public Slider sfxVolSet;

    public float bgmvol;
    public float sfxvol;

    public static MusicSetting muse;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) {//start
            GameManager.instance.SoundLoad();
            bgmVolSet.value = GameManager.instance.BGM_value;
            sfxVolSet.value = GameManager.instance.SFX_value;
            //BGMAS.clip = start_bgm;
            SFXAS.clip = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (muse == null) {
            muse = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }else if(muse != this) {
            Destroy(gameObject);
        }

        BGMAS.volume = bgmvol;
        bgmvol = bgmVolSet.value;

        SFXAS.volume = sfxvol;
        sfxvol = sfxVolSet.value;

        /*if (SceneManager.GetActiveScene().buildIndex == 0) {//start
            BGMAS.clip = start_bgm;
        }

        if (SceneManager.GetActiveScene().buildIndex == 1) {//start
            BGMAS.clip = null;
        }

        if (SceneManager.GetActiveScene().buildIndex == 2) {//home
            BGMAS.clip = home_bgm;
        }

        if (SceneManager.GetActiveScene().buildIndex == 3) {//dungeon
            BGMAS.clip = dungeon_bgm;
        }*/
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1){
        BGMAS.clip = bglist[SceneManager.GetActiveScene().buildIndex];
        BGMAS.Play();
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

    /*private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) {//start
            BGMAS.clip = start_bgm;
            BGMAS.Play();
        }

        if (SceneManager.GetActiveScene().buildIndex == 1) {//start
            BGMAS.clip = null;
        }

        if (SceneManager.GetActiveScene().buildIndex == 2) {//home
            BGMAS.clip = home_bgm;
            BGMAS.Play();
        }

        if (SceneManager.GetActiveScene().buildIndex == 3) {//dungeon
            BGMAS.clip = dungeon_bgm;
            BGMAS.Play();
        }
    }*/
    private void Awake(){
        if(muse == null){}
    }
}