using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI contentText;
    public LayoutElement layoutElement;
    public int characterWrapLimit; 

    // Update is called once per frame
    void Update()
    {
        /*int headerLength = headerText.text.Length;
        int contentLength = contentText.text.Length;

        layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false; */

        Vector2 position = Input.mousePosition;

        transform.position = position;
    }


    public void SetText(string content, string header = "" )
    {
        if (string.IsNullOrEmpty(header))
        {
            headerText.gameObject.SetActive(false);
        }
        else
        {
            headerText.gameObject.SetActive(true);
            headerText.text = header;
        }
        contentText.text = content;

        int headerLength = headerText.text.Length;
        int contentLength = contentText.text.Length;

        layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
    }
}
