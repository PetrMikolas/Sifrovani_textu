
// validace vstupu z klávesnice
function validace() {
    
    let sifrovat = document.getElementById('Sifrovat');
    let desifrovat = document.getElementById('Desifrovat');

     
        if (sifrovat.checked || desifrovat.checked) {
            let charCode = (event.which) ? event.which : event.keyCode;
            if ((charCode == 32) || (charCode == 44) || (charCode == 46) || (charCode >= 97 && charCode <= 122)) { return true; }
            else { return false; }
        }    
}
