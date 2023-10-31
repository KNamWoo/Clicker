using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int money;
    public int xp;//플레이어가 얻은 경험치
    public int level;//플레이어 레벨
    public float slime_size;//슬라임의 크기

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        
        string path = Application.persistentDataPath + "/save.xml";//기기를 파악하여 자동으로 위치를 잡아줌
        XmlManager.XmlSave<SaveData>(saveData, path);
        print(Application.persistentDataPath);
    }

    public void Load(){
        SaveData saveData = new SaveData();

        string path = Application.persistentDataPath + "/save.xml";
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
}
