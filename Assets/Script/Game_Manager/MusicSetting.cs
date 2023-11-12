using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicSetting : MonoBehaviour
{//Audio : https://url.kr/e73cos
    // Start is called before the first frame update
    public AudioSource BGMAS;//BGMAudioSource
    public AudioSource SFXAS;
    public AudioClip audioClip;

    public Slider bgmVolSet;
    public Slider sfxVolSet;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 2) {
            GameManager.instance.SoundLoad();
            bgmVolSet.value = GameManager.instance.BGM_value;
            sfxVolSet.value = GameManager.instance.SFX_value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.BGM_value = bgmVolSet.value;
        BGMAS.volume = GameManager.instance.BGM_value;

        GameManager.instance.SFX_value = sfxVolSet.value;
        SFXAS.volume = GameManager.instance.SFX_value;
    }

    public void Save() {
        GameManager.instance.SoundSave();
    }
}