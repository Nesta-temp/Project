using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;


public class BalloonTXT : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textComponent;
    
    private Color originalColor;

    public string[] sentences = { "Sky is Black", "Sky is Blue", "Weather is cold", "Weather is good" };
    private bool isShowingSentence = false;

    void Start()
    {
        // 텍스트 컴포넌트 가져오기
        textComponent = GetComponent<TMP_Text>();

        // 원본 색상 저장
        originalColor = Color.black;

        // 초기에는 문장을 숨김
        HideSentence();

        // 랜덤한 문장 출력
        InvokeRepeating("DisplayRandomSentence", 5f, 10f); // "DisplayRandomSentence"메서드 실행, 60f : 첫 번째 호출 이전의 시간 지연 (초 단위), 60f : 쿨타임
    }
    private void DisplayRandomSentence()
    {
        if (!isShowingSentence)
        {
            // 랜덤 문장 선택
            int index = Random.Range(0, sentences.Length);
            string sentence = sentences[index];

            // 문장 표시
            textComponent.text = sentence;
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

        // 정해진 시간동안 다시 문장 표시
        Invoke("DisplayRandomSentence", 5f);
    }
    public void OnPointerEnter()
    {
        // 호버 효과: 텍스트 색상을 초록색으로 변경
        textComponent.color = Color.green;
    }

    public void OnPointerExit()
    {
        // 호버 해제: 원래 색상으로 복원
        textComponent.color = originalColor;
    }

    public void OnPointerClick()
    {
        // 클릭 효과: 텍스트 숨기기
        HideSentence(); 
    }
}
