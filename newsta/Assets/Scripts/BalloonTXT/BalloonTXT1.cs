using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;


public class BalloonTXT1 : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textComponent;

    private Color originalColor = Color.black;
    private Color hoverColor = Color.green;

    public string[] sentences = { "Sky is Black", "Sky is Blue", "Weather is cold", "Weather is good" };
    private bool isShowingSentence = false;
    private bool isTextActive = true;
    public string clickSentence;

    void Start()
    {
        // 텍스트 컴포넌트 가져오기
        textComponent = GetComponent<TMP_Text>();

        // 초기에는 문장을 숨김
        HideSentence();

        // 랜덤한 문장 출력
        InvokeRepeating("DisplayRandomSentence", 5f, 10f);
    }

    private void DisplayRandomSentence()
    {
        if (!isShowingSentence && isTextActive)
        {
            // 랜덤 문장 선택
            int index = Random.Range(0, sentences.Length);
            string sentence = sentences[index];

            // 문장 표시
            textComponent.text = sentence;
            textComponent.color = originalColor; // 텍스트 색상을 원래 색상으로 설정
            textComponent.gameObject.SetActive(true);

            isShowingSentence = true;

            // 1분 후에 문장 숨기기
            Invoke("HideSentence", 5f);
        }
    }

    private void HideSentence()
    {
        textComponent.gameObject.SetActive(false);
        isShowingSentence = false;

        // 10초 후에 다시 텍스트 표시
        Invoke("ShowSentence", 10f);
    }

    private void ShowSentence()
    {
        textComponent.gameObject.SetActive(true);
        isTextActive = true;

        // 5초 후에 문장 숨기기
        Invoke("HideSentence", 5f);
    }

    public void OnPointerEnter()
    {
        // 호버 효과: 텍스트 색상을 초록색으로 변경
        textComponent.color = hoverColor;
    }

    public void OnPointerExit()
    {
        // 호버 해제: 원래 색상으로 복원
        textComponent.color = originalColor;
    }

    public void OnPointerClick()
    {
        // 클릭 효과: 텍스트 숨기기
        isTextActive = false;
        HideSentence();

        // 클릭한 문장을 clickSentence에 저장
        clickSentence = textComponent.text;
    }
}
