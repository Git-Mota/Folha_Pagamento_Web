document.addEventListener('DOMContentLoaded', function () {
    // Seu código JavaScript aqui

    document.getElementById('adicionarEntradaButton').addEventListener('click', function () {
        var dataAtual = new Date();
        var horaEntrada = dataAtual.toLocaleTimeString();
        var dataFormatada = dataAtual.toLocaleDateString();
        var diaSemana = dataAtual.toLocaleDateString('pt-BR', { weekday: 'long' });

        // Preencher os campos na última linha da tabela
        document.getElementById('nomeFunc').textContent = "Nome";
        document.getElementById('departamentoFunc').textContent = "Departamento";
        document.getElementById('data').textContent = dataFormatada;
        document.getElementById('diaSemana').textContent = diaSemana;
        document.getElementById('entrada').textContent = horaEntrada;
    });
});
document.getElementById('saveButton').addEventListener('click', function () {
    var table = document.querySelector("table");
    var rows = table.querySelectorAll("tbody tr");

    var data = [];

    rows.forEach(function (row) {
        var cells = row.querySelectorAll("td");
        var ponto = {
            Nome: cells[0].textContent,
            Departamento: cells[1].textContent,
            Data: cells[2].textContent,
            DiaSemana: cells[3].textContent,
            HoraEntrada: cells[4].textContent,
            HoraInicioAlmoco: cells[5].textContent,
            HoraRetornoAlmoco: cells[6].textContent,
            HoraInicioPausa: cells[7].textContent,
            HoraRetornoPausa: cells[8].textContent,
            HoraSaida: cells[9].textContent,
        };
        data.push(ponto);
    });
});
