using UnityEngine;
using System.IO;
using System.Collections.Generic;

namespace Cartes
{
    public class JsonTest : MonoBehaviour
    {
        void Start()
        {
            PaquetsCartes paquetEvenement = new PaquetsCartes();
            paquetEvenement.setPaquetCarte();
            // Debug.Log(paquetEvenement.paquet.Count);
            // emails.remplirPaquetEmail();
            // emails.retirerElementPaquetEmail(emails, 2);
            // evenements.remplirPaquetEvenement();
            /*for(int i=0;i<2;i++) {
                Debug.Log(emails.tirerRandomEmail().getDescription());
                Debug.Log(evenements.tirerRandomEvenement().getDescription());
                Debug.Log(acquisitions.tirerRandomAcquisition().getDescription());

            }*/

        }
    }
}