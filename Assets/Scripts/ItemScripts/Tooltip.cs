using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private Text tooltip;

    public static Tooltip instance { get; private set; }

    private void Start()
    {
        instance = this;
        tooltip = GetComponentInChildren<Text>();
    }
    public void GenerateTooltip(Item item)
    {
        GetComponent<Image>().color = new Color(1,1,1,1);
        transform.GetChild(0).GetComponent<Text>().color = new Color(0,0,0,1);

        string statText = "";
        if(item.stats.Count > 0)
        {
            foreach(var stat in item.stats)
            {
                statText += stat.Key.ToString() + ": " + stat.Value.ToString() + "\n";
            }
        }
        string tooltip = string.Format("<b>{0}</b>\n{1}\n\n<b>{2}</b>", item.title,item.description,statText);
        this.tooltip.text = tooltip;
        gameObject.SetActive(true);
    }
}
