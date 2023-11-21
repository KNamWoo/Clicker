using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEditorInternal;

public class GameManager : MonoBehaviour
{
    //public static MusicSaveManager instance { get; private set; }//other scripts function

    public int gold;
    public int gold_amount;
    public int gold_lv;
    public int gold_price;
    public int slime_lv;
    public double slime_size;
    public int chair_lv;
    public int desk_lv;
    public int bed_lv;
    public int closet_lv;
    public int tv_lv;
    public int iscu;//copper
    public int isag;//silver
    public int isau;//gold
    public int mobCount1, mobCount2;
    public double[] mobHP;
    public int bonusCount;
    public int pet_lv;
    public int pet_price;
    public int mob_gold;

    public float BGM_value;
    public float SFX_value;

    public float increase_gold;
    public float figure_gold;

    //public MusicSetting ms;

    public static GameManager instance;

    void Update(){
        increase_gold = GameManager.instance.chair_lv + GameManager.instance.desk_lv*10 + GameManager.instance.bed_lv*100 + GameManager.instance.closet_lv*1000 + GameManager.instance.tv_lv*50000;
        figure_gold = GameManager.instance.iscu*250000 + GameManager.instance.isag*500000 + GameManager.instance.isau*2500000;

        /*if(Input.GetMouseButtonDown(0)){
            if (SceneManager.GetActiveScene().buildIndex == 2) {
                gold += gold_amount;//1~9 : 1씩 상승, 10~19 : 2씩 상승, 20~29 : 3씩 상승
            }
        }*/
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
        }else if(instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void GameQuit(){
        Application.Quit();//game quit
    }

    public void NewGame() {
        gold = 1000;
        gold_amount = 1;
        gold_lv = 1;
        gold_price = 100;
        slime_lv = 1;
        slime_size = 1;
        bed_lv = 0;
        tv_lv = 0;
        closet_lv = 0;
        chair_lv = 0;
        desk_lv = 0;
        iscu = 0;
        isag = 0;
        isau = 0;
        mobCount1 = 0;
        mobCount2 = 0;
        pet_lv = 0;
        pet_price = 2500;
        mobHP[0] = 100;
        mobHP[1] = 100;
        mobHP[2] = 100;
        mobHP[3] = 100;
        mobHP[4] = 100;
        bonusCount = 0;
        mob_gold = 50;
        Save();
    }

    public void Save() {
        SaveData saveData = new SaveData();

        saveData.gold = gold;
        saveData.gold_amount = gold_amount;
        saveData.gold_lv = gold_lv;
        saveData.gold_price = gold_price;
        saveData.slime_lv = slime_lv;
        saveData.slime_size = slime_size;
        saveData.bed_lv = bed_lv;
        saveData.tv_lv = tv_lv;
        saveData.closet_lv = closet_lv;
        saveData.chair_lv = chair_lv;
        saveData.desk_lv = desk_lv;
        saveData.iscu = iscu;
        saveData.isag = isag;
        saveData.isau = isau;
        saveData.mobCount1 = mobCount1;
        saveData.mobCount2 = mobCount2;
        saveData.mobHP = mobHP;
        saveData.pet_lv = pet_lv;
        saveData.pet_price = pet_price;
        saveData.bonusCount = bonusCount;
        saveData.mob_gold = mob_gold;

        string path = Application.persistentDataPath + "/gamesave.xml";
        XmlManager.XmlSave<SaveData>(saveData, path);
        print(Application.persistentDataPath);
        print("save");
    }

    public void Load() {
        SaveData saveData = new SaveData();

        string path = Application.persistentDataPath + "/gamesave.xml";
        if (File.Exists(path) != true) {
            NewGame();
        }
        saveData = XmlManager.XmlLoad<SaveData>(path);

        gold = saveData.gold;
        gold_amount = saveData.gold_amount;
        gold_lv = saveData.gold_lv;
        gold_price = saveData.gold_price;
        slime_lv = saveData.slime_lv;
        slime_size = saveData.slime_size;
        bed_lv = saveData.bed_lv;
        tv_lv = saveData.tv_lv;
        closet_lv = saveData.closet_lv;
        chair_lv = saveData.chair_lv;
        desk_lv = saveData.desk_lv;
        iscu = saveData.iscu;
        isag = saveData.isag;
        isau = saveData.isau;
        mobCount1 = saveData.mobCount1;
        mobCount2 = saveData.mobCount2;
        mobHP = saveData.mobHP;
        pet_lv = saveData.pet_lv;
        pet_price = saveData.pet_price;
        bonusCount = saveData.bonusCount;
        mob_gold = saveData.mob_gold;
        print("load");
    }
    /*
    string path = Application.persistentDataPath + "/save.xml";
    if(System.IO.File.Exists(path)){
        Load();
    }
    */

    public void SoundSave() {
        MusicData musicData = new MusicData();

        musicData.BGM_value = BGM_value;
        musicData.SFX_value = SFX_value;

        string path = Application.persistentDataPath + "/soundsave.xml";//locate
        XmlManager.XmlSave<MusicData>(musicData, path);
        print(Application.persistentDataPath);
        print("vol save");
    }

    public void SoundLoad() {
        MusicData musicData = new MusicData();

        string path = Application.persistentDataPath + "/soundsave.xml";
        if(File.Exists(path) != true) {
            BGM_value = 0.2f;
            SFX_value = 0.2f;
            SoundSave();
        }
        musicData = XmlManager.XmlLoad<MusicData>(path);

        BGM_value = musicData.BGM_value;
        SFX_value = musicData.SFX_value;

        print(Application.persistentDataPath);
        print("vol load");
    }

    private void OnApplicationQuit() {
        string path = Application.persistentDataPath + "/gamesave.xml";
        if (File.Exists(path) != true) {
            NewGame();
        }else{
            Save();
        }
    }
}
