using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Follow;
    public GameObject Follow2;
    public Vector2 MinCamPos, MaxCamPos;
    public float SmoothTime;

    private Vector2 Speed;
    public bool SigueCam = false;
    // Start is called before the first frame update
    void Start()
    {
        Follow = GameObject.FindGameObjectWithTag("Player2");
        //Follow2 = GameObject.FindGameObjectWithTag("Mazmorra");
    }

    private void FixedUpdate()
    {

        if (Follow != null)
        {
            float posX = Mathf.SmoothDamp(transform.position.x, Follow.transform.position.x, ref Speed.x, SmoothTime);
            float posY = Mathf.SmoothDamp(transform.position.y, Follow.transform.position.y, ref Speed.y, SmoothTime);
            transform.position = new Vector3(
            Mathf.Clamp(posX, MinCamPos.x, MaxCamPos.x),
            Mathf.Clamp(posY, MinCamPos.y, MaxCamPos.y),
            transform.position.z);
            //if (SigueCam == false)
            //{
            //    float posX = Mathf.SmoothDamp(transform.position.x, Follow.transform.position.x, ref Speed.x, SmoothTime);
            //    float posY = Mathf.SmoothDamp(transform.position.y, Follow.transform.position.y, ref Speed.y, SmoothTime);
            //    transform.position = new Vector3(
            //    Mathf.Clamp(posX, MinCamPos.x, MaxCamPos.x),
            //    Mathf.Clamp(posY, MinCamPos.y, MaxCamPos.y),
            //    transform.position.z);
            //}
            //if (SigueCam == true)
            {
                //float posX = Mathf.SmoothDamp(transform.position.x, Follow2.transform.position.x, ref Speed.x, SmoothTime);
                //float posY = Mathf.SmoothDamp(transform.position.y, Follow2.transform.position.y, ref Speed.y, SmoothTime);
                //transform.position = new Vector3(
                //Mathf.Clamp(posX, MinCamPos.x, MaxCamPos.x),
                //Mathf.Clamp(posY, MinCamPos.y, MaxCamPos.y),
                //transform.position.z);
            }

        }

    }
}
