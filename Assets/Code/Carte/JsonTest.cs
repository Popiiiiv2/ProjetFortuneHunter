using UnityEngine;
using System.IO;
using System.Collections.Generic;

namespace Cartes
{
    public class JsonTest : MonoBehaviour
    {

        public ListeEvenement evenements = new ListeEvenement();
        public ListeEmail emails = new ListeEmail();
        public ListeAcquisition acquisitions = new ListeAcquisition();

        void Start()
        {
            acquisitions.remplirPaquetAcquisition();
            Debug.Log(acquisitions.getListeAcquisition().Count);
            emails.remplirPaquetEmail();
            Debug.Log(emails.getListeEmail().Count);
            emails.retirerElementPaquetEmail(emails, 2);
            Debug.Log(emails.getListeEmail().Count);
            evenements.remplirPaquetEvenement();
            Debug.Log(evenements.getListeEvenement().Count);


            /*for(int i=0;i<2;i++) {
                Debug.Log(emails.tirerRandomEmail().getDescription());
                Debug.Log(evenements.tirerRandomEvenement().getDescription());
                Debug.Log(acquisitions.tirerRandomAcquisition().getDescription());

            }*/

        }
    }
}