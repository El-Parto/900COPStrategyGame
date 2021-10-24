using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    public void Load(int SceneSelect)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneSelect);
    }
}
