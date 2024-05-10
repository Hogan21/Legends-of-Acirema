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

    [SerializeField] private CutsceneManager cutsceneManager;
    [SerializeField] private GameObject enemies;
    [SerializeField] private GameObject cutsceneAssets;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
    }
}
