using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform fondo;
    public float factor0 = 1f;

    public Transform capa1;
    public float factor1 = 1 / 2f;

    public Transform capa2;
    public float factor2 = 1 / 4f;

    public Transform capa3;
    public float factor3 = 1 / 6f;

    public Transform capa4;
    public float factor4 = 1 / 8f;

    private float displacement;
    private float iniCamPosFrame;
    private float nextCamPosFrame;

    // Update is called once per frame
    void Update()
    {
        iniCamPosFrame = transform.position.x;
        transform.position = new Vector3(Player.obj.transform.position.x, transform.position.y, transform.position.z);
    }

    private void LateUpdate() 
    {
        nextCamPosFrame = transform.position.x;

        fondo.position = new Vector3(fondo.position.x + (nextCamPosFrame - iniCamPosFrame) * factor0, fondo.position.y, fondo.position.z);
        capa1.position = new Vector3(capa1.position.x + (nextCamPosFrame - iniCamPosFrame) * factor1, capa1.position.y, capa1.position.z);
        capa2.position = new Vector3(capa2.position.x + (nextCamPosFrame - iniCamPosFrame) * factor2, capa2.position.y, capa2.position.z);
        capa3.position = new Vector3(capa3.position.x + (nextCamPosFrame - iniCamPosFrame) * factor3, capa3.position.y, capa3.position.z);
        capa4.position = new Vector3(capa4.position.x + (nextCamPosFrame - iniCamPosFrame) * factor4, capa4.position.y, capa4.position.z);
    }
}
