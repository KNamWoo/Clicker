using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public int plus = 1;
    public int num;//mob의 번호

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.mobHP1 <= 0){
            kill_mob();
            num = 1;
        }else if(GameManager.instance.mobHP2 <= 0){
            kill_mob();
            num = 2;
        }else if(GameManager.instance.mobHP3 <= 0){
            kill_mob();
            num = 3;
        }else if(GameManager.instance.mobHP4 <= 0){
            kill_mob();
            num = 4;
        }else if(GameManager.instance.mobHP5 <= 0){
            kill_mob();
            num = 5;
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
            if(num == 1){
                GameManager.instance.mobHP1 += 25;//mob1이면
            }else if(num == 2){
                GameManager.instance.mobHP2 += 25;//mob2이면
            }else if(num == 3){
                GameManager.instance.mobHP3 += 25;//mob3이면
            }else if(num == 4){
                GameManager.instance.mobHP4 += 25;//mob4이면
            }else if(num == 5){
                GameManager.instance.mobHP5 += 25;//mob5이면
            }else{
                print("잘못된 개체가 죽었다.");
            }
        }

        if(GameManager.instance.bonusCount != GameManager.instance.mobCount1/50){
            GameManager.instance.bonusCount = GameManager.instance.mobCount1/50;
            if(num == 1){
                GameManager.instance.mobHP1 *= 1.15;
                GameManager.instance.mob_gold += 25;
            }else if(num == 2){
                GameManager.instance.mobHP2 *= 1.15;
                GameManager.instance.mob_gold += 25;
            }else if(num == 3){
                GameManager.instance.mobHP3 *= 1.15;
                GameManager.instance.mob_gold += 25;
            }else if(num == 4){
                GameManager.instance.mobHP4 *= 1.15;
                GameManager.instance.mob_gold += 25;
            }else if(num == 5){
                GameManager.instance.mobHP5 *= 1.15;
                GameManager.instance.mob_gold += 25;
            }else{
                print("잘못된 개체가 죽었다.");
            }
        }
    }

    public void kill_mob(){
        GameManager.instance.mobCount2 ++;
        GameManager.instance.gold += GameManager.instance.mob_gold;
    }
    public void spawn_Mob(){
        //몬스터 스폰 및 다음 몬스터 지정
    }
}
