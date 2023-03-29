using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Cartes
{
    [System.Serializable]
    public class ListeEmail
    {
        public List<Email> email;

        public List<Email> getListeEmail()
        {
            return email;
        }

        public Email tirerRandomEmail()
        {
            int random = Random.Range(0, getListeEmail().Count);
            Email carte;
            carte = getListeEmail()[random];
            return carte;
        }

        public bool estVide()
        {
            return getListeEmail().Count == 0;
        }

        public void remplirPaquetEmail()
        {
            string assetsPath = Application.dataPath;
            string jsonFilePath = assetsPath + "\\code\\jsonDonnee\\email.json";
            string jsonEmail = File.ReadAllText(jsonFilePath);
            ListeEmail emails = JsonUtility.FromJson<ListeEmail>(jsonEmail);
            for (int i = 0; i < emails.getListeEmail().Count; i++)
            {
                email.Add(emails.getListeEmail()[i]);
            }
        }

        public void retirerElementPaquetEmail(ListeEmail emails, int index)
        {
            if (!emails.estVide())
            {
                emails.getListeEmail().RemoveAt(index);
            }
        }
    }

}