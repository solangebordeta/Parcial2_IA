using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected GameManager Instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(Instance);
        }
        DontDestroyOnLoad(Instance);
    }

    // Update is called once per frame

}
