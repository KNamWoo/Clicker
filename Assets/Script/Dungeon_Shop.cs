using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

public class Dungeon_Shop : MonoBehaviour
{
    public Text pet_lv_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.pet_lv >= 1){
            pet_lv_text.text = "구매 완료";
        }else{
            pet_lv_text.text = "cost : 2500";
        }
    }

    public void buy_pet(){
        if(GameManager.instance.pet_lv < 1 && GameManager.instance.gold >= 2500){
            GameManager.instance.pet_lv = 1;
            GameManager.instance.gold -= 2500;
        }
    }
}
