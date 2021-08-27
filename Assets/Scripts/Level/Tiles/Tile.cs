using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] protected float buildSpeed;
    [SerializeField] protected EasingFunctionName easingForBuild;
    [SerializeField] protected float fadeOutSpeed;
    [SerializeField] protected EasingFunctionName easingForDestroyWithFadeOut;

    public void BuildTile(Vector3 endScale, float delay)
    {
        StartCoroutine(BuildTileEnumerator(endScale, EasingFunction.GetEasingFunctionByName(easingForBuild), buildSpeed, delay));
    }
    
    public void DestroyTile()
    {
        DestroyTileImmediately();
    }

    public void DestroyTileWithFadeOut(float endValue)
    {
        StartCoroutine(DestroyTileWithFadeOutEnumerator(endValue, EasingFunction.GetEasingFunctionByName(easingForDestroyWithFadeOut), fadeOutSpeed));
    }

    protected virtual void DestroyTileImmediately()
    {
        Destroy(gameObject); // TODO Change this
    }

    protected virtual IEnumerator BuildTileEnumerator(Vector3 endScale, EasingFunctionDelegate easingFunction, float effectSpeed, float delayBeforeBuilding)
    {
        yield return new WaitForSeconds(delayBeforeBuilding);

        Vector3 currentLocalScale = transform.localScale;

        for (float t = 0; t <= 1f; t += 0.1f * Time.deltaTime * effectSpeed)
        {
            float value = easingFunction(t);
            transform.localScale = Vector3.Lerp(currentLocalScale, endScale, value);
            yield return null;
        }

        transform.localScale = Vector3.Lerp(currentLocalScale, endScale, 1);
    }

    protected virtual IEnumerator DestroyTileWithFadeOutEnumerator(float endValue, EasingFunctionDelegate easingFunction, float effectSpeed)
    {
        Renderer renderer = GetComponent<Renderer>();
        float alpha = renderer.material.color.a;
        for (float t = 0.0f; t <= 1.0f; t += 0.1f * Time.deltaTime * effectSpeed)
        {
            Color newColor = renderer.material.color;
            float value = easingFunction(t);
            newColor.a = Mathf.Lerp(alpha, endValue, value);
            renderer.material.color = newColor;
            yield return null;
        }

        Destroy(gameObject);
    }
}