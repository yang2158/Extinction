using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class pulseScreen : MonoBehaviour
{
    public PostProcessVolume volume;
    // Start is called before the first frame update
    float interval = 0;
    public float waveHeight=5;
    public float waveIntensity = 5;
    public float waveFrequency=1f;
    Bloom obj;
    void Start()
    {
        waveFrequency /= 2;
    }

    // Update is called once per frame
    void Update()
    {
        interval = (interval+Time.deltaTime);
        float wave = waveIntensity * Mathf.Cos(((Mathf.PI * 2) / waveIntensity) * interval) + waveIntensity+ waveHeight;
        
        volume.profile.TryGetSettings<Bloom>(out obj);
        obj.intensity.value = wave;
        
    }
}
