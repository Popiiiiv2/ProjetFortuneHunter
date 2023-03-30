using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Cartes
{
    public class CarteVue
    {
        public CarteControleur evenement;
        public CarteControleur brocante;
        public CarteControleur mail;

        public CarteVue()
        {
            evenement = new CarteControleur();
            brocante = new CarteControleur();
            mail = new CarteControleur();
            evenement.nouveauPaquet(TypeCase.EVENEMENT);
            brocante.nouveauPaquet(TypeCase.BROCANTE);
            mail.nouveauPaquet(TypeCase.MAIL);
        }

        public CarteControleur getPaquet(TypeCase type)
        {
            switch (type)
            {
                case TypeCase.BROCANTE:
                    return getBrocante();
                case TypeCase.EVENEMENT:
                    return getEvenement();
                case TypeCase.MAIL:
                    return getemail();
            }
            return null;
        }
        public CarteControleur getEvenement()
        {
            return evenement;
        }
        public CarteControleur getBrocante()
        {
            return brocante;
        }
        public CarteControleur getemail()
        {
            return mail;
        }
    }
}
