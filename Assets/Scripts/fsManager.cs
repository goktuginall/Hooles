using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fsManager : MonoBehaviour
{
    [SerializeField] ProgressSystem progSystem;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        progSystem.ProgressFunction("StarterScene");
    }
}
