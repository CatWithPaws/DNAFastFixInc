using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControll : MonoBehaviour
{
    [SerializeField]
    Image HpBar, countOfCorrectCombsImage;
    [SerializeField]
    Text TimeText,ScoreText, countOfCorrectCombsText;
    [SerializeField]
    Text TotalScore;
    [SerializeField]
    GameObject PauseMenu,WonMenu;
    [SerializeField]
    Sprite[] DNAs;
    [SerializeField]
    Text SmileText;
    [SerializeField]
    Text CorrectGensText;
    // Update is called once per frame

    void Start()
    {
        StartCoroutine(TimeReduces());
    }
    IEnumerator TimeReduces()
    {

        while (!LevelVars.instance.GameOverWindow.activeSelf)
        {

            if (LevelVars.instance.seconds == 0)
            {
                GameOver();
            }
            yield return new WaitForSeconds(1);
            LevelVars.instance.seconds--;
        }
    }
    void Update()
    {
        if(LevelVars.instance.HP <= 0)
        {
            GameOver();
        }
        Debug.Log(LevelVars.instance.MaxHP);
        float tempHPAmount = Mathf.Lerp(HpBar.fillAmount, HpBar.fillAmount = LevelVars.instance.HP / LevelVars.instance.MaxHP, 0.3f);
        HpBar.fillAmount = tempHPAmount;
            TimeText.text = LevelVars.instance.seconds.ToString();
            ScoreText.text = LevelVars.instance.Score.ToString();
            countOfCorrectCombsImage.fillAmount = LevelVars.instance.CountCorrectCombinations / (float)LevelVars.instance.UpperNuclids.Count;
            countOfCorrectCombsText.text = (Mathf.Floor(countOfCorrectCombsImage.fillAmount * 100)).ToString() + "%";
            if(countOfCorrectCombsImage.fillAmount == 1)
            {
                Win();
            }
        
    }
    public void GameOver()
    {
        LevelVars.instance.GameOverWindow.SetActive(true);
        StopAllCoroutines();
        TotalScore.text = LevelVars.instance.Score.ToString();
        SmileText.text = ":(";
        CorrectGensText.text = "Correct Gens:" + countOfCorrectCombsImage.fillAmount.ToString();
    }
    public void ChangeNucle(string value)
    {
        LevelVars.instance.ChangeNuclTo(value);
    }
    public void Win()
    {
        LevelVars.instance.GameOverWindow.SetActive(true);
        TotalScore.text = LevelVars.instance.Score.ToString();
        StopAllCoroutines();
        SmileText.text = "^_^";
        CorrectGensText.text = "Correct Gens:" + countOfCorrectCombsImage.fillAmount.ToString();
    }

    public void StartPause()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }
    public void StopPause()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }

    public void GoToMenu()
    {
        PauseMenu.SetActive(false);
        LevelVars.instance.GameOverWindow.SetActive(false);
        LevelVars.instance.GoToMenu();
        //AuidioManager.instance.Game_Music_Source.Play();

    }
}
