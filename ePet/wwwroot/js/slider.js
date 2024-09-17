document.addEventListener('DOMContentLoaded', function () {
    // Manipulação da visibilidade da div containerAdocao
    const radio1 = document.getElementById('radio1');
    const containerAdocao = document.querySelector('.containerAdocao');

    function updateAdocaoVisibility() {
        if (radio1.checked) {
            containerAdocao.style.display = 'block';
        } else {
            containerAdocao.style.display = 'none';
        }
    }

    // Adiciona ouvintes de eventos para os inputs de rádio
    document.querySelectorAll('input[name="radio-btn"]').forEach(radio => {
        radio.addEventListener('change', updateAdocaoVisibility);
    });

    // Verifica o estado inicial
    updateAdocaoVisibility();

    // Função de rolagem para a div containerComoAdotar
    const images = document.querySelectorAll('.slide img');
    const targetDiv = document.getElementById('containerComoAdotar');

    function scrollToTarget() {
        if (targetDiv) {
            console.log('Rolando para a div:', targetDiv);
            targetDiv.scrollIntoView({ behavior: 'smooth' });
        } else {
            console.log('Div alvo não encontrada.');
        }
    }

    // Adiciona o evento de clique a cada imagem
    images.forEach(image => {
        image.addEventListener('click', function () {
            console.log('Imagem clicada:', this.id);
            // Verifica o ID da imagem para saber se deve rolar a página
            if (this.id === 'img3') {
                scrollToTarget();
            }
        });
    });

    // Alternância de slides automática
    const radioButtons = document.querySelectorAll('input[name="radio-btn"]');
    let currentIndex = 0;

    function changeSlide() {
        radioButtons[currentIndex].checked = false;
        currentIndex = (currentIndex + 1) % radioButtons.length;
        radioButtons[currentIndex].checked = true;
    }

    // Altera o slide a cada 6 segundos
    setInterval(changeSlide, 16000);
});

