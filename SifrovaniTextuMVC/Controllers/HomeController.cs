using Microsoft.AspNetCore.Mvc;
using SifrovaniTextuMVC.Models;

namespace SifrovaniTextuMVC.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {           
            AlgoritmusMorseovaAbeceda morseovaAbeceda = new AlgoritmusMorseovaAbeceda();
            return View(morseovaAbeceda);
        }

        [HttpPost]
        public IActionResult Index(AlgoritmusMorseovaAbeceda morseovaAbeceda) {
            if (ModelState.IsValid) {
                if (morseovaAbeceda.Cinnost == "Sifrovat") {
                    morseovaAbeceda.zobrazLabel();
                }
                if (morseovaAbeceda.Cinnost == "Desifrovat") {
                    morseovaAbeceda.zobrazLabel();
                }                
                if (morseovaAbeceda.Cinnost == "Sifrovat" && morseovaAbeceda.SifrujDesifruj == "Šifruj / Dešifruj") {
                    morseovaAbeceda.sifruj();
                }
                if (morseovaAbeceda.Cinnost == "Desifrovat" && morseovaAbeceda.SifrujDesifruj == "Šifruj / Dešifruj") {
                    morseovaAbeceda.desifruj();
                }
            }
            return View(morseovaAbeceda);
        }

        public IActionResult Caesar() {
            AlgoritmusCaesarovaSifra caesarovaSifra = new AlgoritmusCaesarovaSifra();
            return View(caesarovaSifra);
        }

        [HttpPost]
        public IActionResult Caesar(AlgoritmusCaesarovaSifra caesarovaSifra) {
            if (ModelState.IsValid) {
                if (caesarovaSifra.Cinnost == "Sifrovat") {
                    caesarovaSifra.zobrazLabel();
                }
                if (caesarovaSifra.Cinnost == "Desifrovat") {
                    caesarovaSifra.zobrazLabel();
                }
                if (caesarovaSifra.Cinnost == "Sifrovat" && caesarovaSifra.SifrujDesifruj == "Šifruj / Dešifruj") {
                    caesarovaSifra.sifruj();
                }
                if (caesarovaSifra.Cinnost == "Desifrovat" && caesarovaSifra.SifrujDesifruj == "Šifruj / Dešifruj") {
                    caesarovaSifra.desifruj();
                }
            }
            return View(caesarovaSifra);
        }
    }
}
