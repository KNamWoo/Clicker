using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home_Upgrade : MonoBehaviour
{
    int gold_price = 100;
    int chair_price = 5;
    int desk_price = 50;
    int bed_price = 5000;
    int closet_price = 50000;
    int tv_price = 250000;

    public Text slime_lv_text;
    public Text gold_lv_text;
    public Text chair_lv_text;
    public Text desk_lv_text;
    public Text bed_lv_text;
    public Text closet_lv_text;
    public Text tv_lv_text;

    // Update is called once per frame
    void Update()
    {
        slime_lv_text.text = "lv : " + GameManager.instance.slime_lv;

        gold_lv_text.text = "lv : " + GameManager.instance.gold_lv + "\ncost : " + GameManager.instance.gold_price;

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
            tv_lv_text.text = "lv : " + GameManager.instance.tv_lv + "\ncost : " + ((tv_price) + (GameManager.instance.tv_lv*275000));
        }
    }

    public void Upgrade_gold(){//cost : 1lv : 100gold, 1~9 : 100 up, 10~19 : 200 up, 300up, 
        if(GameManager.instance.gold >= GameManager.instance.gold_price){
            GameManager.instance.gold = GameManager.instance.gold - GameManager.instance.gold_price;
            GameManager.instance.gold_lv++;
            GameManager.instance.gold_amount += 1 + GameManager.instance.gold_lv/10;//1~9 : 1씩 상승, 10~19 : 2씩 상승, 20~29 : 3씩 상승 골드 증가량
            GameManager.instance.gold_price += 100*(GameManager.instance.gold_lv/10 + 1);
        }else{
            print("돈이 부족함");
        }
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
        if(GameManager.instance.tv_lv >= 1 && GameManager.instance.gold >= ((tv_price) + (GameManager.instance.tv_lv*275000))){
            GameManager.instance.gold = GameManager.instance.gold - ((tv_price) + (GameManager.instance.tv_lv*275000));
            GameManager.instance.tv_lv++;
        }else{
            print("tv 구매 안함");
        }
    }
}
