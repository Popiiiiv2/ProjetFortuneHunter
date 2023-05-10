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
        public CarteControleur dimanche;
        public CarteControleur paye;

        public CarteVue()
        {
            evenement = new CarteControleur(TypeCase.EVENEMENT);
            brocante = new CarteControleur(TypeCase.BROCANTE);
            mail = new CarteControleur(TypeCase.MAIL);
            dimanche = new CarteControleur(TypeCase.DIMANCHE);
            paye = new CarteControleur(TypeCase.PAYE);
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
                    return getEmail();
                case TypeCase.DIMANCHE:
                    return getDimanche();
                case TypeCase.PAYE:
                    return getPaye();
                default : return null;
            }
        }
        public CarteControleur getEvenement()
        {
            return evenement;
        }
        public CarteControleur getBrocante()
        {
            return brocante;
        }
        public CarteControleur getEmail()
        {
            return mail;
        }

        public CarteControleur getDimanche()
        {
            return dimanche;
        }

        public CarteControleur getPaye()
        {
            return paye;
        }
    }
}
