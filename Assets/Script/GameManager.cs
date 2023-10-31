using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }//다른 스크립트에서 불러줄 함수

    public int money;
    public int xp;//플레이어가 얻은 경험치
    public int level;//플레이어 레벨
    public float slime_size;//슬라임의 크기
    public float BGM_value;
    public float SFX_value;

    public MusicSetting ms;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake() {
        if(instance != null) {
            Destroy(this);
        } else {
            instance = this;
        }
    }

    public void GameQuit(){
        Application.Quit();//Exit버튼 눌렀을때 게임 꺼짐
    }

    public void Save(){
        SaveData saveData = new SaveData();

        saveData.money = money;
        saveData.xp = xp;
        saveData.level = level;
        saveData.slime_size = slime_size;

        string path = Application.persistentDataPath + "/gamesave.xml";//기기를 파악하여 자동으로 위치를 잡아줌
        XmlManager.XmlSave<SaveData>(saveData, path);
        print(Application.persistentDataPath);
    }

    public void Load(){
        SaveData saveData = new SaveData();

        string path = Application.persistentDataPath + "/gamesave.xml";
        if (File.Exists(path) != true) {
            money = 1000;
            xp = 0;
            level = 1;
            slime_size = 1;
            Save();
        }
        saveData = XmlManager.XmlLoad<SaveData>(path);

        money = saveData.money;
        xp = saveData.xp;
        level = saveData.level;
        slime_size = saveData.slime_size;
    }
    /*불러올때 사용하는 함수
    string path = Application.persistentDataPath + "/save.xml";
    if(System.IO.File.Exists(path)){
        Load();
    }
    */
    public void SoundSave() {
        SaveData saveData = new SaveData();

        saveData.BGM_value = BGM_value;
        saveData.SFX_value = SFX_value;

        string path = Application.persistentDataPath + "/soundsave.xml";//기기를 파악하여 자동으로 위치를 잡아줌
        XmlManager.XmlSave<SaveData>(saveData, path);
        print(Application.persistentDataPath);
    }

    public void SoundLoad() {
        SaveData saveData = new SaveData();

        string path = Application.persistentDataPath + "/soundsave.xml";
        if(File.Exists(path) != true) {
            BGM_value = 0.3f;
            SFX_value = 0.3f;
            SoundSave();
        }
        saveData = XmlManager.XmlLoad<SaveData>(path);

        BGM_value = saveData.BGM_value;
        SFX_value = saveData.SFX_value;

        print(Application.persistentDataPath);
    }
}
