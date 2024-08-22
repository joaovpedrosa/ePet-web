//listas das perguntas
const respostas = document.querySelectorAll('.resposta');
const perguntas = document.querySelectorAll('.abrir');

//vendo qual ele vai clicar
perguntas.forEach(function (item, index) {
    item.addEventListener('click', function () {
        //pegando a resposta daquele indíce
        respostas[index].classList.toggle('apareceu')
    })
})


