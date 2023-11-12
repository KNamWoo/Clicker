using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    int chair_price = 5;
    int desk_price = 50;
    int bed_price = 5000;
    int closet_price = 50000;
    int tv_price;

    public Text slime_lv_text;
    public Text chair_lv_text;
    public Text desk_lv_text;
    public Text bed_lv_text;
    public Text closet_lv_text;
    public Text tv_lv_text;

    // Update is called once per frame
    void Update()
    {
        slime_lv_text.text = "lv : " + GameManager.instance.slime_lv;

        if(GameManager.instance.chair_lv < 1){
            chair_lv_text.text = "구매 안함";
        }else{
            chair_lv_text.text = "lv : " + GameManager.instance.chair_lv + "\ncost : " + ((chair_price) + (GameManager.instance.chair_lv*5));
        }

        if(GameManager.instance.desk_lv < 1){
            desk_lv_text.text = "구매 안함";
        }else{
            desk_lv_text.text = "lv : " + GameManager.instance.desk_lv + "\ncost : " + ((desk_price) + (GameManager.instance.desk_lv*60));
        }

        if(GameManager.instance.bed_lv < 1){
            bed_lv_text.text = "구매 안함";
        }else{
            bed_lv_text.text = "lv : " + GameManager.instance.bed_lv + "\ncost : " + ((bed_price) + (GameManager.instance.bed_lv*6000));
        }

        if(GameManager.instance.closet_lv < 1){
            closet_lv_text.text = "구매 안함";
        }else{
            closet_lv_text.text = "lv : " + GameManager.instance.closet_lv + "\ncost : " + ((closet_price) + (GameManager.instance.closet_lv*65000));
        }

        if(GameManager.instance.tv_lv < 1){
            tv_lv_text.text = "구매 안함";
        }else{
            tv_lv_text.text = "lv : " + GameManager.instance.tv_lv;
        }
    }

    public void Upgrade_slime(){
        GameManager.instance.slime_lv++;
    }

    public void Upgrade_chair(){
        if(GameManager.instance.chair_lv >= 1 && GameManager.instance.gold >= ((chair_price) + (GameManager.instance.chair_lv*5))){
            GameManager.instance.gold = GameManager.instance.gold - ((chair_price) + (GameManager.instance.chair_lv*5));
            GameManager.instance.chair_lv++;
        }else{
            print("의자 구매 안함");
        }
    }

    public void Upgrade_desk(){
        if(GameManager.instance.desk_lv >= 1 && GameManager.instance.gold >= ((desk_price) + (GameManager.instance.desk_lv*60))){
            GameManager.instance.gold = GameManager.instance.gold - ((desk_price) + (GameManager.instance.desk_lv*60));
            GameManager.instance.desk_lv++;
        }else{
            print("책상 구매 안함");
        }
    }

    public void Upgrade_bed(){
        if(GameManager.instance.bed_lv >= 1 && GameManager.instance.gold >= ((bed_price) + (GameManager.instance.bed_lv*6000))){
            GameManager.instance.gold = GameManager.instance.gold - ((bed_price) + (GameManager.instance.bed_lv*6000));
            GameManager.instance.bed_lv++;
        }else{
            print("침대 구매 안함");
        }
    }

    public void Upgrade_closet(){
        if(GameManager.instance.closet_lv >= 1 && GameManager.instance.gold >= ((closet_price) + (GameManager.instance.closet_lv*65000))){
            GameManager.instance.gold = GameManager.instance.gold - ((closet_price) + (GameManager.instance.closet_lv*65000));
            GameManager.instance.closet_lv++;
        }else{
            print("옷장 구매 안함");
        }
    }

    public void Upgrade_tv(){
        if(GameManager.instance.tv_lv >= 1){
            GameManager.instance.tv_lv++;
        }else{
            print("tv 구매 안함");
        }
    }
}
