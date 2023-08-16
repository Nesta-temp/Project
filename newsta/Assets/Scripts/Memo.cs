using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Memo : MonoBehaviour
{/*
    //public BalloonTXT1 balloonScript; // BalloonTXT1 스크립트를 가진 게임 오브젝트에 연결해야 합니다.

    public List<string> keywords = new List<string> { "Blue", "Black", "Sky", "good", "Weather", "cold" };
    private Dictionary<string, int> keywordCount = new Dictionary<string, int>();

    void Start()
    {
        // 키워드 초기화
        foreach (string keyword in keywords)
        {
            keywordCount[keyword] = 0; // 나중에 저장된 값 불러오기로 바꿔야 함
        }
    }

    void Update()
    {
        // 클릭한 문장 받아오기
        //string clickSentence = balloonScript.clickSentence;

        // 단어 리스트 초기화
        List<string> words = new List<string>();

        // 문장을 띄어쓰기 단위로 나누어 단어 리스트에 저장
        string[] sentenceWords = clickSentence.Split(' ');
        foreach (string word in sentenceWords)
        {
            words.Add(word);
        }

        // 키워드와 일치하는 단어 카운트
        foreach (string keyword in keywords)
        {
            int count = keywordCount[keyword];
            foreach (string word in words)
            {
                if (word.Equals(keyword))
                {
                    count++;
                }
            }
            keywordCount[keyword] = count;
        }

        // 유니티 화면에 키워드와 카운트 표시
        for (int i = 0; i < keywords.Count; i++)
        {
            string keyword = keywords[i];
            int count = keywordCount[keyword];
            Debug.Log(keyword + ": " + count);
            // 필요한 경우 화면에 표시하는 방법에 맞게 수정하면 됩니다.
        }
    }
    */
}


