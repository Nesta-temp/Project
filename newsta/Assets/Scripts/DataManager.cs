using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{ // ********************���� �ʿ�*****************************
    private int currentstage;//���� stage�� �����ϴ� ����

    public List<GameObject> stagePanels = new List<GameObject>(); // ���� stage�� gameobject�� �����ϴ� ����Ʈ
    public int progress; // ������ ���� ���¸� �����ϴ� ����
    
    private void Awake()
    {
        // �������� ������ ���������� Ŭ������ �� progress�� ���� �����Ѵ�
        progress = 5;
        Debug.Log($"Progress: {progress}");
    }

    private void Start()
    {
        currentstage = 0;
        ShowStagePanel(currentstage);
    }

    public void ShowLeftSide()
    {
        if (currentstage == 0) return;
        else
        {
            ShowStagePanel(currentstage - 1);
            currentstage--;
        }
    }

    public void ShowRightSide()
    {
        if (currentstage == 4) return;
        else
        {
            ShowStagePanel(currentstage + 1);
            currentstage++;
        }
    }

    private void ShowStagePanel(int stage)
    {
        for (int i = 0; i < stagePanels.Count; i++)
        {
            if (i == stage) stagePanels[i].SetActive(true);
            else stagePanels[i].SetActive(false);
        }
    }

    public void ResetData()
    {
        PlayerPrefs.SetInt("Progress", 0);
        progress = 0;
    }

    public void SetProgress()
    {
        int curprogress = PlayerPrefs.GetInt("Progress");
        progress = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Progress", Mathf.Max(curprogress, progress));
    }
}
