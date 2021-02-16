using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class TestTorche : MonoBehaviour
{
    public Material torcheMaterial; // Je modifie le material juste pour avoir du feedback de test, pas besoin de le maintenir
    public bool isLit = false; //Bool qui d�termine si la torche est active ou pas

    //C'est Pierre qui � fait �a
    public UnityEvent wasUnlit = new UnityEvent();
    List<Collider> litObjects = new List<Collider>();

    private void Start()
    {
        wasUnlit.AddListener(UnlightEverything);
    }
    void Update()
    {
        if (isLit)
        {
            torcheMaterial.color = Color.red;
            GetComponent<SphereCollider>().radius = 2;
        }
        else
        {
            torcheMaterial.color = Color.black;
            wasUnlit.Invoke();
        }
    }

    //Cette m�thode fau=it que quand la torche s'�teint lorsqu'un object est en train d'int�ragir avec, cet objet s'�tein aussi
    void UnlightEverything()
    {
        GetComponent<SphereCollider>().radius = 0;
        foreach (Collider col in litObjects)
        {
            col.GetComponent<TestInvisibleInk>().mesh.enabled = false;
        }
        litObjects.Clear();
    }

    //Contrairement au flash qui dit � l'object d�t�ct� � s'allumer, c'est la torche elle m�me qui vas r�v�ler les objets invisibles
    private void OnTriggerEnter(Collider other)
    {
        if (isLit)
        {
            litObjects.Add(other);
            if (other.GetComponent<TestInvisibleInk>())
            {
                other.GetComponent<TestInvisibleInk>().mesh.enabled = true;
            }
        }
    }

    //La torche �tein l'object en contact lorsqu'il sors de la zone ilumin�
    private void OnTriggerExit(Collider other)
    {
        if (isLit)
        {
            litObjects.Remove(other);
            if (other.GetComponent<TestInvisibleInk>())
            {
                other.GetComponent<TestInvisibleInk>().mesh.enabled = false;
            }
        }
    }
}
