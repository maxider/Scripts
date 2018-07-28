using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    private void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("space"))) { Play(); }
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }
}
