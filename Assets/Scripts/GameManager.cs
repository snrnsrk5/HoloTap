using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.txt";

    [SerializeField]
    private User user = null;
    public User CurrentUser { get { return user; } }
    public int criticalE ;
    public int CriticalE { get { return criticalE; } }

    private UIManager uIManager = null;

    public UIManager UI { get { return uIManager;} }

    private void Awake()
    {
        //안드로이드 빌드시 Application.persistentDataPath 로 수정

        SAVE_PATH = Application.persistentDataPath + "/Save";
        if(Directory.Exists(SAVE_PATH) == false)
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
        InvokeRepeating("SaveToJson", 1f, 60f);
        InvokeRepeating("EarnEnergyPerSecond", 0f, 1f);
        LoadFromJson();
        uIManager = GetComponent<UIManager>();
    }

    public void OptionSave()
    {
        SaveToJson();
    }

    private void EarnEnergyPerSecond()
    {

        foreach (Soldier solider in user.soldiersList)
        {
            float ePs = solider.ePs;
            float amount = solider.amount;
            float eP = GameManager.Instance.CurrentUser.ePsPlusPercent;
            long hapePs = (long)Mathf.Round(ePs * amount * (100 + eP) * 0.01f);
            user.energy += hapePs;
        }
        UI.UpdateEnergyPanel();
    }

    private void LoadFromJson()
    {
        string json = "";
        if(File.Exists(SAVE_PATH + SAVE_FILENAME) == true)
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            user = JsonUtility.FromJson<User>(json);
        }
    }
    private void SaveToJson()
    {
       /* SAVE_PATH = Application.dataPath + "/Save";
         string json = JsonUtility.ToJson(user, true);
         File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);*/
        Debug.Log("저장됨");
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
    }

    private void OnApplicationQuit()
    {
        SaveToJson();
    }

    public void OnClickBeaker()
    {
        UI.OncliCkBeaker(user.soldiersList2[1].amount, user.soldiersList2[2].amount);
    }
}

