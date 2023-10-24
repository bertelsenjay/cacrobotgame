using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{

    private static TooltipSystem current;
    public Tooltip tooltip; 
    private void Awake()
    {
        current = this;
        Hide();
    }

    public static void Show(string content, string header = "")
    {
        current.tooltip.SetText(content, header);
        current.tooltip.gameObject.SetActive(true);
        Debug.Log("Showing");
    }

    public static void Hide()
    {
        current.tooltip.gameObject.SetActive(false);
    }
    
}
