using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveCounter : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI waveText;
    int waveCount;
    [SerializeField] float waveTimer;

    // Start is called before the first frame update
    void Start()
    {
        waveTimer -= Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        waveTimer -= Time.deltaTime;
        if (waveTimer <= 0)
        {
            waveCount++;
            waveTimer = 10;
        }
        waveText.text = "Wave: " + waveCount;
    }
}
