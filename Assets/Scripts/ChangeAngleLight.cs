using System.Collections;
using UnityEngine;

public class ChangeAngleLight : MonoBehaviour
{
    [SerializeField]
    float angleLight = 5f;
    [SerializeField]
    float updateInterval = 0.1f;  
    private Light m_light;
    
    void Awake()
    {
        m_light = GetComponent<Light>();   
        StartCoroutine(ChangeAngleLightCoroutine(m_light.transform.rotation.eulerAngles));
    }

    private IEnumerator ChangeAngleLightCoroutine(Vector3 vector3)
    {
        while (true)
        {
            m_light.transform.rotation = Quaternion.Euler(vector3.x, vector3.y += angleLight , vector3.z);
            yield return new WaitForSeconds(updateInterval);
        }            
    }
}
