using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalvaEscena : MonoBehaviour
{
    static SalvaEscena Perma;
    private void Awake()
    {

        //DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        if(Perma != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            Perma = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AutoDestruccion()
    {
        Destroy(gameObject);
    }
}
