using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager instance;
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
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject transparent;

    [SerializeField] private CutsceneManager cutsceneManager;
    [SerializeField] private GameObject enemies;
    [SerializeField] private GameObject cutsceneAssets;

    [SerializeField] private GameObject tutTextObject0;
    [SerializeField] private GameObject tutText0;
    [SerializeField] private GameObject tutTextObject1;
    [SerializeField] private GameObject tutText1;
    void Start()
    {
        transparent.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (tutText0.GetComponent<TextOutputter>().isFinished == true &&
            player.GetComponent<PlayerController>().hasPipeEquipped == true) 
        {
            tutTextObject0.SetActive(false);
            tutTextObject1.SetActive(true);
        }
        if (tutText1.GetComponent<TextOutputter>().isFinished == true)
        {
            tutTextObject1.SetActive(false);
        }
    }
    public void StartCutscene(string cutscene)
    {
        enemies.SetActive(false);
        player.SetActive(false);

    }
    public void EndCutscene(string cutscene)
    {
        enemies.SetActive(true);
        player.SetActive(true);
        tutTextObject0.SetActive(true);
    }
}
