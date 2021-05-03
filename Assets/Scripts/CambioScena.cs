using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScena : MonoBehaviour
{
    public int NewScene;
    public Vector2 NewPos;
    public GameObject Pers;
    public GameObject PP;
    public bool NewUso;
    // Start is called before the first frame update
    void Start()
    {
        Pers = GameObject.FindGameObjectWithTag("Player");
        //PP = GameObject.FindGameObjectWithTag("SceneControl");
        NewUso =  true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D Obj)
    {
        if (Obj.tag == "Player" && NewUso == true)
        {
            StartCoroutine(LoadLevel());
            NewUso = false;
        }
    }
    IEnumerator LoadLevel(/*int levelIndex*/)
    {
        //PP.GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(NewScene);
        NewUso = true;
        Pers.transform.position = NewPos;
        //PP.GetComponent<Animator>().SetTrigger("End");
    }
}
