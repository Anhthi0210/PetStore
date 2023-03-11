//const form-check - input = document.getElementById('flexSwitchCheckDefault');

//                        form - check - input.addEventListener('change', () => {
//        document.body.classList.toggle('dark');
//                        });
const body = document.body;
const switch_mode = document.querySelector('flexSwitchCheckDefault');
switch_mode.addEventListener('check', () => {
    alert('checked');
});
