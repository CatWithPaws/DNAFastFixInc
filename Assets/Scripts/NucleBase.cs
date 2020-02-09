using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NucleBase : MonoBehaviour
{
    public GlobalVars.Nuclids currNuclid;
    Image nuclImage;

    private void Start()
    {
        nuclImage = GetComponent<Image>();
    }
}
