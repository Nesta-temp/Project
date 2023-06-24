using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Memo : MonoBehaviour
{
    public BalloonTXT balloonTxt; // BalloonTXT ��ũ��Ʈ�� �����ϱ� ���� ����

    public void ProcessText(string sentence)
    {
        // ������ ���⸦ �������� �ܾ�� �и�
        string[] words = sentence.Split(' ');

        List<string> savedWords = new List<string>();

        // �ܾ "Sky", "Blue", "cold", "Weather", "good", "Black" �� �ϳ��� ��ġ�ϴ� ��� ����
        foreach (string word in words)
        {
            if (word == "Sky" || word == "Blue" || word == "cold" || word == "Weather" || word == "good" || word == "Black")
            {
                savedWords.Add(word);
            }
        }

        // ����� �ܾ ���� ��� Unity ȭ�鿡 ǥ��
        if (savedWords.Count > 0)
        {
            string displayText = string.Join(", ", savedWords);
            Debug.Log("Saved Words: " + displayText);
        }
    }
}

