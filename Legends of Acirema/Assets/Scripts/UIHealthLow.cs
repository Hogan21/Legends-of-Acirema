using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthLow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float maxTransparency;
    [SerializeField] private Image image;
    private Health playerHealth;
    private float health;
    private float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<Health>();
        maxHealth = playerHealth.health;
    }

    // Update is called once per frame
    void Update()
    {
        health = playerHealth.health;
       if (health / maxHealth <= 0.4)
        {
            float transparency = 0.02f / (health / maxHealth);
            if (transparency > maxTransparency) { transparency = maxTransparency; }
            image.color = new Color (image.color.r,image.color.g,image.color.b,transparency);
        }
    }
}
