using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoMainScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void GoPublishScene()
    {
        SceneManager.LoadScene("Publishing");
    }
    public void GoSettingScene()
    {
        SceneManager.LoadScene("Setting");
    }
    public void GoCollectionScene()
    {
        SceneManager.LoadScene("Collection");
    }
    public void GoHiringScene()
    {
        SceneManager.LoadScene("Hiring");
    }
    public void GoMarketingScene()
    {
        SceneManager.LoadScene("Marketing");
    }
    public void GoDepartControlScene()
    {
        SceneManager.LoadScene("Departctrl");
    }
    public void GoCompanyinfoScene()
    {
        SceneManager.LoadScene("Companyinfo");
    }
    public void GoKeyword()
    {
        SceneManager.LoadScene("Keyword");
    }
    public void GoLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}


