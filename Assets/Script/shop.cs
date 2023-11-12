using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    public Text chair_lv_text;
    public Text desk_lv_text;
    public Text bed_lv_text;
    public Text closet_lv_text;
    public Text tv_lv_text;

    void Update(){
        if(GameManager.instance.chair_lv >= 1){
            chair_lv_text.text = "구매 완료";
        }
        if(GameManager.instance.desk_lv >= 1){
            desk_lv_text.text = "구매 완료";
        }
        if(GameManager.instance.bed_lv >= 1){
            bed_lv_text.text = "구매 완료";
        }
        if(GameManager.instance.closet_lv >= 1){
            closet_lv_text.text = "구매 완료";
        }
        if(GameManager.instance.tv_lv >= 1){
            tv_lv_text.text = "구매 완료";
        }
    }

    public void buy_chair(){
        if(GameManager.instance.chair_lv < 1){
            GameManager.instance.chair_lv = 1;
        }else{
            print("의자 구매 불가");
        }
    }

    public void buy_desk(){
        if(GameManager.instance.desk_lv < 1){
            GameManager.instance.desk_lv = 1;
        }else{
            print("책상 구매 불가");
        }
    }

    public void buy_bed(){
        if(GameManager.instance.bed_lv < 1){
            GameManager.instance.bed_lv = 1;
        }else{
            print("침대 구매 불가");
        }
    }

    public void buy_closet(){
        if(GameManager.instance.closet_lv < 1){
            GameManager.instance.closet_lv = 1;
        }else{
            print("옷장 구매 불가");
        }
    }

    public void buy_tv(){
        if(GameManager.instance.tv_lv < 1){
            GameManager.instance.tv_lv = 1;
        }else{
            print("tv 구매 불가");
        }
    }
}
