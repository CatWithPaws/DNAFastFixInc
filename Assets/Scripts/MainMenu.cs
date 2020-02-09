using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject PreloadPage;
    [SerializeField]
    UnityEngine.UI.Text Name,PreloadMessageText;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(Name.text != "")
        {
            PreloadMessageText.text = "";
        }
    }

    public void LoadPreLoad(int difficulty)
    {
        GlobalVars.instance.difficulty = difficulty;
        PreloadPage.SetActive(true);

    }
    public void ClosePreLoad()
    {
        PreloadPage.SetActive(false);
    }
    public void LoadLevel()
    {
        if(Name.text != "")
        {
            GlobalVars.instance.PlayerName = Name.text;
            Name.text = "";
            SceneManager.LoadScene("LevelVert");
        }
        else
        {
            PreloadMessageText.text = "Name is Empty";
        }
    }
}
