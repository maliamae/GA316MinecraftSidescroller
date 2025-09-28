using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScreenTransition : MonoBehaviour
{
    public CanvasGroup blackScreen;
    public GameObject steveChar;
    public GameObject creakingChar;
    public Transform steveSpawnPoint;
    public Transform creakingSpawnPoint;
    public GameObject creakingBorder;

    public IEnumerator AnimateTransitionIn()
    {
        blackScreen.gameObject.SetActive(true);
        var tweener = blackScreen.DOFade(1f, 2f);
        yield return tweener.WaitForCompletion();
        steveChar.transform.position = steveSpawnPoint.position;
        creakingChar.transform.position = creakingSpawnPoint.position;
        creakingChar.SetActive(false);
        creakingChar.GetComponentInChildren<CreakingBehavior>().atBorder = false;
        creakingBorder.GetComponent<Collider2D>().isTrigger = true;
        StartCoroutine(AnimateTransitionOut());
    }

    public IEnumerator AnimateTransitionOut()
    {
        var tweener = blackScreen.DOFade(0f, 4f);
        yield return tweener.WaitForCompletion();
        blackScreen.gameObject.SetActive(false);
    }
}
