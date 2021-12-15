
// validace vstupu z klávesnice
function validace() {
    
    let sifrovat = document.getElementById('Sifrovat');
    let desifrovat = document.getElementById('Desifrovat');
    
        if (sifrovat.checked) {
            let charCode = (event.which) ? event.which : event.keyCode;
            if ((charCode == 32) || (charCode == 44) || (charCode == 46) || (charCode >= 48 && charCode <= 57) || (charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122)) { return true; }
            else { return false; }
        }
        if (desifrovat.checked) {
            let charCode = (event.which) ? event.which : event.keyCode;
            if ((charCode == 32) || (charCode == 45) || (charCode == 46) || (charCode == 124)) { return true; }
            else { return false; }
        }      
}