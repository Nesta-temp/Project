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
        // �ؽ�Ʈ ������Ʈ ��������
        textComponent = GetComponent<TMP_Text>();

        // ���� ���� ����
        originalColor = Color.black;

        // �ʱ⿡�� ������ ����
        HideSentence();

        // ������ ���� ���
        InvokeRepeating("DisplayRandomSentence", 5f, 10f); // "DisplayRandomSentence"�޼��� ����, 60f : ù ��° ȣ�� ������ �ð� ���� (�� ����), 60f : ��Ÿ��
    }
    private void DisplayRandomSentence()
    {
        if (!isShowingSentence)
        {
            // ���� ���� ����
            int index = Random.Range(0, sentences.Length);
            string sentence = sentences[index];

            // ���� ǥ��
            textComponent.text = sentence;
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

        // ������ �ð����� �ٽ� ���� ǥ��
        Invoke("DisplayRandomSentence", 5f);
    }
    public void OnPointerEnter()
    {
        // ȣ�� ȿ��: �ؽ�Ʈ ������ �ʷϻ����� ����
        textComponent.color = Color.green;
    }

    public void OnPointerExit()
    {
        // ȣ�� ����: ���� �������� ����
        textComponent.color = originalColor;
    }

    public void OnPointerClick()
    {
        // Ŭ�� ȿ��: �ؽ�Ʈ �����
        HideSentence(); 
    }
}
