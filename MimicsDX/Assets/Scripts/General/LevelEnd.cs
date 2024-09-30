using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private AudioManager _sfx;

    private void Awake()
    {
        _sfx = FindObjectOfType<AudioManager>();
    }

    public void LevelEndStart()
    {
        _sfx.ChangeMus(14, 16);
        Invoke("LevelEndContinue", 2f);
    }

    private void LevelEndContinue()
    {
        _sfx.ChangeMus(16, 15);
        Invoke("LevelEndFinish", 9f);
    }

    private void LevelEndFinish()
    {
        SceneManager.LoadScene("YouWin");
    }
    
}
