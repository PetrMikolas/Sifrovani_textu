using System;

namespace SifrovaniTextuMVC.Models {

    public class AlgoritmusMorseovaAbeceda : IAlgoritmus {

        /// <summary>
        /// Datová složka třídy AlgoritmusMorseovaAbeceda
        /// </summary>
        public readonly char[] znakyTextu = { ' ', ',', '.', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        /// <summary>
        /// Datová složka třídy AlgoritmusMorseovaAbeceda
        /// </summary>
        public readonly string[] znakyMorseovyAbecedy = { " ", "--..--", ".-.-.-", ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----." };

        /// <summary>
        /// Vlastnost třídy AlgoritmusMorseovaAbeceda
        /// </summary>
        public string TextIn { get; set; }

        /// <summary>
        /// Vlastnost třídy AlgoritmusMorseovaAbeceda
        /// </summary>
        public string TextOut { get; set; }

        /// <summary>
        /// Vlastnost třídy AlgoritmusMorseovaAbeceda
        /// </summary>
        public string Cinnost { get; set; }

        /// <summary>
        /// Vlastnost třídy AlgoritmusMorseovaAbeceda
        /// </summary>
        public string LabelIn { get; set; }

        /// <summary>
        /// Vlastnost třídy AlgoritmusMorseovaAbeceda
        /// </summary>
        public string LabelIn2 { get; set; }

        /// <summary>
        /// Vlastnost třídy AlgoritmusMorseovaAbeceda
        /// </summary>
        public string LabelOut { get; set; }

        /// <summary>
        /// Vlastnost třídy AlgoritmusMorseovaAbeceda
        /// </summary>
        public string Vymazat { get; set; }

        /// <summary>
        /// Vlastnost třídy AlgoritmusMorseovaAbeceda
        /// </summary>
        public string SifrujDesifruj { get; set; }

        /// <summary>
        /// Šifruje text do Morseovy abecedy
        /// </summary>        
        public void sifruj() {
            string validniText = string.Empty;

            try {
                // validace 
                if (TextIn != null) {
                    for (int i = 0; i < TextIn.Length; i++) {
                        if ((TextIn[i] == 32) || (TextIn[i] == 44) || (TextIn[i] == 46) || (TextIn[i] >= 48 && TextIn[i] <= 57) || (TextIn[i] >= 65 && TextIn[i] <= 90) || (TextIn[i] >= 97 && TextIn[i] <= 122)) {
                            TextOut = string.Empty;
                            validniText = TextIn.ToLower();            // velká písmena převede na malá písmena  
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
                    for (int j = 0; j < znakyTextu.Length; j++) {
                        if (validniText[i] == znakyTextu[j]) {
                            TextOut += znakyMorseovyAbecedy[j];
                            TextOut += "|";                    // mezera mezi jednotlivými znaky morseovky                              
                        }
                    }
                }
            }
            catch (NullReferenceException e) { TextOut = e.Message; }
            catch (FormatException e) { TextOut = e.Message; }
            catch (Exception e) { TextOut = e.Message; }
        }


        /// <summary>
        /// Dešifruje text z Morseovy abecedy 
        /// </summary>        
        public void desifruj() {
            string validniText = string.Empty;
            string[] znakyMorseovky;

            try {
                // validace 
                if (TextIn != null) {
                    for (int i = 0; i < TextIn.Length; i++) {
                        if ((TextIn[i] == 32) || (TextIn[i] == 45) || (TextIn[i] == 46) || (TextIn[i] == 124)) {
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
                    TextOut = "Nebyl vložen text k dešifrování";
                }

                // dešifrování 
                znakyMorseovky = validniText.Split('|');
                for (int i = 0; i < znakyMorseovky.Length; i++) {
                    for (int j = 0; j < znakyMorseovyAbecedy.Length; j++) {
                        if (znakyMorseovky[i] == znakyMorseovyAbecedy[j]) {
                            TextOut += znakyTextu[j];
                        }
                    }
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
                LabelIn = "Vložte text, který chcete šifrovat do Morseovy abecedy.";
                LabelIn2 = "Pouze velká či malá písmena anglické abecedy, číslice, čárky, tečky a mezery.";
                LabelOut = "Šifrovaný text:";
            }
            if (Cinnost == "Desifrovat") {
                LabelIn = "Vložte šifrovaný text v Morseově abecedě, který chcete dešifrovat.";
                LabelIn2 = "Jednotlivé znaky včetně mezer oddělujte znakem svislice: | ";
                LabelOut = "Dešifrovaný text:";
            }
        }
    }
}
