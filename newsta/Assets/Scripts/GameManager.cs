using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public bool playing; // 게임이 진행 중인지를 나타내는 변수
    public float gameSpeed = 1.0f; // 게임 속도 
    public UIManagers uimanagers { get; set; }
    public DataManager datamanager { get; set; }

    public GameObject bg; // background를 나타내는 game object

    public void FinishStage()
    {
        Debug.Log("Stage Finish");
        //playing = false;
        datamanager.SetProgress();
        //uimanagers.?? StageFinish 할 때마다 어떻게 바뀔지 uimanager에서 정의한 함수 호출
    }
    public void Fail()
    {
        Debug.Log("FAIL");
        //bg.GetComponent<SpriteRenderer>().color = Color.red;//Fail 했을 때 배경색 바꾸기
        //playing = false;
        //uiManager.?? StageFail 할 때마다 어떤 화면 보여줄지 uimanager에서 정의한 함수 호출
    }
    void Start()
    {
        datamanager = FindObjectOfType<DataManager>().GetComponent<DataManager>();
        uimanagers = FindObjectOfType<UIManagers>().GetComponent<UIManagers>();
    }

}
