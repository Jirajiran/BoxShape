using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicOpen : MonoBehaviour
{
    public GameObject objectToToggle;  // Object ����ͧ����Դ���ͻԴ
    public string[] scenesToActivateIn;  // ��ª��ͩҡ����ͧ����Դ object ���
    public string[] scenesToDeactivateIn;  // ��ª��ͩҡ����ͧ��ûԴ object ���

    private bool isActive;  // �����������ʶҹС���Դ���ͻԴ�ͧ object

    void OnEnable()
    {
        // �ѧ�˵ء�ó�������ա����Ŵ�ҡ
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // ��ش�ѧ�˵ء�ó�������ա����Ŵ�ҡ
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        // �������ʶҹС���Դ���ͻԴ�ͧ object
        isActive = false;
        UpdateObjectStatus(SceneManager.GetActiveScene().name);  // ��Ǩ�ͺʶҹ�㹩ҡ�������
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateObjectStatus(scene.name);  // ��Ǩ�ͺʶҹ�������ա����Ŵ�ҡ
    }

    void UpdateObjectStatus(string currentSceneName)
    {
        // ��Ǩ�ͺ��Ҫ��ͩҡ�������ª��ͩҡ����ͧ����Դ�������
        if (System.Array.Exists(scenesToActivateIn, sceneName => sceneName == currentSceneName))
        {
            isActive = true;  // �Դ��ҹ
        }
        else if (System.Array.Exists(scenesToDeactivateIn, sceneName => sceneName == currentSceneName))
        {
            isActive = false;  // �Դ��ҹ
        }

        // �Դ���ͻԴ�����ҹ object ���ʶҹ�
        objectToToggle.SetActive(isActive);
    }
}
