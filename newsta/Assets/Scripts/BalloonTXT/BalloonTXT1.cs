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
        // �ؽ�Ʈ ������Ʈ ��������
        textComponent = GetComponent<TMP_Text>();

        // �ʱ⿡�� ������ ����
        HideSentence();

        // ������ ���� ���
        InvokeRepeating("DisplayRandomSentence", 5f, 10f);
    }

    private void DisplayRandomSentence()
    {
        if (!isShowingSentence && isTextActive)
        {
            // ���� ���� ����
            int index = Random.Range(0, sentences.Length);
            string sentence = sentences[index];

            // ���� ǥ��
            textComponent.text = sentence;
            textComponent.color = originalColor; // �ؽ�Ʈ ������ ���� �������� ����
            textComponent.gameObject.SetActive(true);

            isShowingSentence = true;

            // 1�� �Ŀ� ���� �����
            Invoke("HideSentence", 5f);
        }
    }

    private void HideSentence()
    {
        textComponent.gameObject.SetActive(false);
        isShowingSentence = false;

        // 10�� �Ŀ� �ٽ� �ؽ�Ʈ ǥ��
        Invoke("ShowSentence", 10f);
    }

    private void ShowSentence()
    {
        textComponent.gameObject.SetActive(true);
        isTextActive = true;

        // 5�� �Ŀ� ���� �����
        Invoke("HideSentence", 5f);
    }

    public void OnPointerEnter()
    {
        // ȣ�� ȿ��: �ؽ�Ʈ ������ �ʷϻ����� ����
        textComponent.color = hoverColor;
    }

    public void OnPointerExit()
    {
        // ȣ�� ����: ���� �������� ����
        textComponent.color = originalColor;
    }

    public void OnPointerClick()
    {
        // Ŭ�� ȿ��: �ؽ�Ʈ �����
        isTextActive = false;
        HideSentence();

        // Ŭ���� ������ clickSentence�� ����
        clickSentence = textComponent.text;
    }
}
