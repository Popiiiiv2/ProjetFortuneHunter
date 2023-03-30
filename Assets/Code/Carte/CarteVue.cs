using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Cartes
{
    public class CarteVue : MonoBehaviour
    {
        public CarteControleur evenement;
        public CarteControleur brocante;
        public CarteControleur email;

        void Start()
        {
            evenement.nouveauPaquet(TypeCase.EVENEMENT);
            brocante.nouveauPaquet(TypeCase.BROCANTE);
            email.nouveauPaquet(TypeCase.MAIL);
        }
    }
}
