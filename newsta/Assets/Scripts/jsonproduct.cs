using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.UI;
using System;
using TMPro;

public class jsonproduct : MonoBehaviour
{
    [SerializeField]
    GameObject bubble;
    [SerializeField]
    TMP_Text outsentence;
    [SerializeField]
    TMP_Text sentence;
    [SerializeField]
    TMP_Text[] words;

    int randomnum;
    bool isDisplayingSentence = false;
    bool isScaled = false;
    float displayStartTime;
    float displayDuration = 5f; // 문장을 표시할 시간

    // 스케일 변경을 위한 오리지널 스케일
    Vector3 originalScale;

    void Start()
    {
        // 초기에는 말풍선을 숨김
        HideBubble();
        // 랜덤한 숫자 생성 (0 이상 20 이하)
        randomnum = UnityEngine.Random.Range(0, 21);

        // 랜덤한 문장 출력
        InvokeRepeating("DisplaySentence", 5f, 10f);

        // 오리지널 스케일 저장
        originalScale = transform.localScale;

    }

    private void ParsingJson(JsonData name)
    {
        // 랜덤한 숫자 생성 (0 이상 20 이하)
        randomnum = UnityEngine.Random.Range(0, 21);

        string tmpsentence = name["pair"][randomnum]["sentence"].ToString();
        string tmpword = name["pair"][randomnum]["word"].ToString();

        string[] tmpwords = tmpword.Split(',');
        Console.WriteLine("Parsed Words:");
        foreach (string word in tmpwords)
        {
            string parsedWord = word.Trim(); // 공백을 제거한 단어
            Console.WriteLine(parsedWord);
        }

        sentence.text = tmpsentence;

        for (int i = 0; i < Mathf.Min(tmpwords.Length, words.Length); i++)
        {
            words[i].text = tmpwords[i].Trim(); // 공백을 제거하여 복사
        }
        //sentence는 sentence.text에 저장
        //word는 words 배열에 저장
    }
    private void DisplaySentence()
    {
        // 문장이 표시되고 있지 않을 때 실행될 코드 블록
        if (!isDisplayingSentence)
        {
            // sentence.json 파일의 내용 읽어오기
            string JsonString = File.ReadAllText(Application.dataPath + "/Resources/DataJson/sentence.json");

            // JSON 문자열을 JsonData 객체로 변환
            JsonData jsonData = JsonMapper.ToObject(JsonString);

            // JSON 데이터에서 문장과 단어 추출하여 표시
            ParsingJson(jsonData);

            // 말풍선 게임 오브젝트를 활성화하여 문장을 화면에 표시
            bubble.SetActive(true);

            // 현재 시간을 기록하여 말풍선 표시가 시작된 시간을 저장
            displayStartTime = Time.time;

            // 문장 표시 중 상태를 활성화로 변경
            isDisplayingSentence = true;

            // 마우스가 bubble 위에 있으면 sentence만 활성화하고 outsentence는 비활성화
            if (RectTransformUtility.RectangleContainsScreenPoint(bubble.GetComponent<RectTransform>(), Input.mousePosition))
            {
                sentence.gameObject.SetActive(true);
                outsentence.gameObject.SetActive(false);
            }
            else
            {
                sentence.gameObject.SetActive(false);
                outsentence.gameObject.SetActive(true);
            }
        }

        // 문장이 표시 중이고 일정 시간이 지났을 때 실행될 코드 블록
        if (isDisplayingSentence && Time.time - displayStartTime >= displayDuration)
        {
            // 문장 숨기기 함수 호출
            HideBubble();

            // 문장 표시 중인 상태 해제
            isDisplayingSentence = false;
        }


    }
    private void HideBubble()
    {
        bubble.SetActive(false);
    }
    public void OnPointerClick()
    {
        bubble.SetActive(false);

    }
    public void OnPointerSizing()
    {
        if (isScaled)
        {
            // 화면 내의 모든 GameObject들의 스케일을 원래 스케일로 변경
            ChangeScaleOfAllObjects(1 / 1.5f);
            isScaled = false;
        }
        else
        {
            // 화면 내의 모든 GameObject들의 스케일을 1.5배로 변경
            ChangeScaleOfAllObjects(1.5f);
            isScaled = true;
        }

    }
    // 화면 내의 모든 GameObject들의 스케일을 변경하는 함수
    void ChangeScaleOfAllObjects(float scaleFactor)
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            obj.transform.localScale *= scaleFactor;
        }
    }
}
