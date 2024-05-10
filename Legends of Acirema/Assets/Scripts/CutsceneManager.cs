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
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Camera cutsceneCamera;
    private Animator animator;
    void Start()
    {
        gameManager = gameManager.instance;
        gameManager.StartCutscene("WakeUp");
        animator = cutsceneCamera.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("WakeUp") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            cutsceneCamera.gameObject.SetActive(false);
            gameManager.EndCutscene("WakeUp");
        }
    }
    void Tutorial()
    {
        
    }
}
