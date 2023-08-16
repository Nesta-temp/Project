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
    float displayDuration = 5f; // ������ ǥ���� �ð�

    // ������ ������ ���� �������� ������
    Vector3 originalScale;

    void Start()
    {
        // �ʱ⿡�� ��ǳ���� ����
        HideBubble();
        // ������ ���� ���� (0 �̻� 20 ����)
        randomnum = UnityEngine.Random.Range(0, 21);

        // ������ ���� ���
        InvokeRepeating("DisplaySentence", 5f, 10f);

        // �������� ������ ����
        originalScale = transform.localScale;

    }

    private void ParsingJson(JsonData name)
    {
        // ������ ���� ���� (0 �̻� 20 ����)
        randomnum = UnityEngine.Random.Range(0, 21);

        string tmpsentence = name["pair"][randomnum]["sentence"].ToString();
        string tmpword = name["pair"][randomnum]["word"].ToString();

        string[] tmpwords = tmpword.Split(',');
        Console.WriteLine("Parsed Words:");
        foreach (string word in tmpwords)
        {
            string parsedWord = word.Trim(); // ������ ������ �ܾ�
            Console.WriteLine(parsedWord);
        }

        sentence.text = tmpsentence;

        for (int i = 0; i < Mathf.Min(tmpwords.Length, words.Length); i++)
        {
            words[i].text = tmpwords[i].Trim(); // ������ �����Ͽ� ����
        }
        //sentence�� sentence.text�� ����
        //word�� words �迭�� ����
    }
    private void DisplaySentence()
    {
        // ������ ǥ�õǰ� ���� ���� �� ����� �ڵ� ���
        if (!isDisplayingSentence)
        {
            // sentence.json ������ ���� �о����
            string JsonString = File.ReadAllText(Application.dataPath + "/Resources/DataJson/sentence.json");

            // JSON ���ڿ��� JsonData ��ü�� ��ȯ
            JsonData jsonData = JsonMapper.ToObject(JsonString);

            // JSON �����Ϳ��� ����� �ܾ� �����Ͽ� ǥ��
            ParsingJson(jsonData);

            // ��ǳ�� ���� ������Ʈ�� Ȱ��ȭ�Ͽ� ������ ȭ�鿡 ǥ��
            bubble.SetActive(true);

            // ���� �ð��� ����Ͽ� ��ǳ�� ǥ�ð� ���۵� �ð��� ����
            displayStartTime = Time.time;

            // ���� ǥ�� �� ���¸� Ȱ��ȭ�� ����
            isDisplayingSentence = true;

            // ���콺�� bubble ���� ������ sentence�� Ȱ��ȭ�ϰ� outsentence�� ��Ȱ��ȭ
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

        // ������ ǥ�� ���̰� ���� �ð��� ������ �� ����� �ڵ� ���
        if (isDisplayingSentence && Time.time - displayStartTime >= displayDuration)
        {
            // ���� ����� �Լ� ȣ��
            HideBubble();

            // ���� ǥ�� ���� ���� ����
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
            // ȭ�� ���� ��� GameObject���� �������� ���� �����Ϸ� ����
            ChangeScaleOfAllObjects(1 / 1.5f);
            isScaled = false;
        }
        else
        {
            // ȭ�� ���� ��� GameObject���� �������� 1.5��� ����
            ChangeScaleOfAllObjects(1.5f);
            isScaled = true;
        }

    }
    // ȭ�� ���� ��� GameObject���� �������� �����ϴ� �Լ�
    void ChangeScaleOfAllObjects(float scaleFactor)
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            obj.transform.localScale *= scaleFactor;
        }
    }
}
