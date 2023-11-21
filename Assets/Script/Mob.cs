using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Numerics;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public int plus = 1;
    public int num;//mob의 번호

    public GameObject mob_1;
    public GameObject mob_2;
    public GameObject mob_3;
    public GameObject mob_4;
    public GameObject mob_5;

    public double HP;
    public double slimeStr;
    public double petStr;

    // Start is called before the first frame update
    void Start()
    {
        spawn_Mob();
    }

    // Update is called once per frame
    void Update()
    {
        slimeStr = 20 + 5*GameManager.instance.slime_lv;
        petStr = 10 + 5*GameManager.instance.pet_lv;
        
        if(GameManager.instance.mobHP[0] <= 0){
            kill_mob();
        }

        if(GameManager.instance.mobCount1 != GameManager.instance.mobCount2){
            if(GameManager.instance.mobCount1/20 != GameManager.instance.mobCount2/20 && GameManager.instance.slime_size >= 2 && GameManager.instance.slime_size < 5){
                GameManager.instance.slime_size += 0.15;
            }else if(GameManager.instance.mobCount1/30 != GameManager.instance.mobCount2/30 && GameManager.instance.slime_size >= 5){
                GameManager.instance.slime_size += 0.2;
            }else if(GameManager.instance.mobCount1/10 != GameManager.instance.mobCount2/10 && GameManager.instance.slime_size < 2){
                GameManager.instance.slime_size += 0.15;
            }

            GameManager.instance.mobCount1 = GameManager.instance.mobCount2;
            GameManager.instance.mobHP[num] += 25;//mob1이면
        }

        if(GameManager.instance.bonusCount != GameManager.instance.mobCount1/50){
            GameManager.instance.bonusCount = GameManager.instance.mobCount1/50;
            GameManager.instance.mobHP[num] *= 1.15;
            GameManager.instance.mob_gold += 25;
        }
    }

    public void kill_mob(){
        GameManager.instance.mobCount2++;
        GameManager.instance.gold += GameManager.instance.mob_gold;
        spawn_Mob();
    }

    public void spawn_Mob(){
        //몬스터 스폰 및 다음 몬스터 지정 5마리 -> 2번 10마리 -> 3번 15마리 20마리 25마리 -> 1번
        if(GameManager.instance.mobCount2 % 25 == 0){
            num = 0;
            GameObject mob = MonoBehaviour.Instantiate(mob_1);
            mob.name = "monster";
            var rand = Instantiate(mob_1, new UnityEngine.Vector3(100f, 0f, 0f), UnityEngine.Quaternion.identity);
            HP = GameManager.instance.mobHP[0];
        }else if(GameManager.instance.mobCount2 % 25 == 5){
            num = 1;
            GameObject mob = MonoBehaviour.Instantiate(mob_2);
            mob.name = "monster";
            var rand = Instantiate(mob_2, new UnityEngine.Vector3(100f, 0f, 0f), UnityEngine.Quaternion.identity);
            HP = GameManager.instance.mobHP[1];
        }else if(GameManager.instance.mobCount2 % 25 == 10){
            num = 2;
            GameObject mob = MonoBehaviour.Instantiate(mob_3);
            mob.name = "monster";
            var rand = Instantiate(mob_3, new UnityEngine.Vector3(100f, 0f, 0f), UnityEngine.Quaternion.identity);
            HP = GameManager.instance.mobHP[2];
        }else if(GameManager.instance.mobCount2 % 25 == 15){
            num = 3;
            GameObject mob = MonoBehaviour.Instantiate(mob_4);
            mob.name = "monster";
            var rand = Instantiate(mob_4, new UnityEngine.Vector3(100f, 0f, 0f), UnityEngine.Quaternion.identity);
            HP = GameManager.instance.mobHP[3];
        }else if(GameManager.instance.mobCount2 % 25 == 20){
            num = 4;
            GameObject mob = MonoBehaviour.Instantiate(mob_5);
            mob.name = "monster";
            var rand = Instantiate(mob_5, new UnityEngine.Vector3(100f, 0f, 0f), UnityEngine.Quaternion.identity);
            HP = GameManager.instance.mobHP[4];
        }
    }
}
