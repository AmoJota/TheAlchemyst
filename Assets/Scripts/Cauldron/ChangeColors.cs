using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColors : MonoBehaviour
{
    [SerializeField] Image fillBar;
    [SerializeField] ParticleSystem particles;
    [SerializeField] Color startColorParticles, yelowColorParticles, redColorParticles;

    ParticleSystem.MainModule settings;
    private void Start()
    {
         settings = particles.main;       
    }
    void Update()
    {
        ChangeParticleColors();
    }
    void ChangeParticleColors()
    {
        if (fillBar.fillAmount > 0.5f && fillBar.fillAmount <= 0.8f )
        {
            NewColor(yelowColorParticles);
        }

        if (fillBar.fillAmount < 0.4f)
        {
            NewColor(redColorParticles);
        }

        if (fillBar.fillAmount == 1)
        {
            NewColor(startColorParticles);
        }

    }
    void NewColor(Color color)
    {
        settings.startColor = new ParticleSystem.MinMaxGradient(color);
        fillBar.color = color;
    }
}
