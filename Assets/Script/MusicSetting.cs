using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSetting : MonoBehaviour
{//Audio 관련 코드 : https://url.kr/e73cos
    // Start is called before the first frame update
    public float BGM_value=0f;
    public float SFX_value;

    public AudioSource BGMAS;//BGMAudioSource
    public AudioSource SFXAS;
    public AudioClip audioClip;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BGMAS.volume = BGM_value;
        //SFXAS.volume = SFX_value;
        
    }
}
