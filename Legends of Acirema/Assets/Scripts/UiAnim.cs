using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiAnim : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image image;
    [SerializeField] private float fps;
    [SerializeField] private float speed;
    [SerializeField] private GameObject player;
    private Health playerHealth;
    private float maxHealth;
    private int currentSprite = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Animate());
        speed = 1 / fps;
        playerHealth = player.GetComponent<Health>();
        maxHealth = playerHealth.health;
    }

    // Update is called once per frame
    void Update()
    {
        speed = playerHealth.health / (maxHealth * 3);
    }
    IEnumerator Animate()
    {
        if (currentSprite > sprites.Length - 1) { currentSprite = 0; }
        Debug.Log(currentSprite);
        yield return new WaitForSeconds(speed);
        image.sprite = sprites[currentSprite];
        currentSprite += 1;
        StartCoroutine(Animate());
    }
}
