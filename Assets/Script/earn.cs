using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class earn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2){
            StartCoroutine(GetGold(3));//3초에 한번 실행
            StartCoroutine(FigureGetGold(30));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GetGold(float delayTime){
        GameManager.instance.gold += GameManager.instance.chair_lv + GameManager.instance.desk_lv*10 + GameManager.instance.bed_lv*100 + GameManager.instance.closet_lv*1000 + GameManager.instance.tv_lv*50000;
        MusicSetting.muse.SFXAS.clip = MusicSetting.muse.coin_sfx;
        if(GameManager.instance.chair_lv + GameManager.instance.desk_lv*10 + GameManager.instance.bed_lv*100 + GameManager.instance.closet_lv*1000 + GameManager.instance.tv_lv*50000 > 0){
            MusicSetting.muse.SFXAS.Play();
        }
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(GetGold(3));
    }

    IEnumerator FigureGetGold(float getTime){
        GameManager.instance.gold += GameManager.instance.iscu*250000 + GameManager.instance.isag*500000 + GameManager.instance.isau*2500000;
        yield return new WaitForSeconds(getTime);
        StartCoroutine(FigureGetGold(30));
    }

    public void Click_earn(){
        GameManager.instance.gold += GameManager.instance.gold_amount;
        MusicSetting.muse.SFXAS.clip = MusicSetting.muse.coin_sfx;
        MusicSetting.muse.SFXAS.Play();
    }
}