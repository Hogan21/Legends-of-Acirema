using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextOutputter : MonoBehaviour
{
    [SerializeField] private string fullText;
    [SerializeField] private float outputDelay;
    [SerializeField] private TextMeshProUGUI textBox;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypeWriter());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator TypeWriter()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            textBox.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(outputDelay);
        }
        yield return textBox.text;
    }
}
