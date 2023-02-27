using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance { get; private set; } 
    public List<Sprite> panelGallery; 
    public bool load = false; 

    private void Awake()
    {
        Load();
        Debug.Log(panelGallery); 
        if (Instance != null) 
        {
            Destroy(gameObject);
            return; 
        }
        Instance = this; 
        DontDestroyOnLoad(gameObject); 
    }

    [System.Serializable] 
    class SaveData 
    {
        public List<Sprite> panelGallery;
    }

    public void Save() 
    {
        SaveData data = new SaveData(); 
        data.panelGallery = panelGallery; 
        string json = JsonUtility.ToJson(data); 
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); 
    }

    public void Load() 
    {
        load = true; 
        string path = Application.persistentDataPath + "/savefile.json"; 
        if (File.Exists(path)) 
        {
            string json = File.ReadAllText(path); 
            SaveData data = JsonUtility.FromJson<SaveData>(json); 
            panelGallery = data.panelGallery; 
        }
    }
}
