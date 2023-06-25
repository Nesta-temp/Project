using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{ // ********************수정 필요*****************************
    private int currentstage;//현재 stage를 저장하는 변수

    public List<GameObject> stagePanels = new List<GameObject>(); // 현재 stage의 gameobject를 저장하는 리스트
    public int progress; // 게임의 진행 상태를 저장하는 변수
    
    private void Awake()
    {
        // 스테이지 씬에서 스테이지를 클리어할 때 progress를 새로 설정한다
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
