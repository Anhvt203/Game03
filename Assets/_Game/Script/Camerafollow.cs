using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camerafollow : Singleton<Camerafollow>
{
    public Transform TF;
    public Transform playerTF;
    //public Camera camera;
    [SerializeField] Vector3 offset;
    
    // Update is called once per frame
    void LateUpdate()
    {
        TF.position = Vector3.Lerp(TF.position, playerTF.position + offset,Time.deltaTime * 5f);
    }
}
