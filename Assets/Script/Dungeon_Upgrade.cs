using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dungeon_Upgrade : MonoBehaviour
{
    public int slime_price;
    public Text pet_lv_text;
    public Text slime_lv_text;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slime_lv_text.text = "lv : " + GameManager.instance.slime_lv + "\ncost : " + GameManager.instance.slime_price;

        if(GameManager.instance.pet_lv < 1){
            pet_lv_text.text = "구매 안함";
        }else{
            pet_lv_text.text = "lv : " + GameManager.instance.pet_lv + "\ncost : " + GameManager.instance.pet_price;
        }
        
    }

    public void Upgrade_slime(){//strength 5
        if(GameManager.instance.gold >= GameManager.instance.slime_price){
            GameManager.instance.gold -= GameManager.instance.slime_price;
            GameManager.instance.slime_lv++;
            if(GameManager.instance.slime_lv % 100 == 0){
                GameManager.instance.slime_price *= 2;
                GameManager.instance.slime_price += GameManager.instance.slime_upg_price;
            }else{
                GameManager.instance.slime_price += GameManager.instance.slime_upg_price;
            }
        }else{
            print("돈이 부족함");
        }
    }

    public void Upgrade_pet(){//cost : 1lv : 100gold, 1~9 : 100 up, 10~19 : 200 up, 300up, 
        if(GameManager.instance.gold >= GameManager.instance.pet_price){
            GameManager.instance.gold -= GameManager.instance.pet_price;
            GameManager.instance.pet_lv++;
            if(GameManager.instance.pet_lv % 25 == 0){
                GameManager.instance.pet_price += 10000;
            }else if (GameManager.instance.pet_lv % 100 == 0){
                GameManager.instance.pet_price *= 2;
            }else{
                GameManager.instance.pet_price += 5000;
            }
        }else{
            print("돈이 부족함");
        }
    }
}
