const input = document.querySelector('input[type="file"]');
const preview = document.querySelector('#preview');
input.addEventListener('charge', () => {
    const file = input.files[0];
    if (file) {
        const reader = new FileReader();
        reader.addEventListener('load', () => {
            preview.setAttribute('scr', reader.result);
        });
        reader.readAsDataURL(file);
    }
}