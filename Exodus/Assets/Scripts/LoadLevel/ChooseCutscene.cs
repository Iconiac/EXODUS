using UnityEngine;
using System.Collections;

public class ChooseCutscene : MonoBehaviour
{

    [SerializeField] GameObject SonAndMother;
    [SerializeField] GameObject SonAndFather;
    [SerializeField] GameObject SisterAndMother;
    [SerializeField] GameObject SisterAndFather;

    void Start ()
    {
        Cursor.visible = false;
	    if (Decisions.DadChosen && Decisions.BrotherChosen)
        {
            SonAndMother.SetActive(true);
        }

        else if (Decisions.MomChosen && Decisions.BrotherChosen)
        {
            SonAndFather.SetActive(true);
        }

        else if (Decisions.DadChosen && Decisions.SisterChosen)
        {
            SisterAndMother.SetActive(true);
        }

        else if (Decisions.MomChosen && Decisions.SisterChosen)
        {
            SisterAndFather.SetActive(true);
        }
	}

}
