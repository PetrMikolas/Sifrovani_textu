using System;

namespace SifrovaniTextuMVC.Models {
    public class AlgoritmusCaesarovaSifra : IAlgoritmus {

        /// <summary>
        /// Vlastnost třídy AlgoritmusCaesarovaSifra
        /// </summary>
        public int Posun { get; set; }

        /// <summary>
        /// Vlastnost třídy AlgoritmusCaesarovaSifra
        /// </summary>
        public string Cinnost { get; set; }

        /// <summary>
        /// Vlastnost třídy AlgoritmusCaesarovaSifra
        /// </summary>
        public string TextIn { get; set; }

        /// <summary>
        /// Vlastnost třídy AlgoritmusCaesarovaSifra
        /// </summary>
        public string TextOut { get; set; }

        /// <summary>
        /// Vlastnost třídy AlgoritmusCaesarovaSifra
        /// </summary>
        public string LabelIn { get; set; }

        /// <summary>
        /// Vlastnost třídy AlgoritmusCaesarovaSifra
        /// </summary>
        public string LabelIn2 { get; set; }

        /// <summary>
        /// Vlastnost třídy AlgoritmusCaesarovaSifra
        /// </summary>
        public string LabelOut { get; set; }

        /// <summary>
        /// Vlastnost třídy AlgoritmusCaesarovaSifra
        /// </summary>
        public string SifrujDesifruj { get; set; }

        /// <summary>
        /// Šifruje text do Caesarovy šifry
        /// </summary>        
        public void sifruj() {
            string validniText = string.Empty;
            char znak;

            try {
                // validace 
                if (TextIn != null) {
                    for (int i = 0; i < TextIn.Length; i++) {
                        if ((TextIn[i] == 32) || (TextIn[i] == 44) || (TextIn[i] == 46) || (TextIn[i] >= 97 && TextIn[i] <= 122)) {
                            TextOut = string.Empty;
                            validniText = TextIn;
                        }
                        else {
                            validniText = string.Empty;
                            TextOut = "Zadaný text obsahuje neplatné znaky";
                            break;
                        }
                    }
                }
                else {
                    TextOut = "Nebyl vložen text k šifrování";
                }

                // šifrování                
                for (int i = 0; i < validniText.Length; i++) {
                    znak = char.Parse(validniText.Substring(i, 1));
                    if (znak == 32) {
                        znak = ' ';
                    }
                    else if (znak == 44) {
                        znak = ',';
                    }
                    else if (znak == 46) {
                        znak = '.';
                    }
                    else if (znak + Posun > 122) {
                        znak = Convert.ToChar(znak + Posun - 26);
                    }
                    else {
                        znak = Convert.ToChar(znak + Posun);
                    }
                    TextOut += znak;
                }
            }
            catch (NullReferenceException e) { TextOut = e.Message; }
            catch (FormatException e) { TextOut = e.Message; }
            catch (Exception e) { TextOut = e.Message; }
        }

        /// <summary>
        /// Dešifruje text z Caearovy šifry
        /// </summary>        
        public void desifruj() {
            string validniText = string.Empty;
            char znak;

            try {
                // validace 
                if (TextIn != null) {
                    for (int i = 0; i < TextIn.Length; i++) {
                        if ((TextIn[i] == 32) || (TextIn[i] == 44) || (TextIn[i] == 46) || (TextIn[i] >= 97 && TextIn[i] <= 122)) {
                            validniText = TextIn;
                        }
                        else {
                            validniText = string.Empty;
                            TextOut = "Zadaný text obsahuje neplatné znaky";
                            break;
                        }
                    }
                }
                else {
                    TextOut = "Nebyl vložen text k dešifrování";
                }

                // dešifrování                
                for (int i = 0; i < validniText.Length; i++) {
                    znak = char.Parse(validniText.Substring(i, 1));

                    if (znak == 32) {
                        znak = ' ';
                    }
                    else if (znak == 44) {
                        znak = ',';
                    }
                    else if (znak == 46) {
                        znak = '.';
                    }
                    else if (znak - Posun < 97) {
                        znak = Convert.ToChar(znak - Posun + 26);
                    }
                    else {
                        znak = Convert.ToChar(znak - Posun);
                    }
                    TextOut += znak;
                }
            }
            catch (NullReferenceException e) { TextOut = e.Message; }
            catch (FormatException e) { TextOut = e.Message; }
            catch (Exception e) { TextOut = e.Message; }
        }

        /// <summary>
        /// Podle zvolené činnosti zobrazí v labelu text s instrukcemi pro uživatele
        /// </summary>
        public void zobrazLabel() {
            if (Cinnost == "Sifrovat") {
                LabelIn = "Vložte text, který chcete šifrovat do Caesarovy šifry.";
                LabelIn2 = "Pouze malá písmena anglické abecedy, čárky, tečky a mezery.";
                LabelOut = "Šifrovaný text:";
            }
            if (Cinnost == "Desifrovat") {
                LabelIn2 = "Vložte šifrovaný text v Caesarově šifře, který chcete dešifrovat.";
                LabelOut = "Dešifrovaný text:";
            }
        }
    }
}
