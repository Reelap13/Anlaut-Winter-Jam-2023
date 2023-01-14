using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    [SerializeField] private Act _act;
    public Act Act
    {
        get
        {
            return _act;
        }
    }

    private void Start()
    {
        _act.StartAct();
    }


    public void GoToTheNextAct(string nameOfAct)
    {
        SceneManager.LoadScene(nameOfAct);
    }


}
