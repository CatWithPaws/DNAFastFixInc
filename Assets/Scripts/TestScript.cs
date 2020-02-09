using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestScript : MonoBehaviour
{
    [SerializeField]
    Transform Pos1,CameraPos;
    Image cc,Image2;
    private void Update()
    {

        float pos1y = Pos1.position.y;
        float pos2y = Image2.transform.position.y;

        float CameraPosY = Mathf.Lerp(CameraPos.position.y, pos2y, 0.1f);

        CameraPos.position = new Vector3(CameraPos.position.x, CameraPosY, CameraPos.position.z);
    }
}
