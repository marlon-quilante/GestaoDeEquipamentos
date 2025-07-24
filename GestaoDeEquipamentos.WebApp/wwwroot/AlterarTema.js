document.addEventListener("DOMContentLoaded", function () {
    const html = document.documentElement;

    const botaoTemaEscuro = document.getElementById("temaEscuro");
    const botaoTemaClaro = document.getElementById("temaClaro");

    const temaSalvo = localStorage.getItem("tema");
    if (temaSalvo) {
        html.setAttribute("data-bs-theme", temaSalvo);
    }

    if (botaoTemaEscuro) {
        botaoTemaEscuro.addEventListener("click", function () {
            const temaEscuro = "dark";
            html.setAttribute("data-bs-theme", temaEscuro);
            localStorage.setItem("tema", temaEscuro);
        });
    }

    if (botaoTemaClaro) {
        botaoTemaClaro.addEventListener("click", function () {
            const temaClaro = "light";
            html.setAttribute("data-bs-theme", temaClaro);
            localStorage.setItem("tema", temaClaro);
        });
    }
})