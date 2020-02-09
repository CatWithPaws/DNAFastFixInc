using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelVars : MonoBehaviour
{
    
    public static LevelVars instance;
    public float CountCorrectCombinations = 0;
    public List<NuclidBehaviour> UpperNuclids,LowerNuclids;
    public NuclidBehaviour CurrNuclid;
    public int indexCurrNuclid;
    public GameObject MainMenuLayer;
    public GameObject GameLayer;
    public GameObject GameOverWindow;
    public List<BlockBehaviour> DNABlocks;
    public UIControll UICtrl;
    public string currMusic;
    public Transform Camera;
    public float MaxHP = 100, HP;
    public float seconds, Score = 0;
    public int comboCount = 0;
    public LevelGenerator levelGen;
    public AudioClip SFX_Snd;
    public AudioSource SFX_Source;
    public bool isHor = false;
    private void Awake()
    {
        
        instance = this;
        levelGen.StartGame();
        
    }
    private void Start()
    {
        HP = MaxHP;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (CurrNuclid)
        {
            // AuidioManager.instance.PlayMusic(MainMenuLayer, GameLayer);
                float WillCameraPosY = Mathf.Lerp(Camera.position.y, CurrNuclid.transform.position.y, 0.1f);
                Camera.position = new Vector3(Camera.position.x, WillCameraPosY, Camera.position.z);
        }
    }
    public void ChangeNuclTo(string value)
    {
        SFX_Source.PlayOneShot(SFX_Snd);
        GlobalVars.Nuclids nuclid = GlobalVars.Nuclids.Null;
        switch (value)
        {
            case "A":
                nuclid = GlobalVars.Nuclids.A;
                break;
            case "T":
                nuclid = GlobalVars.Nuclids.T;
                break;
            case "C":
                nuclid = GlobalVars.Nuclids.C;
                break;
            case "G":
                nuclid = GlobalVars.Nuclids.G;
                break;
        }
        CurrNuclid.ChangeNuclid(nuclid);
        CurrNuclid.ValidNuclid();
        CountCorrectCombinations = 0;
        for(int i = 0; i < UpperNuclids.Count;i++)
        {
            if (UpperNuclids[i].currNuclid == GlobalVars.Nuclids.A && LowerNuclids[i].currNuclid == GlobalVars.Nuclids.T)
            {
                CountCorrectCombinations++;
            }
            else if (UpperNuclids[i].currNuclid == GlobalVars.Nuclids.T && LowerNuclids[i].currNuclid == GlobalVars.Nuclids.A)
            {
                CountCorrectCombinations++;
            }
            else if (UpperNuclids[i].currNuclid == GlobalVars.Nuclids.C && LowerNuclids[i].currNuclid == GlobalVars.Nuclids.G)
            {
                CountCorrectCombinations++;
            }
            else if (UpperNuclids[i].currNuclid == GlobalVars.Nuclids.G && LowerNuclids[i].currNuclid == GlobalVars.Nuclids.C)
            {
                CountCorrectCombinations++;
            }

        }

        indexCurrNuclid++;
        print(indexCurrNuclid);
        try
        {
            CurrNuclid = UpperNuclids[indexCurrNuclid];
        }
        catch
        {
            UICtrl.Win();
        }
    }
    
    public void StartLevel()
    {
        seconds = GlobalVars.instance.difficulty == 1 ? 90 : GlobalVars.instance.difficulty == 2 ? 150 : 200;
        
        HP = MaxHP;
    }




    public void GoToMenu()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("MainMenu");
    }
}
