using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class NuclidBehaviour : MonoBehaviour
{
    public GlobalVars.Nuclids currNuclid;
    [SerializeField]
    Image nuclImage;
    public NuclidBehaviour LinkedNucle;
    [SerializeField]
    private GameObject Marker;
    public bool isChanged = false;
    public bool isUpper = false;
    float dmg = 5;


    public void ChangeNuclid(GlobalVars.Nuclids value)
    {
        switch (value)
        {
            case GlobalVars.Nuclids.A:
                currNuclid = GlobalVars.Nuclids.A;
                nuclImage.color = GlobalVars.instance.A_NuclidColor;
                break;
            case GlobalVars.Nuclids.T:
                currNuclid = GlobalVars.Nuclids.T;
                nuclImage.color = GlobalVars.instance.T_NuclidColor;
                break;
            case GlobalVars.Nuclids.C:
                currNuclid = GlobalVars.Nuclids.C;
                nuclImage.color = GlobalVars.instance.C_NuclidColor;
                break;
            case GlobalVars.Nuclids.G:
                currNuclid = GlobalVars.Nuclids.G;
                nuclImage.color = GlobalVars.instance.G_NuclidColor;
                break;
        }
        
    }

    
    public bool GetMarkerIsActive() { return Marker.activeSelf; }
    public void ValidNuclid()
    {
        if (isUpper )
        {
            if (LinkedNucle.currNuclid == GlobalVars.Nuclids.A && currNuclid != GlobalVars.Nuclids.T)
            {
                TakeDamage();
            }
            else if (LinkedNucle.currNuclid == GlobalVars.Nuclids.T && currNuclid != GlobalVars.Nuclids.A)
            {
                TakeDamage();
            }
            else if (LinkedNucle.currNuclid == GlobalVars.Nuclids.C && currNuclid != GlobalVars.Nuclids.G)
            {
                TakeDamage();
            }
            else if (LinkedNucle.currNuclid == GlobalVars.Nuclids.G && currNuclid != GlobalVars.Nuclids.C)
            {
                TakeDamage();
            }
            else
            {
                LevelVars.instance.Score++;
            }
        }
    }


    void TakeDamage()
    {
        LevelVars.instance.HP -= dmg;
        LevelVars.instance.comboCount = 0;
        print("asdasd");
    }
}
