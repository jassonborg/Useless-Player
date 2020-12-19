using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour
{
    public void OnClick(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
    }
}
