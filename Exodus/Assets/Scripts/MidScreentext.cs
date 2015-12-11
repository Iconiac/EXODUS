using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MidScreentext : MonoBehaviour
{
    [SerializeField] GameObject DialogePanel;
    [SerializeField] Text InGameText;
    [SerializeField] string TextToShow;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            DialogePanel.SetActive(true);
            InGameText.text = "" + TextToShow;
            Invoke("DisablePanel", 4f);
        }
    }

    void DisablePanel()
    {
        DialogePanel.SetActive(false);
    }
}
