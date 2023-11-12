using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public Text chair_lv_text;
    public Text desk_lv_text;
    public Text bed_lv_text;
    public Text closet_lv_text;
    public Text tv_lv_text;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.chair_lv < 1){
            chair_lv_text.text = "구매 안함";
        }else{
            chair_lv_text.text = "lv : " + GameManager.instance.chair_lv;
        }

        if(GameManager.instance.desk_lv < 1){
            desk_lv_text.text = "구매 안함";
        }else{
            desk_lv_text.text = "lv : " + GameManager.instance.desk_lv;
        }

        if(GameManager.instance.bed_lv < 1){
            bed_lv_text.text = "구매 안함";
        }else{
            bed_lv_text.text = "lv : " + GameManager.instance.bed_lv;
        }

        if(GameManager.instance.closet_lv < 1){
            closet_lv_text.text = "구매 안함";
        }else{
            closet_lv_text.text = "lv : " + GameManager.instance.closet_lv;
        }

        if(GameManager.instance.tv_lv < 1){
            tv_lv_text.text = "구매 안함";
        }else{
            tv_lv_text.text = "lv : " + GameManager.instance.tv_lv;
        }
    }

    public void Upgrade_chair(){
        if(GameManager.instance.chair_lv >= 1){
            GameManager.instance.chair_lv++;
        }else{
            print("의자 구매 안함");
        }
    }

    public void Upgrade_desk(){
        if(GameManager.instance.desk_lv >= 1){
            GameManager.instance.desk_lv++;
        }else{
            print("책상 구매 안함");
        }
    }

    public void Upgrade_bed(){
        if(GameManager.instance.bed_lv >= 1){
            GameManager.instance.bed_lv++;
        }else{
            print("침대 구매 안함");
        }
    }

    public void Upgrade_closet(){
        if(GameManager.instance.closet_lv >= 1){
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
