using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class SaveData : MonoBehaviour {

    [SerializeField]private Text incorrectName;
    [SerializeField]private InputField nameInput;
    private bool showPanel = true;
    public bool ShowPanel
    {
        get
        {
            return showPanel;
        }
        set
        {
            showPanel = value;
        }
    }
    private string nickname;
    public string Nickname
    {
        get
        {
            return nickname;
        }
        set
        {
            nickname = value;
        }
    }
    private int lp = 0;
    public int LP
    {
        get
        {
            return lp;
        }
        set
        {
            lp = value;
        }
    }
    private int ip = 0;
    public int IP
    {
        get
        {
            return ip;
        }
        set
        {
            ip = value;
        }
    }
    private int iconInt;
    public int IconInt
    {
        get
        {
            return iconInt;
        }
        set
        {
            iconInt = value;
        }
    }

    IEnumerator ShowText(float delay)
    {
        incorrectName.enabled = true;
        yield return new WaitForSeconds(delay);
        incorrectName.enabled = false;       
    }

    public void SaveName()
    {
        StoreData(new EnterData(nameInput.text, IconInt, LP, IP));
    }

    public void StoreData(EnterData newData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        EnterData enterData = newData;

        if (File.Exists(Application.persistentDataPath + "/SaveData.elohell"))
        {
            FileStream file = File.Create(Application.persistentDataPath + "/SaveData.elohell");

            bf.Serialize(file, enterData);
            
            file.Close();
        }
        else
        {
            FileStream file = File.Create(Application.persistentDataPath + "/SaveData.elohell");

                Nickname = nameInput.text;

                enterData.name = nickname;
                enterData.firstTime = false;
                enterData.spriteInt = IconInt;
                enterData.leaguePoints = LP;
                enterData.influencePoints = IP;
                bf.Serialize(file, enterData);
                file.Close();
        }
    }

    public void GetData()
    {
        if(File.Exists(Application.persistentDataPath + "/SaveData.elohell"))
        {
            
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData.elohell", FileMode.Open);

            EnterData saveData = (EnterData)bf.Deserialize(file);
            Nickname = saveData.name;
            showPanel = saveData.firstTime;
            LP = saveData.leaguePoints;
            IP = saveData.influencePoints;
            IconInt = saveData.spriteInt;
            
            file.Close();
        }
    }
}

[System.Serializable]
public class EnterData
{
    public string name;
    public int leaguePoints;
    public bool firstTime = false;
    public int spriteInt;
    public int influencePoints;

    public EnterData(string _name, int _spriteInt, int _lp, int _ip)
    {
        name = _name;
        spriteInt = _spriteInt;
        influencePoints = _ip;
        leaguePoints = _lp;
    }
}