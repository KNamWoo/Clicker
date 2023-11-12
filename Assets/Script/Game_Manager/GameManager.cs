using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    //public static MusicSaveManager instance { get; private set; }//other scripts function

    public int gold;
    public int slime_lv;
    public int chair_lv;
    public int desk_lv;
    public int bed_lv;
    public int closet_lv;
    public int tv_lv;

    public float BGM_value;
    public float SFX_value;

    public float increase_gold;

    //public MusicSetting ms;

    public static GameManager instance;

    void Update(){
        increase_gold = GameManager.instance.chair_lv + GameManager.instance.desk_lv*10 + GameManager.instance.bed_lv*100 + GameManager.instance.closet_lv*1000;
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
        slime_lv = 1;
        bed_lv = 0;
        tv_lv = 0;
        closet_lv = 0;
        chair_lv = 0;
        desk_lv = 0;
        Save();
    }

    public void Save() {
        SaveData saveData = new SaveData();

        saveData.gold = gold;
        saveData.slime_lv = slime_lv;
        saveData.bed_lv = bed_lv;
        saveData.tv_lv = tv_lv;
        saveData.closet_lv = closet_lv;
        saveData.chair_lv = chair_lv;
        saveData.desk_lv = desk_lv;

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
        slime_lv = saveData.slime_lv;
        bed_lv = saveData.bed_lv;
        tv_lv = saveData.tv_lv;
        closet_lv = saveData.closet_lv;
        chair_lv = saveData.chair_lv;
        desk_lv = saveData.desk_lv;
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
