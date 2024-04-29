if (document.getElementById('tabela-romaneio').getElementsByTagName('tr').length > 1) {
    ocultarBuscaRomaneio();
} else {
    mostrarBuscaRomaneio();
}

function ocultarBuscaRomaneio() {
    document.querySelector('.busca-romaneio').style.display = 'none';
}

// Função para mostrar a parte de busca do romaneio
function mostrarBuscaRomaneio() {
    document.querySelector('.busca-romaneio').style.display = 'block';
}

