using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vida = 100;

    public void RecibirDaño(int daño)
    {
        vida -= daño;
        Debug.Log(gameObject.name + " recibió daño. Vida actual: " + vida);

        if (vida <= 0)
        {
            Muerte();
        }
    }

    void Muerte()
    {
        Debug.Log(gameObject.name + " ha muerto!");
        gameObject.SetActive(false);
    }
}
