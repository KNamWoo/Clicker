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
    public Text Figure_Cu;//copper
    public Text Figure_Ag;//silver
    public Text Figure_Au;//gold

    void Update(){
        if(GameManager.instance.chair_lv >= 1){
            chair_lv_text.text = "구매 완료";
        }else{
            chair_lv_text.text = "cost : 5";
        }

        if(GameManager.instance.desk_lv >= 1){
            desk_lv_text.text = "구매 완료";
        }else{
            desk_lv_text.text = "cost : 50";
        }
        if(GameManager.instance.bed_lv >= 1){
            bed_lv_text.text = "구매 완료";
        }else{
            bed_lv_text.text = "cost : 5000";
        }
        if(GameManager.instance.closet_lv >= 1){
            closet_lv_text.text = "구매 완료";
        }else{
            closet_lv_text.text = "cost : 50000";
        }
        if(GameManager.instance.tv_lv >= 1){
            tv_lv_text.text = "구매 완료";
        }else{
            tv_lv_text.text = "cost : 250000";
        }
        if(GameManager.instance.iscu >= 1){
            Figure_Cu.text = "구매 완료";
        }else{
            Figure_Cu.text = "cost : 500000";
        }
        if(GameManager.instance.isag >= 1){
            Figure_Ag.text = "구매 완료";
        }else{
            Figure_Ag.text = "cost : 1000000";
        }
        if(GameManager.instance.isau >= 1){
            Figure_Au.text = "구매 완료";
        }else{
            Figure_Au.text = "cost : 5000000";
        }
    }

    public void buy_chair(){
        if(GameManager.instance.chair_lv < 1 && GameManager.instance.gold >= 5){
            GameManager.instance.chair_lv = 1;
            GameManager.instance.gold -= 5;
        }else{
            print("의자 구매 불가");
        }
    }

    public void buy_desk(){
        if(GameManager.instance.desk_lv < 1 && GameManager.instance.gold >= 50){
            GameManager.instance.desk_lv = 1;
            GameManager.instance.gold -= 50;
        }else{
            print("책상 구매 불가");
        }
    }

    public void buy_bed(){
        if(GameManager.instance.bed_lv < 1 && GameManager.instance.gold >= 5000){
            GameManager.instance.bed_lv = 1;
            GameManager.instance.gold -= 5000;
        }else{
            print("침대 구매 불가");
        }
    }

    public void buy_closet(){
        if(GameManager.instance.closet_lv < 1 && GameManager.instance.gold >= 50000){
            GameManager.instance.closet_lv = 1;
            GameManager.instance.gold -= 50000;
        }else{
            print("옷장 구매 불가");
        }
    }

    public void buy_tv(){
        if(GameManager.instance.tv_lv < 1 && GameManager.instance.gold >= 250000){
            GameManager.instance.tv_lv = 1;
            GameManager.instance.gold -= 250000;
        }else{
            print("tv 구매 불가");
        }
    }

    public void buy_copper(){
        if(GameManager.instance.iscu == 0 && GameManager.instance.gold >= 500000){
            GameManager.instance.iscu = 1;
            GameManager.instance.gold -= 500000;
        }else{
            print("tv 구매 불가");
        }
    }

    public void buy_silver(){
        if(GameManager.instance.isag == 0 && GameManager.instance.gold >= 1000000){
            GameManager.instance.isag = 1;
            GameManager.instance.gold -= 1000000;
        }else{
            print("tv 구매 불가");
        }
    }

    public void buy_gold(){
        if(GameManager.instance.isau == 0 && GameManager.instance.gold >= 5000000){
            GameManager.instance.isau = 1;
            GameManager.instance.gold -= 5000000;
        }else{
            print("tv 구매 불가");
        }
    }
}
