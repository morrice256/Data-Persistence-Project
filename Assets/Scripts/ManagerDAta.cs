using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class ManagerDAta : MonoBehaviour
{

    public static ManagerDAta Instance;
    public string username;
    public string nameBestScore;
    public int bestScore;    

    private void Awake()
    {
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    class SaveData
    {
        public string username;
        public string nameBestScore;
        public int bestScore;
    }


    public void SaveName(string name){

        SaveData data = LoadDataJson();
        data.username = name;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        SaveData data = LoadDataJson();
        username = data.username;
        nameBestScore = data.nameBestScore;
        bestScore = data.bestScore;
    }

    private SaveData LoadDataJson(){
        SaveData data = new SaveData();
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);
        }
        return data;
    }

    public void SaveBestScore(int score){

        SaveData data = LoadDataJson();
        if(score >= data.bestScore){
            data.nameBestScore = data.username;
            data.bestScore = score;
        }
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }
}
