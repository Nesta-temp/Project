using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public bool playing; // ������ ���� �������� ��Ÿ���� ����
    public float gameSpeed = 1.0f; // ���� �ӵ� 
    public UIManagers uimanagers { get; set; }
    public DataManager datamanager { get; set; }

    public GameObject bg; // background�� ��Ÿ���� game object

    public void FinishStage()
    {
        Debug.Log("Stage Finish");
        //playing = false;
        datamanager.SetProgress();
        //uimanagers.?? StageFinish �� ������ ��� �ٲ��� uimanager���� ������ �Լ� ȣ��
    }
    public void Fail()
    {
        Debug.Log("FAIL");
        //bg.GetComponent<SpriteRenderer>().color = Color.red;//Fail ���� �� ���� �ٲٱ�
        //playing = false;
        //uiManager.?? StageFail �� ������ � ȭ�� �������� uimanager���� ������ �Լ� ȣ��
    }
    void Start()
    {
        datamanager = FindObjectOfType<DataManager>().GetComponent<DataManager>();
        uimanagers = FindObjectOfType<UIManagers>().GetComponent<UIManagers>();
    }

}
