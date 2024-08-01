// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let pathOrder = '/api/OrderApi'

$(() => {
    $.ajax({
        url: `${pathOrder}`,
        method: 'GET',
        success: (data) => {
            let countOrder = $("#countOrder");
            if (data = 1) {
                countOrder.text(`${data} ordine evaso`);
            } else {
                countOrder.text(`${data} ordini evasi`);
            }
        }
    })


    $("#research").on('click', () => {
        let date = $("#date").val();
        $.ajax({
            url: `${pathOrder}/TotalByDay/${date}`,
            method: 'GET',
            success: (data) => {
                let dataInp = $("#dateinput");
                let totalPrice = $("#totalPrice");
                
                dataInp.text(date);
                totalPrice.text(`${data}€`);
            }
        })
    })
})