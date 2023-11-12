using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetGold(3));//1초에 한번 실행
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GetGold(float delayTime){
        Debug.Log("Time = "+Time.time);
        GameManager.instance.gold += GameManager.instance.chair_lv + GameManager.instance.desk_lv*10 + GameManager.instance.bed_lv*100 + GameManager.instance.closet_lv*1000;
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(GetGold(1));
    }
}

