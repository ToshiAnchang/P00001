using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    void Update()
    {
        if(Player.Instance == null) { return; }

        Vector2 pPos = Player.Instance.transform.position;
        Camera.main.transform.position = new Vector3(pPos.x, pPos.y, Camera.main.transform.position.z);        
    }
}
