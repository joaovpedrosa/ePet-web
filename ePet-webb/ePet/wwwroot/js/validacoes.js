const senhaInput = document.getElementById("senha");
const confirmaSenhaInput = document.getElementById("Confirme");
const form = document.querySelector(".cadastro");
const alerta = document.getElementById("alerta")

form.addEventListener("submit", function (e) {
    if (senhaInput.value !== confirmaSenhaInput.value) {
        alerta.innerHTML = "As senhas não estão iguais!"
        e.preventDefault(); // Impede o envio do formulário se as senhas não coincidirem.
    }
});


