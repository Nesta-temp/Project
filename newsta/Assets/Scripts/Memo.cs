using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Memo : MonoBehaviour
{/*
    //public BalloonTXT1 balloonScript; // BalloonTXT1 ��ũ��Ʈ�� ���� ���� ������Ʈ�� �����ؾ� �մϴ�.

    public List<string> keywords = new List<string> { "Blue", "Black", "Sky", "good", "Weather", "cold" };
    private Dictionary<string, int> keywordCount = new Dictionary<string, int>();

    void Start()
    {
        // Ű���� �ʱ�ȭ
        foreach (string keyword in keywords)
        {
            keywordCount[keyword] = 0; // ���߿� ����� �� �ҷ������ �ٲ�� ��
        }
    }

    void Update()
    {
        // Ŭ���� ���� �޾ƿ���
        //string clickSentence = balloonScript.clickSentence;

        // �ܾ� ����Ʈ �ʱ�ȭ
        List<string> words = new List<string>();

        // ������ ���� ������ ������ �ܾ� ����Ʈ�� ����
        string[] sentenceWords = clickSentence.Split(' ');
        foreach (string word in sentenceWords)
        {
            words.Add(word);
        }

        // Ű����� ��ġ�ϴ� �ܾ� ī��Ʈ
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

        // ����Ƽ ȭ�鿡 Ű����� ī��Ʈ ǥ��
        for (int i = 0; i < keywords.Count; i++)
        {
            string keyword = keywords[i];
            int count = keywordCount[keyword];
            Debug.Log(keyword + ": " + count);
            // �ʿ��� ��� ȭ�鿡 ǥ���ϴ� ����� �°� �����ϸ� �˴ϴ�.
        }
    }
    */
}


