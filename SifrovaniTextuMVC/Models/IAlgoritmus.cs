
namespace SifrovaniTextuMVC.Models {
    interface IAlgoritmus {
        /// <summary>
        /// Metoda na šifrování textu
        /// </summary>
        void sifruj();

        /// <summary>
        /// Metoda na dešifrování textu
        /// </summary>
        void desifruj();

        /// <summary>
        /// Metoda pro zobraní textu s instrukcemi pro uživatele
        /// </summary>
        void zobrazLabel();
    }
}
