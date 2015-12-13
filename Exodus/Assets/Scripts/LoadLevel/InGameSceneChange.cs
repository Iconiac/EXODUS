using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameSceneChange : MonoBehaviour
{
    [SerializeField] string SceneToLoad;
    [SerializeField] float ChangeDistance;
    [SerializeField] GameObject DialogePanel;
    [SerializeField] Text InGameText;
    [SerializeField] string TextForTooMuchDistance;

    private GameObject _sister;
    private GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player");
        _sister = GameObject.Find("LilSister");
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Vector3.Distance(_player.transform.position, _sister.transform.position) <= ChangeDistance)
            {
                Application.LoadLevel(SceneToLoad);
            }
            
            else
            {
                DialogePanel.SetActive(true);
                InGameText.text = "" + TextForTooMuchDistance;
                Invoke("DisablePanel", 4f);
            }
        }
    }

    void DisablePanel()
    {
        DialogePanel.SetActive(false);
    }

}
