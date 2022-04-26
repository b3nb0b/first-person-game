using System.Collections;
using UnityEngine.VFX;
using UnityEngine;

public class FlintlockController : MonoBehaviour
{
    public Animator handAnimator;
    private bool canFire = true;
    public GameObject muzzleFlash;
    public ParticleSystem smoke;
    public Camera fpsCam;
    public GameObject smokeStart;
    private Vector3 end;
    public Material smokeLineMaterial;
    public GameObject smokeTrailObject;
    public ParticleSystem smokeTrail;
    public ParticleSystem hitSmoke;
    public ParticleSystem hitBlood;
    public ParticleSystem hitDebris;
    public CameraShake Camera;
    public float length, power;


    public GameObject myLine;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            StartCoroutine(Fire());
        }

    }

    IEnumerator Fire()
    {
        //Initialzie
        canFire = false;
        handAnimator.Play("Flintlock Fire", -1, 0);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Weapon_SFX/Flintlock/fire");
        muzzleFlash.SetActive(true);
        StartCoroutine(Camera.StartShake(length, power));
        smoke.Play(true);


        //Raycast
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 50f))
        {
            end = hit.point;

            //Hit Particles
            ParticleSystem hitSmokeClone = Instantiate(hitSmoke, hit.point, Quaternion.identity);
            hitSmokeClone.Play(true);
            if (hit.transform.tag == "enemy")
            {
                ParticleSystem hitBloodClone = Instantiate(hitBlood, hit.point, Quaternion.LookRotation(hit.normal));
                hit.transform.SendMessage("HitByRay");
                hitBloodClone.Play(true);
            }
            if (hit.transform.tag == "ground")
            {
                ParticleSystem hitDebrisClone = Instantiate(hitDebris, hit.point, Quaternion.LookRotation(hit.normal));
                hitDebrisClone.Play(true);
            }
        }
        else
        {
            end = smokeStart.transform.position + fpsCam.transform.forward * 50f;
        }

        //Smoke Line
        GameObject myLineClone = Instantiate(myLine, smokeStart.transform.position, Quaternion.identity);
        myLineClone.layer = 0;
        myLineClone.AddComponent<LineRenderer>();
        LineRenderer lr = myLineClone.GetComponent<LineRenderer>();
        lr.material = smokeLineMaterial;
        lr.startWidth = 0.3f;
        lr.endWidth = 0.3f;
        lr.SetPosition(0, smokeStart.transform.position);
        lr.SetPosition(1, end);
        // smokeLineMaterial.SetTextureScale(name, new Vector2(20, 20));
        lr.textureMode = LineTextureMode.Tile;

        yield return new WaitForSeconds(0.05f);

        muzzleFlash.SetActive(false);

        for (float i = 0.6f; i >= -0.1f; i -= 0.1f)
        {
            Color color = smokeLineMaterial.color;
            color.a = i;
            lr.startWidth -= 0.025f;
            lr.endWidth -= 0.025f;
            smokeLineMaterial.color = color;
            yield return new WaitForSeconds(0.1f);
        }

        GameObject.Destroy(myLineClone);

        yield return new WaitForSeconds(0.35f);

        yield return null;
    }

    public void AnimationFinish()
    {
        canFire = true;
    }
}
