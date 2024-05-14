using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextOutputter : MonoBehaviour
{
    [SerializeField] private string[] allText;
    [SerializeField] private float outputDelay;
    [SerializeField] private float fullDelay;
    [SerializeField] private TextMeshProUGUI textBox;
    public bool isFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypeWriter(allText[0],0));
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("hobotalkdown") &&
            GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) 
        {
            isFinished = true;
        }
    }
    IEnumerator TypeWriter(string fullText, int index)
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            textBox.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(outputDelay);
        }
        index += 1;
        yield return new WaitForSeconds(fullDelay);
        if (index <= allText.Length - 1)
        {
            Debug.Log(index);
            Debug.Log(allText.Length);
            StartCoroutine(TypeWriter(allText[index], index));
        }else
        {
            GetComponentInParent<Animator>().SetTrigger("down");
        }
    }
}
