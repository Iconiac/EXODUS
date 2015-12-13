using UnityEngine;
using System.Collections;

public class LoadMenu : MonoBehaviour {

	
	void Start ()
    {
        Invoke("Menu", 33f);
	}
	
    void Menu()
    {
        Application.LoadLevel("2D_UI_01_Concept_MainMenu_Final");
    }
}
