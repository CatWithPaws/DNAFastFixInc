using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    LevelVars LevelVars;
    [SerializeField] Transform Parent;
    [SerializeField]
    GameObject DNA1,DNA2,blankPref;
    System.Random rnd;
    int maxiterators ;
    public static LevelGenerator instance;

    private void Awake()
    {
        instance = this;
    }
    public void StartGame()
    {
        maxiterators = GlobalVars.instance.difficulty == 1 ? 20 : GlobalVars.instance.difficulty == 2 ? 30 : 40;
        string name = GlobalVars.instance.PlayerName;
        int hash = name.GetHashCode();
        rnd = new System.Random(hash);
        List<char> seed = new List<char>();
        for(int i = 0; i < maxiterators*5; i++)
        {
            int num = rnd.Next(0,100);
            if(num >= 0 && num <= 25f)
            {
                seed.Add( '0');
            }
            else if(num > 25 && num <= 50)
            {
                seed.Add('1');
            }
            else if(num > 50 && num <= 75)
            {
                seed.Add('2');
            }
            else
            {
                seed.Add('3');
            }
        }
        print(seed);
        GameObject blank = Instantiate(blankPref);
        blank.transform.SetParent(Parent, false);
        blank.transform.localScale = new Vector3(-1, 1, 1);
        SetNuclids(seed);
        
    }
    void SetNuclids(List<char> seed)
    {
        int iterator = 0,alterIterator = 0;
        
        List<char> alterSeed = new List<char>();
        for (int i = 0; i < seed.Count; i++)
        {
            int num = rnd.Next(0, 100);
            if (num >= 0 && num <= 25f)
            {
                alterSeed.Add('0');
            }
            else if (num > 25 && num <= 50)
            {
                alterSeed.Add('1');
            }
            else if (num > 50 && num <= 75)
            {
                alterSeed.Add('2');
            }
            else
            {
                alterSeed.Add('3');

            }
        }
            for (int j = 1; j <= maxiterators; j++)
        {
            GameObject TDNABlock;
            if(j%2 == 0)
            {
                TDNABlock = Instantiate(DNA2, Parent);
            }
            else
            {
                TDNABlock = Instantiate(DNA1, Parent);
            }
            BlockBehaviour BlockBeh = TDNABlock.GetComponent<BlockBehaviour>();
            NuclidBehaviour[] Nuclids = BlockBeh.currNucls;
            for(int i = 0; i < Nuclids.Length; i++)
            {
                if (Nuclids[i].isUpper)
                {
                    LevelVars.instance.UpperNuclids.Add(Nuclids[i]);
                }   
                else
                {
                    LevelVars.instance.LowerNuclids.Add(Nuclids[i]);
                }
            }

            for (int i = 0; i < Nuclids.Length; i++)
            {
                bool willMutate = rnd.Next(0,100) > 70;
                if (!Nuclids[i].isUpper)
                {
                    if (willMutate)
                    {
                        switch (seed[iterator])
                        {
                            case '0':
                                Nuclids[i].currNuclid = GlobalVars.Nuclids.G;
                                break;
                            case '1':
                                Nuclids[i].currNuclid = GlobalVars.Nuclids.C;
                                break;
                            case '2':
                                Nuclids[i].currNuclid = GlobalVars.Nuclids.A;
                                break;
                            case '3':
                                Nuclids[i].currNuclid = GlobalVars.Nuclids.T;
                                break;
                        }
                    }
                    else
                    {
                        switch (seed[iterator])
                        {
                            case '0':
                                Nuclids[i].currNuclid = GlobalVars.Nuclids.A;
                                break;
                            case '1':
                                Nuclids[i].currNuclid = GlobalVars.Nuclids.T;
                                break;
                            case '2':
                                Nuclids[i].currNuclid = GlobalVars.Nuclids.C;
                                break;
                            case '3':
                                Nuclids[i].currNuclid = GlobalVars.Nuclids.G;
                                break;
                        }
                    }
                    iterator++;
                }
                else
                {
                        switch (alterSeed[alterIterator])
                        {
                            case '0':
                                Nuclids[i].currNuclid = GlobalVars.Nuclids.A;
                                break;
                            case '1':
                                Nuclids[i].currNuclid = GlobalVars.Nuclids.T;
                                break;
                            case '2':
                                Nuclids[i].currNuclid = GlobalVars.Nuclids.C;
                                break;
                            case '3':
                                Nuclids[i].currNuclid = GlobalVars.Nuclids.G;
                                break;
                        }
                        alterIterator++;
                }
                Nuclids[i].ChangeNuclid(Nuclids[i].currNuclid);
            }
        }

        switch (GlobalVars.instance.difficulty)
        {
            case 1:
                LevelVars.instance.seconds = 60;
                break;
            case 2:
                LevelVars.instance.seconds = 120;
                break;
            case 3:
                LevelVars.instance.seconds = 240;
                break;
        }
        GameObject blank = Instantiate(blankPref);
        blank.transform.SetParent(Parent, false);
        LevelVars.instance.StartLevel();
        LevelVars.instance.CurrNuclid = LevelVars.instance.UpperNuclids[0];
        LevelVars.instance.MaxHP = 100;
    }
}
