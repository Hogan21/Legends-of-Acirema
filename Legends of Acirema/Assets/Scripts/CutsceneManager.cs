using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public CutsceneManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    [SerializeField] private GameObject gameManager;
    public bool tutorial;
    void Start()
    {
        tutorial = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorial) { Tutorial(); }
    }
    void Tutorial()
    {

    }
}
