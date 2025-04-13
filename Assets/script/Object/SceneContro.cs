using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Globalization;


public class SceneContro : MonoBehaviour
{
    public static SceneContro instance;
    public Text txtScene;
    public GameObject player;
    public string[] destroyInScenes;

    private void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
       //sceneName = "Lovel001"
        GetSceneName(sceneName);


    }
    private void Awake()
    {
        // Check if player is not null
        if (player != null)
        {
            //Debug.Log("Change Player");
        }

        // If the current instance is null, set this as the instance and make it persistent
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Check if the current scene is one of the scenes where the object should be destroyed
            string currentSceneName = SceneManager.GetActiveScene().name;
            //Debug.Log("Current scene: " + currentSceneName);

            if (ShouldDestroyInScene(currentSceneName))
            {
                //Debug.Log("Destroying object in scene: " + currentSceneName);
                Destroy(gameObject);
            }
            return; // Make sure to return so the rest of the Awake method doesn't execute
        }

        // Subscribe to the scene change event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the scene change event when this object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // This method will be called when a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (ShouldDestroyInScene(scene.name))
        {
            //Debug.Log("Destroying object on scene load: " + scene.name);
            Destroy(gameObject);
        }
    }

    // Function to check if the object should be destroyed in the given scene
    private bool ShouldDestroyInScene(string sceneName)
    {
        foreach (string destroyScene in destroyInScenes)
        {
            if (sceneName == destroyScene)
            {
                return true;
            }
        }
        return false;
    }



    private void UpdateScene(string sceneName)
    {                
        if (player != null && sceneName != null)
        {
            if (sceneName.ToLower() == "level000")
            {
                //SetPlayerPosition(new Vector3(58, -2.46f, 0));
            }
            else if (sceneName.ToLower() == "level001")
            {
                //SetPlayerPosition(new Vector3(58, -2.46f, 0));
            }
            //Debug.Log("Change Player");
        }
    }
    // Dictionary to hold starting positions for each scene
    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);

        UpdateScene(sceneName);
        GetSceneName(sceneName);
        SaveData Save = new SaveData();
        SaveGameModel saveInfo = new SaveGameModel();        
        saveInfo.playerName = "Player000xxx1";
        saveInfo.playerScore = 100;
        saveInfo.SceneCurrent = sceneName;       
        
        Save.SaveDataInfo(saveInfo);
    }

    public void GetSceneName(string sceneName)
    {
    //    string sceneName = SceneManager.GetActiveScene().name;

        // แสดงชื่อซีนใน Text component
        if (txtScene != null)
        {
            txtScene.text = "" + sceneName; // ตั้งค่าข้อความให้กับ txtScene
           
        }
        else
        {
            //Debug.Log("NAH.");            
        }
    }

    void SetPlayerPosition(Vector3 newPosition)
    {
        // ตั้งค่าตำแหน่งของผู้เล่น
        player.transform.position = newPosition;
    }
}
