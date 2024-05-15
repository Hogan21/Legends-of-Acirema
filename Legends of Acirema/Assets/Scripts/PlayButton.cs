using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject black;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        GetComponent<Animator>().SetTrigger("ShiftGreen");
        GetComponent<AudioSource>().Play();
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        black.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
