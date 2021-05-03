using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public GameObject Platform;
    public Transform StartPoint;
    public Transform EndPoint;
    public float Vel;

    private Vector3 MoverHacia;
    // Start is called before the first frame update
    void Start()
    {
        MoverHacia = EndPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, MoverHacia, Vel * Time.deltaTime);
        if (Platform.transform.position == EndPoint.position)
        {
            MoverHacia = StartPoint.position;
        }
        if (Platform.transform.position == StartPoint.position)
        {
            MoverHacia = EndPoint.position;
        }
    }
}
