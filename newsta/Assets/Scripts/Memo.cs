using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Memo : MonoBehaviour
{
    public BalloonTXT balloonTxt; // BalloonTXT 스크립트에 접근하기 위한 참조

    public void ProcessText(string sentence)
    {
        // 문장을 띄어쓰기를 기준으로 단어로 분리
        string[] words = sentence.Split(' ');

        List<string> savedWords = new List<string>();

        // 단어가 "Sky", "Blue", "cold", "Weather", "good", "Black" 중 하나와 일치하는 경우 저장
        foreach (string word in words)
        {
            if (word == "Sky" || word == "Blue" || word == "cold" || word == "Weather" || word == "good" || word == "Black")
            {
                savedWords.Add(word);
            }
        }

        // 저장된 단어가 있을 경우 Unity 화면에 표시
        if (savedWords.Count > 0)
        {
            string displayText = string.Join(", ", savedWords);
            Debug.Log("Saved Words: " + displayText);
        }
    }
}

