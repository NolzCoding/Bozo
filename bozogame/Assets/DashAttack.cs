using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttack : MonoBehaviour
{
    // Start is called before the first frame update

    private TestPlayer _testPlayer;
    
    void Start()
    {
        _testPlayer = gameObject.transform.parent.gameObject.GetComponent<TestPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
