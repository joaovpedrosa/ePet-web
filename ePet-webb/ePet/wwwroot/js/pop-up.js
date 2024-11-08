document.getElementById('adoptionForm').addEventListener('submit', function (event)
{
let dialog = document.getElementById('dialog');
dialog.style.display = 'block';
event.preventDefault(); // Prevenir o envio do formulário
openDialog(); // Abrir o diálogo
});

function openDialog()
{
    var dialog = document.getElementById('dialog');
    dialog.showModal();
}

function closeDialog()
{
    let dialog = document.getElementById('dialog');
    dialog.style.display = 'none';
}