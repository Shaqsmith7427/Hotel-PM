using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayLightsController : MonoBehaviour
{
    #region Variables
    [SerializeField] private Light light;
    [SerializeField] private float minIntensity = 10f;
    [SerializeField] private float maxIntensity = 40f;
    [Range(1,50)]
    [SerializeField] private int smoothing = 5;
    Queue<float> smoothQueue;
    private float lastSum = 0f;
    private float newVal = 0f;
    #endregion


    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        smoothQueue = new Queue<float>(smoothing);

        if (light == null)
            light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (light == null)
            return;

        //pops off an item if too big
        while(smoothQueue.Count >= smoothing)
        {
            lastSum -= smoothQueue.Dequeue();
        }

        //Generates a random new item, calc. new avg.
        newVal = Random.Range(minIntensity, maxIntensity);
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;

        //Calc. new smoothed avg.
        light.intensity = (lastSum / (float)smoothQueue.Count);
    }

    void Reset()
    {
        smoothQueue.Clear();
        lastSum = 0f;
    }
    #endregion
}
