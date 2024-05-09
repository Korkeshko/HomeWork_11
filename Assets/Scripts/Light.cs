using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    private Light m_light;
    
    void Awake()
    {
        m_light = GetComponent<Light>();   
    }

    void Update()
    {
        //StartCoroutine(ChangeAngleLight(m_light));
    }

    // private IEnumerator ChangeAngleLight(Light light)
    // {
    //     float limitTimer = 20f;
    //     float timer = 0.0f;
       
    //     // while ((timer += Time.time) <= limitTimer)
    //     // {
    //     //     //new WaitForSeconds(2f);
    //     //     light.transform.rotation = Quaternion.Euler(0.0f, timer * limitTimer , 0f);
    //     // }       
    //     yield return null;        
    // }
}
