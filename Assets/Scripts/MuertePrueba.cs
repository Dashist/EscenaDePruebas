using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuertePrueba : MonoBehaviour
{
   
    public Vector2 NewPos;
    public GameObject Pers;
    
    // Start is called before the first frame update
    void Start()
    {
        Pers = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D Obj)
    {
        if (Obj.tag == "Player")
        {
            Pers.transform.position = NewPos;
        }
    }
    
}
