using UnityEngine;

public class Raycast : MonoBehaviour
{
    private GameController gameController;

    public ParticleSystem muzzleFlash;
    public ParticleSystem hitEffect;

    private Camera fpsCam;

    private void Start()
    {
        fpsCam = GetComponentInParent<Camera>();
        gameController = GameController.SharedInstance;
    }

    private void OnEnable()
    {
        FireAction.onFired += CastRay;
    }

    private void OnDisable()
    {
        FireAction.onFired -= CastRay;
    }

    public void CastRay()
    {
        muzzleFlash.Emit(1);
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit))
        {
            hitEffect.transform.position = hit.point;
            hitEffect.transform.forward = hit.normal;
            hitEffect.Emit(1);
            TargetProperties target = hit.collider.GetComponent<TargetProperties>();
            if (target != null)
            {
                gameController.ScoreTracker(target.pointValue);
                target.gameObject.SetActive(false);
            }
        }

    }
}