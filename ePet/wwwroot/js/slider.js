document.addEventListener('DOMContentLoaded', function () {
    const radio1 = document.getElementById('radio1');
    const containerAdocao = document.querySelector('.containerAdocao');

    function updateAdocaoVisibility() {
        if (radio1.checked) {
            containerAdocao.style.display = 'block';
        } else {
            containerAdocao.style.display = 'none';
        }
    }

    // Adicione ouvintes de eventos para os inputs de rádio
    document.querySelectorAll('input[name="radio-btn"]').forEach(radio => {
        radio.addEventListener('change', updateAdocaoVisibility);
    });

    // Verifique o estado inicial
    updateAdocaoVisibility();
});



