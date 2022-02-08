using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public Gradient colorGradient;
    public LineRenderer healthLine;

    void Start()
    {
        healthLine = this.GetComponent<LineRenderer>();
    }

    public void SetHealthBar(float targetPercentage)
    {
        healthLine.positionCount = 2;
        healthLine.SetPosition(0,Vector3.zero);

        float currentPercentage = healthLine.GetPosition(1).x;
        targetPercentage = Mathf.Clamp(targetPercentage,0,1);
        StartCoroutine(AnimateHealthBar(currentPercentage,targetPercentage,3f));
    }

    IEnumerator AnimateHealthBar(float startingPercentage, float targetPercentage, float animationTime)
    {
        //i added this line to scale the animation time according to the amount of health being animated
        animationTime = animationTime * Mathf.Abs(targetPercentage-startingPercentage);
        float timer = 0;

        while(timer<animationTime)
        {
            timer+=Time.deltaTime;
            float timePercentage = timer/animationTime;
            float currentPercentage = Mathf.Lerp(startingPercentage,targetPercentage,timePercentage);
            healthLine.SetPosition(1,new Vector3(currentPercentage,0,0));
            AssignColorAtPercent(currentPercentage);
            yield return null;
        }

        healthLine.SetPosition(1,new Vector3(targetPercentage,0,0));
        AssignColorAtPercent(targetPercentage);
        
        yield return null;
    }

    //assumes line renderer color only has 2 ColorKeys
    void AssignColorAtPercent(float percent)
    {
            Color currentColor = colorGradient.Evaluate(percent);
            healthLine.startColor = currentColor;
            healthLine.endColor = currentColor;
    }
}
