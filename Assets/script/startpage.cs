using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startpage : MonoBehaviour
{
    // Start is called before the first frame update
   public void Playgame()
    {
        SceneManager.LoadScene("spacegame");
    }

    public void Info()
    {
        SceneManager.LoadScene("info");
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
