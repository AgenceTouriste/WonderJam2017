using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistMusic : MonoBehaviour {

	void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
