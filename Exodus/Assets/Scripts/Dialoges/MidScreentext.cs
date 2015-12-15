﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MidScreentext : MonoBehaviour
{
    [SerializeField] GameObject DialogePanel;
    [SerializeField] GameObject Teddy;
    [SerializeField] Text InGameText;
    [SerializeField] string TextToShow;
	[SerializeField] AudioSource SoundToPlay;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            if (gameObject.CompareTag("Teddy"))
            {
                Teddy.SetActive(true);
            }
			SoundToPlay.Play();
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
