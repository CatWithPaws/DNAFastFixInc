using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GlobalVars : MonoBehaviour
{
    public static GlobalVars instance;



    public Color A_NuclidColor = Color.yellow, T_NuclidColor = Color.red, C_NuclidColor = Color.blue, G_NuclidColor = Color.green;

    public int difficulty = 3   ;// 1 - easy,2 - normal,3 - hard;
    public bool isLoose = false;
    public string PlayerName;
    public bool isInGame = false;
    public List<NuclidBehaviour> NucliвBehs = new List<NuclidBehaviour>();

    private void Awake()
    {
        if(instance == null) { 
        
            instance = this;
        }
        else if(instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
    public enum Nuclids
    {
        A = 0,T = 1,C = 2,G = 3,Null
    }
    

    

}
