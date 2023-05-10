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
            evenement = new CarteControleur(TypeCase.EVENEMENT);
            brocante = new CarteControleur(TypeCase.BROCANTE);
            mail = new CarteControleur(TypeCase.MAIL);
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
            return getemail();
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
